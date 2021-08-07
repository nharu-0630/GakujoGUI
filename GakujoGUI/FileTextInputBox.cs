using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace GakujoGUI
{
    public partial class FileTextInputBox : MaterialForm
    {
        public string inputText;
        public string inputFile;

        public FileTextInputBox()
        {
            InitializeComponent();
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
