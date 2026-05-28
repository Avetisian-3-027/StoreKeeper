using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;
using StoreKeeper.Data.Permissions;

namespace StoreKeeper.WinForms.Forms
{
    public partial class ManageUsersForm : Form
    {
        private AppDbContext _context;
        private User _currentUser;

        public ManageUsersForm(AppDbContext context, User currentUser)
        {
            InitializeComponent();
            _context = context;
            _currentUser = currentUser;
            LoadUsers();
        }

        private void LoadUsers()
        {
            _context.ChangeTracker.Clear();
            var users = _context.Users.OrderBy(u => u.Username).ToList();
            dataGridViewUsers.DataSource = null;
            dataGridViewUsers.DataSource = users;

            // Приховуємо всі колонки, які не потрібні
            dataGridViewUsers.Columns["Id"].Visible = false;
            dataGridViewUsers.Columns["PasswordHash"].Visible = false;
            dataGridViewUsers.Columns["PermissionsList"].Visible = false;
            dataGridViewUsers.Columns["DatabaseConfigJson"].Visible = false;
            dataGridViewUsers.Columns["IsAdmin"].Visible = false;
            dataGridViewUsers.Columns["DatabaseConfig"].Visible = false; // Додано!

            // Налаштовуємо колонку Username
            dataGridViewUsers.Columns["Username"].HeaderText = "Ім'я користувача";
            dataGridViewUsers.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Видаляємо старі кастомні колонки, якщо вони є
            if (dataGridViewUsers.Columns["RulesColumn"] != null)
                dataGridViewUsers.Columns.Remove("RulesColumn");
            if (dataGridViewUsers.Columns["ProviderColumn"] != null)
                dataGridViewUsers.Columns.Remove("ProviderColumn");
            if (dataGridViewUsers.Columns["ConnectionStringColumn"] != null)
                dataGridViewUsers.Columns.Remove("ConnectionStringColumn");

            // Додаємо нові колонки
            var rulesColumn = new DataGridViewTextBoxColumn
            {
                Name = "RulesColumn",
                HeaderText = "Правила",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridViewUsers.Columns.Add(rulesColumn);

            var providerColumn = new DataGridViewTextBoxColumn
            {
                Name = "ProviderColumn",
                HeaderText = "Тип БД",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridViewUsers.Columns.Add(providerColumn);

            var connStringColumn = new DataGridViewTextBoxColumn
            {
                Name = "ConnectionStringColumn",
                HeaderText = "Рядок підключення",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridViewUsers.Columns.Add(connStringColumn);
        }

        private void dataGridViewUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var user = dataGridViewUsers.Rows[e.RowIndex].DataBoundItem as User;
            if (user == null) return;

            if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "RulesColumn")
            {
                if (user.IsAdmin)
                    e.Value = "Адміністратор";
                else
                {
                    var perms = user.GetPermissionsArray();
                    if (perms.Length == 0)
                        e.Value = "Немає прав";
                    else
                    {
                        var localized = AppPermissions.GetLocalizedNames();
                        var displayPerms = perms.Select(p => localized.ContainsKey(p) ? localized[p] : p);
                        e.Value = string.Join(", ", displayPerms);
                    }
                }
                e.FormattingApplied = true;
            }
            else if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "ProviderColumn")
            {
                string provider = user.DatabaseConfig.Provider;
                if (provider == "MySQL" || provider == "PostgreSQL")
                    e.Value = $"{provider} (в розробці)";
                else
                    e.Value = provider;
                e.FormattingApplied = true;
            }
            else if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "ConnectionStringColumn")
            {
                var config = user.DatabaseConfig;
                if (config.Provider == "SQLite")
                    e.Value = config.FolderPath;
                else
                    e.Value = $"{config.Server}:{config.Port}/{config.DatabaseName} (користувач: {config.Username})";
                e.FormattingApplied = true;
            }
        }


        private void BackupDatabase()
        {
            string dbFile = "users.list";
            string backupFile = "users.list.bak";
            if (File.Exists(dbFile))
            {
                try
                {
                    File.Copy(dbFile, backupFile, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не вдалося створити резервну копію: {ex.Message}", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new UserEditForm(null, _context, _currentUser))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    BackupDatabase();
                    LoadUsers();
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow == null) return;
            var user = (User)dataGridViewUsers.CurrentRow.DataBoundItem;
            using (var editForm = new UserEditForm(user, _context, _currentUser))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    BackupDatabase();
                    LoadUsers();
                }
            }
        }

        
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow == null) return;
            var user = (User)dataGridViewUsers.CurrentRow.DataBoundItem;
            if (user.Id == _currentUser.Id)
            {
                MessageBox.Show("Ви не можете видалити самого себе.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Видалити користувача '{user.Username}'?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                BackupDatabase();
                LoadUsers();
            }
        }
    }
}