﻿using MaterialSkin;
using MaterialSkin.Controls;
using System;

namespace GakujoGUI
{
    public partial class SyllabusForm : MaterialForm
    {
        public SyllabusForm()
        {
            InitializeComponent();
        }

        private void webView2Main_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            webView2Main.ExecuteScriptAsync("dbLinkClick = function(url){ window.chrome.webview.postMessage(url); }");
        }

        private void webView2Main_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            webView2Sub.Source = new Uri("https://syllabus.shizuoka.ac.jp/" + e.TryGetWebMessageAsString());
        }

        private async void SyllabusForm_Load(object sender, EventArgs e)
        {
            await webView2Main.EnsureCoreWebView2Async();
            await webView2Sub.EnsureCoreWebView2Async();
        }
    }
}
