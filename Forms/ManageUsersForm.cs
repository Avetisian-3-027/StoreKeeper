using System;
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
            // Оновлюємо контекст, щоб отримати свіжі дані
            _context.ChangeTracker.Clear();
            var users = _context.Users.OrderBy(u => u.Username).ToList();
            dataGridViewUsers.DataSource = null;
            dataGridViewUsers.DataSource = users;
            dataGridViewUsers.Columns["PasswordHash"].Visible = false;
            dataGridViewUsers.Columns["PermissionsList"].Visible = false;
            dataGridViewUsers.Columns["Id"].Visible = false;
            dataGridViewUsers.Columns["Username"].HeaderText = "Ім'я користувача";
            dataGridViewUsers.Columns["IsAdmin"].HeaderText = "Адміністратор";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new UserEditForm(null, _context))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.CurrentRow == null) return;
            var user = (User)dataGridViewUsers.CurrentRow.DataBoundItem;
            // Не можна редагувати самого себе, якщо це не адмін? Дозволимо, але обмежимо зміну прав.
            using (var editForm = new UserEditForm(user, _context))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
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
                LoadUsers();
            }
        }
    }
}