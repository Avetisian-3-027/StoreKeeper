using System.Windows.Forms;

namespace StoreKeeper.WinForms.Forms
{
    public partial class AddDatabaseDialog : Form
    {
        public bool IsNewDatabase { get; private set; }

        public AddDatabaseDialog()
        {
            InitializeComponent();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            IsNewDatabase = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonExisting_Click(object sender, EventArgs e)
        {
            IsNewDatabase = false;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}