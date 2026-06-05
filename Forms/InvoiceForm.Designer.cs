namespace StoreKeeper.WinForms.Forms
{
    partial class InvoiceForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label labelSupplier;
        private System.Windows.Forms.TextBox textBoxSupplier;
        private System.Windows.Forms.GroupBox groupBoxAddProduct;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.GroupBox groupBoxFromDish;
        private System.Windows.Forms.ComboBox comboBoxDish;
        private System.Windows.Forms.Label labelDish;
        private System.Windows.Forms.Label labelPortions;
        private System.Windows.Forms.NumericUpDown numericUpDownPortions;
        private System.Windows.Forms.Button buttonAddFromDish;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Button buttonDeleteItem;
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
            labelNumber = new Label();
            textBoxNumber = new TextBox();
            labelDate = new Label();
            dateTimePickerDate = new DateTimePicker();
            labelComment = new Label();
            textBoxComment = new TextBox();
            labelSupplier = new Label();
            textBoxSupplier = new TextBox();
            groupBoxAddProduct = new GroupBox();
            comboBoxProduct = new ComboBox();
            labelProduct = new Label();
            labelQuantity = new Label();
            numericUpDownQuantity = new NumericUpDown();
            labelPrice = new Label();
            numericUpDownPrice = new NumericUpDown();
            buttonAddProduct = new Button();
            groupBoxFromDish = new GroupBox();
            comboBoxDish = new ComboBox();
            labelDish = new Label();
            labelPortions = new Label();
            numericUpDownPortions = new NumericUpDown();
            buttonAddFromDish = new Button();
            dataGridViewItems = new DataGridView();
            buttonDeleteItem = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            groupBoxAddProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            groupBoxFromDish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPortions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            SuspendLayout();
            // 
            // labelNumber
            // 
            labelNumber.AutoSize = true;
            labelNumber.Location = new Point(12, 15);
            labelNumber.Name = "labelNumber";
            labelNumber.Size = new Size(60, 20);
            labelNumber.TabIndex = 0;
            labelNumber.Text = "Номер:";
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(128, 12);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(150, 27);
            textBoxNumber.TabIndex = 1;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(12, 50);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(44, 20);
            labelDate.TabIndex = 2;
            labelDate.Text = "Дата:";
            // 
            // dateTimePickerDate
            // 
            dateTimePickerDate.Location = new Point(128, 47);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(200, 27);
            dateTimePickerDate.TabIndex = 3;
            // 
            // labelComment
            // 
            labelComment.AutoSize = true;
            labelComment.Location = new Point(12, 85);
            labelComment.Name = "labelComment";
            labelComment.Size = new Size(81, 20);
            labelComment.TabIndex = 4;
            labelComment.Text = "Коментар:";
            // 
            // textBoxComment
            // 
            textBoxComment.Location = new Point(128, 84);
            textBoxComment.Name = "textBoxComment";
            textBoxComment.Size = new Size(400, 27);
            textBoxComment.TabIndex = 5;
            // 
            // labelSupplier
            // 
            labelSupplier.AutoSize = true;
            labelSupplier.Location = new Point(12, 120);
            labelSupplier.Name = "labelSupplier";
            labelSupplier.Size = new Size(110, 20);
            labelSupplier.TabIndex = 6;
            labelSupplier.Text = "Постачальник:";
            // 
            // textBoxSupplier
            // 
            textBoxSupplier.Location = new Point(128, 117);
            textBoxSupplier.Name = "textBoxSupplier";
            textBoxSupplier.Size = new Size(400, 27);
            textBoxSupplier.TabIndex = 7;
            textBoxSupplier.Visible = false;
            // 
            // groupBoxAddProduct
            // 
            groupBoxAddProduct.Controls.Add(comboBoxProduct);
            groupBoxAddProduct.Controls.Add(labelProduct);
            groupBoxAddProduct.Controls.Add(labelQuantity);
            groupBoxAddProduct.Controls.Add(numericUpDownQuantity);
            groupBoxAddProduct.Controls.Add(labelPrice);
            groupBoxAddProduct.Controls.Add(numericUpDownPrice);
            groupBoxAddProduct.Controls.Add(buttonAddProduct);
            groupBoxAddProduct.Location = new Point(12, 160);
            groupBoxAddProduct.Name = "groupBoxAddProduct";
            groupBoxAddProduct.Size = new Size(520, 100);
            groupBoxAddProduct.TabIndex = 8;
            groupBoxAddProduct.TabStop = false;
            groupBoxAddProduct.Text = "Додати товар вручну";
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProduct.Location = new Point(80, 22);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(250, 28);
            comboBoxProduct.TabIndex = 0;
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(6, 25);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(54, 20);
            labelProduct.TabIndex = 1;
            labelProduct.Text = "Товар:";
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(340, 25);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(75, 20);
            labelQuantity.TabIndex = 2;
            labelQuantity.Text = "К-сть (кг):";
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.DecimalPlaces = 3;
            numericUpDownQuantity.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownQuantity.Location = new Point(430, 23);
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(80, 27);
            numericUpDownQuantity.TabIndex = 3;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(6, 60);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(80, 20);
            labelPrice.TabIndex = 4;
            labelPrice.Text = "Ціна за кг:";
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Location = new Point(94, 58);
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(100, 27);
            numericUpDownPrice.TabIndex = 5;
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.Location = new Point(200, 55);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new Size(100, 30);
            buttonAddProduct.TabIndex = 6;
            buttonAddProduct.Text = "Додати";
            buttonAddProduct.Click += buttonAddProduct_Click;
            // 
            // groupBoxFromDish
            // 
            groupBoxFromDish.Controls.Add(comboBoxDish);
            groupBoxFromDish.Controls.Add(labelDish);
            groupBoxFromDish.Controls.Add(labelPortions);
            groupBoxFromDish.Controls.Add(numericUpDownPortions);
            groupBoxFromDish.Controls.Add(buttonAddFromDish);
            groupBoxFromDish.Location = new Point(12, 266);
            groupBoxFromDish.Name = "groupBoxFromDish";
            groupBoxFromDish.Size = new Size(520, 94);
            groupBoxFromDish.TabIndex = 9;
            groupBoxFromDish.TabStop = false;
            groupBoxFromDish.Text = "Додати зі страви";
            // 
            // comboBoxDish
            // 
            comboBoxDish.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDish.Location = new Point(80, 22);
            comboBoxDish.Name = "comboBoxDish";
            comboBoxDish.Size = new Size(250, 28);
            comboBoxDish.TabIndex = 0;
            // 
            // labelDish
            // 
            labelDish.AutoSize = true;
            labelDish.Location = new Point(6, 25);
            labelDish.Name = "labelDish";
            labelDish.Size = new Size(60, 20);
            labelDish.TabIndex = 1;
            labelDish.Text = "Страва:";
            // 
            // labelPortions
            // 
            labelPortions.AutoSize = true;
            labelPortions.Location = new Point(340, 25);
            labelPortions.Name = "labelPortions";
            labelPortions.Size = new Size(63, 20);
            labelPortions.TabIndex = 2;
            labelPortions.Text = "Порцій:";
            // 
            // numericUpDownPortions
            // 
            numericUpDownPortions.Location = new Point(430, 23);
            numericUpDownPortions.Name = "numericUpDownPortions";
            numericUpDownPortions.Size = new Size(80, 27);
            numericUpDownPortions.TabIndex = 3;
            // 
            // buttonAddFromDish
            // 
            buttonAddFromDish.Location = new Point(200, 56);
            buttonAddFromDish.Name = "buttonAddFromDish";
            buttonAddFromDish.Size = new Size(100, 30);
            buttonAddFromDish.TabIndex = 4;
            buttonAddFromDish.Text = "Додати";
            buttonAddFromDish.Click += buttonAddFromDish_Click;
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.AllowUserToAddRows = false;
            dataGridViewItems.AllowUserToDeleteRows = false;
            dataGridViewItems.ColumnHeadersHeight = 29;
            dataGridViewItems.Location = new Point(12, 370);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.ReadOnly = true;
            dataGridViewItems.RowHeadersWidth = 51;
            dataGridViewItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewItems.Size = new Size(860, 250);
            dataGridViewItems.TabIndex = 6;
            dataGridViewItems.SelectionChanged += dataGridViewItems_SelectionChanged;
            // 
            // buttonDeleteItem
            // 
            buttonDeleteItem.Enabled = false;
            buttonDeleteItem.Location = new Point(12, 630);
            buttonDeleteItem.Name = "buttonDeleteItem";
            buttonDeleteItem.Size = new Size(238, 40);
            buttonDeleteItem.TabIndex = 10;
            buttonDeleteItem.Text = "Видалити вибраний рядок";
            buttonDeleteItem.Click += buttonDeleteItem_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(600, 630);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 40);
            buttonSave.TabIndex = 11;
            buttonSave.Text = "Зберегти";
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(740, 630);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(120, 40);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "Скасувати";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 690);
            Controls.Add(labelNumber);
            Controls.Add(textBoxNumber);
            Controls.Add(labelDate);
            Controls.Add(dateTimePickerDate);
            Controls.Add(labelComment);
            Controls.Add(textBoxComment);
            Controls.Add(labelSupplier);
            Controls.Add(textBoxSupplier);
            Controls.Add(groupBoxAddProduct);
            Controls.Add(groupBoxFromDish);
            Controls.Add(dataGridViewItems);
            Controls.Add(buttonDeleteItem);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "InvoiceForm";
            ShowIcon = false;
            groupBoxAddProduct.ResumeLayout(false);
            groupBoxAddProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            groupBoxFromDish.ResumeLayout(false);
            groupBoxFromDish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPortions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}