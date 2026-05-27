using System;
using System.Windows.Forms;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;
using StoreKeeper.Data.Permissions;

namespace StoreKeeper.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        private AppDbContext _context;

        public MainForm(User user, AppDbContext context)
        {
            _currentUser = user;
            _context = context;
            InitializeComponent();
            ConfigureMenuByPermissions();
            Text = $"Складська програма - {_currentUser.Username}";
        }

        private void ConfigureMenuByPermissions()
        {
            // Показуємо пункт "Адміністрування" тільки якщо користувач має право ManageUsers
            адмініструванняToolStripMenuItem.Visible = _currentUser.HasPermission(AppPermissions.ManageUsers);

            // Інші пункти поки що видимі для всіх, але в майбутньому додамо перевірки
            // довідникиToolStripMenuItem.Visible = _currentUser.HasPermission(AppPermissions.ViewProducts);
            // складToolStripMenuItem.Visible = _currentUser.HasPermission(AppPermissions.CreateInvoices);
            // звітиToolStripMenuItem.Visible = ...
        }

        // Обробники пунктів меню (поки що заглушки)
        private void товариToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма товарів у розробці", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void стравиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма страв у розробці", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void прихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма приходу товарів у розробці", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void розхідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Форма розходу товарів у розробці", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void залишкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Звіт по залишках у розробці", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void користувачіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Відкриваємо форму керування користувачами
            var manageUsersForm = new ManageUsersForm(_context, _currentUser);
            manageUsersForm.ShowDialog(this);
            // Після закриття форми оновлюємо головне меню (на випадок, якщо змінились права поточного користувача)
            ConfigureMenuByPermissions();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}