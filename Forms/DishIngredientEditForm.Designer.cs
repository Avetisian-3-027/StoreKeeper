namespace StoreKeeper.WinForms.Forms
{
    partial class DishIngredientEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Label labelGrams;
        private System.Windows.Forms.NumericUpDown numericUpDownGrams;
        private System.Windows.Forms.CheckBox checkBoxPeriod;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
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
            checkBoxPeriod = new CheckBox();
            labelFrom = new Label();
            labelTo = new Label();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownGrams).BeginInit();
            SuspendLayout();
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(20, 20);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(69, 20);
            labelProduct.TabIndex = 0;
            labelProduct.Text = "Продукт:";
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProduct.Location = new Point(142, 17);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(288, 28);
            comboBoxProduct.TabIndex = 1;
            // 
            // labelGrams
            // 
            labelGrams.AutoSize = true;
            labelGrams.Location = new Point(20, 60);
            labelGrams.Name = "labelGrams";
            labelGrams.Size = new Size(116, 20);
            labelGrams.TabIndex = 2;
            labelGrams.Text = "Грами (брутто):";
            // 
            // numericUpDownGrams
            // 
            numericUpDownGrams.DecimalPlaces = 1;
            numericUpDownGrams.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownGrams.Location = new Point(142, 58);
            numericUpDownGrams.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownGrams.Name = "numericUpDownGrams";
            numericUpDownGrams.Size = new Size(120, 27);
            numericUpDownGrams.TabIndex = 2;
            numericUpDownGrams.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // checkBoxPeriod
            // 
            checkBoxPeriod.AutoSize = true;
            checkBoxPeriod.Location = new Point(20, 103);
            checkBoxPeriod.Name = "checkBoxPeriod";
            checkBoxPeriod.Size = new Size(118, 24);
            checkBoxPeriod.TabIndex = 3;
            checkBoxPeriod.Text = "Діє в період:";
            checkBoxPeriod.UseVisualStyleBackColor = true;
            checkBoxPeriod.CheckedChanged += checkBoxPeriod_CheckedChanged;
            // 
            // labelFrom
            // 
            labelFrom.AutoSize = true;
            labelFrom.Location = new Point(130, 130);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(16, 20);
            labelFrom.TabIndex = 4;
            labelFrom.Text = "з";
            labelFrom.Visible = false;
            // 
            // labelTo
            // 
            labelTo.AutoSize = true;
            labelTo.Location = new Point(280, 130);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(26, 20);
            labelTo.TabIndex = 6;
            labelTo.Text = "до";
            labelTo.Visible = false;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(150, 127);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(120, 27);
            dateTimePickerStart.TabIndex = 5;
            dateTimePickerStart.Visible = false;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(310, 127);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(120, 27);
            dateTimePickerEnd.TabIndex = 7;
            dateTimePickerEnd.Visible = false;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(206, 178);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 40);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Зберегти";
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(330, 178);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 40);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Скасувати";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // DishIngredientEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 230);
            Controls.Add(labelProduct);
            Controls.Add(comboBoxProduct);
            Controls.Add(labelGrams);
            Controls.Add(numericUpDownGrams);
            Controls.Add(checkBoxPeriod);
            Controls.Add(labelFrom);
            Controls.Add(dateTimePickerStart);
            Controls.Add(labelTo);
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