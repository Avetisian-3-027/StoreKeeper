namespace StoreKeeper.WinForms.Forms
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxIsAdmin;
        private System.Windows.Forms.Label labelPermissions;
        private System.Windows.Forms.CheckedListBox checkedListBoxPermissions;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxIsAdmin = new System.Windows.Forms.CheckBox();
            this.labelPermissions = new System.Windows.Forms.Label();
            this.checkedListBoxPermissions = new System.Windows.Forms.CheckedListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // labelUsername
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(20, 20);
            this.labelUsername.Text = "Ім'я користувача:";

            // textBoxUsername
            this.textBoxUsername.Location = new System.Drawing.Point(150, 17);
            this.textBoxUsername.Width = 200;

            // labelPassword
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(20, 60);
            this.labelPassword.Text = "Пароль:";

            // textBoxPassword
            this.textBoxPassword.Location = new System.Drawing.Point(150, 57);
            this.textBoxPassword.Width = 200;
            this.textBoxPassword.UseSystemPasswordChar = true;

            // checkBoxIsAdmin
            this.checkBoxIsAdmin.AutoSize = true;
            this.checkBoxIsAdmin.Location = new System.Drawing.Point(150, 100);
            this.checkBoxIsAdmin.Text = "Адміністратор";
            this.checkBoxIsAdmin.CheckedChanged += new System.EventHandler(this.checkBoxIsAdmin_CheckedChanged);

            // labelPermissions
            this.labelPermissions.AutoSize = true;
            this.labelPermissions.Location = new System.Drawing.Point(20, 140);
            this.labelPermissions.Text = "Права:";

            // checkedListBoxPermissions
            this.checkedListBoxPermissions.FormattingEnabled = true;
            this.checkedListBoxPermissions.Location = new System.Drawing.Point(150, 140);
            this.checkedListBoxPermissions.Size = new System.Drawing.Size(300, 200);
            this.checkedListBoxPermissions.TabIndex = 5;

            // buttonSave
            this.buttonSave.Location = new System.Drawing.Point(150, 360);
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // buttonCancel
            this.buttonCancel.Location = new System.Drawing.Point(250, 360);
            this.buttonCancel.Text = "Скасувати";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

            // UserEditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.checkedListBoxPermissions);
            this.Controls.Add(this.labelPermissions);
            this.Controls.Add(this.checkBoxIsAdmin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelUsername);
            this.Text = "Редагування користувача";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}