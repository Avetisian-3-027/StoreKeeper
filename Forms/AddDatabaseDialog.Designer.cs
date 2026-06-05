namespace StoreKeeper.WinForms.Forms
{
    partial class AddDatabaseDialog
    {
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonExisting;

        private void InitializeComponent()
        {
            buttonNew = new Button();
            buttonExisting = new Button();
            SuspendLayout();
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(24, 30);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(120, 40);
            buttonNew.TabIndex = 0;
            buttonNew.Text = "Нова база";
            buttonNew.Click += buttonNew_Click;
            // 
            // buttonExisting
            // 
            buttonExisting.Location = new Point(180, 30);
            buttonExisting.Name = "buttonExisting";
            buttonExisting.Size = new Size(150, 40);
            buttonExisting.TabIndex = 1;
            buttonExisting.Text = "Існуюча база";
            buttonExisting.Click += buttonExisting_Click;
            // 
            // AddDatabaseDialog
            // 
            ClientSize = new Size(350, 100);
            Controls.Add(buttonNew);
            Controls.Add(buttonExisting);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddDatabaseDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Вибір дії";
            ResumeLayout(false);
        }
    }
}