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

        public LoginForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(ConfigHelper.GetConnectionString())
                .Options;
            _context = new AppDbContext(options);
            AppDbContext.InitializeDatabase(_context); // гарантує наявність адміна

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
            if (_selectedUser != null && string.IsNullOrEmpty(_selectedUser.PasswordHash))
            {
                textBoxPassword.PlaceholderText = "(пароль не потрібен)";
            }
            else
            {
                textBoxPassword.PlaceholderText = "Введіть пароль";
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("Оберіть профіль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                if (_selectedUser.IsAdmin && string.IsNullOrEmpty(_selectedUser.PasswordHash))
                {
                    var result = MessageBox.Show(
                        "Ви увійшли як Адміністратор без пароля. Бажаєте встановити пароль зараз?",
                        "Безпека",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SetAdminPassword();
                        LoadUsers();
                        comboBoxUsers.SelectedValue = _selectedUser.Id;
                        return;
                    }
                }
            }

            this.Hide();
            var mainForm = new MainForm(_selectedUser, _context);
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void SetAdminPassword()
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Встановлення пароля адміністратора";
                dialog.Width = 300;
                dialog.Height = 150;
                var txtPassword = new TextBox() { PasswordChar = '*', Location = new System.Drawing.Point(20, 20), Width = 240 };
                var txtConfirm = new TextBox() { PasswordChar = '*', Location = new System.Drawing.Point(20, 50), Width = 240 };
                var btnOk = new Button() { Text = "OK", Location = new System.Drawing.Point(100, 80), DialogResult = DialogResult.OK };
                dialog.Controls.Add(txtPassword);
                dialog.Controls.Add(txtConfirm);
                dialog.Controls.Add(btnOk);

                if (dialog.ShowDialog() == DialogResult.OK && txtPassword.Text == txtConfirm.Text && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    _selectedUser.PasswordHash = HashHelper.ComputeSha256Hash(txtPassword.Text);
                    _context.SaveChanges();
                    MessageBox.Show("Пароль встановлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Пароль не співпадає або порожній. Спробуйте пізніше.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}