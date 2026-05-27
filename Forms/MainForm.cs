using System;
using System.Windows.Forms;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models;

namespace StoreKeeper.WinForms.Forms
{
    public partial class MainForm : Form
    {
        private User _currentUser;
        private AppDbContext _context;

        public MainForm(User user, AppDbContext context)
        {
            _currentUser = user;
            _context = context;
            InitializeComponent();
            ConfigureUIByPermissions();
        }

        private void ConfigureUIByPermissions()
        {
            Text = $"Складська програма - {_currentUser.Username}";
            // Тут потім додасте кнопки та приховаєте їх згідно прав
        }
    }
}