namespace StoreKeeper.WinForms.Forms
{
    partial class ProductEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;

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
            labelCategory = new Label();
            comboBoxCategory = new ComboBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(20, 20);
            labelName.Name = "labelName";
            labelName.Size = new Size(54, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Назва:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(120, 17);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(268, 27);
            textBoxName.TabIndex = 1;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(20, 60);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(79, 20);
            labelCategory.TabIndex = 2;
            labelCategory.Text = "Категорія:";
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.Location = new Point(120, 57);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(268, 28);
            comboBoxCategory.TabIndex = 3;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(176, 109);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(103, 40);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Зберегти";
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(285, 109);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(103, 40);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Скасувати";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ProductEditForm
            // 
            ClientSize = new Size(400, 171);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(labelCategory);
            Controls.Add(comboBoxCategory);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Товар";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}