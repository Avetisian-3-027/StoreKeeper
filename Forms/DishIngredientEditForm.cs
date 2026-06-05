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
        private List<Product> _allProducts;

        public DishIngredientEditForm(DishIngredient? ingredient, int dishId, WorkDbContext context)
        {
            InitializeComponent();
            _context = context;
            _dishId = dishId;
            _isNew = (ingredient == null);
            if (_isNew)
            {
                _ingredient = new DishIngredient { DishId = _dishId };
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
            _allProducts = _context.Products.OrderBy(p => p.Name).ToList();
            comboBoxProduct.DataSource = _allProducts;
            comboBoxProduct.DisplayMember = "Name";
            comboBoxProduct.ValueMember = "Id";
            comboBoxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadData()
        {
            if (!_isNew)
                comboBoxProduct.SelectedValue = _ingredient.ProductId;

            decimal grams = (decimal)_ingredient.GramsBrutto;
            if (grams < numericUpDownGrams.Minimum) grams = numericUpDownGrams.Minimum;
            if (grams > numericUpDownGrams.Maximum) grams = numericUpDownGrams.Maximum;
            numericUpDownGrams.Value = grams;

            bool hasPeriod = _ingredient.StartDate.HasValue && _ingredient.EndDate.HasValue;
            checkBoxPeriod.Checked = hasPeriod;
            if (hasPeriod)
            {
                // Встановлюємо фіксований рік 2000 для відображення
                dateTimePickerStart.Value = new DateTime(2000, _ingredient.StartDate.Value.Month, _ingredient.StartDate.Value.Day);
                dateTimePickerEnd.Value = new DateTime(2000, _ingredient.EndDate.Value.Month, _ingredient.EndDate.Value.Day);
            }
            UpdatePeriodVisibility();
        }

        private void checkBoxPeriod_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePeriodVisibility();
        }

        private void UpdatePeriodVisibility()
        {
            bool visible = checkBoxPeriod.Checked;
            dateTimePickerStart.Visible = visible;
            dateTimePickerEnd.Visible = visible;
            labelFrom.Visible = visible;
            labelTo.Visible = visible;
        }

        private bool CheckOverlap(DateTime start, DateTime end, int? excludeId = null)
        {
            // Фіксуємо рік 2000 для порівняння
            var newStart = new DateTime(2000, start.Month, start.Day);
            var newEnd = new DateTime(2000, end.Month, end.Day);
            if (newStart > newEnd) // період через Новий рік
            {
                // розбиваємо на два: newStart..31.12 та 01.01..newEnd
                var end1 = new DateTime(2000, 12, 31);
                var start2 = new DateTime(2000, 1, 1);
                return CheckOverlap(newStart, end1, excludeId) || CheckOverlap(start2, newEnd, excludeId);
            }
            // Отримуємо всі інгредієнти для цього продукту та страви, крім поточного
            var query = _context.DishIngredients
                .Where(di => di.DishId == _dishId && di.ProductId == (int)comboBoxProduct.SelectedValue);
            if (excludeId.HasValue)
                query = query.Where(di => di.Id != excludeId.Value);
            var existing = query.ToList();
            foreach (var ing in existing)
            {
                if (!ing.StartDate.HasValue || !ing.EndDate.HasValue)
                {
                    // Глобальний інгредієнт конфліктує з будь-яким періодом
                    MessageBox.Show("Для цього продукту вже існує глобальний інгредієнт (без періоду). Неможливо додати періодичний.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
                var ingStart = new DateTime(2000, ing.StartDate.Value.Month, ing.StartDate.Value.Day);
                var ingEnd = new DateTime(2000, ing.EndDate.Value.Month, ing.EndDate.Value.Day);
                if (ingStart > ingEnd) // період через Новий рік
                {
                    // Перевіряємо перетин з двома інтервалами
                    if (CheckIntervalOverlap(newStart, newEnd, ingStart, new DateTime(2000, 12, 31)) ||
                        CheckIntervalOverlap(newStart, newEnd, new DateTime(2000, 1, 1), ingEnd))
                        return true;
                }
                else
                {
                    if (CheckIntervalOverlap(newStart, newEnd, ingStart, ingEnd))
                        return true;
                }
            }
            return false;
        }

        private bool CheckIntervalOverlap(DateTime a1, DateTime a2, DateTime b1, DateTime b2)
        {
            return a1 <= b2 && a2 >= b1;
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

            if (checkBoxPeriod.Checked)
            {
                DateTime start = dateTimePickerStart.Value;
                DateTime end = dateTimePickerEnd.Value;
                if (start > end)
                {
                    MessageBox.Show("Дата початку не може бути пізнішою за дату закінчення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Фіксуємо рік 2000 для зберігання
                _ingredient.StartDate = new DateTime(2000, start.Month, start.Day);
                _ingredient.EndDate = new DateTime(2000, end.Month, end.Day);
                // Перевіряємо перетин з іншими інгредієнтами
                if (CheckOverlap(start, end, _isNew ? null : _ingredient.Id))
                {
                    MessageBox.Show("Цей період перетинається з вже існуючим періодом для того ж продукту. Оберіть інші дати.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                _ingredient.StartDate = null;
                _ingredient.EndDate = null;
                // Перевіряємо, чи вже існує глобальний для цього продукту
                var globalExists = _context.DishIngredients
                    .Any(di => di.DishId == _dishId && di.ProductId == _ingredient.ProductId && di.Id != _ingredient.Id &&
                               !di.StartDate.HasValue && !di.EndDate.HasValue);
                if (globalExists)
                {
                    MessageBox.Show("Для цього продукту вже існує глобальний інгредієнт.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

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