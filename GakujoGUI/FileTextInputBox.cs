using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;

namespace GakujoGUI
{
    public partial class FileTextInputBox : MaterialForm
    {
        public string inputText;
        public string inputFile;

        public FileTextInputBox()
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
            label.Text = caption;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            inputText = textBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            inputText = textBox.Text;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonFile_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }
            inputFile = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            buttonFile.Text = inputFile;
        }

        private void buttonFile_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
