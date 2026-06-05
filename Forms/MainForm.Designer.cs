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
        private System.Windows.Forms.ToolStripMenuItem базиДанихToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вкладкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закритиПоточнуВкладкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem змінитиКористувачаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завершитиРоботуToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem журналToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            довідникиToolStripMenuItem = new ToolStripMenuItem();
            товариToolStripMenuItem = new ToolStripMenuItem();
            стравиToolStripMenuItem = new ToolStripMenuItem();
            складToolStripMenuItem = new ToolStripMenuItem();
            прихідToolStripMenuItem = new ToolStripMenuItem();
            розхідToolStripMenuItem = new ToolStripMenuItem();
            звітиToolStripMenuItem = new ToolStripMenuItem();
            залишкиToolStripMenuItem = new ToolStripMenuItem();
            журналToolStripMenuItem = new ToolStripMenuItem();
            адмініструванняToolStripMenuItem = new ToolStripMenuItem();
            користувачіToolStripMenuItem = new ToolStripMenuItem();
            базиДанихToolStripMenuItem = new ToolStripMenuItem();
            вкладкиToolStripMenuItem = new ToolStripMenuItem();
            закритиПоточнуВкладкуToolStripMenuItem = new ToolStripMenuItem();
            вихідToolStripMenuItem = new ToolStripMenuItem();
            змінитиКористувачаToolStripMenuItem = new ToolStripMenuItem();
            завершитиРоботуToolStripMenuItem = new ToolStripMenuItem();
            tabControl = new TabControl();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { довідникиToolStripMenuItem, складToolStripMenuItem, звітиToolStripMenuItem, журналToolStripMenuItem, адмініструванняToolStripMenuItem, вкладкиToolStripMenuItem, вихідToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 28);
            menuStrip.TabIndex = 0;
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
            // журналToolStripMenuItem
            // 
            журналToolStripMenuItem.Name = "журналToolStripMenuItem";
            журналToolStripMenuItem.Size = new Size(77, 24);
            журналToolStripMenuItem.Text = "Журнал";
            журналToolStripMenuItem.Click += журналToolStripMenuItem_Click;
            // 
            // адмініструванняToolStripMenuItem
            // 
            адмініструванняToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { користувачіToolStripMenuItem, базиДанихToolStripMenuItem });
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
            // базиДанихToolStripMenuItem
            // 
            базиДанихToolStripMenuItem.Name = "базиДанихToolStripMenuItem";
            базиДанихToolStripMenuItem.Size = new Size(185, 26);
            базиДанихToolStripMenuItem.Text = "Бази даних...";
            базиДанихToolStripMenuItem.Click += базиДанихToolStripMenuItem_Click;
            // 
            // вкладкиToolStripMenuItem
            // 
            вкладкиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { закритиПоточнуВкладкуToolStripMenuItem });
            вкладкиToolStripMenuItem.Name = "вкладкиToolStripMenuItem";
            вкладкиToolStripMenuItem.Size = new Size(79, 24);
            вкладкиToolStripMenuItem.Text = "Вкладки";
            вкладкиToolStripMenuItem.Visible = false;
            // 
            // закритиПоточнуВкладкуToolStripMenuItem
            // 
            закритиПоточнуВкладкуToolStripMenuItem.Name = "закритиПоточнуВкладкуToolStripMenuItem";
            закритиПоточнуВкладкуToolStripMenuItem.Size = new Size(266, 26);
            закритиПоточнуВкладкуToolStripMenuItem.Text = "Закрити поточну вкладку";
            закритиПоточнуВкладкуToolStripMenuItem.Click += закритиПоточнуВкладкуToolStripMenuItem_Click;
            // 
            // вихідToolStripMenuItem
            // 
            вихідToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { змінитиКористувачаToolStripMenuItem, завершитиРоботуToolStripMenuItem });
            вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            вихідToolStripMenuItem.Size = new Size(60, 24);
            вихідToolStripMenuItem.Text = "Вихід";
            // 
            // змінитиКористувачаToolStripMenuItem
            // 
            змінитиКористувачаToolStripMenuItem.Name = "змінитиКористувачаToolStripMenuItem";
            змінитиКористувачаToolStripMenuItem.Size = new Size(238, 26);
            змінитиКористувачаToolStripMenuItem.Text = "Змінити користувача";
            змінитиКористувачаToolStripMenuItem.Click += змінитиКористувачаToolStripMenuItem_Click;
            // 
            // завершитиРоботуToolStripMenuItem
            // 
            завершитиРоботуToolStripMenuItem.Name = "завершитиРоботуToolStripMenuItem";
            завершитиРоботуToolStripMenuItem.Size = new Size(238, 26);
            завершитиРоботуToolStripMenuItem.Text = "Завершити роботу";
            завершитиРоботуToolStripMenuItem.Click += завершитиРоботуToolStripMenuItem_Click;
            // 
            // tabControl
            // 
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 28);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 422);
            tabControl.TabIndex = 1;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "Головна форма";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}