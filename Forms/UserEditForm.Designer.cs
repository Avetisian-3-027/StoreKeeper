namespace StoreKeeper.WinForms.Forms
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPagePermissions;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxIsAdmin;
        private System.Windows.Forms.Label labelSelfWarning;
        private System.Windows.Forms.CheckedListBox checkedListBoxPermissions;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelDatabase;
        private System.Windows.Forms.ComboBox comboBoxDatabase;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPagePermissions = new System.Windows.Forms.TabPage();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.checkBoxIsAdmin = new System.Windows.Forms.CheckBox();
            this.labelSelfWarning = new System.Windows.Forms.Label();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.checkedListBoxPermissions = new System.Windows.Forms.CheckedListBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPagePermissions.SuspendLayout();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabPagePermissions);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(620, 380);
            this.tabControl.TabIndex = 0;

            // tabPageMain
            this.tabPageMain.Controls.Add(this.labelUsername);
            this.tabPageMain.Controls.Add(this.textBoxUsername);
            this.tabPageMain.Controls.Add(this.labelPassword);
            this.tabPageMain.Controls.Add(this.textBoxPassword);
            this.tabPageMain.Controls.Add(this.checkBoxIsAdmin);
            this.tabPageMain.Controls.Add(this.labelSelfWarning);
            this.tabPageMain.Controls.Add(this.labelDatabase);
            this.tabPageMain.Controls.Add(this.comboBoxDatabase);
            this.tabPageMain.Text = "Основне";
            this.tabPageMain.UseVisualStyleBackColor = true;

            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(20, 25);
            this.labelUsername.Text = "Ім'я користувача:";
            this.textBoxUsername.Location = new System.Drawing.Point(150, 22);
            this.textBoxUsername.Size = new System.Drawing.Size(250, 27);

            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(20, 65);
            this.labelPassword.Text = "Пароль:";
            this.textBoxPassword.Location = new System.Drawing.Point(150, 62);
            this.textBoxPassword.Size = new System.Drawing.Size(250, 27);
            this.textBoxPassword.UseSystemPasswordChar = true;

            this.checkBoxIsAdmin.AutoSize = true;
            this.checkBoxIsAdmin.Location = new System.Drawing.Point(150, 105);
            this.checkBoxIsAdmin.Text = "Адміністратор";
            this.checkBoxIsAdmin.CheckedChanged += new System.EventHandler(this.checkBoxIsAdmin_CheckedChanged);

            this.labelSelfWarning.AutoSize = true;
            this.labelSelfWarning.ForeColor = System.Drawing.Color.Red;
            this.labelSelfWarning.Location = new System.Drawing.Point(20, 145);
            this.labelSelfWarning.Text = "Ви не можете змінювати власні права адміністратора.";
            this.labelSelfWarning.Visible = false;

            this.labelDatabase.AutoSize = true;
            this.labelDatabase.Location = new System.Drawing.Point(20, 185);
            this.labelDatabase.Text = "База даних:";
            this.comboBoxDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatabase.Location = new System.Drawing.Point(150, 182);
            this.comboBoxDatabase.Size = new System.Drawing.Size(250, 28);

            // tabPagePermissions
            this.tabPagePermissions.Controls.Add(this.checkedListBoxPermissions);
            this.tabPagePermissions.Text = "Права";
            this.checkedListBoxPermissions.Location = new System.Drawing.Point(20, 20);
            this.checkedListBoxPermissions.Size = new System.Drawing.Size(560, 290);

            // buttonSave, buttonCancel
            this.buttonSave.Location = new System.Drawing.Point(350, 410);
            this.buttonSave.Size = new System.Drawing.Size(120, 40);
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            this.buttonCancel.Location = new System.Drawing.Point(490, 410);
            this.buttonCancel.Size = new System.Drawing.Size(120, 40);
            this.buttonCancel.Text = "Скасувати";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);

            // UserEditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 470);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редагування користувача";
            this.tabControl.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPagePermissions.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}