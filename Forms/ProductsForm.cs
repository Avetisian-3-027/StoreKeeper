using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;
using StoreKeeper.Data.Models.Work;
using StoreKeeper.Data.Permissions;
using StoreKeeper.WinForms.Services;

namespace StoreKeeper.WinForms.Forms
{
    public partial class ProductsForm : Form
    {
        private WorkDbContext _context;
        private User _currentUser;

        public ProductsForm(WorkDbContext context, User currentUser)
        {
            InitializeComponent();
            _context = context;
            _currentUser = currentUser;
            LoadProducts();
            ApplyPermissions();
        }

        private void LoadProducts()
        {
            var products = _context.Products.Include(p => p.Category).OrderBy(p => p.Name).ToList();
            dataGridViewProducts.AutoGenerateColumns = false;
            dataGridViewProducts.Columns.Clear();

            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Назва товару",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Категорія",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Кількість (кг)",
                DataPropertyName = "Quantity",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N3" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PricePerKg",
                HeaderText = "Ціна за кг (грн)",
                DataPropertyName = "PricePerKg",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalValue",
                HeaderText = "Вартість (грн)",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });

            dataGridViewProducts.DataSource = products;
            dataGridViewProducts.CellFormatting += DataGridViewProducts_CellFormatting;
        }
        public void RefreshData()
        {
            LoadProducts();
        }
        private void DataGridViewProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var product = dataGridViewProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (product == null) return;

            if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "Category")
            {
                e.Value = product.Category?.Name ?? "Без категорії";
                e.FormattingApplied = true;
            }
            else if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "TotalValue")
            {
                e.Value = (product.Quantity * product.PricePerKg).ToString("N2");
                e.FormattingApplied = true;
            }
        }

        private void ApplyPermissions()
        {
            buttonAdd.Enabled = _currentUser.HasPermission(AppPermissions.EditProducts);
            buttonEdit.Enabled = _currentUser.HasPermission(AppPermissions.EditProducts);
            buttonDelete.Enabled = _currentUser.HasPermission(AppPermissions.DeleteProducts);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!_currentUser.HasPermission(AppPermissions.EditProducts)) return;
            using (var editForm = new ProductEditForm(null, _context))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!_currentUser.HasPermission(AppPermissions.EditProducts)) return;
            if (dataGridViewProducts.CurrentRow == null) return;
            var product = (Product)dataGridViewProducts.CurrentRow.DataBoundItem;
            using (var editForm = new ProductEditForm(product, _context))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null) return;
            var product = (Product)dataGridViewProducts.CurrentRow.DataBoundItem;
            if (product.Quantity != 0)
            {
                MessageBox.Show("Неможливо видалити товар, оскільки на складі є його залишки. Спочатку списайте їх через видаткову накладну.",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Видалити товар '{product.Name}'?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                AuditService.Log(_context, _currentUser.Username, "DeleteProduct", $"Видалено товар: {product.Name}");
                LoadProducts();
            }
        }
    }
}