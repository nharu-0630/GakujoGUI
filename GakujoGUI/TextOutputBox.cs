﻿using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace GakujoGUI
{
    public partial class TextOutputBox : MaterialForm
    {
        public TextOutputBox()
        {
            InitializeComponent();
        }

        public void Set(string message, string caption, MessageBoxButtons messageBoxButtons)
        {
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
