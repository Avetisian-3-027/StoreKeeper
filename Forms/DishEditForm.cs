using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models.Work;
using System;
using System.Windows.Forms;

namespace StoreKeeper.WinForms.Forms
{
    public partial class DishEditForm : Form
    {
        private Dish _dish;
        private WorkDbContext _context;
        private bool _isNew;

        public DishEditForm(Dish? dish, WorkDbContext context)
        {
            InitializeComponent();
            _context = context;
            _isNew = (dish == null);
            if (_isNew)
            {
                _dish = new Dish();
                Text = "Нова страва";
            }
            else
            {
                _dish = dish;
                Text = $"Редагування: {_dish.Name}";
            }
            LoadData();
        }

        private void LoadData()
        {
            textBoxTechMapNumber.Text = _dish.TechMapNumber;
            textBoxName.Text = _dish.Name;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string techNumber = textBoxTechMapNumber.Text.Trim();
            if (string.IsNullOrWhiteSpace(techNumber))
            {
                MessageBox.Show("Введіть номер технологічної карти", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name = textBoxName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введіть назву страви", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _dish.TechMapNumber = techNumber;
            _dish.Name = name;
            if (_isNew)
                _context.Dishes.Add(_dish);
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