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
