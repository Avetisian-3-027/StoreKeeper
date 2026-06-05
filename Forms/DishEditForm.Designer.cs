namespace StoreKeeper.WinForms.Forms
{
    partial class DishEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTechMapNumber;
        private System.Windows.Forms.TextBox textBoxTechMapNumber;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
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
            labelTechMapNumber = new Label();
            textBoxTechMapNumber = new TextBox();
            labelName = new Label();
            textBoxName = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelTechMapNumber
            // 
            labelTechMapNumber.AutoSize = true;
            labelTechMapNumber.Location = new Point(20, 25);
            labelTechMapNumber.Name = "labelTechMapNumber";
            labelTechMapNumber.Size = new Size(172, 20);
            labelTechMapNumber.TabIndex = 0;
            labelTechMapNumber.Text = "№ технологічної карти:";
            // 
            // textBoxTechMapNumber
            // 
            textBoxTechMapNumber.Location = new Point(198, 22);
            textBoxTechMapNumber.Name = "textBoxTechMapNumber";
            textBoxTechMapNumber.Size = new Size(106, 27);
            textBoxTechMapNumber.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(20, 65);
            labelName.Name = "labelName";
            labelName.Size = new Size(105, 20);
            labelName.TabIndex = 2;
            labelName.Text = "Назва страви:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(198, 62);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(302, 27);
            textBoxName.TabIndex = 2;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(280, 110);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 40);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Зберегти";
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(400, 110);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 40);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Скасувати";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // DishEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 180);
            Controls.Add(labelTechMapNumber);
            Controls.Add(textBoxTechMapNumber);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DishEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редагування страви";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}