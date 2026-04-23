using System;
using System.Windows.Forms;

namespace NorthSussexJudo
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
        }

        private void Register_Click(object sender, EventArgs e)
        {
            new RegistrationForm().ShowDialog();
        }
    }
}
