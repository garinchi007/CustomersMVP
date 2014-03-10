using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Settings_btn_Click(object sender, EventArgs e)
        {
            using (SettingsForm forma = new SettingsForm())
            {
                forma.ShowDialog();
            }
        }
    }
}
