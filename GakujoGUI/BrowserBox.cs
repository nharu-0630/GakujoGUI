using MaterialSkin;
using MaterialSkin.Controls;
using System;

namespace GakujoGUI
{
    public partial class BrowserBox : MaterialForm
    {
        public string inputHtml;

        public BrowserBox()
        {
            InitializeComponent();
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
