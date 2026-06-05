using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StoreKeeper.Data.Models.Work;
using StoreKeeper.Data.Models;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Permissions;

namespace StoreKeeper.WinForms.Forms
{
    public partial class DishesForm : Form
    {
        private WorkDbContext _context;
        private User _currentUser;

        public DishesForm(WorkDbContext context, User currentUser)
        {
            InitializeComponent();
            _context = context;
            _currentUser = currentUser;
            LoadDishes();
            ApplyPermissions();
        }

        private MainForm _parentMainForm;

        public void SetParentMainForm(MainForm parent)
        {
            _parentMainForm = parent;
        }
        private void LoadDishes()
        {
            var dishes = _context.Dishes.OrderBy(d => d.TechMapNumber).ToList();
            dataGridViewDishes.AutoGenerateColumns = false;
            dataGridViewDishes.Columns.Clear();

            dataGridViewDishes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });
            dataGridViewDishes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TechMapNumber",
                HeaderText = "№ тех.карти",
                DataPropertyName = "TechMapNumber",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });
            dataGridViewDishes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Назва страви",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            dataGridViewDishes.DataSource = dishes;
        }

        private void ApplyPermissions()
        {
            buttonAdd.Enabled = _currentUser.HasPermission(AppPermissions.EditDishes);
            buttonEdit.Enabled = _currentUser.HasPermission(AppPermissions.EditDishes);
            buttonDelete.Enabled = _currentUser.HasPermission(AppPermissions.DeleteDishes);
            buttonIngredients.Enabled = dataGridViewDishes.CurrentRow != null;
        }

        private void dataGridViewDishes_SelectionChanged(object sender, EventArgs e)
        {
            buttonIngredients.Enabled = dataGridViewDishes.CurrentRow != null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!_currentUser.HasPermission(AppPermissions.EditDishes)) return;
            using (var editForm = new DishEditForm(null, _context))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadDishes();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!_currentUser.HasPermission(AppPermissions.EditDishes)) return;
            if (dataGridViewDishes.CurrentRow == null) return;
            var dish = (Dish)dataGridViewDishes.CurrentRow.DataBoundItem;
            using (var editForm = new DishEditForm(dish, _context))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadDishes();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!_currentUser.HasPermission(AppPermissions.DeleteDishes)) return;
            if (dataGridViewDishes.CurrentRow == null) return;
            var dish = (Dish)dataGridViewDishes.CurrentRow.DataBoundItem;
            bool hasIngredients = _context.DishIngredients.Any(di => di.DishId == dish.Id);
            if (hasIngredients)
            {
                MessageBox.Show("Неможливо видалити страву, оскільки вона має інгредієнти. Спочатку видаліть інгредієнти.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Видалити страву '{dish.Name}'?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _context.Dishes.Remove(dish);
                _context.SaveChanges();
                LoadDishes();
            }
        }

        private void buttonIngredients_Click(object sender, EventArgs e)
        {
            if (dataGridViewDishes.CurrentRow == null) return;
            var dish = (Dish)dataGridViewDishes.CurrentRow.DataBoundItem;
            if (_parentMainForm != null)
            {
                _parentMainForm.OpenIngredientsInTab(dish.Id, dish.Name);
            }
            else
            {
                // fallback: старий модальний варіант
                using (var ingredientsForm = new DishIngredientsForm(dish.Id, _context, _currentUser))
                {
                    ingredientsForm.ShowDialog();
                }
            }
        }
    }
}