using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;
using StoreKeeper.Data.Permissions;
using StoreKeeper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StoreKeeper.WinForms.Forms
{
    public partial class UserEditForm : Form
    {
        private User _user;
        private User _currentUser;
        private AppDbContext _context;
        private bool _isNew;

        public UserEditForm(User? user, AppDbContext context, User currentUser)
        {
            InitializeComponent();
            _context = context;
            _currentUser = currentUser;
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
            LoadDatabasesCombo();
            LoadPermissionsChecklist();
            LoadUserData();
            LoadSelectedDatabase();
        }

        private void LoadDatabasesCombo()
        {
            var databases = _context.Databases.OrderBy(d => d.Name).ToList();
            comboBoxDatabase.DataSource = databases;
            comboBoxDatabase.DisplayMember = "Name";
            comboBoxDatabase.ValueMember = "Id";
            comboBoxDatabase.SelectedItem = null;
        }

        private void LoadPermissionsChecklist()
        {
            var allPerms = AppPermissions.GetAllPermissions();
            var localized = AppPermissions.GetLocalizedNames();
            checkedListBoxPermissions.Items.Clear();
            foreach (var perm in allPerms)
            {
                string display = localized.ContainsKey(perm) ? localized[perm] : perm;
                checkedListBoxPermissions.Items.Add(display, false);
            }
        }

        private void LoadUserData()
        {
            textBoxUsername.Text = _user.Username;
            checkBoxIsAdmin.Checked = _user.IsAdmin;

            if (!_isNew && !string.IsNullOrEmpty(_user.PasswordHash))
                textBoxPassword.PlaceholderText = "(залишити порожнім, щоб не змінювати)";

            bool isSelf = (!_isNew && _user.Id == _currentUser.Id);
            if (isSelf)
            {
                checkBoxIsAdmin.Enabled = false;
                checkedListBoxPermissions.Enabled = false;
                labelSelfWarning.Visible = true;
            }
            else
            {
                checkBoxIsAdmin.Enabled = true;
                checkedListBoxPermissions.Enabled = !_user.IsAdmin;
                labelSelfWarning.Visible = false;
            }

            if (_user.IsAdmin)
            {
                for (int i = 0; i < checkedListBoxPermissions.Items.Count; i++)
                    checkedListBoxPermissions.SetItemChecked(i, true);
            }
            else
            {
                var userPerms = _user.GetPermissionsArray();
                var allPerms = AppPermissions.GetAllPermissions();
                for (int i = 0; i < allPerms.Length && i < checkedListBoxPermissions.Items.Count; i++)
                {
                    if (userPerms.Contains(allPerms[i]))
                        checkedListBoxPermissions.SetItemChecked(i, true);
                }
            }
        }

        private void LoadSelectedDatabase()
        {
            if (_user.SelectedDatabaseId.HasValue)
                comboBoxDatabase.SelectedValue = _user.SelectedDatabaseId.Value;
            else
                comboBoxDatabase.SelectedItem = null;
        }

        private void checkBoxIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            bool isAdmin = checkBoxIsAdmin.Checked;
            if (!_isNew && _user.Id == _currentUser.Id)
            {
                checkBoxIsAdmin.Checked = _user.IsAdmin;
                return;
            }
            checkedListBoxPermissions.Enabled = !isAdmin;
            if (isAdmin)
            {
                for (int i = 0; i < checkedListBoxPermissions.Items.Count; i++)
                    checkedListBoxPermissions.SetItemChecked(i, true);
            }
            else if (_isNew)
            {
                for (int i = 0; i < checkedListBoxPermissions.Items.Count; i++)
                    checkedListBoxPermissions.SetItemChecked(i, false);
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

            var existing = _context.Users.FirstOrDefault(u => u.Username == username && u.Id != _user.Id);
            if (existing != null)
            {
                MessageBox.Show("Користувач з таким іменем вже існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _user.Username = username;

            string newPassword = textBoxPassword.Text;
            if (!string.IsNullOrWhiteSpace(newPassword))
                _user.PasswordHash = HashHelper.ComputeSha256Hash(newPassword);
            else if (_isNew)
                _user.PasswordHash = null;

            bool isSelf = (!_isNew && _user.Id == _currentUser.Id);
            if (!isSelf)
            {
                bool newIsAdmin = checkBoxIsAdmin.Checked;
                bool oldIsAdmin = _user.IsAdmin;
                if (oldIsAdmin && !newIsAdmin)
                {
                    int remainingAdmins = _context.Users.Count(u => u.IsAdmin && u.Id != _user.Id);
                    if (remainingAdmins == 0)
                    {
                        MessageBox.Show("Не можна зняти роль адміністратора з останнього адміністратора в системі.",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                _user.IsAdmin = newIsAdmin;
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
            }
            else
            {
                if (_user.IsAdmin && !checkBoxIsAdmin.Checked)
                {
                    MessageBox.Show("Ви не можете зняти з себе роль адміністратора.",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Вибір бази даних
            if (comboBoxDatabase.SelectedValue != null)
                _user.SelectedDatabaseId = (int)comboBoxDatabase.SelectedValue;
            else
                _user.SelectedDatabaseId = null;

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