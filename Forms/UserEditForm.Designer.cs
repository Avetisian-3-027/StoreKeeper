namespace StoreKeeper.WinForms.Forms
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPagePermissions;
        private System.Windows.Forms.TabPage tabPageDatabase;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxIsAdmin;
        private System.Windows.Forms.CheckedListBox checkedListBoxPermissions;
        private System.Windows.Forms.Label labelProvider;
        private System.Windows.Forms.ComboBox comboBoxProvider;
        private System.Windows.Forms.Label labelSelfWarning;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;

        // Панель для SQLite
        private System.Windows.Forms.Panel panelSQLite;
        private System.Windows.Forms.Label labelFolderPath;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button buttonBrowseFolder;

        // Панель для MySQL/PostgreSQL
        private System.Windows.Forms.Panel panelNetwork;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelDatabaseName;
        private System.Windows.Forms.TextBox textBoxDatabaseName;
        private System.Windows.Forms.Label labelDbUsername;
        private System.Windows.Forms.TextBox textBoxDbUsername;
        private System.Windows.Forms.Label labelDbPassword;
        private System.Windows.Forms.TextBox textBoxDbPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabPageMain = new TabPage();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            checkBoxIsAdmin = new CheckBox();
            labelSelfWarning = new Label();
            tabPagePermissions = new TabPage();
            checkedListBoxPermissions = new CheckedListBox();
            tabPageDatabase = new TabPage();
            labelProvider = new Label();
            comboBoxProvider = new ComboBox();
            panelSQLite = new Panel();
            labelFolderPath = new Label();
            textBoxFolderPath = new TextBox();
            buttonBrowseFolder = new Button();
            panelNetwork = new Panel();
            labelServer = new Label();
            textBoxServer = new TextBox();
            labelPort = new Label();
            textBoxPort = new TextBox();
            labelDatabaseName = new Label();
            textBoxDatabaseName = new TextBox();
            labelDbUsername = new Label();
            textBoxDbUsername = new TextBox();
            labelDbPassword = new Label();
            textBoxDbPassword = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            tabControl.SuspendLayout();
            tabPageMain.SuspendLayout();
            tabPagePermissions.SuspendLayout();
            tabPageDatabase.SuspendLayout();
            panelSQLite.SuspendLayout();
            panelNetwork.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageMain);
            tabControl.Controls.Add(tabPagePermissions);
            tabControl.Controls.Add(tabPageDatabase);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(620, 380);
            tabControl.TabIndex = 0;
            // 
            // tabPageMain
            // 
            tabPageMain.Controls.Add(labelUsername);
            tabPageMain.Controls.Add(textBoxUsername);
            tabPageMain.Controls.Add(labelPassword);
            tabPageMain.Controls.Add(textBoxPassword);
            tabPageMain.Controls.Add(checkBoxIsAdmin);
            tabPageMain.Controls.Add(labelSelfWarning);
            tabPageMain.Location = new Point(4, 29);
            tabPageMain.Name = "tabPageMain";
            tabPageMain.Size = new Size(612, 347);
            tabPageMain.TabIndex = 0;
            tabPageMain.Text = "Основне";
            tabPageMain.UseVisualStyleBackColor = true;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(20, 25);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(128, 20);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Ім'я користувача:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(150, 22);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(250, 27);
            textBoxUsername.TabIndex = 1;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(20, 65);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(65, 20);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Пароль:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(150, 62);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(250, 27);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // checkBoxIsAdmin
            // 
            checkBoxIsAdmin.AutoSize = true;
            checkBoxIsAdmin.Location = new Point(150, 105);
            checkBoxIsAdmin.Name = "checkBoxIsAdmin";
            checkBoxIsAdmin.Size = new Size(131, 24);
            checkBoxIsAdmin.TabIndex = 4;
            checkBoxIsAdmin.Text = "Адміністратор";
            checkBoxIsAdmin.CheckedChanged += checkBoxIsAdmin_CheckedChanged;
            // 
            // labelSelfWarning
            // 
            labelSelfWarning.AutoSize = true;
            labelSelfWarning.ForeColor = Color.Red;
            labelSelfWarning.Location = new Point(20, 150);
            labelSelfWarning.Name = "labelSelfWarning";
            labelSelfWarning.Size = new Size(390, 20);
            labelSelfWarning.TabIndex = 5;
            labelSelfWarning.Text = "Ви не можете змінювати власні права адміністратора.";
            labelSelfWarning.Visible = false;
            // 
            // tabPagePermissions
            // 
            tabPagePermissions.Controls.Add(checkedListBoxPermissions);
            tabPagePermissions.Location = new Point(4, 29);
            tabPagePermissions.Name = "tabPagePermissions";
            tabPagePermissions.Size = new Size(612, 347);
            tabPagePermissions.TabIndex = 1;
            tabPagePermissions.Text = "Права";
            // 
            // checkedListBoxPermissions
            // 
            checkedListBoxPermissions.Location = new Point(20, 20);
            checkedListBoxPermissions.Name = "checkedListBoxPermissions";
            checkedListBoxPermissions.Size = new Size(560, 290);
            checkedListBoxPermissions.TabIndex = 0;
            // 
            // tabPageDatabase
            // 
            tabPageDatabase.Controls.Add(labelProvider);
            tabPageDatabase.Controls.Add(comboBoxProvider);
            tabPageDatabase.Controls.Add(panelSQLite);
            tabPageDatabase.Controls.Add(panelNetwork);
            tabPageDatabase.Location = new Point(4, 29);
            tabPageDatabase.Name = "tabPageDatabase";
            tabPageDatabase.Size = new Size(612, 347);
            tabPageDatabase.TabIndex = 2;
            tabPageDatabase.Text = "База даних";
            // 
            // labelProvider
            // 
            labelProvider.AutoSize = true;
            labelProvider.Location = new Point(30, 22);
            labelProvider.Name = "labelProvider";
            labelProvider.Size = new Size(120, 20);
            labelProvider.TabIndex = 0;
            labelProvider.Text = "Тип бази даних:";
            // 
            // comboBoxProvider
            // 
            comboBoxProvider.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProvider.Location = new Point(160, 19);
            comboBoxProvider.Name = "comboBoxProvider";
            comboBoxProvider.Size = new Size(153, 28);
            comboBoxProvider.TabIndex = 1;
            comboBoxProvider.SelectedIndexChanged += comboBoxProvider_SelectedIndexChanged;
            // 
            // panelSQLite
            // 
            panelSQLite.Controls.Add(labelFolderPath);
            panelSQLite.Controls.Add(textBoxFolderPath);
            panelSQLite.Controls.Add(buttonBrowseFolder);
            panelSQLite.Location = new Point(20, 70);
            panelSQLite.Name = "panelSQLite";
            panelSQLite.Size = new Size(560, 120);
            panelSQLite.TabIndex = 2;
            // 
            // labelFolderPath
            // 
            labelFolderPath.AutoSize = true;
            labelFolderPath.Location = new Point(10, 21);
            labelFolderPath.Name = "labelFolderPath";
            labelFolderPath.Size = new Size(150, 20);
            labelFolderPath.TabIndex = 0;
            labelFolderPath.Text = "Шлях до папки з БД:";
            // 
            // textBoxFolderPath
            // 
            textBoxFolderPath.Location = new Point(166, 17);
            textBoxFolderPath.Name = "textBoxFolderPath";
            textBoxFolderPath.Size = new Size(220, 27);
            textBoxFolderPath.TabIndex = 1;
            // 
            // buttonBrowseFolder
            // 
            buttonBrowseFolder.Location = new Point(392, 17);
            buttonBrowseFolder.Name = "buttonBrowseFolder";
            buttonBrowseFolder.Size = new Size(60, 28);
            buttonBrowseFolder.TabIndex = 2;
            buttonBrowseFolder.Text = "...";
            buttonBrowseFolder.Click += buttonBrowseFolder_Click;
            // 
            // panelNetwork
            // 
            panelNetwork.Controls.Add(labelServer);
            panelNetwork.Controls.Add(textBoxServer);
            panelNetwork.Controls.Add(labelPort);
            panelNetwork.Controls.Add(textBoxPort);
            panelNetwork.Controls.Add(labelDatabaseName);
            panelNetwork.Controls.Add(textBoxDatabaseName);
            panelNetwork.Controls.Add(labelDbUsername);
            panelNetwork.Controls.Add(textBoxDbUsername);
            panelNetwork.Controls.Add(labelDbPassword);
            panelNetwork.Controls.Add(textBoxDbPassword);
            panelNetwork.Location = new Point(20, 70);
            panelNetwork.Name = "panelNetwork";
            panelNetwork.Size = new Size(560, 200);
            panelNetwork.TabIndex = 3;
            panelNetwork.Visible = false;
            // 
            // labelServer
            // 
            labelServer.AutoSize = true;
            labelServer.Location = new Point(10, 20);
            labelServer.Name = "labelServer";
            labelServer.Size = new Size(63, 20);
            labelServer.TabIndex = 0;
            labelServer.Text = "Сервер:";
            // 
            // textBoxServer
            // 
            textBoxServer.Location = new Point(150, 17);
            textBoxServer.Name = "textBoxServer";
            textBoxServer.Size = new Size(200, 27);
            textBoxServer.TabIndex = 1;
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(10, 60);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(47, 20);
            labelPort.TabIndex = 2;
            labelPort.Text = "Порт:";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(150, 57);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(100, 27);
            textBoxPort.TabIndex = 3;
            // 
            // labelDatabaseName
            // 
            labelDatabaseName.AutoSize = true;
            labelDatabaseName.Location = new Point(10, 100);
            labelDatabaseName.Name = "labelDatabaseName";
            labelDatabaseName.Size = new Size(89, 20);
            labelDatabaseName.TabIndex = 4;
            labelDatabaseName.Text = "База даних:";
            // 
            // textBoxDatabaseName
            // 
            textBoxDatabaseName.Location = new Point(150, 97);
            textBoxDatabaseName.Name = "textBoxDatabaseName";
            textBoxDatabaseName.Size = new Size(200, 27);
            textBoxDatabaseName.TabIndex = 5;
            // 
            // labelDbUsername
            // 
            labelDbUsername.AutoSize = true;
            labelDbUsername.Location = new Point(10, 140);
            labelDbUsername.Name = "labelDbUsername";
            labelDbUsername.Size = new Size(92, 20);
            labelDbUsername.TabIndex = 6;
            labelDbUsername.Text = "Користувач:";
            // 
            // textBoxDbUsername
            // 
            textBoxDbUsername.Location = new Point(150, 137);
            textBoxDbUsername.Name = "textBoxDbUsername";
            textBoxDbUsername.Size = new Size(200, 27);
            textBoxDbUsername.TabIndex = 7;
            // 
            // labelDbPassword
            // 
            labelDbPassword.AutoSize = true;
            labelDbPassword.Location = new Point(10, 180);
            labelDbPassword.Name = "labelDbPassword";
            labelDbPassword.Size = new Size(65, 20);
            labelDbPassword.TabIndex = 8;
            labelDbPassword.Text = "Пароль:";
            // 
            // textBoxDbPassword
            // 
            textBoxDbPassword.Location = new Point(150, 177);
            textBoxDbPassword.Name = "textBoxDbPassword";
            textBoxDbPassword.Size = new Size(200, 27);
            textBoxDbPassword.TabIndex = 9;
            textBoxDbPassword.UseSystemPasswordChar = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(350, 410);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 40);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Зберегти";
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(490, 410);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(120, 40);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Скасувати";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // UserEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 470);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редагування користувача";
            tabControl.ResumeLayout(false);
            tabPageMain.ResumeLayout(false);
            tabPageMain.PerformLayout();
            tabPagePermissions.ResumeLayout(false);
            tabPageDatabase.ResumeLayout(false);
            tabPageDatabase.PerformLayout();
            panelSQLite.ResumeLayout(false);
            panelSQLite.PerformLayout();
            panelNetwork.ResumeLayout(false);
            panelNetwork.PerformLayout();
            ResumeLayout(false);
        }
    }
}