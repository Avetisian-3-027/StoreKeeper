namespace StoreKeeper.WinForms.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem довідникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem товариToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стравиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem розхідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem звітиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem залишкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem адмініструванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem користувачіToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            адмініструванняToolStripMenuItem = new ToolStripMenuItem();
            користувачіToolStripMenuItem = new ToolStripMenuItem();
            складToolStripMenuItem = new ToolStripMenuItem();
            прихідToolStripMenuItem = new ToolStripMenuItem();
            розхідToolStripMenuItem = new ToolStripMenuItem();
            звітиToolStripMenuItem = new ToolStripMenuItem();
            залишкиToolStripMenuItem = new ToolStripMenuItem();
            довідникиToolStripMenuItem = new ToolStripMenuItem();
            товариToolStripMenuItem = new ToolStripMenuItem();
            стравиToolStripMenuItem = new ToolStripMenuItem();
            вихідToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { адмініструванняToolStripMenuItem, складToolStripMenuItem, звітиToolStripMenuItem, довідникиToolStripMenuItem, вихідToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1006, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // адмініструванняToolStripMenuItem
            // 
            адмініструванняToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { користувачіToolStripMenuItem });
            адмініструванняToolStripMenuItem.Name = "адмініструванняToolStripMenuItem";
            адмініструванняToolStripMenuItem.Size = new Size(140, 24);
            адмініструванняToolStripMenuItem.Text = "Адміністрування";
            // 
            // користувачіToolStripMenuItem
            // 
            користувачіToolStripMenuItem.Name = "користувачіToolStripMenuItem";
            користувачіToolStripMenuItem.Size = new Size(185, 26);
            користувачіToolStripMenuItem.Text = "Користувачі...";
            користувачіToolStripMenuItem.Click += користувачіToolStripMenuItem_Click;
            // 
            // складToolStripMenuItem
            // 
            складToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { прихідToolStripMenuItem, розхідToolStripMenuItem });
            складToolStripMenuItem.Name = "складToolStripMenuItem";
            складToolStripMenuItem.Size = new Size(63, 24);
            складToolStripMenuItem.Text = "Склад";
            // 
            // прихідToolStripMenuItem
            // 
            прихідToolStripMenuItem.Name = "прихідToolStripMenuItem";
            прихідToolStripMenuItem.Size = new Size(191, 26);
            прихідToolStripMenuItem.Text = "Прихід товару";
            прихідToolStripMenuItem.Click += прихідToolStripMenuItem_Click;
            // 
            // розхідToolStripMenuItem
            // 
            розхідToolStripMenuItem.Name = "розхідToolStripMenuItem";
            розхідToolStripMenuItem.Size = new Size(191, 26);
            розхідToolStripMenuItem.Text = "Розхід товару";
            розхідToolStripMenuItem.Click += розхідToolStripMenuItem_Click;
            // 
            // звітиToolStripMenuItem
            // 
            звітиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { залишкиToolStripMenuItem });
            звітиToolStripMenuItem.Name = "звітиToolStripMenuItem";
            звітиToolStripMenuItem.Size = new Size(58, 24);
            звітиToolStripMenuItem.Text = "Звіти";
            // 
            // залишкиToolStripMenuItem
            // 
            залишкиToolStripMenuItem.Name = "залишкиToolStripMenuItem";
            залишкиToolStripMenuItem.Size = new Size(209, 26);
            залишкиToolStripMenuItem.Text = "Залишки товарів";
            залишкиToolStripMenuItem.Click += залишкиToolStripMenuItem_Click;
            // 
            // довідникиToolStripMenuItem
            // 
            довідникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { товариToolStripMenuItem, стравиToolStripMenuItem });
            довідникиToolStripMenuItem.Name = "довідникиToolStripMenuItem";
            довідникиToolStripMenuItem.Size = new Size(96, 24);
            довідникиToolStripMenuItem.Text = "Довідники";
            // 
            // товариToolStripMenuItem
            // 
            товариToolStripMenuItem.Name = "товариToolStripMenuItem";
            товариToolStripMenuItem.Size = new Size(143, 26);
            товариToolStripMenuItem.Text = "Товари";
            товариToolStripMenuItem.Click += товариToolStripMenuItem_Click;
            // 
            // стравиToolStripMenuItem
            // 
            стравиToolStripMenuItem.Name = "стравиToolStripMenuItem";
            стравиToolStripMenuItem.Size = new Size(143, 26);
            стравиToolStripMenuItem.Text = "Страви";
            стравиToolStripMenuItem.Click += стравиToolStripMenuItem_Click;
            // 
            // вихідToolStripMenuItem
            // 
            вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            вихідToolStripMenuItem.Size = new Size(60, 24);
            вихідToolStripMenuItem.Text = "Вихід";
            вихідToolStripMenuItem.Click += вихідToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(1024, 768);
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Головна форма";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}