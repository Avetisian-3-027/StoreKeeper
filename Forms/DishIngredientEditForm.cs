using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models.Work;
using System;
using System.Linq;
using System.Windows.Forms;

namespace StoreKeeper.WinForms.Forms
{
    public partial class DishIngredientEditForm : Form
    {
        private DishIngredient _ingredient;
        private int _dishId;
        private WorkDbContext _context;
        private bool _isNew;

        public DishIngredientEditForm(DishIngredient? ingredient, int dishId, WorkDbContext context)
        {
            InitializeComponent();
            _context = context;
            _dishId = dishId;
            _isNew = (ingredient == null);
            if (_isNew)
            {
                _ingredient = new DishIngredient { DishId = _dishId, GramsBrutto = 1.0m }; // Початкове значення 1 грам
                Text = "Новий інгредієнт";
            }
            else
            {
                _ingredient = ingredient;
                Text = "Редагування інгредієнта";
            }
            LoadProducts();
            LoadData();
        }

        private void LoadProducts()
        {
            var products = _context.Products.OrderBy(p => p.Name).ToList();
            comboBoxProduct.DataSource = products;
            comboBoxProduct.DisplayMember = "Name";
            comboBoxProduct.ValueMember = "Id";
        }

        private void LoadData()
        {
            if (!_isNew)
                comboBoxProduct.SelectedValue = _ingredient.ProductId;
            // Встановлюємо значення NumericUpDown, переконуючись, що воно в межах [Minimum, Maximum]
            decimal grams = _ingredient.GramsBrutto;
            if (grams < numericUpDownGrams.Minimum) grams = numericUpDownGrams.Minimum;
            if (grams > numericUpDownGrams.Maximum) grams = numericUpDownGrams.Maximum;
            numericUpDownGrams.Value = grams;

            if (_ingredient.StartDate.HasValue)
            {
                checkBoxStartDate.Checked = true;
                dateTimePickerStart.Value = _ingredient.StartDate.Value;
            }
            else
            {
                checkBoxStartDate.Checked = false;
                dateTimePickerStart.Value = DateTime.Today;
            }

            if (_ingredient.EndDate.HasValue)
            {
                checkBoxEndDate.Checked = true;
                dateTimePickerEnd.Value = _ingredient.EndDate.Value;
            }
            else
            {
                checkBoxEndDate.Checked = false;
                dateTimePickerEnd.Value = DateTime.Today.AddYears(10);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Оберіть продукт", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ingredient.ProductId = (int)comboBoxProduct.SelectedValue;
            _ingredient.GramsBrutto = numericUpDownGrams.Value;
            _ingredient.StartDate = checkBoxStartDate.Checked ? dateTimePickerStart.Value.Date : (DateTime?)null;
            _ingredient.EndDate = checkBoxEndDate.Checked ? dateTimePickerEnd.Value.Date : (DateTime?)null;

            if (_isNew)
                _context.DishIngredients.Add(_ingredient);
            _context.SaveChanges();
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