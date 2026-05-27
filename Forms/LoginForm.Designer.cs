namespace StoreKeeper.WinForms.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelProfile = new System.Windows.Forms.Label();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.labelProfile.AutoSize = true;
            this.labelProfile.Location = new System.Drawing.Point(30, 30);
            this.labelProfile.Text = "Профіль:";

            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.Location = new System.Drawing.Point(120, 27);
            this.comboBoxUsers.Width = 180;
            this.comboBoxUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsers_SelectedIndexChanged);

            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(30, 70);
            this.labelPassword.Text = "Пароль:";

            this.textBoxPassword.Location = new System.Drawing.Point(120, 67);
            this.textBoxPassword.Width = 180;
            this.textBoxPassword.UseSystemPasswordChar = true;

            this.buttonLogin.Location = new System.Drawing.Point(120, 110);
            this.buttonLogin.Text = "Увійти";
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 170);
            this.Controls.Add(this.labelProfile);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonLogin);
            this.Text = "Авторизація";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}