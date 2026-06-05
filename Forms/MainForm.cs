using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;
using StoreKeeper.Data.Models.Work;
using StoreKeeper.Data.Permissions;
using StoreKeeper.WinForms.Reports;

namespace StoreKeeper.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        private AppDbContext _authContext;
        private WorkDbContext _workContext;

        public MainForm(User user, AppDbContext authContext, string workConnectionString)
        {
            _currentUser = user;
            _authContext = authContext;
            InitializeComponent();
            ConfigureMenuByPermissions();
            Text = $"Складська програма - {_currentUser.Username}";

            if (!string.IsNullOrEmpty(workConnectionString))
            {
                try
                {
                    var options = new DbContextOptionsBuilder<WorkDbContext>()
                        .UseSqlite(workConnectionString)
                        .Options;
                    _workContext = new WorkDbContext(options);
                    _workContext.Database.EnsureCreated();
                    InitializeDefaultCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка ініціалізації робочої БД:\n{ex.Message}",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BlockWorkFeatures();
                }
            }
            else
            {
                BlockWorkFeatures();
            }
        }

        private void InitializeDefaultCategories()
        {
            if (!_workContext.Categories.Any())
            {
                _workContext.Categories.AddRange(
                    new Category { Name = "Овочі" },
                    new Category { Name = "Фрукти" },
                    new Category { Name = "М'ясо" },
                    new Category { Name = "Риба" },
                    new Category { Name = "Крупи" },
                    new Category { Name = "Молочні продукти" },
                    new Category { Name = "Інше" }
                );
                _workContext.SaveChanges();
            }
        }

        private void ConfigureMenuByPermissions()
        {
            адмініструванняToolStripMenuItem.Visible = _currentUser.HasPermission(AppPermissions.ManageUsers);
            журналToolStripMenuItem.Visible = _currentUser.HasPermission(AppPermissions.ViewLogs);
        }

        private void BlockWorkFeatures()
        {
            довідникиToolStripMenuItem.Enabled = false;
            складToolStripMenuItem.Enabled = false;
            звітиToolStripMenuItem.Enabled = false;
        }

        private void OpenFormInTab(Form form, string tabTitle, string key)
        {
            foreach (TabPage page in tabControl.TabPages)
            {
                if (page.Tag as string == key)
                {
                    tabControl.SelectedTab = page;
                    return;
                }
            }

            var tabPage = new TabPage(tabTitle);
            tabPage.Tag = key;

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Visible = true;

            tabPage.Controls.Add(form);
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;
        }

        private void CloseCurrentTab()
        {
            if (tabControl.TabCount == 0) return;
            TabPage currentTab = tabControl.SelectedTab;
            if (currentTab != null)
            {
                foreach (Control ctrl in currentTab.Controls)
                {
                    if (ctrl is Form f)
                    {
                        f.Close();
                        break;
                    }
                }
                tabControl.TabPages.Remove(currentTab);
                currentTab.Dispose();
            }
        }

        private void UpdateTabsMenuVisibility()
        {
            вкладкиToolStripMenuItem.Visible = tabControl.TabCount > 0;
        }

        private void товариToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_workContext == null)
            {
                MessageBox.Show("Робоча база даних не доступна.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_currentUser.HasPermission(AppPermissions.ViewProducts))
            {
                var productsForm = new ProductsForm(_workContext, _currentUser);
                OpenFormInTab(productsForm, "Товари", "Products");
                UpdateTabsMenuVisibility();
            }
            else
            {
                MessageBox.Show("У вас немає прав на перегляд товарів.", "Доступ заборонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void стравиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_workContext == null)
            {
                MessageBox.Show("Робоча база даних не доступна.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_currentUser.HasPermission(AppPermissions.ViewDishes))
            {
                var dishesForm = new DishesForm(_workContext, _currentUser);
                dishesForm.SetParentMainForm(this);
                OpenFormInTab(dishesForm, "Страви", "Dishes");
                UpdateTabsMenuVisibility();
            }
            else
            {
                MessageBox.Show("У вас немає прав на перегляд страв.", "Доступ заборонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void OpenIngredientsInTab(int dishId, string dishName)
        {
            if (_workContext == null)
            {
                MessageBox.Show("Робоча база даних не доступна.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var ingredientsForm = new DishIngredientsForm(dishId, _workContext, _currentUser);
            OpenFormInTab(ingredientsForm, $"Інгредієнти: {dishName}", $"Ingredients_{dishId}");
            UpdateTabsMenuVisibility();
        }

        private void прихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_workContext == null)
            {
                MessageBox.Show("Робоча база даних не доступна.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_currentUser.HasPermission(AppPermissions.CreateInvoices))
            {
                var invoiceForm = new InvoiceForm(_workContext, _currentUser, 1);
                invoiceForm.ShowDialog(this);
                RefreshProductsTab();
            }
            else
            {
                MessageBox.Show("У вас немає прав на створення накладних.", "Доступ заборонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void розхідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_workContext == null)
            {
                MessageBox.Show("Робоча база даних не доступна.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_currentUser.HasPermission(AppPermissions.CreateInvoices))
            {
                var invoiceForm = new InvoiceForm(_workContext, _currentUser, 2);
                invoiceForm.ShowDialog(this);
                RefreshProductsTab();
            }
            else
            {
                MessageBox.Show("У вас немає прав на створення накладних.", "Доступ заборонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshProductsTab()
        {
            foreach (TabPage page in tabControl.TabPages)
            {
                if (page.Tag as string == "Products")
                {
                    var productsForm = page.Controls[0] as ProductsForm;
                    productsForm?.RefreshData();
                    break;
                }
            }
        }

        private void залишкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_workContext == null)
            {
                MessageBox.Show("Робоча база даних не доступна.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var products = _workContext.Products.Include(p => p.Category).ToList();
            var saveDialog = new SaveFileDialog
            {
                Filter = "DOCX files (*.docx)|*.docx",
                FileName = $"StockReport_{DateTime.Now:yyyyMMdd_HHmmss}.docx"
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                DocxHelper.GenerateStockReportDocx(products, saveDialog.FileName);
                try
                {
                    var psi = new System.Diagnostics.ProcessStartInfo(saveDialog.FileName)
                    {
                        UseShellExecute = true
                    };
                    System.Diagnostics.Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Файл збережено, але не вдалося відкрити: {ex.Message}\nШлях: {saveDialog.FileName}",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void журналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_workContext == null)
            {
                MessageBox.Show("Робоча база даних не доступна.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_currentUser.HasPermission(AppPermissions.ViewLogs))
            {
                var auditForm = new AuditLogForm(_workContext);
                OpenFormInTab(auditForm, "Журнал подій", "AuditLog");
                UpdateTabsMenuVisibility();
            }
            else
            {
                MessageBox.Show("У вас немає прав на перегляд журналу подій.", "Доступ заборонено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void користувачіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageUsersForm = new ManageUsersForm(_authContext, _currentUser);
            OpenFormInTab(manageUsersForm, "Керування користувачами", "ManageUsers");
            UpdateTabsMenuVisibility();
        }

        private void базиДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageDatabasesForm = new ManageDatabasesForm(_authContext);
            OpenFormInTab(manageDatabasesForm, "Бази даних", "ManageDatabases");
            UpdateTabsMenuVisibility();
        }

        private void закритиПоточнуВкладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseCurrentTab();
            UpdateTabsMenuVisibility();
        }

        private void змінитиКористувачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void завершитиРоботуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTabsMenuVisibility();
        }
    }
}