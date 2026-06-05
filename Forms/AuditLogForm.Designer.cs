namespace StoreKeeper.WinForms.Forms
{
    partial class AuditLogForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewLogs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewLogs = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLogs).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewLogs
            // 
            dataGridViewLogs.AllowUserToAddRows = false;
            dataGridViewLogs.AllowUserToDeleteRows = false;
            dataGridViewLogs.ColumnHeadersHeight = 29;
            dataGridViewLogs.Dock = DockStyle.Fill;
            dataGridViewLogs.Location = new Point(0, 0);
            dataGridViewLogs.Name = "dataGridViewLogs";
            dataGridViewLogs.ReadOnly = true;
            dataGridViewLogs.RowHeadersWidth = 51;
            dataGridViewLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLogs.Size = new Size(800, 450);
            dataGridViewLogs.TabIndex = 0;
            dataGridViewLogs.CellClick += dataGridViewLogs_CellClick;
            // 
            // AuditLogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewLogs);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AuditLogForm";
            Text = "Журнал подій";
            ((System.ComponentModel.ISupportInitialize)dataGridViewLogs).EndInit();
            ResumeLayout(false);
        }
    }
}