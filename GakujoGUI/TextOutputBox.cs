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
    public partial class TextOutputBox : MaterialForm
    {
        public TextOutputBox()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.Blue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);
        }

        public DialogResult Set(string message, string caption, MessageBoxButtons messageBoxButtons)
        {
            DialogResult dialogResult = DialogResult.None;
            Text = message;
            label.Text = caption;
            switch (messageBoxButtons)
            {
                case MessageBoxButtons.YesNo:
                    buttonYes.Visible = true;
                    buttonNo.Visible = true;
                    AcceptButton = buttonYes;
                    CancelButton = buttonNo;
                    break;
                case MessageBoxButtons.OK:
                    buttonOk.Visible = true;
                    AcceptButton = buttonOk;
                    break;
            }
            return dialogResult;
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
