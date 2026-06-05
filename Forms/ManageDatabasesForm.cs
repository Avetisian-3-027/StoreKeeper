using System;
using System.Linq;
using System.Windows.Forms;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;

namespace StoreKeeper.WinForms.Forms
{
    public partial class ManageDatabasesForm : Form
    {
        private AppDbContext _context;
        private DatabaseRecord? _selectedDatabase;

        public ManageDatabasesForm(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            LoadDatabases();
            UpdateButtonsState();
        }

        private void LoadDatabases()
        {
            _context.ChangeTracker.Clear();
            var dbs = _context.Databases.OrderBy(d => d.Name).ToList();

            // Фіксуємо колонки
            dataGridViewDatabases.AutoGenerateColumns = false;
            dataGridViewDatabases.Columns.Clear();

            // Назва бази
            dataGridViewDatabases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Назва бази",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Папка
            dataGridViewDatabases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FolderPath",
                HeaderText = "Папка",
                DataPropertyName = "FolderPath",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });

            // Файл
            dataGridViewDatabases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FileName",
                HeaderText = "Файл",
                DataPropertyName = "FileName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });

            // Шифрування (заповнюється через CellFormatting)
            dataGridViewDatabases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EncryptedColumn",
                HeaderText = "Шифрування",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });

            dataGridViewDatabases.DataSource = dbs;
            dataGridViewDatabases.AllowUserToOrderColumns = false;
        }

        private void dataGridViewDatabases_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var db = dataGridViewDatabases.Rows[e.RowIndex].DataBoundItem as DatabaseRecord;
            if (db == null) return;

            if (dataGridViewDatabases.Columns[e.ColumnIndex].Name == "EncryptedColumn")
            {
                e.Value = db.IsEncrypted ? "Так" : "Ні";
                e.FormattingApplied = true;
            }
        }

        private void UpdateButtonsState()
        {
            bool hasSelection = dataGridViewDatabases.CurrentRow != null;
            buttonEdit.Enabled = hasSelection;
            buttonDelete.Enabled = hasSelection;
        }

        private void dataGridViewDatabases_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
            _selectedDatabase = dataGridViewDatabases.CurrentRow?.DataBoundItem as DatabaseRecord;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new AddDatabaseDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (dialog.IsNewDatabase)
                    {
                        using (var editForm = new DatabaseEditForm(null, _context))
                        {
                            if (editForm.ShowDialog() == DialogResult.OK)
                                LoadDatabases();
                        }
                    }
                    else
                    {
                        using (var openDialog = new OpenFileDialog())
                        {
                            openDialog.Title = "Виберіть існуючу базу даних SQLite";
                            openDialog.Filter = "SQLite files (*.db)|*.db";
                            if (openDialog.ShowDialog() == DialogResult.OK)
                            {
                                string fullPath = openDialog.FileName;
                                string folder = System.IO.Path.GetDirectoryName(fullPath);
                                string fileName = System.IO.Path.GetFileName(fullPath);
                                string name = System.IO.Path.GetFileNameWithoutExtension(fullPath);
                                var existing = _context.Databases.FirstOrDefault(d => d.FolderPath == folder && d.FileName == fileName);
                                if (existing != null)
                                {
                                    MessageBox.Show("Ця база даних вже додана.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                bool isEncrypted = MessageBox.Show("Ця база зашифрована?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                                string keyFile = null;
                                if (isEncrypted)
                                {
                                    using (var keyDialog = new OpenFileDialog())
                                    {
                                        keyDialog.Title = "Виберіть файл ключа";
                                        keyDialog.Filter = "Ключі (*.key)|*.key";
                                        if (keyDialog.ShowDialog() != DialogResult.OK) return;
                                        keyFile = keyDialog.FileName;
                                    }
                                }
                                var newDb = new DatabaseRecord
                                {
                                    Name = name,
                                    FolderPath = folder,
                                    FileName = fileName,
                                    IsEncrypted = isEncrypted,
                                    KeyFilePath = keyFile
                                };
                                _context.Databases.Add(newDb);
                                _context.SaveChanges();
                                LoadDatabases();
                                MessageBox.Show($"Базу даних '{name}' додано.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (_selectedDatabase == null) return;
            using (var editForm = new DatabaseEditForm(_selectedDatabase, _context))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadDatabases();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_selectedDatabase == null) return;
            if (MessageBox.Show($"Видалити базу '{_selectedDatabase.Name}' зі списку?\n(Файл бази не буде видалено)", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _context.Databases.Remove(_selectedDatabase);
                _context.SaveChanges();
                LoadDatabases();
            }
        }
    }
}