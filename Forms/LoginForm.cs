using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;

namespace StoreKeeper.WinForms.Forms
{
    public partial class LoginForm : Form
    {
        private AppDbContext _context;
        private User? _selectedUser;
        private const string ConnectionString = "Data Source=users.list";

        public LoginForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(ConnectionString)
                .Options;
            _context = new AppDbContext(options);
            AppDbContext.InitializeDatabase(_context);

            var users = _context.Users.OrderBy(u => u.Username).ToList();
            comboBoxUsers.DataSource = users;
            comboBoxUsers.DisplayMember = "Username";
            comboBoxUsers.ValueMember = "Id";

            if (users.Count > 0)
                comboBoxUsers.SelectedIndex = 0;
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedUser = comboBoxUsers.SelectedItem as User;
            textBoxPassword.Text = "";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("Оберіть профіль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка пароля
            if (!string.IsNullOrEmpty(_selectedUser.PasswordHash))
            {
                string inputPassword = textBoxPassword.Text;
                string hashedInput = HashHelper.ComputeSha256Hash(inputPassword);
                if (hashedInput != _selectedUser.PasswordHash)
                {
                    MessageBox.Show("Невірний пароль", "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Якщо немає пароля – пропонуємо встановити (тільки для адміна)
                if (_selectedUser.IsAdmin)
                {
                    var result = MessageBox.Show(
                        "У профілю немає пароля. Бажаєте встановити пароль зараз?",
                        "Безпека",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        using (var pwdForm = new SetPasswordForm(_selectedUser, hash =>
                        {
                            _selectedUser.PasswordHash = hash;
                            _context.SaveChanges();
                        }))
                        {
                            if (pwdForm.ShowDialog() == DialogResult.OK)
                            {
                                MessageBox.Show("Пароль встановлено. Тепер увійдіть знову.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadUsers(); // оновити список
                                comboBoxUsers.SelectedValue = _selectedUser.Id;
                                return;
                            }
                            else
                                return; // не входимо без пароля
                        }
                    }
                    else
                    {
                        // Дозволяємо вхід без пароля для адміна, якщо він відмовився
                    }
                }
                else
                {
                    MessageBox.Show("Профіль не має пароля. Зверніться до адміністратора.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            this.Hide();
            var mainForm = new MainForm(_selectedUser, _context);
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }
    }
}