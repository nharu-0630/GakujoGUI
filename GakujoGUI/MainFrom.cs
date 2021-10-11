using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using Discord;
using System.Threading;

namespace GakujoGUI
{
    public partial class MainFrom : MaterialForm
    {
        public MainFrom()
        {
            InitializeComponent();
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        #region 変数

        private GakujoAPI gakujoAPI = new GakujoAPI();
        private List<ClassContact> _classContactList = new List<ClassContact> { };
        private List<ClassContact> classContactList
        {
            get
            {
                return _classContactList;
            }
            set
            {
                _classContactList = value;
                try
                {
                    StreamWriter streamWriter = new StreamWriter("classContact.json", false, Encoding.UTF8);
                    streamWriter.WriteLine(JsonConvert.SerializeObject(classContactList, Formatting.None));
                    streamWriter.Close();
                }
                catch { }
                listViewClassContact.Items.Clear();
                foreach (ClassContact classContact in classContactList)
                {
                    listViewClassContact.Items.Add(new ListViewItem(new string[] { "", classContact.classSubjects, classContact.title, classContact.content, classContact.contactTime }));
                }
            }
        }
        private List<Report> _reportList = new List<Report> { };
        private List<Report> reportList
        {
            get
            {
                return _reportList;
            }
            set
            {
                _reportList = value;
                try
                {
                    StreamWriter streamWriter = new StreamWriter("report.json", false, Encoding.UTF8);
                    streamWriter.WriteLine(JsonConvert.SerializeObject(reportList, Formatting.None));
                    streamWriter.Close();
                }
                catch { }
                listViewReport.Items.Clear();
                foreach (Report report in reportList)
                {
                    listViewReport.Items.Add(new ListViewItem(new string[] { "", report.classSubjects, report.title, report.status, report.submissionPeriod, report.lastSubmissionTime, report.operation }));
                }
            }
        }
        private List<Quiz> _quizList = new List<Quiz> { };
        private List<Quiz> quizList
        {
            get
            {
                return _quizList;
            }
            set
            {
                _quizList = value;
                try
                {
                    StreamWriter streamWriter = new StreamWriter("quiz.json", false, Encoding.UTF8);
                    streamWriter.WriteLine(JsonConvert.SerializeObject(quizList, Formatting.None));
                    streamWriter.Close();
                }
                catch { }
                listViewQuiz.Items.Clear();
                foreach (Quiz quiz in quizList.Where(quiz => quiz.invisible == false))
                {
                    listViewQuiz.Items.Add(new ListViewItem(new string[] { "", "非表示", quiz.classSubjects, quiz.title, quiz.status, quiz.submissionPeriod, quiz.submissionStatus, quiz.operation }));
                }
            }
        }
        private List<SchoolContact> _schoolContactList = new List<SchoolContact> { };
        private List<SchoolContact> schoolContactList
        {
            get
            {
                return _schoolContactList;
            }
            set
            {
                _schoolContactList = value;
                try
                {
                    StreamWriter streamWriter = new StreamWriter("schoolContact.json", false, Encoding.UTF8);
                    streamWriter.WriteLine(JsonConvert.SerializeObject(schoolContactList, Formatting.None));
                    streamWriter.Close();
                }
                catch { }
                listViewSchoolContact.Items.Clear();
                foreach (SchoolContact schoolContact in schoolContactList)
                {
                    listViewSchoolContact.Items.Add(new ListViewItem(new string[] { "", schoolContact.category, schoolContact.title, schoolContact.content, schoolContact.contactTime }));
                }
            }
        }
        private List<ClassSharedFile> _classSharedFileList = new List<ClassSharedFile> { };
        private List<ClassSharedFile> classSharedFileList
        {
            get
            {
                return _classSharedFileList;
            }
            set
            {
                _classSharedFileList = value;
                try
                {
                    StreamWriter streamWriter = new StreamWriter("classSharedFile.json", false, Encoding.UTF8);
                    streamWriter.WriteLine(JsonConvert.SerializeObject(classSharedFileList, Formatting.None));
                    streamWriter.Close();
                }
                catch { }
                listViewClassSharedFile.Items.Clear();
                foreach (ClassSharedFile classSharedFile in classSharedFileList)
                {
                    listViewClassSharedFile.Items.Add(new ListViewItem(new string[] { "", classSharedFile.classSubjects, classSharedFile.title, classSharedFile.fileDescription, classSharedFile.updateTime }));
                }
            }
        }
        private List<SchoolSharedFile> _schoolSharedFileList = new List<SchoolSharedFile> { };
        private List<SchoolSharedFile> schoolSharedFileList
        {
            get
            {
                return _schoolSharedFileList;
            }
            set
            {
                _schoolSharedFileList = value;
                try
                {
                    StreamWriter streamWriter = new StreamWriter("schoolSharedFile.json", false, Encoding.UTF8);
                    streamWriter.WriteLine(JsonConvert.SerializeObject(schoolSharedFileList, Formatting.None));
                    streamWriter.Close();
                }
                catch { }
                listViewSchoolSharedFile.Items.Clear();
                foreach (SchoolSharedFile schoolSharedFile in schoolSharedFileList)
                {
                    listViewSchoolSharedFile.Items.Add(new ListViewItem(new string[] { "", schoolSharedFile.category, schoolSharedFile.title, schoolSharedFile.fileDescription, schoolSharedFile.updateTime }));
                }
            }
        }
        private List<MaterialFlatButton> buttonClassContactFileList = new List<MaterialFlatButton> { };
        private List<MaterialFlatButton> buttonSchoolContactFileList = new List<MaterialFlatButton> { };
        private List<MaterialFlatButton> buttonClassSharedFileFileList = new List<MaterialFlatButton> { };
        private List<MaterialFlatButton> buttonSchoolSharedFileFileList = new List<MaterialFlatButton> { };
        private readonly string downloadPath = Environment.CurrentDirectory + "/download/";
        private MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        private bool _gakujoLogin = false;
        private bool gakujoLogin
        {
            get
            {
                return _gakujoLogin;
            }
            set
            {
                _gakujoLogin = value;
                if (gakujoLogin)
                {
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.Blue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);
                }
                else
                {
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                }
            }
        }
        private bool dialogShow = true;

        #endregion

        #region フォーム

        private void LoadJson()
        {
            if (File.Exists("account.json"))
            {
                StreamReader streamReader = new StreamReader("account.json", Encoding.UTF8);
                gakujoAPI.account = JsonConvert.DeserializeObject<Account>(streamReader.ReadToEnd());
                streamReader.Close();
                textBoxUserId.Text = gakujoAPI.account.userId;
                textBoxPassWord.Text = gakujoAPI.account.passWord;
                textBoxStudentCode.Text = gakujoAPI.account.studentCode;
                textBoxStudentName.Text = gakujoAPI.account.studentName;
            }
            if (File.Exists("classContact.json"))
            {
                StreamReader streamReader = new StreamReader("classContact.json", Encoding.UTF8);
                classContactList = JsonConvert.DeserializeObject<List<ClassContact>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            if (File.Exists("report.json"))
            {
                StreamReader streamReader = new StreamReader("report.json", Encoding.UTF8);
                reportList = JsonConvert.DeserializeObject<List<Report>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            if (File.Exists("quiz.json"))
            {
                StreamReader streamReader = new StreamReader("quiz.json", Encoding.UTF8);
                quizList = JsonConvert.DeserializeObject<List<Quiz>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            if (File.Exists("schoolContact.json"))
            {
                StreamReader streamReader = new StreamReader("schoolContact.json", Encoding.UTF8);
                schoolContactList = JsonConvert.DeserializeObject<List<SchoolContact>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            if (File.Exists("classSharedFile.json"))
            {
                StreamReader streamReader = new StreamReader("classSharedFile.json", Encoding.UTF8);
                classSharedFileList = JsonConvert.DeserializeObject<List<ClassSharedFile>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            if (File.Exists("schoolSharedFile.json"))
            {
                StreamReader streamReader = new StreamReader("schoolSharedFile.json", Encoding.UTF8);
                schoolSharedFileList = JsonConvert.DeserializeObject<List<SchoolSharedFile>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
        }

        private void buttonTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/xyzyxJP");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string latestVersion = gakujoAPI.GetLatestVersion();
            string currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (latestVersion == currentVersion)
            {
                using (TextOutputBox textOutputBox = new TextOutputBox())
                {
                    textOutputBox.Set("GakujoGUI", "現在バージョン : " + currentVersion + Environment.NewLine + "GakujoGUIは最新バージョンです", MessageBoxButtons.OK);
                    textOutputBox.ShowDialog();
                }
            }
            else
            {
                using (TextOutputBox textOutputBox = new TextOutputBox())
                {
                    textOutputBox.Set("GakujoGUI", "現在バージョン : " + currentVersion + Environment.NewLine + "最新バージョン : " + latestVersion + Environment.NewLine + "新しいバージョンがあります" + Environment.NewLine + "ダウンロードページを開きますか", MessageBoxButtons.YesNo);
                    if (textOutputBox.ShowDialog() == DialogResult.Yes)
                    {
                        Process.Start("https://github.com/xyzyxJP/GakujoGUI/releases/latest");
                    }
                }
            }
        }

        private void MainFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            gakujoAPI.SaveAccount();
            Properties.Settings.Default.classContactFileDownload = checkBoxClassContactFileDownload.Checked;
            Properties.Settings.Default.schoolContactFileDownload = checkBoxSchoolContactFileDownload.Checked;
            Properties.Settings.Default.Save();
        }

        private async void MainFrom_Shown(object sender, EventArgs e)
        {
            Text += " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            checkBoxClassContactFileDownload.Checked = Properties.Settings.Default.classContactFileDownload;
            checkBoxSchoolContactFileDownload.Checked = Properties.Settings.Default.schoolContactFileDownload;
            string[] argsArray = Environment.GetCommandLineArgs();
            dialogShow = argsArray.Contains("-debug");
            if (argsArray.Contains("+year") && argsArray.Length >= Array.IndexOf(argsArray, "+year") + 1)
            {
                gakujoAPI.schoolYear = argsArray[Array.IndexOf(argsArray, "+year") + 1];
            }
            if (argsArray.Contains("+semester") && argsArray.Length >= Array.IndexOf(argsArray, "+semester") + 1)
            {
                gakujoAPI.semesterCode = argsArray[Array.IndexOf(argsArray, "+semester") + 1];
            }
            LoadJson();
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                gakujoLogin = await Task.Run(() => gakujoAPI.SetCookies(progress));
                progressBox.Close();
            }
            if (gakujoLogin)
            {
                using (TextOutputBox textOutputBox = new TextOutputBox())
                {
                    textOutputBox.Set("GakujoGUI", "キャッシュログインに成功しました。", MessageBoxButtons.OK);
                    textOutputBox.ShowDialog();
                }
            }
            else
            {
                //textOutputBox.Set("GakujoGUI", "キャッシュログインに失敗しました。", MessageBoxButtons.OK);
            }
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if (gakujoLogin)
            {
                using (TextOutputBox textOutputBox = new TextOutputBox())
                {
                    textOutputBox.Set("GakujoGUI", "再ログインしますか。", MessageBoxButtons.YesNo);
                    switch (textOutputBox.ShowDialog())
                    {
                        case DialogResult.No:
                            return;
                    }
                }
            }
            buttonLogin.Enabled = false;
            gakujoAPI.account.userId = textBoxUserId.Text;
            gakujoAPI.account.passWord = textBoxPassWord.Text;
            gakujoAPI.account.studentName = textBoxStudentName.Text;
            gakujoAPI.account.studentCode = textBoxStudentCode.Text;
            gakujoAPI.SaveAccount();
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                gakujoLogin = await Task.Run(() => gakujoAPI.Login(progress));
                progressBox.Close();
            }
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                if (gakujoLogin)
                {
                    textOutputBox.Set("GakujoGUI", "ログインに成功しました。", MessageBoxButtons.OK);
                }
                else
                {
                    textOutputBox.Set("GakujoGUI", "ログインに失敗しました。", MessageBoxButtons.OK);
                }
                textOutputBox.ShowDialog();
            }
            gakujoAPI.WriteCookiesToFile("cookies");
            buttonLogin.Enabled = true;
        }

        private void GetListViewSeletColumnIndex(MaterialListView materialListView, int[] indexArray)
        {
            Point point = materialListView.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = materialListView.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
            indexArray[0] = selectIndex;
            indexArray[1] = columnIndex;
        }

        #endregion

        #region 授業連絡

        private async void buttonRefreshClassContact_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            buttonRefreshClassContact.Enabled = false;
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                ClassContact classContact = new ClassContact { classSubjects = "", title = "", contactTime = "" }; ;
                if (classContactList.Count != 0)
                {
                    classContact = classContactList[0];
                }
                List<ClassContact> tempClassContactList = await Task.Run(() => gakujoAPI.GetClassContactList(progress, classContact));
                progressBox.Close();
                if (tempClassContactList.Count != 0 && dialogShow)
                {
                    using (TextOutputBox textOutputBox = new TextOutputBox())
                    {
                        textOutputBox.Set("GakujoGUI", tempClassContactList.Count + "件の授業連絡を取得しました。", MessageBoxButtons.OK);
                        textOutputBox.ShowDialog();
                    }
                }
                tempClassContactList.AddRange(classContactList);
                classContactList = tempClassContactList;
            }
            classContactList = classContactList;
            buttonRefreshClassContact.Enabled = true;
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(downloadPath + ((Button)sender).Text))
            {
                Process.Start(downloadPath + ((Button)sender).Text);
            }
        }

        private void listViewClassContact_MouseMove(object sender, MouseEventArgs e)
        {
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewClassContact, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (columnIndex == 2 || columnIndex == 3)
            {
                listViewClassContact.Cursor = Cursors.Hand;
            }
            else
            {
                listViewClassContact.Cursor = Cursors.Default;
            }
        }

        private async void listViewClassContact_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewClassContact.SelectedItems.Count != 1)
            {
                return;
            }
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewClassContact, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (listViewClassContact.SelectedItems.Count != 1 || (columnIndex != 2 && columnIndex != 3))
            {
                return;
            }
            if (classContactList[selectIndex].content != null)
            {
            }
            else
            {
                if (!gakujoLogin)
                {
                    return;
                }
                using (TextOutputBox textOutputBox = new TextOutputBox())
                {
                    textOutputBox.Set("GakujoGUI", "詳細を取得しますか。", MessageBoxButtons.YesNo);
                    switch (textOutputBox.ShowDialog())
                    {
                        case DialogResult.Yes:
                            using (ProgressBox progressBox = new ProgressBox())
                            {
                                progressBox.Set("GakujoGUI", "");
                                progressBox.Show();
                                Progress<double> progress = new Progress<double>(progressBox.Update);
                                ClassContact classContact = await Task.Run(() => gakujoAPI.GetClassContact(progress, classContactList[selectIndex], selectIndex, checkBoxClassContactFileDownload.Checked, downloadPath));
                                progressBox.Close();
                                classContactList[selectIndex] = classContact;
                                classContactList = classContactList;
                            }
                            break;
                        default:
                            return;
                    }
                }
            }
            ShowClassContact(selectIndex);
        }

        private async void listViewClassContact_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewClassContact.SelectedItems.Count != 1)
            {
                return;
            }
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewClassContact, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (columnIndex != 2 && columnIndex != 3)
            {
                return;
            }
            if (!gakujoLogin)
            {
                return;
            }
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", "詳細を再取得しますか。", MessageBoxButtons.YesNo);
                switch (textOutputBox.ShowDialog())
                {
                    case DialogResult.Yes:
                        using (ProgressBox progressBox = new ProgressBox())
                        {
                            progressBox.Set("GakujoGUI", "");
                            progressBox.Show();
                            Progress<double> progress = new Progress<double>(progressBox.Update);
                            ClassContact classContact = await Task.Run(() => gakujoAPI.GetClassContact(progress, classContactList[selectIndex], selectIndex, checkBoxClassContactFileDownload.Checked, downloadPath));
                            progressBox.Close();
                            classContactList[selectIndex] = classContact;
                            classContactList = classContactList;
                        }
                        break;
                    default:
                        return;
                }
            }
            ShowClassContact(selectIndex);
        }

        private void ShowClassContact(int selectIndex)
        {
            labelClassContactTitle.Text = classContactList[selectIndex].title;
            labelClassContactContent.Text = classContactList[selectIndex].content;
            foreach (MaterialFlatButton flatButton in buttonClassContactFileList)
            {
                flatButton.Dispose();
            }
            buttonClassContactFileList.Clear();
            if (classContactList[selectIndex].file != "")
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(classContactList[selectIndex].file);
                while (stringReader.Peek() > -1)
                {
                    MaterialFlatButton fileButton = new MaterialFlatButton
                    {
                        Text = stringReader.ReadLine(),
                        Anchor = (AnchorStyles.Bottom | AnchorStyles.Left)
                    };
                    if (buttonClassContactFileList.Count == 0)
                    {
                        fileButton.Location = buttonClassContactFile.Location;
                    }
                    else
                    {
                        fileButton.Location = new Point(buttonClassContactFileList[buttonClassContactFileList.Count - 1].Location.X + buttonClassContactFileList[buttonClassContactFileList.Count - 1].Size.Width, buttonClassContactFileList[buttonClassContactFileList.Count - 1].Location.Y);
                    }
                    fileButton.Click += FileButton_Click;
                    splitContainerClassContact.Panel2.Controls.Add(fileButton);
                    fileButton.BringToFront();
                    buttonClassContactFileList.Add(fileButton);
                }
            }
        }

        #endregion

        #region レポート

        private async void buttonRefreshReport_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            buttonRefreshReport.Enabled = false;
            int lastReportListCount = reportList.Count;
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                reportList = await Task.Run(() => gakujoAPI.GetReportList(progress));
                StreamWriter streamWriter = new StreamWriter("report.json", false, Encoding.UTF8);
                streamWriter.WriteLine(JsonConvert.SerializeObject(reportList, Formatting.None));
                streamWriter.Close();
                progressBox.Close();
                if (lastReportListCount != reportList.Count && dialogShow)
                {
                    using (TextOutputBox textOutputBox = new TextOutputBox())
                    {
                        textOutputBox.Set("GakujoGUI", reportList.Count + "件のレポートを取得しました。", MessageBoxButtons.OK);
                        textOutputBox.ShowDialog();
                    }
                }
            }
            buttonRefreshReport.Enabled = true;
        }

        private void listViewReport_MouseMove(object sender, MouseEventArgs e)
        {
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewReport, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (columnIndex == 2)
            {
                listViewReport.Cursor = Cursors.Hand;
            }
            else if (columnIndex == 6 && (reportList[selectIndex].operation == "提出開始" || reportList[selectIndex].operation == "提出取消"))
            {
                listViewReport.Cursor = Cursors.Hand;
            }
            else
            {
                listViewReport.Cursor = Cursors.Default;
            }
        }

        private void listViewReport_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewReport.SelectedItems.Count != 1)
            {
                return;
            }
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewReport, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (!gakujoLogin)
            {
                return;
            }
            if (columnIndex == 2)
            {
                string reportHtml = "";
                using (ProgressBox progressBox = new ProgressBox())
                {
                    progressBox.Set("GakujoGUI", "");
                    progressBox.Show();
                    Progress<double> progress = new Progress<double>(progressBox.Update);
                    reportHtml = Task.Run(() => gakujoAPI.GetReportDetail(progress, reportList[selectIndex])).Result;
                    progressBox.Close();
                }
                reportHtml = reportHtml.Replace("<a href=\"javascript:void(0);\" class=\"btn_large\" onclick=\"formSubmit('reportSubmit');\"><span class=\"btn-side\"><span class=\"icon-answer\">提出開始</span></span></a>", "").Replace("<a href=\"javascript:void(0);\" class=\"btn\" onclick=\"formSubmit('backScreen')\"><span class=\"btn-side\"><span class=\"icon-back\">戻る</span></span></a>", "");
                using (BrowserBox browserBox = new BrowserBox())
                {
                    browserBox.SetHtml("GakujoGUI", reportHtml);
                    browserBox.ShowDialog();
                }
            }
            else if (columnIndex == 6 && reportList[selectIndex].operation == "提出開始")
            {
                using (FileTextInputBox fileTextInputBox = new FileTextInputBox())
                {
                    fileTextInputBox.Set("GakujoGUI", reportList[selectIndex].classSubjects + Environment.NewLine + reportList[selectIndex].title);
                    if (fileTextInputBox.ShowDialog() == DialogResult.OK)
                    {
                        using (ProgressBox progressBox = new ProgressBox())
                        {
                            progressBox.Set("GakujoGUI", "");
                            progressBox.Show();
                            Progress<double> progress = new Progress<double>(progressBox.Update);
                            Task.Run(() => gakujoAPI.SubmitReport(progress, reportList[selectIndex].reportId, new string[] { fileTextInputBox.inputFile }, fileTextInputBox.inputText));
                            progressBox.Close();
                            Enabled = true;
                        }
                        using (TextOutputBox textOutputBox = new TextOutputBox())
                        {
                            textOutputBox.Set("GakujoGUI", "提出が完了しました。", MessageBoxButtons.OK);
                            textOutputBox.ShowDialog();
                        }
                    }
                }
            }
            else if (columnIndex == 6 && reportList[selectIndex].operation == "提出取消")
            {
                using (TextOutputBox textOutputBox = new TextOutputBox())
                {
                    textOutputBox.Set("GakujoGUI", reportList[selectIndex].classSubjects + Environment.NewLine + reportList[selectIndex].title + Environment.NewLine + "を提出取消しますか。", MessageBoxButtons.YesNo);
                    if (textOutputBox.ShowDialog() == DialogResult.Yes)
                    {
                        using (ProgressBox progressBox = new ProgressBox())
                        {
                            progressBox.Set("GakujoGUI", "");
                            progressBox.Show();
                            Progress<double> progress = new Progress<double>(progressBox.Update);
                            gakujoAPI.CancelReport(progress, reportList[selectIndex]);
                            progressBox.Close();
                        }
                    }
                }
            }
        }

        #endregion

        #region 小テスト

        private async void buttonRefreshQuiz_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            buttonRefreshQuiz.Enabled = false;
            int lastQuizListCount = quizList.Count;
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                quizList = await Task.Run(() => gakujoAPI.GetQuizList(progress));
                StreamWriter streamWriter = new StreamWriter("quiz.json", false, Encoding.UTF8);
                streamWriter.WriteLine(JsonConvert.SerializeObject(quizList, Formatting.None));
                streamWriter.Close();
                progressBox.Close();
                if (lastQuizListCount != quizList.Count && dialogShow)
                {
                    using (TextOutputBox textOutputBox = new TextOutputBox())
                    {
                        textOutputBox.Set("GakujoGUI", quizList.Count + "件の小テストを取得しました。", MessageBoxButtons.OK);
                        textOutputBox.ShowDialog();
                    }
                }
            }
            buttonRefreshQuiz.Enabled = true;
        }

        private void listViewQuiz_MouseMove(object sender, MouseEventArgs e)
        {
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewQuiz, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if ((columnIndex == 7 && (quizList.Where(quiz => (checkBoxAllVisible.Checked || (!quiz.invisible && !checkBoxAllVisible.Checked))).ToArray()[selectIndex].operation == "提出開始" || quizList.Where(quiz => (checkBoxAllVisible.Checked || (!quiz.invisible && !checkBoxAllVisible.Checked))).ToArray()[selectIndex].operation == "提出取消")) || (columnIndex == 1) || (columnIndex == 3))
            {
                listViewQuiz.Cursor = Cursors.Hand;
            }
            else
            {
                listViewQuiz.Cursor = Cursors.Default;
            }
        }

        private async void listViewQuiz_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewQuiz.SelectedItems.Count != 1)
            {
                return;
            }
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewQuiz, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            List<Quiz> tempQuizList = quizList.Where(quiz => (checkBoxAllVisible.Checked || (!quiz.invisible && !checkBoxAllVisible.Checked))).ToList();
            if (!gakujoLogin)
            {
                return;
            }
            if (columnIndex == 7 && tempQuizList[selectIndex].operation == "提出開始")
            {
                using (QuizForm quizForm = new QuizForm())
                {
                    using (ProgressBox progressBox = new ProgressBox())
                    {
                        progressBox.Set("GakujoGUI", "");
                        progressBox.Show();
                        Progress<double> progress = new Progress<double>(progressBox.Update);
                        string quizDetail = (await Task.Run(() => gakujoAPI.GetQuizDetail(progress, tempQuizList[selectIndex].id))).Replace("<a href=\"javascript:void(0);\" class=\"btn_large\" onclick=\"formSubmit('tempSaveAction')\"><span class=\"btn-side\"><span class=\"icon-save_temp\">一時保存</span></span></a>", "").Replace("<a href=\"javascript:void(0);\" class=\"btn_large ml20\" onclick=\"formSubmit('confirmAction')\"><span class=\"btn-side\"><span class=\"icon-confirm\">確認</span></span></a>", "").Replace("<a href=\"javascript:void(0);\" class=\"btn\" onclick=\"formSubmit('backScreen')\"><span class=\"btn-side\"><span class=\"icon-back\">戻る</span></span></a>", "<a href=\"javascript:void(0);\" class=\"btn\" onclick=\"window.chrome.webview.postMessage(GetOutputText())\"><span class=\"btn-side\"><span class=\"icon-back\">登録</span></span></a>");
                        progressBox.Close();
                        quizForm.Set("GakujoGUI", "<script type=\"text/javascript\">function GetOutputText(){ var outputText = \"\"; for (var i = 10; true; i++){ var jLimit = document.getElementsByName(\"value\" + i).length; if (jLimit === 0){ break; } for (var j = 0; j < jLimit; j++){ if (document.getElementsByName(\"value\" + i)[j].checked){ outputText = outputText + \"&value\" + i + \"=\"; outputText = outputText +document.getElementsByName(\"value\" + i)[j].value; } } } return outputText;}</script>" + quizDetail);
                    }
                    if (quizForm.ShowDialog() == DialogResult.OK)
                    {
                        using (ProgressBox progressBox = new ProgressBox())
                        {
                            progressBox.Set("GakujoGUI", "");
                            progressBox.Show();
                            Progress<double> progress = new Progress<double>(progressBox.Update);
                            gakujoAPI.SubmitQuiz(progress, tempQuizList[selectIndex].id, quizForm.outputText);
                            progressBox.Close();
                        }
                    }

                }
            }
            else if (columnIndex == 7 && tempQuizList[selectIndex].operation == "提出取消")
            {
                using (TextOutputBox textOutputBox = new TextOutputBox())
                {
                    textOutputBox.Set("GakujoGUI", tempQuizList[selectIndex].classSubjects + Environment.NewLine + tempQuizList[selectIndex].title + Environment.NewLine + "を提出取消しますか。", MessageBoxButtons.YesNo);
                    if (textOutputBox.ShowDialog() == DialogResult.Yes)
                    {
                        using (ProgressBox progressBox = new ProgressBox())
                        {
                            progressBox.Set("GakujoGUI", "");
                            progressBox.Show();
                            Progress<double> progress = new Progress<double>(progressBox.Update);
                            gakujoAPI.CancelQuiz(progress, tempQuizList[selectIndex].id);
                            progressBox.Close();
                        }
                    }
                }
            }
            else if (columnIndex == 1)
            {
                quizList.Where(quiz => (checkBoxAllVisible.Checked || (!quiz.invisible && !checkBoxAllVisible.Checked))).ToArray()[selectIndex].invisible = !quizList.Where(quiz => (checkBoxAllVisible.Checked || (!quiz.invisible && !checkBoxAllVisible.Checked))).ToArray()[selectIndex].invisible;
                if (checkBoxAllVisible.Checked)
                {
                    listViewQuiz.Items.Clear();
                    foreach (Quiz quiz in quizList)
                    {
                        if (quiz.invisible)
                        {
                            listViewQuiz.Items.Add(new ListViewItem(new string[] { "", "表示　", quiz.classSubjects, quiz.title, quiz.status, quiz.submissionPeriod, quiz.submissionStatus, quiz.operation }));
                        }
                        else
                        {
                            listViewQuiz.Items.Add(new ListViewItem(new string[] { "", "非表示　", quiz.classSubjects, quiz.title, quiz.status, quiz.submissionPeriod, quiz.submissionStatus, quiz.operation }));
                        }
                    }
                }
                else
                {
                    listViewQuiz.Items.Clear();
                    foreach (Quiz quiz in quizList.Where(quiz => quiz.invisible == false))
                    {
                        listViewQuiz.Items.Add(new ListViewItem(new string[] { "", "非表示", quiz.classSubjects, quiz.title, quiz.status, quiz.submissionPeriod, quiz.submissionStatus, quiz.operation }));
                    }
                }
            }
            else if (columnIndex == 3)
            {
                string quizHtml = "";
                using (ProgressBox progressBox = new ProgressBox())
                {
                    progressBox.Set("GakujoGUI", "");
                    progressBox.Show();
                    Progress<double> progress = new Progress<double>(progressBox.Update);
                    quizHtml = Task.Run(() => gakujoAPI.GetQuizDetail(progress, tempQuizList[selectIndex].id)).Result;
                    HtmlDocument htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(quizHtml);
                    htmlDocument.DocumentNode.SelectSingleNode("div[2]").Remove();
                    htmlDocument.DocumentNode.SelectSingleNode("div[2]").Remove();
                    htmlDocument.DocumentNode.SelectSingleNode("p").Remove();
                    quizHtml = htmlDocument.DocumentNode.OuterHtml;
                    progressBox.Close();
                }

                using (BrowserBox browserBox = new BrowserBox())
                {
                    browserBox.SetHtml("GakujoGUI", quizHtml);
                    browserBox.ShowDialog();
                }
            }
        }

        private void checkBoxAllVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAllVisible.Checked)
            {
                listViewQuiz.Items.Clear();
                foreach (Quiz quiz in quizList)
                {
                    if (quiz.invisible)
                    {
                        listViewQuiz.Items.Add(new ListViewItem(new string[] { "", "表示　", quiz.classSubjects, quiz.title, quiz.status, quiz.submissionPeriod, quiz.submissionStatus, quiz.operation }));
                    }
                    else
                    {
                        listViewQuiz.Items.Add(new ListViewItem(new string[] { "", "非表示　", quiz.classSubjects, quiz.title, quiz.status, quiz.submissionPeriod, quiz.submissionStatus, quiz.operation }));
                    }
                }
            }
            else
            {
                listViewQuiz.Items.Clear();
                foreach (Quiz quiz in quizList.Where(quiz => quiz.invisible == false))
                {
                    listViewQuiz.Items.Add(new ListViewItem(new string[] { "", "非表示", quiz.classSubjects, quiz.title, quiz.status, quiz.submissionPeriod, quiz.submissionStatus, quiz.operation }));
                }
            }
        }

        #endregion

        #region 学内連絡

        private async void buttonRefreshSchoolContact_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            buttonRefreshSchoolContact.Enabled = false;
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                SchoolContact schoolContact = new SchoolContact { title = "", contactTime = "" }; ;
                if (schoolContactList.Count != 0)
                {
                    schoolContact = schoolContactList[0];
                }
                List<SchoolContact> tempSchoolContactList = await Task.Run(() => gakujoAPI.GetSchoolContactList(progress, schoolContact));
                progressBox.Close();
                if (tempSchoolContactList.Count != 0 && dialogShow)
                {
                    using (TextOutputBox textOutputBox = new TextOutputBox())
                    {
                        textOutputBox.Set("GakujoGUI", tempSchoolContactList.Count + "件の学内連絡を取得しました。", MessageBoxButtons.OK);
                        textOutputBox.ShowDialog();
                    }
                }
                tempSchoolContactList.AddRange(schoolContactList);
                schoolContactList = tempSchoolContactList;
            }
            schoolContactList = schoolContactList;
            buttonRefreshSchoolContact.Enabled = true;
        }

        private void listViewSchoolContact_MouseMove(object sender, MouseEventArgs e)
        {
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewSchoolContact, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (columnIndex == 2 || columnIndex == 3)
            {
                listViewSchoolContact.Cursor = Cursors.Hand;
            }
            else
            {
                listViewSchoolContact.Cursor = Cursors.Default;
            }
        }

        private async void listViewSchoolContact_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewSchoolContact.SelectedItems.Count != 1)
            {
                return;
            }
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewSchoolContact, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (columnIndex != 2 && columnIndex != 3)
            {
                return;
            }
            if (schoolContactList[selectIndex].content != null)
            {
            }
            else
            {
                if (!gakujoLogin)
                {
                    return;
                }
                using (TextOutputBox textOutputBox = new TextOutputBox())
                {
                    textOutputBox.Set("GakujoGUI", "詳細を取得しますか。", MessageBoxButtons.YesNo);
                    switch (textOutputBox.ShowDialog())
                    {
                        case DialogResult.Yes:
                            using (ProgressBox progressBox = new ProgressBox())
                            {
                                progressBox.Set("GakujoGUI", "");
                                progressBox.Show();
                                Progress<double> progress = new Progress<double>(progressBox.Update);
                                SchoolContact schoolContact = await Task.Run(() => gakujoAPI.GetSchoolContact(progress, schoolContactList[selectIndex], selectIndex, checkBoxSchoolContactFileDownload.Checked, downloadPath));
                                progressBox.Close();
                                schoolContactList[selectIndex] = schoolContact;
                                schoolContactList = schoolContactList;
                            }
                            break;
                        default:
                            return;
                    }
                }
            }
            ShowSchoolContact(selectIndex);
        }

        private async void listViewSchoolContact_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewSchoolContact.SelectedItems.Count != 1)
            {
                return;
            }
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewSchoolContact, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (columnIndex != 2 && columnIndex != 3)
            {
                return;
            }
            if (!gakujoLogin)
            {
                return;
            }
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", "詳細を再取得しますか。", MessageBoxButtons.YesNo);
                switch (textOutputBox.ShowDialog())
                {
                    case DialogResult.Yes:
                        using (ProgressBox progressBox = new ProgressBox())
                        {
                            progressBox.Set("GakujoGUI", "");
                            progressBox.Show();
                            Progress<double> progress = new Progress<double>(progressBox.Update);
                            SchoolContact schoolContact = await Task.Run(() => gakujoAPI.GetSchoolContact(progress, schoolContactList[selectIndex], selectIndex, checkBoxSchoolContactFileDownload.Checked, downloadPath));
                            progressBox.Close();
                            schoolContactList[selectIndex] = schoolContact;
                            schoolContactList = schoolContactList;
                        }
                        break;
                    default:
                        return;
                }
            }
            ShowSchoolContact(selectIndex);
        }

        private void ShowSchoolContact(int selectIndex)
        {
            labelSchoolContactTitle.Text = schoolContactList[selectIndex].title;
            labelSchoolContactContent.Text = schoolContactList[selectIndex].content;
            foreach (MaterialFlatButton flatButton in buttonSchoolContactFileList)
            {
                flatButton.Dispose();
            }
            buttonSchoolContactFileList.Clear();
            if (schoolContactList[selectIndex].file != "")
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(schoolContactList[selectIndex].file);
                while (stringReader.Peek() > -1)
                {
                    MaterialFlatButton fileButton = new MaterialFlatButton
                    {
                        Text = stringReader.ReadLine(),
                        Anchor = (AnchorStyles.Bottom | AnchorStyles.Left)
                    };
                    if (buttonSchoolContactFileList.Count == 0)
                    {
                        fileButton.Location = buttonSchoolContactFile.Location;
                    }
                    else
                    {
                        fileButton.Location = new Point(buttonSchoolContactFileList[buttonSchoolContactFileList.Count - 1].Location.X + buttonSchoolContactFileList[buttonSchoolContactFileList.Count - 1].Size.Width, buttonSchoolContactFileList[buttonSchoolContactFileList.Count - 1].Location.Y);
                    }
                    fileButton.Click += FileButton_Click;
                    splitContainerSchoolContact.Panel2.Controls.Add(fileButton);
                    fileButton.BringToFront();
                    buttonSchoolContactFileList.Add(fileButton);
                }
            }
        }

        #endregion

        #region 授業共有ファイル

        private async void buttonRefreshClassSharedFile_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            buttonRefreshClassSharedFile.Enabled = false;
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                ClassSharedFile classSharedFile = new ClassSharedFile { classSubjects = "", title = "" }; ;
                if (classSharedFileList.Count != 0)
                {
                    classSharedFile = classSharedFileList[0];
                }
                List<ClassSharedFile> tempClassSharedFileList = await Task.Run(() => gakujoAPI.GetClassSharedFileList(progress, classSharedFile));
                progressBox.Close();
                if (tempClassSharedFileList.Count != 0 && dialogShow)
                {
                    using (TextOutputBox textOutputBox = new TextOutputBox())
                    {
                        textOutputBox.Set("GakujoGUI", tempClassSharedFileList.Count + "件の授業共有ファイルを取得しました。", MessageBoxButtons.OK);
                        textOutputBox.ShowDialog();
                    }
                }
                tempClassSharedFileList.AddRange(classSharedFileList);
                classSharedFileList = tempClassSharedFileList;
            }
            classSharedFileList = classSharedFileList;
            buttonRefreshClassSharedFile.Enabled = true;
        }

        private void listViewClassSharedFile_MouseMove(object sender, MouseEventArgs e)
        {
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewClassSharedFile, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (columnIndex == 2 || columnIndex == 3)
            {
                listViewClassSharedFile.Cursor = Cursors.Hand;
            }
            else
            {
                listViewClassSharedFile.Cursor = Cursors.Default;
            }
        }

        private async void listViewClassSharedFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewClassSharedFile.SelectedItems.Count != 1)
            {
                return;
            }
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewClassSharedFile, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (columnIndex != 2 && columnIndex != 3)
            {
                return;
            }
            if (classSharedFileList[selectIndex].fileDescription != null)
            {
            }
            else
            {
                if (!gakujoLogin)
                {
                    return;
                }
                using (TextOutputBox textOutputBox = new TextOutputBox())
                {
                    textOutputBox.Set("GakujoGUI", "詳細を取得しますか。", MessageBoxButtons.YesNo);
                    switch (textOutputBox.ShowDialog())
                    {
                        case DialogResult.Yes:
                            using (ProgressBox progressBox = new ProgressBox())
                            {
                                progressBox.Set("GakujoGUI", "");
                                progressBox.Show();
                                Progress<double> progress = new Progress<double>(progressBox.Update);
                                ClassSharedFile classSharedFile = await Task.Run(() => gakujoAPI.GetClassSharedFile(progress, classSharedFileList[selectIndex], selectIndex, true, downloadPath));
                                progressBox.Close();
                                classSharedFileList[selectIndex] = classSharedFile;
                                classSharedFileList = classSharedFileList;
                            }
                            break;
                        default:
                            return;
                    }
                }
            }
            labelClassSharedFileTitle.Text = classSharedFileList[selectIndex].title;
            labelClassSharedFileFileDescription.Text = classSharedFileList[selectIndex].fileDescription;
            foreach (MaterialFlatButton flatButton in buttonClassSharedFileFileList)
            {
                flatButton.Dispose();
            }
            buttonClassSharedFileFileList.Clear();
            if (classSharedFileList[selectIndex].file != "")
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(classSharedFileList[selectIndex].file);
                while (stringReader.Peek() > -1)
                {
                    MaterialFlatButton fileButton = new MaterialFlatButton
                    {
                        Text = stringReader.ReadLine(),
                        Anchor = (AnchorStyles.Bottom | AnchorStyles.Left)
                    };
                    if (buttonClassSharedFileFileList.Count == 0)
                    {
                        fileButton.Location = buttonClassSharedFileFile.Location;
                    }
                    else
                    {
                        fileButton.Location = new Point(buttonClassSharedFileFileList[buttonClassSharedFileFileList.Count - 1].Location.X + buttonClassSharedFileFileList[buttonClassSharedFileFileList.Count - 1].Size.Width, buttonClassSharedFileFileList[buttonClassSharedFileFileList.Count - 1].Location.Y);
                    }
                    fileButton.Click += FileButton_Click;
                    splitContainerClassSharedFile.Panel2.Controls.Add(fileButton);
                    fileButton.BringToFront();
                    buttonClassSharedFileFileList.Add(fileButton);
                }
            }
        }

        #endregion

        #region 学内共有ファイル

        private async void buttonRefreshSchoolSharedFile_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            buttonRefreshSchoolSharedFile.Enabled = false;
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                SchoolSharedFile schoolSharedFile = new SchoolSharedFile { category = "", title = "" }; ;
                if (schoolSharedFileList.Count != 0)
                {
                    schoolSharedFile = schoolSharedFileList[0];
                }
                List<SchoolSharedFile> tempSchoolSharedFileList = await Task.Run(() => gakujoAPI.GetSchoolSharedFileList(progress, schoolSharedFile));
                progressBox.Close();
                if (tempSchoolSharedFileList.Count != 0 && dialogShow)
                {
                    using (TextOutputBox textOutputBox = new TextOutputBox())
                    {
                        textOutputBox.Set("GakujoGUI", tempSchoolSharedFileList.Count + "件の学内共有ファイルを取得しました。", MessageBoxButtons.OK);
                        textOutputBox.ShowDialog();
                    }
                }
                tempSchoolSharedFileList.AddRange(schoolSharedFileList);
                schoolSharedFileList = tempSchoolSharedFileList;
            }
            schoolSharedFileList = schoolSharedFileList;
            buttonRefreshSchoolSharedFile.Enabled = true;
        }

        private void listViewSchoolSharedFile_MouseMove(object sender, MouseEventArgs e)
        {
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewSchoolSharedFile, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (columnIndex == 2 || columnIndex == 3)
            {
                listViewSchoolSharedFile.Cursor = Cursors.Hand;
            }
            else
            {
                listViewSchoolSharedFile.Cursor = Cursors.Default;
            }
        }

        private async void listViewSchoolSharedFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewSchoolSharedFile.SelectedItems.Count != 1)
            {
                return;
            }
            int[] indexArray = new int[2];
            GetListViewSeletColumnIndex(listViewSchoolSharedFile, indexArray);
            int selectIndex = indexArray[0];
            int columnIndex = indexArray[1];
            if (columnIndex != 2 && columnIndex != 3)
            {
                return;
            }
            if (schoolSharedFileList[selectIndex].fileDescription != null)
            {
            }
            else
            {
                if (!gakujoLogin)
                {
                    return;
                }
                using (TextOutputBox textOutputBox = new TextOutputBox())
                {
                    textOutputBox.Set("GakujoGUI", "詳細を取得しますか。", MessageBoxButtons.YesNo);
                    switch (textOutputBox.ShowDialog())
                    {
                        case DialogResult.Yes:
                            using (ProgressBox progressBox = new ProgressBox())
                            {
                                progressBox.Set("GakujoGUI", "");
                                progressBox.Show();
                                Progress<double> progress = new Progress<double>(progressBox.Update);
                                SchoolSharedFile schoolSharedFile = await Task.Run(() => gakujoAPI.GetSchoolSharedFile(progress, schoolSharedFileList[selectIndex], selectIndex, true, downloadPath));
                                progressBox.Close();
                                schoolSharedFileList[selectIndex] = schoolSharedFile;
                                schoolSharedFileList = schoolSharedFileList;
                            }
                            break;
                        default:
                            return;
                    }
                }
            }
            labelSchoolSharedFileTitle.Text = schoolSharedFileList[selectIndex].title;
            labelSchoolSharedFileFileDescription.Text = schoolSharedFileList[selectIndex].fileDescription;
            foreach (MaterialFlatButton flatButton in buttonSchoolSharedFileFileList)
            {
                flatButton.Dispose();
            }
            buttonSchoolSharedFileFileList.Clear();
            if (schoolSharedFileList[selectIndex].file != "")
            {
                System.IO.StringReader stringReader = new System.IO.StringReader(schoolSharedFileList[selectIndex].file);
                while (stringReader.Peek() > -1)
                {
                    MaterialFlatButton fileButton = new MaterialFlatButton
                    {
                        Text = stringReader.ReadLine(),
                        Anchor = (AnchorStyles.Bottom | AnchorStyles.Left)
                    };
                    if (buttonSchoolSharedFileFileList.Count == 0)
                    {
                        fileButton.Location = buttonSchoolSharedFileFile.Location;
                    }
                    else
                    {
                        fileButton.Location = new Point(buttonSchoolSharedFileFileList[buttonSchoolSharedFileFileList.Count - 1].Location.X + buttonSchoolSharedFileFileList[buttonSchoolSharedFileFileList.Count - 1].Size.Width, buttonSchoolSharedFileFileList[buttonSchoolSharedFileFileList.Count - 1].Location.Y);
                    }
                    fileButton.Click += FileButton_Click;
                    splitContainerSchoolSharedFile.Panel2.Controls.Add(fileButton);
                    fileButton.BringToFront();
                    buttonSchoolSharedFileFileList.Add(fileButton);
                }
            }
        }

        #endregion

        #region 教務システム

        private async void buttonResultInformation_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            string html = "";
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                //html = await Task.Run(() => gakujoAPI.GetResultInformation(progress));
                html = "<table>\n<thead>\n<tr>\n<th>教科名</th>\n<th>担当教員名</th>\n<th>科目区分</th>\n<th>必修選択区分</th>\n<th>単位</th>\n<th>評価</th>\n<th>得点</th>\n<th>科目GP</th>\n<th>取得年度</th>\n<th>報告日</th>\n<th>試験種別</th>\n</tr>\n<tbody>\n";
                foreach (var item in await Task.Run(() => gakujoAPI.GetResultInformation(progress)))
                {
                    html += "<tr>\n<td>" + item.subjectName + "</td>\n<td>" + item.repTeacherName + "</td>\n<td>" + item.subjectSection + "</td>\n<td>" + item.compulsorySelectionSection + "</td>\n<td>" + item.schoolCredit + "</td>\n<td>" + item.evaluation + "</td>\n<td>" + item.score + "</td>\n<td>" + item.subjectGP + "</td>\n<td>" + item.acquisitionFiscalYear + "</td>\n<td>" + item.reportDate + "</td>\n<td>" + item.testingType + "</td>\n</tr>\n";
                }
                html += "</tbody>\n</table>";
                await webView2AcademicAffairsSystem.EnsureCoreWebView2Async();
                progressBox.Close();
            }
            webView2AcademicAffairsSystem.NavigateToString(html);
        }

        private async void buttonCreditAcquisitionInformation_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            string html = "";
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                html = await Task.Run(() => gakujoAPI.GetCreditAcquisitionInformation(progress));
                await webView2AcademicAffairsSystem.EnsureCoreWebView2Async();
                progressBox.Close();
            }
            webView2AcademicAffairsSystem.NavigateToString(html);
        }

        private async void buttonCurriculumInformation_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            string html = "";
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                html = await Task.Run(() => gakujoAPI.GetCurriculumInformation(progress));
                await webView2AcademicAffairsSystem.EnsureCoreWebView2Async();
                progressBox.Close();
            }
            webView2AcademicAffairsSystem.NavigateToString(html);
        }

        private async void buttonSchoolRegisterInformation_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            string html = "";
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                html = await Task.Run(() => gakujoAPI.GetSchoolRegisterInformation(progress));
                await webView2AcademicAffairsSystem.EnsureCoreWebView2Async();
                progressBox.Close();
            }
            webView2AcademicAffairsSystem.NavigateToString(html);
        }

        private void buttonSyllabusReference_Click(object sender, EventArgs e)
        {
            using (SyllabusForm syllabusForm = new SyllabusForm())
            {
                syllabusForm.ShowDialog();
            }
        }

        #endregion

        #region タスクトレイ

        private void 表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonRefreshClassContact_Click(sender, e);
            buttonRefreshReport_Click(sender, e);
            buttonRefreshQuiz_Click(sender, e);
            buttonRefreshSchoolContact_Click(sender, e);
            WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
            Visible = false;
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Close();
        }

        private void MainFrom_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                Visible = false;
            }
            else
            {
                notifyIcon.Visible = false;
                Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon.Visible = false;
            Visible = true;
            WindowState = FormWindowState.Normal;
        }

        #endregion

    }
}
