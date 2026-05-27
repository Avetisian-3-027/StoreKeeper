using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;
using StoreKeeper.Data.Permissions;

namespace StoreKeeper.WinForms.Forms
{
    public partial class UserEditForm : Form
    {
        private User _user;
        private AppDbContext _context;
        private bool _isNew;

        public UserEditForm(User? user, AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            _isNew = (user == null);
            if (_isNew)
            {
                _user = new User { IsAdmin = false };
                Text = "Новий користувач";
            }
            else
            {
                _user = user;
                Text = $"Редагування: {_user.Username}";
            }
            LoadPermissions();
            LoadUserData();
        }

        private void LoadPermissions()
        {
            var allPerms = AppPermissions.GetAllPermissions();
            var localized = AppPermissions.GetLocalizedNames();
            checkedListBoxPermissions.Items.Clear();
            foreach (var perm in allPerms)
            {
                string display = localized.ContainsKey(perm) ? localized[perm] : perm;
                checkedListBoxPermissions.Items.Add(display, false);
                checkedListBoxPermissions.SetItemChecked(checkedListBoxPermissions.Items.Count - 1, false);
            }
            // Зберігаємо відповідність індексу -> назва права
            // Краще зберігати в окремому списку, але спростимо: будемо використовувати Tag або словник.
            // Для простоти створимо список прав у тому ж порядку.
        }

        private void LoadUserData()
        {
            textBoxUsername.Text = _user.Username;
            checkBoxIsAdmin.Checked = _user.IsAdmin;
            if (!_isNew && !string.IsNullOrEmpty(_user.PasswordHash))
            {
                // Поле пароля не заповнюємо, тільки для нового або зміни
                textBoxPassword.PlaceholderText = "(залишити порожнім, щоб не змінювати)";
            }

            // Відмічаємо права
            if (!_user.IsAdmin && !string.IsNullOrEmpty(_user.PermissionsList))
            {
                var userPerms = _user.GetPermissionsArray();
                var allPerms = AppPermissions.GetAllPermissions();
                for (int i = 0; i < allPerms.Length && i < checkedListBoxPermissions.Items.Count; i++)
                {
                    if (userPerms.Contains(allPerms[i]))
                        checkedListBoxPermissions.SetItemChecked(i, true);
                }
            }
            else if (_user.IsAdmin)
            {
                // Для адміна всі права відмічені, але CheckedListBox неактивний
                for (int i = 0; i < checkedListBoxPermissions.Items.Count; i++)
                    checkedListBoxPermissions.SetItemChecked(i, true);
                checkedListBoxPermissions.Enabled = false;
            }

            // Якщо редагуємо адміна, не дозволяємо знімати IsAdmin через UI (хоча можна дозволити)
        }

        private void checkBoxIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            bool isAdmin = checkBoxIsAdmin.Checked;
            checkedListBoxPermissions.Enabled = !isAdmin;
            if (isAdmin)
            {
                // Відмічаємо всі права, але вони не редагуються
                for (int i = 0; i < checkedListBoxPermissions.Items.Count; i++)
                    checkedListBoxPermissions.SetItemChecked(i, true);
            }
            else
            {
                // Знімаємо всі позначки, якщо були
                // Краще не чіпати – залишити як було
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Введіть ім'я користувача", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Перевірка унікальності імені
            var existing = _context.Users.FirstOrDefault(u => u.Username == username && u.Id != _user.Id);
            if (existing != null)
            {
                MessageBox.Show("Користувач з таким іменем вже існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _user.Username = username;
            _user.IsAdmin = checkBoxIsAdmin.Checked;

            // Обробка пароля
            string newPassword = textBoxPassword.Text;
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                _user.PasswordHash = HashHelper.ComputeSha256Hash(newPassword);
            }
            else if (_isNew)
            {
                // Для нового користувача, якщо пароль не введений – залишаємо null (без пароля)
                _user.PasswordHash = null;
            }

            // Збір прав, якщо не адмін
            if (!_user.IsAdmin)
            {
                var allPerms = AppPermissions.GetAllPermissions();
                var selectedPerms = new List<string>();
                for (int i = 0; i < checkedListBoxPermissions.Items.Count && i < allPerms.Length; i++)
                {
                    if (checkedListBoxPermissions.GetItemChecked(i))
                        selectedPerms.Add(allPerms[i]);
                }
                _user.SetPermissions(selectedPerms);
            }
            else
            {
                _user.PermissionsList = null;
            }

            if (_isNew)
                _context.Users.Add(_user);
            _context.SaveChanges();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}