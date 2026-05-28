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
            labelProfile = new Label();
            comboBoxUsers = new ComboBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            SuspendLayout();
            // 
            // labelProfile
            // 
            labelProfile.AutoSize = true;
            labelProfile.Font = new Font("Segoe UI", 9F);
            labelProfile.Location = new Point(18, 36);
            labelProfile.Name = "labelProfile";
            labelProfile.Size = new Size(71, 20);
            labelProfile.TabIndex = 0;
            labelProfile.Text = "Профіль:";
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUsers.Location = new Point(95, 33);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(180, 28);
            comboBoxUsers.TabIndex = 1;
            comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9F);
            labelPassword.Location = new Point(23, 92);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(65, 20);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(95, 90);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(180, 27);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            buttonLogin.Font = new Font("Segoe UI", 9F);
            buttonLogin.Location = new Point(95, 143);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(180, 33);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Увійти";
            buttonLogin.Click += buttonLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 209);
            Controls.Add(labelProfile);
            Controls.Add(comboBoxUsers);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonLogin);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "LoginForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизація";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}