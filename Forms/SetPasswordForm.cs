using System;
using System.Windows.Forms;
using StoreKeeper.Data.Models;

namespace StoreKeeper.WinForms.Forms
{
    public partial class SetPasswordForm : Form
    {
        private User _user;
        private Action<string> _onPasswordSet; // передає хеш пароля

        public SetPasswordForm(User user, Action<string> onPasswordSet)
        {
            InitializeComponent();
            _user = user;
            _onPasswordSet = onPasswordSet;
            labelUser.Text = $"Встановлення пароля для: {_user.Username}";
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != textBoxConfirm.Text)
            {
                MessageBox.Show("Паролі не співпадають", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Пароль не може бути порожнім", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hash = HashHelper.ComputeSha256Hash(textBoxPassword.Text);
            _onPasswordSet(hash);
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