namespace StoreKeeper.WinForms.Forms
{
    partial class DatabaseEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelFolderPath;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button buttonBrowseFolder;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.CheckBox checkBoxEncrypted;
        private System.Windows.Forms.Panel panelEncryption;
        private System.Windows.Forms.Label labelKeyFilePath;
        private System.Windows.Forms.TextBox textBoxKeyFilePath;
        private System.Windows.Forms.Button buttonBrowseKeyFile;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonEncrypt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelName = new Label();
            textBoxName = new TextBox();
            labelFolderPath = new Label();
            textBoxFolderPath = new TextBox();
            buttonBrowseFolder = new Button();
            labelFileName = new Label();
            textBoxFileName = new TextBox();
            checkBoxEncrypted = new CheckBox();
            panelEncryption = new Panel();
            labelKeyFilePath = new Label();
            textBoxKeyFilePath = new TextBox();
            buttonBrowseKeyFile = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            buttonEncrypt = new Button();
            panelEncryption.SuspendLayout();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(20, 20);
            labelName.Name = "labelName";
            labelName.Size = new Size(91, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Назва бази:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(150, 17);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(250, 27);
            textBoxName.TabIndex = 1;
            // 
            // labelFolderPath
            // 
            labelFolderPath.AutoSize = true;
            labelFolderPath.Location = new Point(20, 60);
            labelFolderPath.Name = "labelFolderPath";
            labelFolderPath.Size = new Size(115, 20);
            labelFolderPath.TabIndex = 2;
            labelFolderPath.Text = "Папка з базою:";
            // 
            // textBoxFolderPath
            // 
            textBoxFolderPath.Location = new Point(150, 57);
            textBoxFolderPath.Name = "textBoxFolderPath";
            textBoxFolderPath.Size = new Size(280, 27);
            textBoxFolderPath.TabIndex = 3;
            // 
            // buttonBrowseFolder
            // 
            buttonBrowseFolder.Location = new Point(440, 56);
            buttonBrowseFolder.Name = "buttonBrowseFolder";
            buttonBrowseFolder.Size = new Size(40, 28);
            buttonBrowseFolder.TabIndex = 4;
            buttonBrowseFolder.Text = "...";
            buttonBrowseFolder.Click += buttonBrowseFolder_Click;
            // 
            // labelFileName
            // 
            labelFileName.AutoSize = true;
            labelFileName.Location = new Point(20, 100);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(119, 20);
            labelFileName.TabIndex = 5;
            labelFileName.Text = "Ім'я файлу (.db):";
            // 
            // textBoxFileName
            // 
            textBoxFileName.Location = new Point(150, 97);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(250, 27);
            textBoxFileName.TabIndex = 6;
            textBoxFileName.Text = "storekeeper.db";
            // 
            // checkBoxEncrypted
            // 
            checkBoxEncrypted.AutoSize = true;
            checkBoxEncrypted.Location = new Point(150, 140);
            checkBoxEncrypted.Name = "checkBoxEncrypted";
            checkBoxEncrypted.Size = new Size(129, 24);
            checkBoxEncrypted.TabIndex = 7;
            checkBoxEncrypted.Text = "Зашифрована";
            checkBoxEncrypted.CheckedChanged += checkBoxEncrypted_CheckedChanged;
            // 
            // panelEncryption
            // 
            panelEncryption.Controls.Add(labelKeyFilePath);
            panelEncryption.Controls.Add(textBoxKeyFilePath);
            panelEncryption.Controls.Add(buttonBrowseKeyFile);
            panelEncryption.Location = new Point(20, 170);
            panelEncryption.Name = "panelEncryption";
            panelEncryption.Size = new Size(500, 50);
            panelEncryption.TabIndex = 8;
            panelEncryption.Visible = false;
            // 
            // labelKeyFilePath
            // 
            labelKeyFilePath.AutoSize = true;
            labelKeyFilePath.Location = new Point(0, 15);
            labelKeyFilePath.Name = "labelKeyFilePath";
            labelKeyFilePath.Size = new Size(95, 20);
            labelKeyFilePath.TabIndex = 0;
            labelKeyFilePath.Text = "Файл ключа:";
            // 
            // textBoxKeyFilePath
            // 
            textBoxKeyFilePath.Location = new Point(130, 12);
            textBoxKeyFilePath.Name = "textBoxKeyFilePath";
            textBoxKeyFilePath.Size = new Size(280, 27);
            textBoxKeyFilePath.TabIndex = 1;
            // 
            // buttonBrowseKeyFile
            // 
            buttonBrowseKeyFile.Location = new Point(420, 11);
            buttonBrowseKeyFile.Name = "buttonBrowseKeyFile";
            buttonBrowseKeyFile.Size = new Size(40, 28);
            buttonBrowseKeyFile.TabIndex = 2;
            buttonBrowseKeyFile.Text = "...";
            buttonBrowseKeyFile.Click += buttonBrowseKeyFile_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(300, 300);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 40);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Зберегти";
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(420, 300);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 40);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Скасувати";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonEncrypt
            // 
            buttonEncrypt.Location = new Point(300, 131);
            buttonEncrypt.Name = "buttonEncrypt";
            buttonEncrypt.Size = new Size(180, 40);
            buttonEncrypt.TabIndex = 9;
            buttonEncrypt.Text = "Зашифрувати базу...";
            buttonEncrypt.Click += buttonEncrypt_Click;
            // 
            // DatabaseEditForm
            // 
            ClientSize = new Size(550, 370);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(labelFolderPath);
            Controls.Add(textBoxFolderPath);
            Controls.Add(buttonBrowseFolder);
            Controls.Add(labelFileName);
            Controls.Add(textBoxFileName);
            Controls.Add(checkBoxEncrypted);
            Controls.Add(panelEncryption);
            Controls.Add(buttonEncrypt);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DatabaseEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редагування бази даних";
            panelEncryption.ResumeLayout(false);
            panelEncryption.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}