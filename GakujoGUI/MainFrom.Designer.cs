
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
            this.buttonUpdate = new MaterialSkin.Controls.MaterialFlatButton();
            this.textBoxStudentCode = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxStudentName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.buttonTwitter = new MaterialSkin.Controls.MaterialFlatButton();
            this.buttonLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.textBoxPassWord = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxUserId = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tabPageClassContact = new System.Windows.Forms.TabPage();
            this.splitContainerClassContact = new System.Windows.Forms.SplitContainer();
            this.checkBoxClassContactFileDownload = new MaterialSkin.Controls.MaterialCheckBox();
            this.buttonRefreshClassContact = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listViewClassContact = new MaterialSkin.Controls.MaterialListView();
            this.columnEmpty0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnClassSubjects0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnContent0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnContactTime0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClassContactFile = new MaterialSkin.Controls.MaterialFlatButton();
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
            this.tabPageSchoolContact = new System.Windows.Forms.TabPage();
            this.splitContainerSchoolContact = new System.Windows.Forms.SplitContainer();
            this.checkBoxSchoolContactFileDownload = new MaterialSkin.Controls.MaterialCheckBox();
            this.buttonRefreshSchoolContact = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listViewSchoolContact = new MaterialSkin.Controls.MaterialListView();
            this.columnEmpty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategory3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnContent3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnContactTime3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSchoolContactFile = new MaterialSkin.Controls.MaterialFlatButton();
            this.labelSchoolContactTitle = new System.Windows.Forms.Label();
            this.labelSchoolContactContent = new System.Windows.Forms.TextBox();
            this.tabPageClassSharedFile = new System.Windows.Forms.TabPage();
            this.splitContainerClassSharedFile = new System.Windows.Forms.SplitContainer();
            this.buttonRefreshClassSharedFile = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listViewClassSharedFile = new MaterialSkin.Controls.MaterialListView();
            this.columnEmpty4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnClassSubjects4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFileDescription4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUpdateTime4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClassSharedFileFile = new MaterialSkin.Controls.MaterialFlatButton();
            this.labelClassSharedFileTitle = new System.Windows.Forms.Label();
            this.labelClassSharedFileFileDescription = new System.Windows.Forms.TextBox();
            this.tabPageSchoolSharedFile = new System.Windows.Forms.TabPage();
            this.splitContainerSchoolSharedFile = new System.Windows.Forms.SplitContainer();
            this.buttonRefreshSchoolSharedFile = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listViewSchoolSharedFile = new MaterialSkin.Controls.MaterialListView();
            this.columnEmpty5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategory5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTitle5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFileDescription5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUpdateTime5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSchoolSharedFileFile = new MaterialSkin.Controls.MaterialFlatButton();
            this.labelSchoolSharedFileTitle = new System.Windows.Forms.Label();
            this.labelSchoolSharedFileFileDescription = new System.Windows.Forms.TextBox();
            this.tabPageAcademicAffairsSystem = new System.Windows.Forms.TabPage();
            this.buttonSyllabusReference = new MaterialSkin.Controls.MaterialFlatButton();
            this.buttonSchoolRegisterInformation = new MaterialSkin.Controls.MaterialFlatButton();
            this.webView2AcademicAffairsSystem = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.buttonCurriculumInformation = new MaterialSkin.Controls.MaterialFlatButton();
            this.buttonCreditAcquisitionInformation = new MaterialSkin.Controls.MaterialFlatButton();
            this.buttonResultInformation = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialTabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialTabControl.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).BeginInit();
            this.tabPageClassContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClassContact)).BeginInit();
            this.splitContainerClassContact.Panel1.SuspendLayout();
            this.splitContainerClassContact.Panel2.SuspendLayout();
            this.splitContainerClassContact.SuspendLayout();
            this.tabPageReport.SuspendLayout();
            this.tabPageQuiz.SuspendLayout();
            this.tabPageSchoolContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSchoolContact)).BeginInit();
            this.splitContainerSchoolContact.Panel1.SuspendLayout();
            this.splitContainerSchoolContact.Panel2.SuspendLayout();
            this.splitContainerSchoolContact.SuspendLayout();
            this.tabPageClassSharedFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClassSharedFile)).BeginInit();
            this.splitContainerClassSharedFile.Panel1.SuspendLayout();
            this.splitContainerClassSharedFile.Panel2.SuspendLayout();
            this.splitContainerClassSharedFile.SuspendLayout();
            this.tabPageSchoolSharedFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSchoolSharedFile)).BeginInit();
            this.splitContainerSchoolSharedFile.Panel1.SuspendLayout();
            this.splitContainerSchoolSharedFile.Panel2.SuspendLayout();
            this.splitContainerSchoolSharedFile.SuspendLayout();
            this.tabPageAcademicAffairsSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2AcademicAffairsSystem)).BeginInit();
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
            this.materialTabControl.Controls.Add(this.tabPageSchoolContact);
            this.materialTabControl.Controls.Add(this.tabPageClassSharedFile);
            this.materialTabControl.Controls.Add(this.tabPageSchoolSharedFile);
            this.materialTabControl.Controls.Add(this.tabPageAcademicAffairsSystem);
            this.materialTabControl.Depth = 0;
            this.materialTabControl.Location = new System.Drawing.Point(12, 93);
            this.materialTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl.Name = "materialTabControl";
            this.materialTabControl.SelectedIndex = 0;
            this.materialTabControl.Size = new System.Drawing.Size(776, 345);
            this.materialTabControl.TabIndex = 0;
            this.materialTabControl.TabStop = false;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.BackColor = System.Drawing.Color.White;
            this.tabPageLogin.Controls.Add(this.buttonUpdate);
            this.tabPageLogin.Controls.Add(this.textBoxStudentCode);
            this.tabPageLogin.Controls.Add(this.textBoxStudentName);
            this.tabPageLogin.Controls.Add(this.webView2);
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
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpdate.AutoSize = true;
            this.buttonUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonUpdate.Depth = 0;
            this.buttonUpdate.Icon = null;
            this.buttonUpdate.Location = new System.Drawing.Point(165, 277);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Primary = false;
            this.buttonUpdate.Size = new System.Drawing.Size(88, 36);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "アップデート";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
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
            this.textBoxStudentCode.TabIndex = 4;
            this.textBoxStudentCode.TabStop = false;
            this.textBoxStudentCode.UseSystemPasswordChar = false;
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
            this.textBoxStudentName.TabIndex = 3;
            this.textBoxStudentName.TabStop = false;
            this.textBoxStudentName.UseSystemPasswordChar = false;
            // 
            // webView2
            // 
            this.webView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView2.CreationProperties = null;
            this.webView2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2.Location = new System.Drawing.Point(259, 0);
            this.webView2.Name = "webView2";
            this.webView2.Size = new System.Drawing.Size(509, 319);
            this.webView2.Source = new System.Uri("https://gakujo.shizuoka.ac.jp/UI/jsp/topPage/topPage.jsp", System.UriKind.Absolute);
            this.webView2.TabIndex = 0;
            this.webView2.TabStop = false;
            this.webView2.ZoomFactor = 1D;
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
            this.buttonTwitter.TabIndex = 6;
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
            this.buttonLogin.TabIndex = 5;
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
            this.textBoxPassWord.TabIndex = 2;
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
            this.textBoxUserId.TabIndex = 1;
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
            this.splitContainerClassContact.Panel1.Controls.Add(this.checkBoxClassContactFileDownload);
            this.splitContainerClassContact.Panel1.Controls.Add(this.buttonRefreshClassContact);
            this.splitContainerClassContact.Panel1.Controls.Add(this.listViewClassContact);
            // 
            // splitContainerClassContact.Panel2
            // 
            this.splitContainerClassContact.Panel2.Controls.Add(this.buttonClassContactFile);
            this.splitContainerClassContact.Panel2.Controls.Add(this.labelClassContactTitle);
            this.splitContainerClassContact.Panel2.Controls.Add(this.labelClassContactContent);
            this.splitContainerClassContact.Size = new System.Drawing.Size(762, 313);
            this.splitContainerClassContact.SplitterDistance = 156;
            this.splitContainerClassContact.TabIndex = 11;
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
            this.checkBoxClassContactFileDownload.TabIndex = 2;
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
            this.buttonRefreshClassContact.TabIndex = 1;
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
            this.listViewClassContact.TabIndex = 3;
            this.listViewClassContact.UseCompatibleStateImageBehavior = false;
            this.listViewClassContact.View = System.Windows.Forms.View.Details;
            this.listViewClassContact.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewClassContact_MouseClick);
            this.listViewClassContact.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewClassContact_MouseDoubleClick);
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
            // buttonClassContactFile
            // 
            this.buttonClassContactFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClassContactFile.AutoSize = true;
            this.buttonClassContactFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonClassContactFile.Depth = 0;
            this.buttonClassContactFile.Icon = null;
            this.buttonClassContactFile.Location = new System.Drawing.Point(3, 117);
            this.buttonClassContactFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonClassContactFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonClassContactFile.Name = "buttonClassContactFile";
            this.buttonClassContactFile.Primary = false;
            this.buttonClassContactFile.Size = new System.Drawing.Size(63, 36);
            this.buttonClassContactFile.TabIndex = 6;
            this.buttonClassContactFile.Text = "ファイル";
            this.buttonClassContactFile.UseVisualStyleBackColor = true;
            this.buttonClassContactFile.Visible = false;
            // 
            // labelClassContactTitle
            // 
            this.labelClassContactTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClassContactTitle.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClassContactTitle.Location = new System.Drawing.Point(3, 0);
            this.labelClassContactTitle.Name = "labelClassContactTitle";
            this.labelClassContactTitle.Size = new System.Drawing.Size(756, 20);
            this.labelClassContactTitle.TabIndex = 4;
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
            this.labelClassContactContent.TabIndex = 5;
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
            this.buttonRefreshReport.TabIndex = 1;
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
            this.listViewReport.TabIndex = 2;
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
            this.checkBoxAllVisible.TabIndex = 2;
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
            this.buttonRefreshQuiz.TabIndex = 1;
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
            this.listViewQuiz.TabIndex = 3;
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
            // tabPageSchoolContact
            // 
            this.tabPageSchoolContact.BackColor = System.Drawing.Color.White;
            this.tabPageSchoolContact.Controls.Add(this.splitContainerSchoolContact);
            this.tabPageSchoolContact.Location = new System.Drawing.Point(4, 22);
            this.tabPageSchoolContact.Name = "tabPageSchoolContact";
            this.tabPageSchoolContact.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchoolContact.Size = new System.Drawing.Size(768, 319);
            this.tabPageSchoolContact.TabIndex = 5;
            this.tabPageSchoolContact.Text = "学内連絡";
            // 
            // splitContainerSchoolContact
            // 
            this.splitContainerSchoolContact.BackColor = System.Drawing.Color.White;
            this.splitContainerSchoolContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSchoolContact.Location = new System.Drawing.Point(3, 3);
            this.splitContainerSchoolContact.Name = "splitContainerSchoolContact";
            this.splitContainerSchoolContact.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSchoolContact.Panel1
            // 
            this.splitContainerSchoolContact.Panel1.Controls.Add(this.checkBoxSchoolContactFileDownload);
            this.splitContainerSchoolContact.Panel1.Controls.Add(this.buttonRefreshSchoolContact);
            this.splitContainerSchoolContact.Panel1.Controls.Add(this.listViewSchoolContact);
            // 
            // splitContainerSchoolContact.Panel2
            // 
            this.splitContainerSchoolContact.Panel2.Controls.Add(this.buttonSchoolContactFile);
            this.splitContainerSchoolContact.Panel2.Controls.Add(this.labelSchoolContactTitle);
            this.splitContainerSchoolContact.Panel2.Controls.Add(this.labelSchoolContactContent);
            this.splitContainerSchoolContact.Size = new System.Drawing.Size(762, 313);
            this.splitContainerSchoolContact.SplitterDistance = 156;
            this.splitContainerSchoolContact.TabIndex = 12;
            // 
            // checkBoxSchoolContactFileDownload
            // 
            this.checkBoxSchoolContactFileDownload.AutoSize = true;
            this.checkBoxSchoolContactFileDownload.BackColor = System.Drawing.Color.White;
            this.checkBoxSchoolContactFileDownload.Depth = 0;
            this.checkBoxSchoolContactFileDownload.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkBoxSchoolContactFileDownload.Location = new System.Drawing.Point(57, 6);
            this.checkBoxSchoolContactFileDownload.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSchoolContactFileDownload.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxSchoolContactFileDownload.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxSchoolContactFileDownload.Name = "checkBoxSchoolContactFileDownload";
            this.checkBoxSchoolContactFileDownload.Ripple = true;
            this.checkBoxSchoolContactFileDownload.Size = new System.Drawing.Size(140, 30);
            this.checkBoxSchoolContactFileDownload.TabIndex = 2;
            this.checkBoxSchoolContactFileDownload.Text = "ファイルダウンロード";
            this.checkBoxSchoolContactFileDownload.UseVisualStyleBackColor = false;
            // 
            // buttonRefreshSchoolContact
            // 
            this.buttonRefreshSchoolContact.AutoSize = true;
            this.buttonRefreshSchoolContact.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRefreshSchoolContact.Depth = 0;
            this.buttonRefreshSchoolContact.Icon = null;
            this.buttonRefreshSchoolContact.Location = new System.Drawing.Point(3, 3);
            this.buttonRefreshSchoolContact.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRefreshSchoolContact.Name = "buttonRefreshSchoolContact";
            this.buttonRefreshSchoolContact.Primary = true;
            this.buttonRefreshSchoolContact.Size = new System.Drawing.Size(51, 36);
            this.buttonRefreshSchoolContact.TabIndex = 1;
            this.buttonRefreshSchoolContact.Text = "更新";
            this.buttonRefreshSchoolContact.UseVisualStyleBackColor = true;
            this.buttonRefreshSchoolContact.Click += new System.EventHandler(this.buttonRefreshSchoolContact_Click);
            // 
            // listViewSchoolContact
            // 
            this.listViewSchoolContact.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSchoolContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewSchoolContact.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEmpty3,
            this.columnCategory3,
            this.columnTitle3,
            this.columnContent3,
            this.columnContactTime3});
            this.listViewSchoolContact.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewSchoolContact.Depth = 0;
            this.listViewSchoolContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listViewSchoolContact.FullRowSelect = true;
            this.listViewSchoolContact.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSchoolContact.HideSelection = false;
            this.listViewSchoolContact.Location = new System.Drawing.Point(0, 45);
            this.listViewSchoolContact.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewSchoolContact.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewSchoolContact.MultiSelect = false;
            this.listViewSchoolContact.Name = "listViewSchoolContact";
            this.listViewSchoolContact.OwnerDraw = true;
            this.listViewSchoolContact.Size = new System.Drawing.Size(762, 108);
            this.listViewSchoolContact.TabIndex = 3;
            this.listViewSchoolContact.UseCompatibleStateImageBehavior = false;
            this.listViewSchoolContact.View = System.Windows.Forms.View.Details;
            this.listViewSchoolContact.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewSchoolContact_MouseClick);
            this.listViewSchoolContact.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewSchoolContact_MouseDoubleClick);
            this.listViewSchoolContact.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewSchoolContact_MouseMove);
            // 
            // columnEmpty3
            // 
            this.columnEmpty3.Text = "";
            this.columnEmpty3.Width = 0;
            // 
            // columnCategory3
            // 
            this.columnCategory3.Text = "カテゴリ";
            this.columnCategory3.Width = 100;
            // 
            // columnTitle3
            // 
            this.columnTitle3.Text = "タイトル";
            this.columnTitle3.Width = 280;
            // 
            // columnContent3
            // 
            this.columnContent3.Text = "内容";
            this.columnContent3.Width = 240;
            // 
            // columnContactTime3
            // 
            this.columnContactTime3.Text = "連絡日時";
            this.columnContactTime3.Width = 120;
            // 
            // buttonSchoolContactFile
            // 
            this.buttonSchoolContactFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSchoolContactFile.AutoSize = true;
            this.buttonSchoolContactFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSchoolContactFile.BackColor = System.Drawing.Color.White;
            this.buttonSchoolContactFile.Depth = 0;
            this.buttonSchoolContactFile.Icon = null;
            this.buttonSchoolContactFile.Location = new System.Drawing.Point(3, 117);
            this.buttonSchoolContactFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSchoolContactFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSchoolContactFile.Name = "buttonSchoolContactFile";
            this.buttonSchoolContactFile.Primary = false;
            this.buttonSchoolContactFile.Size = new System.Drawing.Size(63, 36);
            this.buttonSchoolContactFile.TabIndex = 6;
            this.buttonSchoolContactFile.Text = "ファイル";
            this.buttonSchoolContactFile.UseVisualStyleBackColor = false;
            this.buttonSchoolContactFile.Visible = false;
            // 
            // labelSchoolContactTitle
            // 
            this.labelSchoolContactTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSchoolContactTitle.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSchoolContactTitle.Location = new System.Drawing.Point(3, 0);
            this.labelSchoolContactTitle.Name = "labelSchoolContactTitle";
            this.labelSchoolContactTitle.Size = new System.Drawing.Size(756, 20);
            this.labelSchoolContactTitle.TabIndex = 4;
            // 
            // labelSchoolContactContent
            // 
            this.labelSchoolContactContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSchoolContactContent.BackColor = System.Drawing.Color.White;
            this.labelSchoolContactContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelSchoolContactContent.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSchoolContactContent.Location = new System.Drawing.Point(3, 23);
            this.labelSchoolContactContent.Multiline = true;
            this.labelSchoolContactContent.Name = "labelSchoolContactContent";
            this.labelSchoolContactContent.ReadOnly = true;
            this.labelSchoolContactContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.labelSchoolContactContent.Size = new System.Drawing.Size(756, 85);
            this.labelSchoolContactContent.TabIndex = 5;
            // 
            // tabPageClassSharedFile
            // 
            this.tabPageClassSharedFile.BackColor = System.Drawing.Color.White;
            this.tabPageClassSharedFile.Controls.Add(this.splitContainerClassSharedFile);
            this.tabPageClassSharedFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageClassSharedFile.Name = "tabPageClassSharedFile";
            this.tabPageClassSharedFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClassSharedFile.Size = new System.Drawing.Size(768, 319);
            this.tabPageClassSharedFile.TabIndex = 6;
            this.tabPageClassSharedFile.Text = "授業共有ファイル";
            // 
            // splitContainerClassSharedFile
            // 
            this.splitContainerClassSharedFile.BackColor = System.Drawing.Color.White;
            this.splitContainerClassSharedFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerClassSharedFile.Location = new System.Drawing.Point(3, 3);
            this.splitContainerClassSharedFile.Name = "splitContainerClassSharedFile";
            this.splitContainerClassSharedFile.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerClassSharedFile.Panel1
            // 
            this.splitContainerClassSharedFile.Panel1.Controls.Add(this.buttonRefreshClassSharedFile);
            this.splitContainerClassSharedFile.Panel1.Controls.Add(this.listViewClassSharedFile);
            // 
            // splitContainerClassSharedFile.Panel2
            // 
            this.splitContainerClassSharedFile.Panel2.Controls.Add(this.buttonClassSharedFileFile);
            this.splitContainerClassSharedFile.Panel2.Controls.Add(this.labelClassSharedFileTitle);
            this.splitContainerClassSharedFile.Panel2.Controls.Add(this.labelClassSharedFileFileDescription);
            this.splitContainerClassSharedFile.Size = new System.Drawing.Size(762, 313);
            this.splitContainerClassSharedFile.SplitterDistance = 156;
            this.splitContainerClassSharedFile.TabIndex = 12;
            // 
            // buttonRefreshClassSharedFile
            // 
            this.buttonRefreshClassSharedFile.AutoSize = true;
            this.buttonRefreshClassSharedFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRefreshClassSharedFile.Depth = 0;
            this.buttonRefreshClassSharedFile.Icon = null;
            this.buttonRefreshClassSharedFile.Location = new System.Drawing.Point(3, 3);
            this.buttonRefreshClassSharedFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRefreshClassSharedFile.Name = "buttonRefreshClassSharedFile";
            this.buttonRefreshClassSharedFile.Primary = true;
            this.buttonRefreshClassSharedFile.Size = new System.Drawing.Size(51, 36);
            this.buttonRefreshClassSharedFile.TabIndex = 1;
            this.buttonRefreshClassSharedFile.Text = "更新";
            this.buttonRefreshClassSharedFile.UseVisualStyleBackColor = true;
            this.buttonRefreshClassSharedFile.Click += new System.EventHandler(this.buttonRefreshClassSharedFile_Click);
            // 
            // listViewClassSharedFile
            // 
            this.listViewClassSharedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewClassSharedFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewClassSharedFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEmpty4,
            this.columnClassSubjects4,
            this.columnTitle4,
            this.columnFileDescription4,
            this.columnUpdateTime4});
            this.listViewClassSharedFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewClassSharedFile.Depth = 0;
            this.listViewClassSharedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listViewClassSharedFile.FullRowSelect = true;
            this.listViewClassSharedFile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewClassSharedFile.HideSelection = false;
            this.listViewClassSharedFile.Location = new System.Drawing.Point(0, 45);
            this.listViewClassSharedFile.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewClassSharedFile.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewClassSharedFile.MultiSelect = false;
            this.listViewClassSharedFile.Name = "listViewClassSharedFile";
            this.listViewClassSharedFile.OwnerDraw = true;
            this.listViewClassSharedFile.Size = new System.Drawing.Size(762, 108);
            this.listViewClassSharedFile.TabIndex = 5;
            this.listViewClassSharedFile.UseCompatibleStateImageBehavior = false;
            this.listViewClassSharedFile.View = System.Windows.Forms.View.Details;
            this.listViewClassSharedFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewClassSharedFile_MouseClick);
            this.listViewClassSharedFile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewClassSharedFile_MouseMove);
            // 
            // columnEmpty4
            // 
            this.columnEmpty4.Text = "";
            this.columnEmpty4.Width = 0;
            // 
            // columnClassSubjects4
            // 
            this.columnClassSubjects4.Text = "授業科目";
            this.columnClassSubjects4.Width = 100;
            // 
            // columnTitle4
            // 
            this.columnTitle4.Text = "タイトル";
            this.columnTitle4.Width = 280;
            // 
            // columnFileDescription4
            // 
            this.columnFileDescription4.Text = "ファイル説明";
            this.columnFileDescription4.Width = 240;
            // 
            // columnUpdateTime4
            // 
            this.columnUpdateTime4.Text = "更新日時";
            this.columnUpdateTime4.Width = 120;
            // 
            // buttonClassSharedFileFile
            // 
            this.buttonClassSharedFileFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClassSharedFileFile.AutoSize = true;
            this.buttonClassSharedFileFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonClassSharedFileFile.BackColor = System.Drawing.Color.White;
            this.buttonClassSharedFileFile.Depth = 0;
            this.buttonClassSharedFileFile.Icon = null;
            this.buttonClassSharedFileFile.Location = new System.Drawing.Point(3, 117);
            this.buttonClassSharedFileFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonClassSharedFileFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonClassSharedFileFile.Name = "buttonClassSharedFileFile";
            this.buttonClassSharedFileFile.Primary = false;
            this.buttonClassSharedFileFile.Size = new System.Drawing.Size(63, 36);
            this.buttonClassSharedFileFile.TabIndex = 8;
            this.buttonClassSharedFileFile.Text = "ファイル";
            this.buttonClassSharedFileFile.UseVisualStyleBackColor = false;
            this.buttonClassSharedFileFile.Visible = false;
            // 
            // labelClassSharedFileTitle
            // 
            this.labelClassSharedFileTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClassSharedFileTitle.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClassSharedFileTitle.Location = new System.Drawing.Point(3, 0);
            this.labelClassSharedFileTitle.Name = "labelClassSharedFileTitle";
            this.labelClassSharedFileTitle.Size = new System.Drawing.Size(756, 20);
            this.labelClassSharedFileTitle.TabIndex = 6;
            // 
            // labelClassSharedFileFileDescription
            // 
            this.labelClassSharedFileFileDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClassSharedFileFileDescription.BackColor = System.Drawing.Color.White;
            this.labelClassSharedFileFileDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelClassSharedFileFileDescription.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelClassSharedFileFileDescription.Location = new System.Drawing.Point(3, 23);
            this.labelClassSharedFileFileDescription.Multiline = true;
            this.labelClassSharedFileFileDescription.Name = "labelClassSharedFileFileDescription";
            this.labelClassSharedFileFileDescription.ReadOnly = true;
            this.labelClassSharedFileFileDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.labelClassSharedFileFileDescription.Size = new System.Drawing.Size(756, 85);
            this.labelClassSharedFileFileDescription.TabIndex = 7;
            // 
            // tabPageSchoolSharedFile
            // 
            this.tabPageSchoolSharedFile.BackColor = System.Drawing.Color.White;
            this.tabPageSchoolSharedFile.Controls.Add(this.splitContainerSchoolSharedFile);
            this.tabPageSchoolSharedFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageSchoolSharedFile.Name = "tabPageSchoolSharedFile";
            this.tabPageSchoolSharedFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchoolSharedFile.Size = new System.Drawing.Size(768, 319);
            this.tabPageSchoolSharedFile.TabIndex = 7;
            this.tabPageSchoolSharedFile.Text = "学内共有ファイル";
            // 
            // splitContainerSchoolSharedFile
            // 
            this.splitContainerSchoolSharedFile.BackColor = System.Drawing.Color.White;
            this.splitContainerSchoolSharedFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSchoolSharedFile.Location = new System.Drawing.Point(3, 3);
            this.splitContainerSchoolSharedFile.Name = "splitContainerSchoolSharedFile";
            this.splitContainerSchoolSharedFile.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSchoolSharedFile.Panel1
            // 
            this.splitContainerSchoolSharedFile.Panel1.Controls.Add(this.buttonRefreshSchoolSharedFile);
            this.splitContainerSchoolSharedFile.Panel1.Controls.Add(this.listViewSchoolSharedFile);
            // 
            // splitContainerSchoolSharedFile.Panel2
            // 
            this.splitContainerSchoolSharedFile.Panel2.Controls.Add(this.buttonSchoolSharedFileFile);
            this.splitContainerSchoolSharedFile.Panel2.Controls.Add(this.labelSchoolSharedFileTitle);
            this.splitContainerSchoolSharedFile.Panel2.Controls.Add(this.labelSchoolSharedFileFileDescription);
            this.splitContainerSchoolSharedFile.Size = new System.Drawing.Size(762, 313);
            this.splitContainerSchoolSharedFile.SplitterDistance = 156;
            this.splitContainerSchoolSharedFile.TabIndex = 12;
            // 
            // buttonRefreshSchoolSharedFile
            // 
            this.buttonRefreshSchoolSharedFile.AutoSize = true;
            this.buttonRefreshSchoolSharedFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRefreshSchoolSharedFile.Depth = 0;
            this.buttonRefreshSchoolSharedFile.Icon = null;
            this.buttonRefreshSchoolSharedFile.Location = new System.Drawing.Point(3, 3);
            this.buttonRefreshSchoolSharedFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRefreshSchoolSharedFile.Name = "buttonRefreshSchoolSharedFile";
            this.buttonRefreshSchoolSharedFile.Primary = true;
            this.buttonRefreshSchoolSharedFile.Size = new System.Drawing.Size(51, 36);
            this.buttonRefreshSchoolSharedFile.TabIndex = 1;
            this.buttonRefreshSchoolSharedFile.Text = "更新";
            this.buttonRefreshSchoolSharedFile.UseVisualStyleBackColor = true;
            this.buttonRefreshSchoolSharedFile.Click += new System.EventHandler(this.buttonRefreshSchoolSharedFile_Click);
            // 
            // listViewSchoolSharedFile
            // 
            this.listViewSchoolSharedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSchoolSharedFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewSchoolSharedFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnEmpty5,
            this.columnCategory5,
            this.columnTitle5,
            this.columnFileDescription5,
            this.columnUpdateTime5});
            this.listViewSchoolSharedFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewSchoolSharedFile.Depth = 0;
            this.listViewSchoolSharedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listViewSchoolSharedFile.FullRowSelect = true;
            this.listViewSchoolSharedFile.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSchoolSharedFile.HideSelection = false;
            this.listViewSchoolSharedFile.Location = new System.Drawing.Point(0, 45);
            this.listViewSchoolSharedFile.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewSchoolSharedFile.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewSchoolSharedFile.MultiSelect = false;
            this.listViewSchoolSharedFile.Name = "listViewSchoolSharedFile";
            this.listViewSchoolSharedFile.OwnerDraw = true;
            this.listViewSchoolSharedFile.Size = new System.Drawing.Size(762, 108);
            this.listViewSchoolSharedFile.TabIndex = 2;
            this.listViewSchoolSharedFile.UseCompatibleStateImageBehavior = false;
            this.listViewSchoolSharedFile.View = System.Windows.Forms.View.Details;
            this.listViewSchoolSharedFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewSchoolSharedFile_MouseClick);
            this.listViewSchoolSharedFile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewSchoolSharedFile_MouseMove);
            // 
            // columnEmpty5
            // 
            this.columnEmpty5.Text = "";
            this.columnEmpty5.Width = 0;
            // 
            // columnCategory5
            // 
            this.columnCategory5.Text = "カテゴリ";
            this.columnCategory5.Width = 100;
            // 
            // columnTitle5
            // 
            this.columnTitle5.Text = "タイトル";
            this.columnTitle5.Width = 280;
            // 
            // columnFileDescription5
            // 
            this.columnFileDescription5.Text = "ファイル説明";
            this.columnFileDescription5.Width = 240;
            // 
            // columnUpdateTime5
            // 
            this.columnUpdateTime5.Text = "更新日時";
            this.columnUpdateTime5.Width = 120;
            // 
            // buttonSchoolSharedFileFile
            // 
            this.buttonSchoolSharedFileFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSchoolSharedFileFile.AutoSize = true;
            this.buttonSchoolSharedFileFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSchoolSharedFileFile.BackColor = System.Drawing.Color.White;
            this.buttonSchoolSharedFileFile.Depth = 0;
            this.buttonSchoolSharedFileFile.Icon = null;
            this.buttonSchoolSharedFileFile.Location = new System.Drawing.Point(3, 117);
            this.buttonSchoolSharedFileFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSchoolSharedFileFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSchoolSharedFileFile.Name = "buttonSchoolSharedFileFile";
            this.buttonSchoolSharedFileFile.Primary = false;
            this.buttonSchoolSharedFileFile.Size = new System.Drawing.Size(63, 36);
            this.buttonSchoolSharedFileFile.TabIndex = 5;
            this.buttonSchoolSharedFileFile.Text = "ファイル";
            this.buttonSchoolSharedFileFile.UseVisualStyleBackColor = false;
            this.buttonSchoolSharedFileFile.Visible = false;
            // 
            // labelSchoolSharedFileTitle
            // 
            this.labelSchoolSharedFileTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSchoolSharedFileTitle.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSchoolSharedFileTitle.Location = new System.Drawing.Point(3, 0);
            this.labelSchoolSharedFileTitle.Name = "labelSchoolSharedFileTitle";
            this.labelSchoolSharedFileTitle.Size = new System.Drawing.Size(756, 20);
            this.labelSchoolSharedFileTitle.TabIndex = 3;
            // 
            // labelSchoolSharedFileFileDescription
            // 
            this.labelSchoolSharedFileFileDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSchoolSharedFileFileDescription.BackColor = System.Drawing.Color.White;
            this.labelSchoolSharedFileFileDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelSchoolSharedFileFileDescription.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSchoolSharedFileFileDescription.Location = new System.Drawing.Point(3, 23);
            this.labelSchoolSharedFileFileDescription.Multiline = true;
            this.labelSchoolSharedFileFileDescription.Name = "labelSchoolSharedFileFileDescription";
            this.labelSchoolSharedFileFileDescription.ReadOnly = true;
            this.labelSchoolSharedFileFileDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.labelSchoolSharedFileFileDescription.Size = new System.Drawing.Size(756, 85);
            this.labelSchoolSharedFileFileDescription.TabIndex = 4;
            // 
            // tabPageAcademicAffairsSystem
            // 
            this.tabPageAcademicAffairsSystem.BackColor = System.Drawing.Color.White;
            this.tabPageAcademicAffairsSystem.Controls.Add(this.buttonSyllabusReference);
            this.tabPageAcademicAffairsSystem.Controls.Add(this.buttonSchoolRegisterInformation);
            this.tabPageAcademicAffairsSystem.Controls.Add(this.webView2AcademicAffairsSystem);
            this.tabPageAcademicAffairsSystem.Controls.Add(this.buttonCurriculumInformation);
            this.tabPageAcademicAffairsSystem.Controls.Add(this.buttonCreditAcquisitionInformation);
            this.tabPageAcademicAffairsSystem.Controls.Add(this.buttonResultInformation);
            this.tabPageAcademicAffairsSystem.Location = new System.Drawing.Point(4, 22);
            this.tabPageAcademicAffairsSystem.Name = "tabPageAcademicAffairsSystem";
            this.tabPageAcademicAffairsSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAcademicAffairsSystem.Size = new System.Drawing.Size(768, 319);
            this.tabPageAcademicAffairsSystem.TabIndex = 8;
            this.tabPageAcademicAffairsSystem.Text = "教務システム";
            // 
            // buttonSyllabusReference
            // 
            this.buttonSyllabusReference.AutoSize = true;
            this.buttonSyllabusReference.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSyllabusReference.Depth = 0;
            this.buttonSyllabusReference.Icon = null;
            this.buttonSyllabusReference.Location = new System.Drawing.Point(392, 0);
            this.buttonSyllabusReference.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSyllabusReference.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSyllabusReference.Name = "buttonSyllabusReference";
            this.buttonSyllabusReference.Primary = false;
            this.buttonSyllabusReference.Size = new System.Drawing.Size(98, 36);
            this.buttonSyllabusReference.TabIndex = 5;
            this.buttonSyllabusReference.Text = "シラバス参照";
            this.buttonSyllabusReference.UseVisualStyleBackColor = true;
            this.buttonSyllabusReference.Click += new System.EventHandler(this.buttonSyllabusReference_Click);
            // 
            // buttonSchoolRegisterInformation
            // 
            this.buttonSchoolRegisterInformation.AutoSize = true;
            this.buttonSchoolRegisterInformation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSchoolRegisterInformation.Depth = 0;
            this.buttonSchoolRegisterInformation.Icon = null;
            this.buttonSchoolRegisterInformation.Location = new System.Drawing.Point(303, 0);
            this.buttonSchoolRegisterInformation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSchoolRegisterInformation.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSchoolRegisterInformation.Name = "buttonSchoolRegisterInformation";
            this.buttonSchoolRegisterInformation.Primary = false;
            this.buttonSchoolRegisterInformation.Size = new System.Drawing.Size(81, 36);
            this.buttonSchoolRegisterInformation.TabIndex = 4;
            this.buttonSchoolRegisterInformation.Text = "学籍情報";
            this.buttonSchoolRegisterInformation.UseVisualStyleBackColor = true;
            this.buttonSchoolRegisterInformation.Click += new System.EventHandler(this.buttonSchoolRegisterInformation_Click);
            // 
            // webView2AcademicAffairsSystem
            // 
            this.webView2AcademicAffairsSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView2AcademicAffairsSystem.CreationProperties = null;
            this.webView2AcademicAffairsSystem.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2AcademicAffairsSystem.Location = new System.Drawing.Point(0, 45);
            this.webView2AcademicAffairsSystem.Name = "webView2AcademicAffairsSystem";
            this.webView2AcademicAffairsSystem.Size = new System.Drawing.Size(768, 274);
            this.webView2AcademicAffairsSystem.TabIndex = 6;
            this.webView2AcademicAffairsSystem.ZoomFactor = 1D;
            // 
            // buttonCurriculumInformation
            // 
            this.buttonCurriculumInformation.AutoSize = true;
            this.buttonCurriculumInformation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCurriculumInformation.Depth = 0;
            this.buttonCurriculumInformation.Icon = null;
            this.buttonCurriculumInformation.Location = new System.Drawing.Point(209, 0);
            this.buttonCurriculumInformation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCurriculumInformation.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCurriculumInformation.Name = "buttonCurriculumInformation";
            this.buttonCurriculumInformation.Primary = false;
            this.buttonCurriculumInformation.Size = new System.Drawing.Size(86, 36);
            this.buttonCurriculumInformation.TabIndex = 3;
            this.buttonCurriculumInformation.Text = "カリキュラム";
            this.buttonCurriculumInformation.UseVisualStyleBackColor = true;
            this.buttonCurriculumInformation.Click += new System.EventHandler(this.buttonCurriculumInformation_Click);
            // 
            // buttonCreditAcquisitionInformation
            // 
            this.buttonCreditAcquisitionInformation.AutoSize = true;
            this.buttonCreditAcquisitionInformation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCreditAcquisitionInformation.Depth = 0;
            this.buttonCreditAcquisitionInformation.Icon = null;
            this.buttonCreditAcquisitionInformation.Location = new System.Drawing.Point(89, 0);
            this.buttonCreditAcquisitionInformation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCreditAcquisitionInformation.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCreditAcquisitionInformation.Name = "buttonCreditAcquisitionInformation";
            this.buttonCreditAcquisitionInformation.Primary = false;
            this.buttonCreditAcquisitionInformation.Size = new System.Drawing.Size(112, 36);
            this.buttonCreditAcquisitionInformation.TabIndex = 2;
            this.buttonCreditAcquisitionInformation.Text = "単位修得情報";
            this.buttonCreditAcquisitionInformation.UseVisualStyleBackColor = true;
            this.buttonCreditAcquisitionInformation.Click += new System.EventHandler(this.buttonCreditAcquisitionInformation_Click);
            // 
            // buttonResultInformation
            // 
            this.buttonResultInformation.AutoSize = true;
            this.buttonResultInformation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonResultInformation.Depth = 0;
            this.buttonResultInformation.Icon = null;
            this.buttonResultInformation.Location = new System.Drawing.Point(0, 0);
            this.buttonResultInformation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonResultInformation.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonResultInformation.Name = "buttonResultInformation";
            this.buttonResultInformation.Primary = false;
            this.buttonResultInformation.Size = new System.Drawing.Size(81, 36);
            this.buttonResultInformation.TabIndex = 1;
            this.buttonResultInformation.Text = "成績情報";
            this.buttonResultInformation.UseVisualStyleBackColor = true;
            this.buttonResultInformation.Click += new System.EventHandler(this.buttonResultInformation_Click);
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
            this.materialTabSelector.TabIndex = 0;
            this.materialTabSelector.TabStop = false;
            this.materialTabSelector.Text = "materialTabSelector";
            // 
            // 表示ToolStripMenuItem
            // 
            this.表示ToolStripMenuItem.Name = "表示ToolStripMenuItem";
            this.表示ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrom_FormClosed);
            this.Shown += new System.EventHandler(this.MainFrom_Shown);
            this.materialTabControl.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).EndInit();
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
            this.tabPageSchoolContact.ResumeLayout(false);
            this.splitContainerSchoolContact.Panel1.ResumeLayout(false);
            this.splitContainerSchoolContact.Panel1.PerformLayout();
            this.splitContainerSchoolContact.Panel2.ResumeLayout(false);
            this.splitContainerSchoolContact.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSchoolContact)).EndInit();
            this.splitContainerSchoolContact.ResumeLayout(false);
            this.tabPageClassSharedFile.ResumeLayout(false);
            this.splitContainerClassSharedFile.Panel1.ResumeLayout(false);
            this.splitContainerClassSharedFile.Panel1.PerformLayout();
            this.splitContainerClassSharedFile.Panel2.ResumeLayout(false);
            this.splitContainerClassSharedFile.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerClassSharedFile)).EndInit();
            this.splitContainerClassSharedFile.ResumeLayout(false);
            this.tabPageSchoolSharedFile.ResumeLayout(false);
            this.splitContainerSchoolSharedFile.Panel1.ResumeLayout(false);
            this.splitContainerSchoolSharedFile.Panel1.PerformLayout();
            this.splitContainerSchoolSharedFile.Panel2.ResumeLayout(false);
            this.splitContainerSchoolSharedFile.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSchoolSharedFile)).EndInit();
            this.splitContainerSchoolSharedFile.ResumeLayout(false);
            this.tabPageAcademicAffairsSystem.ResumeLayout(false);
            this.tabPageAcademicAffairsSystem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2AcademicAffairsSystem)).EndInit();
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
        private MaterialSkin.Controls.MaterialFlatButton buttonClassContactFile;
        private MaterialSkin.Controls.MaterialCheckBox checkBoxClassContactFileDownload;
        private MaterialSkin.Controls.MaterialFlatButton buttonTwitter;
        private System.Windows.Forms.ColumnHeader columnVisible2;
        private MaterialSkin.Controls.MaterialCheckBox checkBoxAllVisible;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxStudentCode;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxStudentName;
        private System.Windows.Forms.TabPage tabPageSchoolContact;
        private System.Windows.Forms.SplitContainer splitContainerSchoolContact;
        private MaterialSkin.Controls.MaterialCheckBox checkBoxSchoolContactFileDownload;
        private MaterialSkin.Controls.MaterialRaisedButton buttonRefreshSchoolContact;
        private MaterialSkin.Controls.MaterialListView listViewSchoolContact;
        private System.Windows.Forms.ColumnHeader columnEmpty3;
        private System.Windows.Forms.ColumnHeader columnCategory3;
        private System.Windows.Forms.ColumnHeader columnTitle3;
        private System.Windows.Forms.ColumnHeader columnContent3;
        private System.Windows.Forms.ColumnHeader columnContactTime3;
        private MaterialSkin.Controls.MaterialFlatButton buttonSchoolContactFile;
        private System.Windows.Forms.Label labelSchoolContactTitle;
        private System.Windows.Forms.TextBox labelSchoolContactContent;
        private System.Windows.Forms.TabPage tabPageClassSharedFile;
        private System.Windows.Forms.SplitContainer splitContainerClassSharedFile;
        private MaterialSkin.Controls.MaterialRaisedButton buttonRefreshClassSharedFile;
        private MaterialSkin.Controls.MaterialListView listViewClassSharedFile;
        private System.Windows.Forms.ColumnHeader columnEmpty4;
        private System.Windows.Forms.ColumnHeader columnClassSubjects4;
        private System.Windows.Forms.ColumnHeader columnTitle4;
        private System.Windows.Forms.ColumnHeader columnFileDescription4;
        private System.Windows.Forms.ColumnHeader columnUpdateTime4;
        private MaterialSkin.Controls.MaterialFlatButton buttonClassSharedFileFile;
        private System.Windows.Forms.Label labelClassSharedFileTitle;
        private System.Windows.Forms.TextBox labelClassSharedFileFileDescription;
        private System.Windows.Forms.TabPage tabPageSchoolSharedFile;
        private System.Windows.Forms.SplitContainer splitContainerSchoolSharedFile;
        private MaterialSkin.Controls.MaterialRaisedButton buttonRefreshSchoolSharedFile;
        private MaterialSkin.Controls.MaterialListView listViewSchoolSharedFile;
        private System.Windows.Forms.ColumnHeader columnEmpty5;
        private System.Windows.Forms.ColumnHeader columnCategory5;
        private System.Windows.Forms.ColumnHeader columnTitle5;
        private System.Windows.Forms.ColumnHeader columnFileDescription5;
        private System.Windows.Forms.ColumnHeader columnUpdateTime5;
        private MaterialSkin.Controls.MaterialFlatButton buttonSchoolSharedFileFile;
        private System.Windows.Forms.Label labelSchoolSharedFileTitle;
        private System.Windows.Forms.TextBox labelSchoolSharedFileFileDescription;
        private System.Windows.Forms.TabPage tabPageAcademicAffairsSystem;
        private MaterialSkin.Controls.MaterialFlatButton buttonResultInformation;
        private MaterialSkin.Controls.MaterialFlatButton buttonCreditAcquisitionInformation;
        private MaterialSkin.Controls.MaterialFlatButton buttonCurriculumInformation;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2AcademicAffairsSystem;
        private MaterialSkin.Controls.MaterialFlatButton buttonSchoolRegisterInformation;
        private MaterialSkin.Controls.MaterialFlatButton buttonSyllabusReference;
        private MaterialSkin.Controls.MaterialFlatButton buttonUpdate;
        private System.Windows.Forms.ToolStripMenuItem 表示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
    }
}

