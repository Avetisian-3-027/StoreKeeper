using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;
using StoreKeeper.Helpers;

namespace StoreKeeper.WinForms.Forms
{
    public partial class LoginForm : Form
    {
        private AppDbContext _context;
        private User? _selectedUser;
        private const string ConnectionString = "Data Source=data.list";

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

            var users = _context.Users
                .Include(u => u.SelectedDatabase)
                .OrderBy(u => u.Username)
                .ToList();
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
                if (_selectedUser.IsAdmin)
                {
                    var result = MessageBox.Show("У профілю немає пароля. Встановити зараз?", "Безпека",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                                MessageBox.Show("Пароль встановлено. Увійдіть знову.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadUsers();
                                comboBoxUsers.SelectedValue = _selectedUser.Id;
                                return;
                            }
                            else return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Профіль не має пароля. Зверніться до адміністратора.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string workConnectionString = null;
            if (_selectedUser.SelectedDatabaseId.HasValue && _selectedUser.SelectedDatabase != null)
            {
                try
                {
                    workConnectionString = _selectedUser.SelectedDatabase.GetConnectionString();
                    using (var testConn = new Microsoft.Data.Sqlite.SqliteConnection(workConnectionString))
                    {
                        testConn.Open();
                    }
                }
                catch (Exception ex)
                {
                    if (_selectedUser.IsAdmin)
                    {
                        MessageBox.Show($"Помилка підключення до БД:\n{ex.Message}\nВи можете увійти без робочої бази.",
                            "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        workConnectionString = null;
                    }
                    else
                    {
                        MessageBox.Show($"Не вдалося підключитися до бази даних.\nПомилка: {ex.Message}",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                if (!_selectedUser.IsAdmin)
                {
                    MessageBox.Show("Користувачеві не призначено базу даних. Зверніться до адміністратора.",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("У вас не вибрана база даних. Ви можете увійти, але функції роботи з даними будуть недоступні.",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            this.Hide(); 
            var mainForm = new MainForm(_selectedUser, _context, workConnectionString);
            mainForm.FormClosed += (s, args) =>
            {
                this.Show(); 
                LoadUsers();
                textBoxPassword.Text = "";
            };
            mainForm.Show();
        }
    }
}