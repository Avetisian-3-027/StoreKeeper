using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models.Work;
using StoreKeeper.WinForms.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace StoreKeeper.WinForms.Forms
{
    public partial class ProductEditForm : Form
    {
        private Product _product;
        private WorkDbContext _context;
        private bool _isNew;

        public ProductEditForm(Product? product, WorkDbContext context)
        {
            InitializeComponent();
            _context = context;
            _isNew = (product == null);
            if (_isNew)
            {
                _product = new Product { Quantity = 0, PricePerKg = 0 };
                Text = "Новий товар";
            }
            else
            {
                _product = product;
                Text = $"Редагування: {_product.Name}";
            }
            LoadCategories();
            LoadData();
        }

        private void LoadCategories()
        {
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();
            comboBoxCategory.DataSource = categories;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";
        }

        private void LoadData()
        {
            textBoxName.Text = _product.Name;
            if (_product.CategoryId != 0)
                comboBoxCategory.SelectedValue = _product.CategoryId;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введіть назву товару", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _product.Name = name;
            if (comboBoxCategory.SelectedValue != null)
                _product.CategoryId = (int)comboBoxCategory.SelectedValue;
            // Quantity і PricePerKg не змінюються!

            if (_isNew)
                _context.Products.Add(_product);
            _context.SaveChanges();

            AuditService.Log(_context, "Система", _isNew ? "CreateProduct" : "EditProduct",
                $"{(_isNew ? "Створено" : "Редаговано")} товар: {_product.Name}");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}