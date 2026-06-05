namespace StoreKeeper.WinForms.Forms
{
    partial class ProductsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewProducts = new DataGridView();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.AllowUserToDeleteRows = false;
            dataGridViewProducts.ColumnHeadersHeight = 29;
            dataGridViewProducts.Location = new Point(12, 12);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.RowHeadersWidth = 51;
            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProducts.Size = new Size(776, 300);
            dataGridViewProducts.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(12, 330);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(100, 40);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Додати";
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(120, 330);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(100, 40);
            buttonEdit.TabIndex = 2;
            buttonEdit.Text = "Редагувати";
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(230, 330);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(100, 40);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Видалити";
            buttonDelete.Click += buttonDelete_Click;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(dataGridViewProducts);
            Controls.Add(buttonAdd);
            Controls.Add(buttonEdit);
            Controls.Add(buttonDelete);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductsForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Товари";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
        }
    }
}