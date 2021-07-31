
namespace GakujoGUI
{
    partial class MainFrom
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.materialTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.checkBoxAutoLogin = new MaterialSkin.Controls.MaterialCheckBox();
            this.buttonTwitter = new MaterialSkin.Controls.MaterialFlatButton();
            this.buttonLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.textBoxPassWord = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxUserId = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tabPageClassContact = new System.Windows.Forms.TabPage();
            this.splitContainerClassContact = new System.Windows.Forms.SplitContainer();
            this.textBoxClassContactDetail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxClassContactLimit = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.checkBoxClassContactFileDownload = new MaterialSkin.Controls.MaterialCheckBox();
            this.buttonRefreshClassContact = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listViewClassContact = new MaterialSkin.Controls.MaterialListView();
            this.columnEmpty0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnClassSubjects0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnContent0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnContactTime0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonFile = new MaterialSkin.Controls.MaterialFlatButton();
            this.labelClassContactTitle = new System.Windows.Forms.Label();
            this.labelClassContactContent = new System.Windows.Forms.TextBox();
            this.tabPageReport = new System.Windows.Forms.TabPage();
            this.buttonRefreshReport = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listViewReport = new MaterialSkin.Controls.MaterialListView();
            this.columnEmpty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnClassSubjects1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSubmissionPeriod1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastSubmissionTime1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOperation1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageQuiz = new System.Windows.Forms.TabPage();
            this.checkBoxAllVisible = new MaterialSkin.Controls.MaterialCheckBox();
            this.buttonRefreshQuiz = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listViewQuiz = new MaterialSkin.Controls.MaterialListView();
            this.columnEmpty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVisible2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnClassSubjects2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSubmissionPeriod2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSubmissionStatus2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOperation2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialTabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.textBoxStudentName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxStudentCode = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialTabControl.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.tabPageClassContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClassContact)).BeginInit();
            this.splitContainerClassContact.Panel1.SuspendLayout();
            this.splitContainerClassContact.Panel2.SuspendLayout();
            this.splitContainerClassContact.SuspendLayout();
            this.tabPageReport.SuspendLayout();
            this.tabPageQuiz.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl
            // 
            this.materialTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabControl.Controls.Add(this.tabPageLogin);
            this.materialTabControl.Controls.Add(this.tabPageClassContact);
            this.materialTabControl.Controls.Add(this.tabPageReport);
            this.materialTabControl.Controls.Add(this.tabPageQuiz);
            this.materialTabControl.Depth = 0;
            this.materialTabControl.Location = new System.Drawing.Point(12, 93);
            this.materialTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl.Name = "materialTabControl";
            this.materialTabControl.SelectedIndex = 0;
            this.materialTabControl.Size = new System.Drawing.Size(776, 345);
            this.materialTabControl.TabIndex = 5;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.BackColor = System.Drawing.Color.White;
            this.tabPageLogin.Controls.Add(this.textBoxStudentCode);
            this.tabPageLogin.Controls.Add(this.textBoxStudentName);
            this.tabPageLogin.Controls.Add(this.webView21);
            this.tabPageLogin.Controls.Add(this.checkBoxAutoLogin);
            this.tabPageLogin.Controls.Add(this.buttonTwitter);
            this.tabPageLogin.Controls.Add(this.buttonLogin);
            this.tabPageLogin.Controls.Add(this.textBoxPassWord);
            this.tabPageLogin.Controls.Add(this.textBoxUserId);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Size = new System.Drawing.Size(768, 319);
            this.tabPageLogin.TabIndex = 4;
            this.tabPageLogin.Text = "ログイン";
            // 
            // webView21
            // 
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(259, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(509, 319);
            this.webView21.Source = new System.Uri("https://gakujo.shizuoka.ac.jp/UI/jsp/topPage/topPage.jsp", System.UriKind.Absolute);
            this.webView21.TabIndex = 6;
            this.webView21.ZoomFactor = 1D;
            // 
            // checkBoxAutoLogin
            // 
            this.checkBoxAutoLogin.AutoSize = true;
            this.checkBoxAutoLogin.Depth = 0;
            this.checkBoxAutoLogin.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkBoxAutoLogin.Location = new System.Drawing.Point(79, 122);
            this.checkBoxAutoLogin.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAutoLogin.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxAutoLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            this.checkBoxAutoLogin.Ripple = true;
            this.checkBoxAutoLogin.Size = new System.Drawing.Size(105, 30);
            this.checkBoxAutoLogin.TabIndex = 5;
            this.checkBoxAutoLogin.Text = "自動ログイン";
            this.checkBoxAutoLogin.UseVisualStyleBackColor = true;
            // 
            // buttonTwitter
            // 
            this.buttonTwitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTwitter.AutoSize = true;
            this.buttonTwitter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonTwitter.Depth = 0;
            this.buttonTwitter.Icon = null;
            this.buttonTwitter.Location = new System.Drawing.Point(4, 277);
            this.buttonTwitter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonTwitter.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonTwitter.Name = "buttonTwitter";
            this.buttonTwitter.Primary = false;
            this.buttonTwitter.Size = new System.Drawing.Size(92, 36);
            this.buttonTwitter.TabIndex = 4;
            this.buttonTwitter.Text = "@xyzyxjp";
            this.buttonTwitter.UseVisualStyleBackColor = true;
            this.buttonTwitter.Click += new System.EventHandler(this.buttonTwitter_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.AutoSize = true;
            this.buttonLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonLogin.Depth = 0;
            this.buttonLogin.Icon = null;
            this.buttonLogin.Location = new System.Drawing.Point(187, 119);
            this.buttonLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Primary = true;
            this.buttonLogin.Size = new System.Drawing.Size(66, 36);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "ログイン";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPassWord
            // 
            this.textBoxPassWord.Depth = 0;
            this.textBoxPassWord.Hint = "パスワード";
            this.textBoxPassWord.Location = new System.Drawing.Point(3, 32);
            this.textBoxPassWord.MaxLength = 32767;
            this.textBoxPassWord.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPassWord.Name = "textBoxPassWord";
            this.textBoxPassWord.PasswordChar = '*';
            this.textBoxPassWord.SelectedText = "";
            this.textBoxPassWord.SelectionLength = 0;
            this.textBoxPassWord.SelectionStart = 0;
            this.textBoxPassWord.Size = new System.Drawing.Size(250, 23);
            this.textBoxPassWord.TabIndex = 1;
            this.textBoxPassWord.TabStop = false;
            this.textBoxPassWord.UseSystemPasswordChar = false;
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Depth = 0;
            this.textBoxUserId.Hint = "静大ID";
            this.textBoxUserId.Location = new System.Drawing.Point(3, 3);
            this.textBoxUserId.MaxLength = 32767;
            this.textBoxUserId.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.PasswordChar = '\0';
            this.textBoxUserId.SelectedText = "";
            this.textBoxUserId.SelectionLength = 0;
            this.textBoxUserId.SelectionStart = 0;
            this.textBoxUserId.Size = new System.Drawing.Size(250, 23);
            this.textBoxUserId.TabIndex = 0;
            this.textBoxUserId.TabStop = false;
            this.textBoxUserId.UseSystemPasswordChar = false;
            // 
            // tabPageClassContact
            // 
            this.tabPageClassContact.BackColor = System.Drawing.Color.White;
            this.tabPageClassContact.Controls.Add(this.splitContainerClassContact);
            this.tabPageClassContact.Location = new System.Drawing.Point(4, 22);
            this.tabPageClassContact.Name = "tabPageClassContact";
            this.tabPageClassContact.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClassContact.Size = new System.Drawing.Size(768, 319);
            this.tabPageClassContact.TabIndex = 1;
            this.tabPageClassContact.Text = "授業連絡";
            // 
            // splitContainerClassContact
            // 
            this.splitContainerClassContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerClassContact.Location = new System.Drawing.Point(3, 3);
            this.splitContainerClassContact.Name = "splitContainerClassContact";
            this.splitContainerClassContact.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerClassContact.Panel1
            // 
            this.splitContainerClassContact.Panel1.Controls.Add(this.textBoxClassContactDetail);
            this.splitContainerClassContact.Panel1.Controls.Add(this.textBoxClassContactLimit);
            this.splitContainerClassContact.Panel1.Controls.Add(this.checkBoxClassContactFileDownload);
            this.splitContainerClassContact.Panel1.Controls.Add(this.buttonRefreshClassContact);
            this.splitContainerClassContact.Panel1.Controls.Add(this.listViewClassContact);
            // 
            // splitContainerClassContact.Panel2
            // 
            this.splitContainerClassContact.Panel2.Controls.Add(this.buttonFile);
            this.splitContainerClassContact.Panel2.Controls.Add(this.labelClassContactTitle);
            this.splitContainerClassContact.Panel2.Controls.Add(this.labelClassContactContent);
            this.splitContainerClassContact.Size = new System.Drawing.Size(762, 313);
            this.splitContainerClassContact.SplitterDistance = 156;
            this.splitContainerClassContact.TabIndex = 11;
            // 
            // textBoxClassContactDetail
            // 
            this.textBoxClassContactDetail.Depth = 0;
            this.textBoxClassContactDetail.Hint = "詳細件数";
            this.textBoxClassContactDetail.Location = new System.Drawing.Point(286, 10);
            this.textBoxClassContactDetail.MaxLength = 32767;
            this.textBoxClassContactDetail.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxClassContactDetail.Name = "textBoxClassContactDetail";
            this.textBoxClassContactDetail.PasswordChar = '\0';
            this.textBoxClassContactDetail.SelectedText = "";
            this.textBoxClassContactDetail.SelectionLength = 0;
            this.textBoxClassContactDetail.SelectionStart = 0;
            this.textBoxClassContactDetail.Size = new System.Drawing.Size(80, 23);
            this.textBoxClassContactDetail.TabIndex = 10;
            this.textBoxClassContactDetail.TabStop = false;
            this.textBoxClassContactDetail.Text = "10";
            this.textBoxClassContactDetail.UseSystemPasswordChar = false;
            this.textBoxClassContactDetail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxClassContactDetail_KeyPress);
            // 
            // textBoxClassContactLimit
            // 
            this.textBoxClassContactLimit.Depth = 0;
            this.textBoxClassContactLimit.Hint = "一覧件数";
            this.textBoxClassContactLimit.Location = new System.Drawing.Point(200, 10);
            this.textBoxClassContactLimit.MaxLength = 32767;
            this.textBoxClassContactLimit.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxClassContactLimit.Name = "textBoxClassContactLimit";
            this.textBoxClassContactLimit.PasswordChar = '\0';
            this.textBoxClassContactLimit.SelectedText = "";
            this.textBoxClassContactLimit.SelectionLength = 0;
            this.textBoxClassContactLimit.SelectionStart = 0;
            this.textBoxClassContactLimit.Size = new System.Drawing.Size(80, 23);
            this.textBoxClassContactLimit.TabIndex = 9;
            this.textBoxClassContactLimit.TabStop = false;
            this.textBoxClassContactLimit.Text = "0";
            this.textBoxClassContactLimit.UseSystemPasswordChar = false;
            this.textBoxClassContactLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxClassContactLimit_KeyPress);
            // 
            // checkBoxClassContactFileDownload
            // 
            this.checkBoxClassContactFileDownload.AutoSize = true;
            this.checkBoxClassContactFileDownload.Depth = 0;
            this.checkBoxClassContactFileDownload.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkBoxClassContactFileDownload.Location = new System.Drawing.Point(57, 6);
            this.checkBoxClassContactFileDownload.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxClassContactFileDownload.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxClassContactFileDownload.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxClassContactFileDownload.Name = "checkBoxClassContactFileDownload";
            this.checkBoxClassContactFileDownload.Ripple = true;
            this.checkBoxClassContactFileDownload.Size = new System.Drawing.Size(140, 30);
            this.checkBoxClassContactFileDownload.TabIndex = 8;
            this.checkBoxClassContactFileDownload.Text = "ファイルダウンロード";
            this.checkBoxClassContactFileDownload.UseVisualStyleBackColor = true;
            // 
            // buttonRefreshClassContact
            // 
            this.buttonRefreshClassContact.AutoSize = true;
            this.buttonRefreshClassContact.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRefreshClassContact.Depth = 0;
            this.buttonRefreshClassContact.Icon = null;
            this.buttonRefreshClassContact.Location = new System.Drawing.Point(3, 3);
            this.buttonRefreshClassContact.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRefreshClassContact.Name = "buttonRefreshClassContact";
            this.buttonRefreshClassContact.Primary = true;
            this.buttonRefreshClassContact.Size = new System.Drawing.Size(51, 36);
            this.buttonRefreshClassContact.TabIndex = 7;
            this.buttonRefreshClassContact.Text = "更新";
            this.buttonRefreshClassContact.UseVisualStyleBackColor = true;
            this.buttonRefreshClassContact.Click += new System.EventHandler(this.buttonRefreshClassContact_Click);
            // 
            // listViewClassContact
            // 
            this.listViewClassContact.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewClassContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewClassContact.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEmpty0,
            this.columnClassSubjects0,
            this.columnTitle0,
            this.columnContent0,
            this.columnContactTime0});
            this.listViewClassContact.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewClassContact.Depth = 0;
            this.listViewClassContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listViewClassContact.FullRowSelect = true;
            this.listViewClassContact.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewClassContact.HideSelection = false;
            this.listViewClassContact.Location = new System.Drawing.Point(0, 45);
            this.listViewClassContact.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewClassContact.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewClassContact.MultiSelect = false;
            this.listViewClassContact.Name = "listViewClassContact";
            this.listViewClassContact.OwnerDraw = true;
            this.listViewClassContact.Size = new System.Drawing.Size(762, 108);
            this.listViewClassContact.TabIndex = 0;
            this.listViewClassContact.UseCompatibleStateImageBehavior = false;
            this.listViewClassContact.View = System.Windows.Forms.View.Details;
            this.listViewClassContact.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewClassContact_MouseClick);
            this.listViewClassContact.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewClassContact_MouseMove);
            // 
            // columnEmpty0
            // 
            this.columnEmpty0.Width = 0;
            // 
            // columnClassSubjects0
            // 
            this.columnClassSubjects0.Text = "授業科目";
            this.columnClassSubjects0.Width = 100;
            // 
            // columnTitle0
            // 
            this.columnTitle0.Text = "タイトル";
            this.columnTitle0.Width = 280;
            // 
            // columnContent0
            // 
            this.columnContent0.Text = "内容";
            this.columnContent0.Width = 240;
            // 
            // columnContactTime0
            // 
            this.columnContactTime0.Text = "連絡日時";
            this.columnContactTime0.Width = 120;
            // 
            // buttonFile
            // 
            this.buttonFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFile.AutoSize = true;
            this.buttonFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonFile.Depth = 0;
            this.buttonFile.Icon = null;
            this.buttonFile.Location = new System.Drawing.Point(3, 117);
            this.buttonFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Primary = false;
            this.buttonFile.Size = new System.Drawing.Size(63, 36);
            this.buttonFile.TabIndex = 13;
            this.buttonFile.Text = "ファイル";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Visible = false;
            // 
            // labelClassContactTitle
            // 
            this.labelClassContactTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClassContactTitle.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClassContactTitle.Location = new System.Drawing.Point(3, 0);
            this.labelClassContactTitle.Name = "labelClassContactTitle";
            this.labelClassContactTitle.Size = new System.Drawing.Size(756, 20);
            this.labelClassContactTitle.TabIndex = 12;
            this.labelClassContactTitle.Text = "タイトル";
            // 
            // labelClassContactContent
            // 
            this.labelClassContactContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClassContactContent.BackColor = System.Drawing.Color.White;
            this.labelClassContactContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelClassContactContent.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClassContactContent.Location = new System.Drawing.Point(3, 23);
            this.labelClassContactContent.Multiline = true;
            this.labelClassContactContent.Name = "labelClassContactContent";
            this.labelClassContactContent.ReadOnly = true;
            this.labelClassContactContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.labelClassContactContent.Size = new System.Drawing.Size(756, 85);
            this.labelClassContactContent.TabIndex = 11;
            this.labelClassContactContent.TabStop = false;
            // 
            // tabPageReport
            // 
            this.tabPageReport.BackColor = System.Drawing.Color.White;
            this.tabPageReport.Controls.Add(this.buttonRefreshReport);
            this.tabPageReport.Controls.Add(this.listViewReport);
            this.tabPageReport.Location = new System.Drawing.Point(4, 22);
            this.tabPageReport.Name = "tabPageReport";
            this.tabPageReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReport.Size = new System.Drawing.Size(768, 319);
            this.tabPageReport.TabIndex = 2;
            this.tabPageReport.Text = "レポート";
            // 
            // buttonRefreshReport
            // 
            this.buttonRefreshReport.AutoSize = true;
            this.buttonRefreshReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRefreshReport.Depth = 0;
            this.buttonRefreshReport.Icon = null;
            this.buttonRefreshReport.Location = new System.Drawing.Point(6, 6);
            this.buttonRefreshReport.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRefreshReport.Name = "buttonRefreshReport";
            this.buttonRefreshReport.Primary = true;
            this.buttonRefreshReport.Size = new System.Drawing.Size(51, 36);
            this.buttonRefreshReport.TabIndex = 8;
            this.buttonRefreshReport.Text = "更新";
            this.buttonRefreshReport.UseVisualStyleBackColor = true;
            this.buttonRefreshReport.Click += new System.EventHandler(this.buttonRefreshReport_Click);
            // 
            // listViewReport
            // 
            this.listViewReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEmpty1,
            this.columnClassSubjects1,
            this.columnTitle1,
            this.columnStatus1,
            this.columnSubmissionPeriod1,
            this.columnLastSubmissionTime1,
            this.columnOperation1});
            this.listViewReport.Depth = 0;
            this.listViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listViewReport.FullRowSelect = true;
            this.listViewReport.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewReport.HideSelection = false;
            this.listViewReport.Location = new System.Drawing.Point(3, 48);
            this.listViewReport.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewReport.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewReport.MultiSelect = false;
            this.listViewReport.Name = "listViewReport";
            this.listViewReport.OwnerDraw = true;
            this.listViewReport.Size = new System.Drawing.Size(762, 268);
            this.listViewReport.TabIndex = 1;
            this.listViewReport.UseCompatibleStateImageBehavior = false;
            this.listViewReport.View = System.Windows.Forms.View.Details;
            this.listViewReport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewReport_MouseClick);
            this.listViewReport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewReport_MouseMove);
            // 
            // columnEmpty1
            // 
            this.columnEmpty1.Text = "";
            this.columnEmpty1.Width = 0;
            // 
            // columnClassSubjects1
            // 
            this.columnClassSubjects1.Text = "授業科目";
            this.columnClassSubjects1.Width = 100;
            // 
            // columnTitle1
            // 
            this.columnTitle1.Text = "タイトル";
            this.columnTitle1.Width = 160;
            // 
            // columnStatus1
            // 
            this.columnStatus1.Text = "状態";
            this.columnStatus1.Width = 120;
            // 
            // columnSubmissionPeriod1
            // 
            this.columnSubmissionPeriod1.Text = "提出期間";
            this.columnSubmissionPeriod1.Width = 240;
            // 
            // columnLastSubmissionTime1
            // 
            this.columnLastSubmissionTime1.Text = "最終提出日時";
            this.columnLastSubmissionTime1.Width = 120;
            // 
            // columnOperation1
            // 
            this.columnOperation1.Text = "操作";
            this.columnOperation1.Width = 120;
            // 
            // tabPageQuiz
            // 
            this.tabPageQuiz.BackColor = System.Drawing.Color.White;
            this.tabPageQuiz.Controls.Add(this.checkBoxAllVisible);
            this.tabPageQuiz.Controls.Add(this.buttonRefreshQuiz);
            this.tabPageQuiz.Controls.Add(this.listViewQuiz);
            this.tabPageQuiz.Location = new System.Drawing.Point(4, 22);
            this.tabPageQuiz.Name = "tabPageQuiz";
            this.tabPageQuiz.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuiz.Size = new System.Drawing.Size(768, 319);
            this.tabPageQuiz.TabIndex = 3;
            this.tabPageQuiz.Text = "小テスト";
            // 
            // checkBoxAllVisible
            // 
            this.checkBoxAllVisible.AutoSize = true;
            this.checkBoxAllVisible.Depth = 0;
            this.checkBoxAllVisible.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkBoxAllVisible.Location = new System.Drawing.Point(60, 9);
            this.checkBoxAllVisible.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxAllVisible.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxAllVisible.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxAllVisible.Name = "checkBoxAllVisible";
            this.checkBoxAllVisible.Ripple = true;
            this.checkBoxAllVisible.Size = new System.Drawing.Size(97, 30);
            this.checkBoxAllVisible.TabIndex = 10;
            this.checkBoxAllVisible.Text = "すべて表示";
            this.checkBoxAllVisible.UseVisualStyleBackColor = true;
            this.checkBoxAllVisible.CheckedChanged += new System.EventHandler(this.checkBoxAllVisible_CheckedChanged);
            // 
            // buttonRefreshQuiz
            // 
            this.buttonRefreshQuiz.AutoSize = true;
            this.buttonRefreshQuiz.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRefreshQuiz.Depth = 0;
            this.buttonRefreshQuiz.Icon = null;
            this.buttonRefreshQuiz.Location = new System.Drawing.Point(6, 6);
            this.buttonRefreshQuiz.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRefreshQuiz.Name = "buttonRefreshQuiz";
            this.buttonRefreshQuiz.Primary = true;
            this.buttonRefreshQuiz.Size = new System.Drawing.Size(51, 36);
            this.buttonRefreshQuiz.TabIndex = 9;
            this.buttonRefreshQuiz.Text = "更新";
            this.buttonRefreshQuiz.UseVisualStyleBackColor = true;
            this.buttonRefreshQuiz.Click += new System.EventHandler(this.buttonRefreshQuiz_Click);
            // 
            // listViewQuiz
            // 
            this.listViewQuiz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewQuiz.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewQuiz.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEmpty2,
            this.columnVisible2,
            this.columnClassSubjects2,
            this.columnTitle2,
            this.columnStatus2,
            this.columnSubmissionPeriod2,
            this.columnSubmissionStatus2,
            this.columnOperation2});
            this.listViewQuiz.Depth = 0;
            this.listViewQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listViewQuiz.FullRowSelect = true;
            this.listViewQuiz.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewQuiz.HideSelection = false;
            this.listViewQuiz.Location = new System.Drawing.Point(3, 48);
            this.listViewQuiz.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewQuiz.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewQuiz.MultiSelect = false;
            this.listViewQuiz.Name = "listViewQuiz";
            this.listViewQuiz.OwnerDraw = true;
            this.listViewQuiz.Size = new System.Drawing.Size(762, 268);
            this.listViewQuiz.TabIndex = 2;
            this.listViewQuiz.UseCompatibleStateImageBehavior = false;
            this.listViewQuiz.View = System.Windows.Forms.View.Details;
            this.listViewQuiz.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewQuiz_MouseClick);
            this.listViewQuiz.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewQuiz_MouseMove);
            // 
            // columnEmpty2
            // 
            this.columnEmpty2.Text = "";
            this.columnEmpty2.Width = 0;
            // 
            // columnVisible2
            // 
            this.columnVisible2.Text = "";
            this.columnVisible2.Width = 100;
            // 
            // columnClassSubjects2
            // 
            this.columnClassSubjects2.Text = "授業科目";
            this.columnClassSubjects2.Width = 100;
            // 
            // columnTitle2
            // 
            this.columnTitle2.Text = "タイトル";
            this.columnTitle2.Width = 160;
            // 
            // columnStatus2
            // 
            this.columnStatus2.Text = "状態";
            this.columnStatus2.Width = 120;
            // 
            // columnSubmissionPeriod2
            // 
            this.columnSubmissionPeriod2.Text = "提出期間";
            this.columnSubmissionPeriod2.Width = 240;
            // 
            // columnSubmissionStatus2
            // 
            this.columnSubmissionStatus2.Text = "提出状況";
            this.columnSubmissionStatus2.Width = 120;
            // 
            // columnOperation2
            // 
            this.columnOperation2.Text = "操作";
            this.columnOperation2.Width = 120;
            // 
            // materialTabSelector
            // 
            this.materialTabSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector.BaseTabControl = this.materialTabControl;
            this.materialTabSelector.Depth = 0;
            this.materialTabSelector.Location = new System.Drawing.Point(0, 64);
            this.materialTabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector.Name = "materialTabSelector";
            this.materialTabSelector.Size = new System.Drawing.Size(800, 23);
            this.materialTabSelector.TabIndex = 6;
            this.materialTabSelector.Text = "materialTabSelector";
            // 
            // textBoxStudentName
            // 
            this.textBoxStudentName.Depth = 0;
            this.textBoxStudentName.Hint = "氏名（全角スペース）";
            this.textBoxStudentName.Location = new System.Drawing.Point(3, 61);
            this.textBoxStudentName.MaxLength = 32767;
            this.textBoxStudentName.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxStudentName.Name = "textBoxStudentName";
            this.textBoxStudentName.PasswordChar = '\0';
            this.textBoxStudentName.SelectedText = "";
            this.textBoxStudentName.SelectionLength = 0;
            this.textBoxStudentName.SelectionStart = 0;
            this.textBoxStudentName.Size = new System.Drawing.Size(250, 23);
            this.textBoxStudentName.TabIndex = 7;
            this.textBoxStudentName.TabStop = false;
            this.textBoxStudentName.UseSystemPasswordChar = false;
            // 
            // textBoxStudentCode
            // 
            this.textBoxStudentCode.Depth = 0;
            this.textBoxStudentCode.Hint = "学籍番号（半角数字）";
            this.textBoxStudentCode.Location = new System.Drawing.Point(3, 90);
            this.textBoxStudentCode.MaxLength = 32767;
            this.textBoxStudentCode.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxStudentCode.Name = "textBoxStudentCode";
            this.textBoxStudentCode.PasswordChar = '\0';
            this.textBoxStudentCode.SelectedText = "";
            this.textBoxStudentCode.SelectionLength = 0;
            this.textBoxStudentCode.SelectionStart = 0;
            this.textBoxStudentCode.Size = new System.Drawing.Size(250, 23);
            this.textBoxStudentCode.TabIndex = 8;
            this.textBoxStudentCode.TabStop = false;
            this.textBoxStudentCode.UseSystemPasswordChar = false;
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialTabSelector);
            this.Controls.Add(this.materialTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "MainFrom";
            this.Text = "GakujoGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialTabControl.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.tabPageClassContact.ResumeLayout(false);
            this.splitContainerClassContact.Panel1.ResumeLayout(false);
            this.splitContainerClassContact.Panel1.PerformLayout();
            this.splitContainerClassContact.Panel2.ResumeLayout(false);
            this.splitContainerClassContact.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClassContact)).EndInit();
            this.splitContainerClassContact.ResumeLayout(false);
            this.tabPageReport.ResumeLayout(false);
            this.tabPageReport.PerformLayout();
            this.tabPageQuiz.ResumeLayout(false);
            this.tabPageQuiz.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl materialTabControl;
        private System.Windows.Forms.TabPage tabPageClassContact;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector;
        private System.Windows.Forms.TabPage tabPageReport;
        private System.Windows.Forms.TabPage tabPageQuiz;
        private System.Windows.Forms.TabPage tabPageLogin;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxUserId;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPassWord;
        private MaterialSkin.Controls.MaterialRaisedButton buttonLogin;
        private MaterialSkin.Controls.MaterialListView listViewClassContact;
        private System.Windows.Forms.ColumnHeader columnClassSubjects0;
        private System.Windows.Forms.ColumnHeader columnTitle0;
        private System.Windows.Forms.ColumnHeader columnContactTime0;
        private System.Windows.Forms.ColumnHeader columnContent0;
        private MaterialSkin.Controls.MaterialRaisedButton buttonRefreshClassContact;
        private System.Windows.Forms.ColumnHeader columnEmpty0;
        private MaterialSkin.Controls.MaterialListView listViewReport;
        private System.Windows.Forms.ColumnHeader columnEmpty1;
        private System.Windows.Forms.ColumnHeader columnClassSubjects1;
        private System.Windows.Forms.ColumnHeader columnTitle1;
        private System.Windows.Forms.ColumnHeader columnStatus1;
        private System.Windows.Forms.ColumnHeader columnSubmissionPeriod1;
        private System.Windows.Forms.ColumnHeader columnOperation1;
        private MaterialSkin.Controls.MaterialRaisedButton buttonRefreshReport;
        private MaterialSkin.Controls.MaterialListView listViewQuiz;
        private System.Windows.Forms.ColumnHeader columnEmpty2;
        private System.Windows.Forms.ColumnHeader columnClassSubjects2;
        private System.Windows.Forms.ColumnHeader columnTitle2;
        private System.Windows.Forms.ColumnHeader columnStatus2;
        private System.Windows.Forms.ColumnHeader columnSubmissionPeriod2;
        private System.Windows.Forms.ColumnHeader columnSubmissionStatus2;
        private System.Windows.Forms.ColumnHeader columnOperation2;
        private System.Windows.Forms.ColumnHeader columnLastSubmissionTime1;
        private MaterialSkin.Controls.MaterialRaisedButton buttonRefreshQuiz;
        private System.Windows.Forms.SplitContainer splitContainerClassContact;
        private System.Windows.Forms.TextBox labelClassContactContent;
        private System.Windows.Forms.Label labelClassContactTitle;
        private MaterialSkin.Controls.MaterialFlatButton buttonFile;
        private MaterialSkin.Controls.MaterialCheckBox checkBoxClassContactFileDownload;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxClassContactLimit;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxClassContactDetail;
        private MaterialSkin.Controls.MaterialFlatButton buttonTwitter;
        private MaterialSkin.Controls.MaterialCheckBox checkBoxAutoLogin;
        private System.Windows.Forms.ColumnHeader columnVisible2;
        private MaterialSkin.Controls.MaterialCheckBox checkBoxAllVisible;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxStudentCode;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxStudentName;
    }
}

