
namespace GakujoGUI
{
    partial class SyllabusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyllabusForm));
            this.webView2Main = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webView2Sub = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webView2Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2Sub)).BeginInit();
            this.SuspendLayout();
            // 
            // webView2Main
            // 
            this.webView2Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView2Main.CreationProperties = null;
            this.webView2Main.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2Main.Location = new System.Drawing.Point(3, 3);
            this.webView2Main.Name = "webView2Main";
            this.webView2Main.Size = new System.Drawing.Size(380, 356);
            this.webView2Main.Source = new System.Uri("https://syllabus.shizuoka.ac.jp/ext_syllabus/syllabusSearchDirect.do?nologin=on", System.UriKind.Absolute);
            this.webView2Main.TabIndex = 1;
            this.webView2Main.ZoomFactor = 1D;
            this.webView2Main.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webView2Main_NavigationCompleted);
            this.webView2Main.WebMessageReceived += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs>(this.webView2Main_WebMessageReceived);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 76);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.webView2Main);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webView2Sub);
            this.splitContainer1.Size = new System.Drawing.Size(776, 362);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 2;
            // 
            // webView2Sub
            // 
            this.webView2Sub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView2Sub.CreationProperties = null;
            this.webView2Sub.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2Sub.Location = new System.Drawing.Point(3, 3);
            this.webView2Sub.Name = "webView2Sub";
            this.webView2Sub.Size = new System.Drawing.Size(380, 356);
            this.webView2Sub.TabIndex = 2;
            this.webView2Sub.ZoomFactor = 1D;
            // 
            // SyllabusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "SyllabusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GakujoGUI";
            this.Load += new System.EventHandler(this.SyllabusForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView2Main)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView2Sub)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2Main;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2Sub;
    }
}