using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace GakujoGUI
{
    public partial class QuizForm : MaterialForm
    {
        public string inputHtml;
        public string outputText;

        public QuizForm()
        {
            InitializeComponent();
        }

        public void Set(string message, string html)
        {
            Text = message;
            inputHtml = html;
        }

        private async void QuizForm_Load(object sender, EventArgs e)
        {
            await webView2.EnsureCoreWebView2Async();
            webView2.NavigateToString(inputHtml);
        }

        private void webView2_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            outputText = e.TryGetWebMessageAsString();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
