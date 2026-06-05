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
            var users = _context.Users
                .Include(u => u.SelectedDatabase)
                .OrderBy(u => u.Username)
                .ToList();

            // Фіксуємо колонки
            dataGridViewUsers.AutoGenerateColumns = false;
            dataGridViewUsers.Columns.Clear();

            // Колонка "Ім'я користувача"
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Ім'я користувача",
                DataPropertyName = "Username",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });

            // Колонка "База даних" (заповнюється через CellFormatting)
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DatabaseColumn",
                HeaderText = "База даних",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Колонка "Правила" (заповнюється через CellFormatting)
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RulesColumn",
                HeaderText = "Правила",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            dataGridViewUsers.DataSource = users;
            dataGridViewUsers.AllowUserToOrderColumns = false;
        }

        private void dataGridViewUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var user = dataGridViewUsers.Rows[e.RowIndex].DataBoundItem as User;
            if (user == null) return;

            if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "DatabaseColumn")
            {
                e.Value = user.SelectedDatabase?.Name ?? "(не вибрано)";
                e.FormattingApplied = true;
            }
            else if (dataGridViewUsers.Columns[e.ColumnIndex].Name == "RulesColumn")
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
        }

        private void BackupDatabase()
        {
            string dbFile = "data.list";
            string backupFile = "data.list.bak";
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