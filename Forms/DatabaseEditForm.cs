using System;
using System.Linq;
using System.Windows.Forms;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;

namespace StoreKeeper.WinForms.Forms
{
    public partial class DatabaseEditForm : Form
    {
        private DatabaseRecord _dbRecord;
        private AppDbContext _context;
        private bool _isNew;

        public DatabaseEditForm(DatabaseRecord? db, AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            _isNew = (db == null);
            if (_isNew)
            {
                _dbRecord = new DatabaseRecord { IsEncrypted = false };
                Text = "Нова база даних";
                buttonEncrypt.Visible = false;
            }
            else
            {
                _dbRecord = db;
                Text = $"Редагування бази: {_dbRecord.Name}";
                if (_dbRecord.IsEncrypted)
                {
                    checkBoxEncrypted.Enabled = false;
                    buttonEncrypt.Visible = false;
                }
                else
                {
                    checkBoxEncrypted.Enabled = false;
                    buttonEncrypt.Visible = true;
                    buttonEncrypt.Text = "Зашифрувати базу...";
                }
            }
            LoadDatabaseData();
            UpdateEncryptionPanelVisibility();
        }

        private void LoadDatabaseData()
        {
            textBoxName.Text = _dbRecord.Name;
            textBoxFolderPath.Text = _dbRecord.FolderPath ?? "";
            textBoxFileName.Text = _dbRecord.FileName ?? "storekeeper.db";
            checkBoxEncrypted.Checked = _dbRecord.IsEncrypted;
            textBoxKeyFilePath.Text = _dbRecord.KeyFilePath ?? "";
        }

        private void UpdateEncryptionPanelVisibility()
        {
            panelEncryption.Visible = checkBoxEncrypted.Checked;
        }

        private void checkBoxEncrypted_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEncryptionPanelVisibility();
            if (!checkBoxEncrypted.Checked)
                textBoxKeyFilePath.Text = "";
        }

        private void buttonBrowseFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Виберіть папку для зберігання бази даних";
                if (dialog.ShowDialog() == DialogResult.OK)
                    textBoxFolderPath.Text = dialog.SelectedPath;
            }
        }

        private void buttonBrowseKeyFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Зберегти файл ключа";
                dialog.Filter = "Ключі (*.key)|*.key";
                if (dialog.ShowDialog() == DialogResult.OK)
                    textBoxKeyFilePath.Text = dialog.FileName;
            }
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (_dbRecord.IsEncrypted)
            {
                MessageBox.Show("База вже зашифрована.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Виберіть папку для створення зашифрованої копії бази даних";
                if (dialog.ShowDialog() != DialogResult.OK) return;

                string newFolder = dialog.SelectedPath;
                string keyFilePath = "";
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Title = "Зберегти файл ключа";
                    saveDialog.Filter = "Ключі (*.key)|*.key";
                    if (saveDialog.ShowDialog() != DialogResult.OK) return;
                    keyFilePath = saveDialog.FileName;
                }

                try
                {
                    var newDb = _dbRecord.EncryptCopy(newFolder, keyFilePath);
                    _context.Databases.Add(newDb);
                    _context.Databases.Remove(_dbRecord);
                    _context.SaveChanges();
                    _dbRecord = newDb;
                    LoadDatabaseData();
                    checkBoxEncrypted.Enabled = false;
                    buttonEncrypt.Visible = false;
                    MessageBox.Show("Базу даних успішно зашифровано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка шифрування: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введіть назву бази даних", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string folder = textBoxFolderPath.Text.Trim();
            if (string.IsNullOrEmpty(folder))
            {
                MessageBox.Show("Вкажіть папку для бази даних", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fileName = textBoxFileName.Text.Trim();
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Вкажіть ім'я файлу бази даних", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!fileName.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
                fileName += ".db";

            _dbRecord.Name = name;
            _dbRecord.FolderPath = folder;
            _dbRecord.FileName = fileName;

            if (_isNew)
            {
                _dbRecord.IsEncrypted = checkBoxEncrypted.Checked;
                if (_dbRecord.IsEncrypted)
                {
                    if (string.IsNullOrEmpty(textBoxKeyFilePath.Text))
                    {
                        MessageBox.Show("Для зашифрованої бази вкажіть шлях до файлу ключа", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _dbRecord.KeyFilePath = textBoxKeyFilePath.Text;
                }
            }
            else
            {
                // При редагуванні дозволяємо змінити шлях до папки або ключа (якщо незашифрована)
                if (!_dbRecord.IsEncrypted)
                {
                    _dbRecord.KeyFilePath = string.IsNullOrEmpty(textBoxKeyFilePath.Text) ? null : textBoxKeyFilePath.Text;
                }
                // Якщо зашифрована, ключ не змінюємо, але папку можна змінити
            }

            if (_isNew)
                _context.Databases.Add(_dbRecord);
            _context.SaveChanges();

            // Фізичне створення бази (тільки для нової)
            if (_isNew)
            {
                try
                {
                    _dbRecord.CreateEmptyDatabase();
                    MessageBox.Show("База даних успішно створена.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при створенні бази: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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