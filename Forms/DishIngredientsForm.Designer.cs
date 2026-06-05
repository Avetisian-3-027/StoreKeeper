namespace StoreKeeper.WinForms.Forms
{
    partial class DishIngredientsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewIngredients;
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
            dataGridViewIngredients = new DataGridView();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredients).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewIngredients
            // 
            dataGridViewIngredients.AllowUserToAddRows = false;
            dataGridViewIngredients.AllowUserToDeleteRows = false;
            dataGridViewIngredients.ColumnHeadersHeight = 29;
            dataGridViewIngredients.Location = new Point(12, 12);
            dataGridViewIngredients.Name = "dataGridViewIngredients";
            dataGridViewIngredients.ReadOnly = true;
            dataGridViewIngredients.RowHeadersWidth = 51;
            dataGridViewIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIngredients.Size = new Size(776, 300);
            dataGridViewIngredients.TabIndex = 0;
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
            // DishIngredientsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(dataGridViewIngredients);
            Controls.Add(buttonAdd);
            Controls.Add(buttonEdit);
            Controls.Add(buttonDelete);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DishIngredientsForm";
            Text = "Інгредієнти страви";
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredients).EndInit();
            ResumeLayout(false);
        }
    }
}