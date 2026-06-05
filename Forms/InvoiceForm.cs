using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;
using StoreKeeper.Data.Models.Work;
using StoreKeeper.WinForms.Services;

namespace StoreKeeper.WinForms.Forms
{
    public partial class InvoiceForm : Form
    {
        private WorkDbContext _context;
        private User _currentUser;
        private BindingSource _itemsBindingSource;
        private List<InvoiceItemDto> _items;
        private int _invoiceType;

        public InvoiceForm(WorkDbContext context, User currentUser, int invoiceType)
        {
            InitializeComponent();
            _context = context;
            _currentUser = currentUser;
            _invoiceType = invoiceType;
            _items = new List<InvoiceItemDto>();
            _itemsBindingSource = new BindingSource { DataSource = _items };
            dataGridViewItems.DataSource = _itemsBindingSource;
            Text = invoiceType == 1 ? "Прихідна накладна" : "Видаткова накладна";
            LoadProductsAndDishes();
            ConfigureDataGridView();
            UpdateDeleteButtonState();

            // Налаштування видимості залежно від типу
            if (_invoiceType == 1) // прихід
            {
                labelSupplier.Visible = true;
                textBoxSupplier.Visible = true;
                numericUpDownPrice.Enabled = true;
                labelPrice.Visible = true;
                numericUpDownPrice.Visible = true;
            }
            else // розхід
            {
                labelSupplier.Visible = false;
                textBoxSupplier.Visible = false;
                numericUpDownPrice.Enabled = false;
                numericUpDownPrice.Visible = false;
                labelPrice.Visible = false;
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridViewItems.AutoGenerateColumns = false;
            dataGridViewItems.Columns.Clear();

            dataGridViewItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Товар",
                DataPropertyName = "ProductName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridViewItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Кількість (кг)",
                DataPropertyName = "Quantity",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N3" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });
            dataGridViewItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PricePerKg",
                HeaderText = "Ціна за кг",
                DataPropertyName = "PricePerKg",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });
            dataGridViewItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Сума",
                DataPropertyName = "Total",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });

            dataGridViewItems.AllowUserToAddRows = false;
            dataGridViewItems.AllowUserToDeleteRows = false;
            dataGridViewItems.ReadOnly = true;
            dataGridViewItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadProductsAndDishes()
        {
            var products = _context.Products.OrderBy(p => p.Name).ToList();
            comboBoxProduct.DataSource = products;
            comboBoxProduct.DisplayMember = "Name";
            comboBoxProduct.ValueMember = "Id";

            var dishes = _context.Dishes.OrderBy(d => d.Name).ToList();
            comboBoxDish.DataSource = dishes;
            comboBoxDish.DisplayMember = "Name";
            comboBoxDish.ValueMember = "Id";
        }

        private void RefreshDataGridView()
        {
            _itemsBindingSource.ResetBindings(false);
            UpdateDeleteButtonState();
        }

        private void UpdateDeleteButtonState()
        {
            buttonDeleteItem.Enabled = dataGridViewItems.CurrentRow != null && _items.Count > 0;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedItem == null) return;
            var product = (Product)comboBoxProduct.SelectedItem;
            decimal quantity = numericUpDownQuantity.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Кількість має бути більше нуля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal price;
            if (_invoiceType == 1)
            {
                price = numericUpDownPrice.Value;
                if (price <= 0)
                {
                    MessageBox.Show("Ціна має бути більше нуля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                price = product.PricePerKg;
            }

            var existing = _items.FirstOrDefault(i => i.ProductId == product.Id);
            if (existing != null)
            {
                existing.Quantity += quantity;
                if (_invoiceType == 1)
                    existing.PricePerKg = price;
                existing.Total = existing.Quantity * existing.PricePerKg;
            }
            else
            {
                _items.Add(new InvoiceItemDto
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = quantity,
                    PricePerKg = price,
                    Total = quantity * price
                });
            }
            RefreshDataGridView();
        }

        private void buttonAddFromDish_Click(object sender, EventArgs e)
        {
            if (comboBoxDish.SelectedItem == null) return;
            var dish = (Dish)comboBoxDish.SelectedItem;
            int portions = (int)numericUpDownPortions.Value;
            if (portions <= 0)
            {
                MessageBox.Show("Кількість порцій має бути більше нуля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime currentDate = dateTimePickerDate.Value;
            var ingredients = _context.DishIngredients
                .Include(di => di.Product)
                .Where(di => di.DishId == dish.Id &&
                    (di.StartDate == null || di.StartDate <= currentDate) &&
                    (di.EndDate == null || di.EndDate >= currentDate))
                .ToList();

            if (ingredients.Count == 0)
            {
                MessageBox.Show("Для обраної страви немає активних інгредієнтів на вказану дату.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var ing in ingredients)
            {
                decimal totalGrams = ing.GramsBrutto * portions;
                decimal totalKg = totalGrams / 1000m;
                var product = ing.Product;
                decimal price = (_invoiceType == 1) ? numericUpDownPrice.Value : product.PricePerKg;

                var existing = _items.FirstOrDefault(i => i.ProductId == product.Id);
                if (existing != null)
                {
                    existing.Quantity += totalKg;
                    if (_invoiceType == 1)
                        existing.PricePerKg = price;
                    existing.Total = existing.Quantity * existing.PricePerKg;
                }
                else
                {
                    _items.Add(new InvoiceItemDto
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Quantity = totalKg,
                        PricePerKg = price,
                        Total = totalKg * price
                    });
                }
            }
            RefreshDataGridView();
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewItems.CurrentRow == null)
            {
                MessageBox.Show("Оберіть рядок для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var item = (InvoiceItemDto)dataGridViewItems.CurrentRow.DataBoundItem;
            if (item != null)
            {
                _items.Remove(item);
                RefreshDataGridView();
            }
        }

        private void dataGridViewItems_SelectionChanged(object sender, EventArgs e)
        {
            UpdateDeleteButtonState();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_items.Count == 0)
            {
                MessageBox.Show("Додайте хоча б один товар до накладної", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string number = textBoxNumber.Text.Trim();
            if (string.IsNullOrWhiteSpace(number))
            {
                MessageBox.Show("Введіть номер накладної", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var invoice = new Invoice
            {
                Date = dateTimePickerDate.Value,
                Type = _invoiceType,
                Number = number,
                Comment = textBoxComment.Text,
                UserId = _currentUser.Id
            };
            if (_invoiceType == 1)
                invoice.Supplier = textBoxSupplier.Text.Trim();

            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            foreach (var item in _items)
            {
                var invoiceItem = new InvoiceItem
                {
                    InvoiceId = invoice.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    PricePerKg = item.PricePerKg
                };
                _context.InvoiceItems.Add(invoiceItem);

                var product = _context.Products.Find(item.ProductId);
                if (product != null)
                {
                    if (_invoiceType == 1) // прихід
                    {
                        product.Quantity += item.Quantity;
                        product.PricePerKg = item.PricePerKg; // оновлюємо ціну товару
                    }
                    else // розхід
                    {
                        if (product.Quantity < item.Quantity)
                        {
                            MessageBox.Show($"Недостатньо товару '{product.Name}' на складі. Доступно: {product.Quantity:N3} кг", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _context.Invoices.Remove(invoice);
                            _context.SaveChanges();
                            return;
                        }
                        product.Quantity -= item.Quantity;
                    }
                }
            }
            _context.SaveChanges();

            AuditService.Log(_context, _currentUser.Username, "CreateInvoice",
                $"Створено накладну {(_invoiceType == 1 ? "прихідну" : "видаткову")} №{number} на суму {_items.Sum(i => i.Total):N2} грн",
                invoice.Id,
                null,
                new { Number = number, Date = dateTimePickerDate.Value, ItemsCount = _items.Count, TotalSum = _items.Sum(i => i.Total) }
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    public class InvoiceItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal Total { get; set; }
    }
}