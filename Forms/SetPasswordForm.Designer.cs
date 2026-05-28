namespace StoreKeeper.WinForms.Forms
{
    partial class SetPasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.TextBox textBoxConfirm;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Button buttonCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelUser = new Label();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            labelConfirm = new Label();
            textBoxConfirm = new TextBox();
            buttonSet = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Font = new Font("Segoe UI", 9F);
            labelUser.Location = new Point(12, 9);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(193, 20);
            labelUser.TabIndex = 0;
            labelUser.Text = "Встановлення пароля для:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9F);
            labelPassword.Location = new Point(12, 47);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(113, 20);
            labelPassword.TabIndex = 1;
            labelPassword.Text = "Новий пароль:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(141, 44);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(166, 27);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelConfirm
            // 
            labelConfirm.AutoSize = true;
            labelConfirm.Font = new Font("Segoe UI", 9F);
            labelConfirm.Location = new Point(12, 92);
            labelConfirm.Name = "labelConfirm";
            labelConfirm.Size = new Size(119, 20);
            labelConfirm.TabIndex = 3;
            labelConfirm.Text = "Підтвердження:";
            // 
            // textBoxConfirm
            // 
            textBoxConfirm.Location = new Point(141, 89);
            textBoxConfirm.Name = "textBoxConfirm";
            textBoxConfirm.Size = new Size(166, 27);
            textBoxConfirm.TabIndex = 4;
            textBoxConfirm.UseSystemPasswordChar = true;
            // 
            // buttonSet
            // 
            buttonSet.Font = new Font("Segoe UI", 9F);
            buttonSet.ForeColor = SystemColors.ActiveCaptionText;
            buttonSet.Location = new Point(37, 137);
            buttonSet.Name = "buttonSet";
            buttonSet.Size = new Size(115, 34);
            buttonSet.TabIndex = 5;
            buttonSet.Text = "Встановити";
            buttonSet.Click += buttonSet_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 9F);
            buttonCancel.ForeColor = SystemColors.ControlDarkDark;
            buttonCancel.Location = new Point(168, 137);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(124, 34);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Скасувати";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // SetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 201);
            Controls.Add(labelUser);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(labelConfirm);
            Controls.Add(textBoxConfirm);
            Controls.Add(buttonSet);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MinimizeBox = false;
            Name = "SetPasswordForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Встановлення пароля";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}