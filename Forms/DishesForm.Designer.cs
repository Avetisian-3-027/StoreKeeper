namespace StoreKeeper.WinForms.Forms
{
    partial class DishesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewDishes;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonIngredients;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewDishes = new DataGridView();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonIngredients = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDishes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDishes
            // 
            dataGridViewDishes.AllowUserToAddRows = false;
            dataGridViewDishes.AllowUserToDeleteRows = false;
            dataGridViewDishes.ColumnHeadersHeight = 29;
            dataGridViewDishes.Location = new Point(12, 12);
            dataGridViewDishes.Name = "dataGridViewDishes";
            dataGridViewDishes.ReadOnly = true;
            dataGridViewDishes.RowHeadersWidth = 51;
            dataGridViewDishes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDishes.Size = new Size(776, 300);
            dataGridViewDishes.TabIndex = 0;
            dataGridViewDishes.SelectionChanged += dataGridViewDishes_SelectionChanged;
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
            // buttonIngredients
            // 
            buttonIngredients.Location = new Point(340, 330);
            buttonIngredients.Name = "buttonIngredients";
            buttonIngredients.Size = new Size(120, 40);
            buttonIngredients.TabIndex = 4;
            buttonIngredients.Text = "Інгредієнти...";
            buttonIngredients.Click += buttonIngredients_Click;
            // 
            // DishesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(dataGridViewDishes);
            Controls.Add(buttonAdd);
            Controls.Add(buttonEdit);
            Controls.Add(buttonDelete);
            Controls.Add(buttonIngredients);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DishesForm";
            Text = "Страви";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDishes).EndInit();
            ResumeLayout(false);
        }
    }
}