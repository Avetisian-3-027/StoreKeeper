using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;
using StoreKeeper.Data.Models.Work;
using StoreKeeper.Data.Permissions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace StoreKeeper.WinForms.Forms
{
    public partial class DishIngredientsForm : Form
    {
        private int _dishId;
        private WorkDbContext _context;
        private User _currentUser;

        public DishIngredientsForm(int dishId, WorkDbContext context, User currentUser)
        {
            InitializeComponent();
            _dishId = dishId;
            _context = context;
            _currentUser = currentUser;
            LoadIngredients();
            ApplyPermissions();
        }

        private void LoadIngredients()
        {
            var ingredients = _context.DishIngredients
                .Include(di => di.Product)
                .Where(di => di.DishId == _dishId)
                .OrderBy(di => di.Product.Name)
                .ToList();

            dataGridViewIngredients.AutoGenerateColumns = false;
            dataGridViewIngredients.Columns.Clear();

            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Продукт",
                DataPropertyName = "Product.Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GramsBrutto",
                HeaderText = "Грами (брутто)",
                DataPropertyName = "GramsBrutto",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N1" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StartDate",
                HeaderText = "Діє з",
                DataPropertyName = "StartDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });
            dataGridViewIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EndDate",
                HeaderText = "Діє до",
                DataPropertyName = "EndDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });

            dataGridViewIngredients.DataSource = ingredients;

            // Прив'язка для колонки ProductName потребує спеціальної обробки, якщо DataPropertyName="Product.Name" не працює,
            // тому краще використати CellFormatting. Додамо обробник.
            dataGridViewIngredients.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                var ing = dataGridViewIngredients.Rows[e.RowIndex].DataBoundItem as DishIngredient;
                if (ing == null) return;
                if (dataGridViewIngredients.Columns[e.ColumnIndex].Name == "ProductName")
                {
                    e.Value = ing.Product?.Name;
                    e.FormattingApplied = true;
                }
            };
        }

        private void ApplyPermissions()
        {
            bool canEdit = _currentUser.HasPermission(AppPermissions.EditDishes);
            buttonAdd.Enabled = canEdit;
            buttonEdit.Enabled = canEdit;
            buttonDelete.Enabled = canEdit;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new DishIngredientEditForm(null, _dishId, _context))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadIngredients();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewIngredients.CurrentRow == null) return;
            var ingredient = (DishIngredient)dataGridViewIngredients.CurrentRow.DataBoundItem;
            using (var editForm = new DishIngredientEditForm(ingredient, _dishId, _context))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadIngredients();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewIngredients.CurrentRow == null) return;
            var ingredient = (DishIngredient)dataGridViewIngredients.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Видалити інгредієнт '{ingredient.Product?.Name}'?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _context.DishIngredients.Remove(ingredient);
                _context.SaveChanges();
                LoadIngredients();
            }
        }
    }
}