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
    public partial class BrowserBox : MaterialForm
    {
        public string inputHtml;

        public BrowserBox()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.Blue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);
        }

        public void SetUrl(string message, string url)
        {
            Text = message;
            webView2.Source = new Uri(url);
        }

        public void SetHtml(string message, string html)
        {
            Text = message;
            inputHtml = html;
        }

        private async void BrowserBox_Load(object sender, EventArgs e)
        {
            if (inputHtml != null)
            {
                await webView2.EnsureCoreWebView2Async();
                webView2.NavigateToString(inputHtml);
            }
        }
    }
}
