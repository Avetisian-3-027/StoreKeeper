namespace StoreKeeper.WinForms.Forms
{
    partial class ManageDatabasesForm
    {
        private System.Windows.Forms.DataGridView dataGridViewDatabases;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelButtons;

        private void InitializeComponent()
        {
            dataGridViewDatabases = new DataGridView();
            panelButtons = new Panel();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDatabases).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewDatabases
            // 
            dataGridViewDatabases.AllowUserToAddRows = false;
            dataGridViewDatabases.AllowUserToDeleteRows = false;
            dataGridViewDatabases.ColumnHeadersHeight = 29;
            dataGridViewDatabases.Location = new Point(12, 12);
            dataGridViewDatabases.Name = "dataGridViewDatabases";
            dataGridViewDatabases.ReadOnly = true;
            dataGridViewDatabases.RowHeadersWidth = 51;
            dataGridViewDatabases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDatabases.Size = new Size(776, 300);
            dataGridViewDatabases.TabIndex = 0;
            dataGridViewDatabases.CellFormatting += dataGridViewDatabases_CellFormatting;
            dataGridViewDatabases.SelectionChanged += dataGridViewDatabases_SelectionChanged;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonAdd);
            panelButtons.Controls.Add(buttonEdit);
            panelButtons.Controls.Add(buttonDelete);
            panelButtons.Location = new Point(12, 330);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(776, 50);
            panelButtons.TabIndex = 1;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(0, 5);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(100, 40);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Додати";
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(110, 5);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(100, 40);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Редагувати";
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(220, 5);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(100, 40);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Видалити";
            buttonDelete.Click += buttonDelete_Click;
            // 
            // ManageDatabasesForm
            // 
            ClientSize = new Size(800, 400);
            Controls.Add(dataGridViewDatabases);
            Controls.Add(panelButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ManageDatabasesForm";
            Text = "Управління базами даних";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDatabases).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}