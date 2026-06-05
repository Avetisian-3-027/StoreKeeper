namespace StoreKeeper.WinForms.Forms
{
    partial class DishIngredientEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Label labelGrams;
        private System.Windows.Forms.NumericUpDown numericUpDownGrams;
        private System.Windows.Forms.CheckBox checkBoxStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.CheckBox checkBoxEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
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
            labelProduct = new Label();
            comboBoxProduct = new ComboBox();
            labelGrams = new Label();
            numericUpDownGrams = new NumericUpDown();
            checkBoxStartDate = new CheckBox();
            dateTimePickerStart = new DateTimePicker();
            checkBoxEndDate = new CheckBox();
            dateTimePickerEnd = new DateTimePicker();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownGrams).BeginInit();
            SuspendLayout();
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(20, 25);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(69, 20);
            labelProduct.TabIndex = 0;
            labelProduct.Text = "Продукт:";
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProduct.Location = new Point(142, 22);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(286, 28);
            comboBoxProduct.TabIndex = 1;
            // 
            // labelGrams
            // 
            labelGrams.AutoSize = true;
            labelGrams.Location = new Point(20, 65);
            labelGrams.Name = "labelGrams";
            labelGrams.Size = new Size(116, 20);
            labelGrams.TabIndex = 2;
            labelGrams.Text = "Грами (брутто):";
            // 
            // numericUpDownGrams
            // 
            numericUpDownGrams.DecimalPlaces = 1;
            numericUpDownGrams.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownGrams.Location = new Point(142, 63);
            numericUpDownGrams.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownGrams.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownGrams.Name = "numericUpDownGrams";
            numericUpDownGrams.Size = new Size(100, 27);
            numericUpDownGrams.TabIndex = 2;
            numericUpDownGrams.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // checkBoxStartDate
            // 
            checkBoxStartDate.AutoSize = true;
            checkBoxStartDate.Location = new Point(23, 102);
            checkBoxStartDate.Name = "checkBoxStartDate";
            checkBoxStartDate.Size = new Size(66, 24);
            checkBoxStartDate.TabIndex = 3;
            checkBoxStartDate.Text = "Діє з:";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(142, 102);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(180, 27);
            dateTimePickerStart.TabIndex = 4;
            // 
            // checkBoxEndDate
            // 
            checkBoxEndDate.AutoSize = true;
            checkBoxEndDate.Location = new Point(23, 142);
            checkBoxEndDate.Name = "checkBoxEndDate";
            checkBoxEndDate.Size = new Size(76, 24);
            checkBoxEndDate.TabIndex = 5;
            checkBoxEndDate.Text = "Діє до:";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(142, 142);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(180, 27);
            dateTimePickerEnd.TabIndex = 6;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(250, 200);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 40);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Зберегти";
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(370, 200);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 40);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Скасувати";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // DishIngredientEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 270);
            Controls.Add(labelProduct);
            Controls.Add(comboBoxProduct);
            Controls.Add(labelGrams);
            Controls.Add(numericUpDownGrams);
            Controls.Add(checkBoxStartDate);
            Controls.Add(dateTimePickerStart);
            Controls.Add(checkBoxEndDate);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DishIngredientEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Інгредієнт";
            ((System.ComponentModel.ISupportInitialize)numericUpDownGrams).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}