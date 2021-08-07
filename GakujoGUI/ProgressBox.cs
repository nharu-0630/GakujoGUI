using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace GakujoGUI
{
    public partial class ProgressBox : MaterialForm
    {
        public ProgressBox()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.Blue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);
        }

        public void Set(string message, string caption)
        {
            Text = message;
            //label.Text = caption;
        }

        public void Update(double progress)
        {
            progressBar.Value = Convert.ToInt32(progress);
        }

        private void ProgressBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

    }
}
