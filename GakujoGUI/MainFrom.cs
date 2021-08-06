using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace GakujoGUI
{
    public partial class MainFrom : MaterialForm
    {
        public MainFrom()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue800, Primary.Blue900, Primary.LightBlue500, Accent.LightBlue200, TextShade.WHITE);
        }

        #region 変数

        private GakujoAPI.GakujoAPI gakujoAPI = new GakujoAPI.GakujoAPI();
        private List<GakujoAPI.ClassContact> _classContactList = new List<GakujoAPI.ClassContact> { };
        private List<GakujoAPI.ClassContact> classContactList
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
                foreach (GakujoAPI.ClassContact classContact in classContactList)
                {
                    listViewClassContact.Items.Add(new ListViewItem(new string[] { "", classContact.classSubjects, classContact.title, classContact.content, classContact.contactTime }));
                }
            }
        }
        private List<GakujoAPI.Report> _reportList = new List<GakujoAPI.Report> { };
        private List<GakujoAPI.Report> reportList
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
                foreach (GakujoAPI.Report report in reportList)
                {
                    listViewReport.Items.Add(new ListViewItem(new string[] { "", report.classSubjects, report.title, report.status, report.submissionPeriod, report.lastSubmissionTime, report.operation }));
                }
            }
        }
        private List<GakujoAPI.Quiz> _quizList = new List<GakujoAPI.Quiz> { };
        private List<GakujoAPI.Quiz> quizList
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
                foreach (GakujoAPI.Quiz quiz in quizList.Where(quiz => quiz.invisible == false))
                {
                    listViewQuiz.Items.Add(new ListViewItem(new string[] { "", "非表示", quiz.classSubjects, quiz.title, quiz.status, quiz.submissionPeriod, quiz.submissionStatus, quiz.operation }));
                }
            }
        }
        private List<GakujoAPI.SchoolContact> _schoolContactList = new List<GakujoAPI.SchoolContact> { };
        private List<GakujoAPI.SchoolContact> schoolContactList
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
                foreach (GakujoAPI.SchoolContact schoolContact in schoolContactList)
                {
                    listViewSchoolContact.Items.Add(new ListViewItem(new string[] { "", schoolContact.category, schoolContact.title, schoolContact.content, schoolContact.contactTime }));
                }
            }
        }
        private List<GakujoAPI.ClassSharedFile> _classSharedFileList = new List<GakujoAPI.ClassSharedFile> { };
        private List<GakujoAPI.ClassSharedFile> classSharedFileList
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
                foreach (GakujoAPI.ClassSharedFile classSharedFile in classSharedFileList)
                {
                    listViewClassSharedFile.Items.Add(new ListViewItem(new string[] { "", classSharedFile.classSubjects, classSharedFile.title, classSharedFile.fileDescription, classSharedFile.updateTime }));
                }
            }
        }
        private List<GakujoAPI.SchoolSharedFile> _schoolSharedFileList = new List<GakujoAPI.SchoolSharedFile> { };
        private List<GakujoAPI.SchoolSharedFile> schoolSharedFileList
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
                foreach (GakujoAPI.SchoolSharedFile schoolSharedFile in schoolSharedFileList)
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
        private bool gakujoLogin = false;

        #endregion

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
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
            buttonLogin.Enabled = true;
            gakujoAPI.WriteCookiesToFile("cookies");
        }

        private void LoadJson()
        {
            if (File.Exists("account.json"))
            {
                StreamReader streamReader = new StreamReader("account.json", Encoding.UTF8);
                gakujoAPI.account = JsonConvert.DeserializeObject<GakujoAPI.Account>(streamReader.ReadToEnd());
                streamReader.Close();
                textBoxUserId.Text = gakujoAPI.account.userId;
                textBoxPassWord.Text = gakujoAPI.account.passWord;
                textBoxStudentCode.Text = gakujoAPI.account.studentCode;
                textBoxStudentName.Text = gakujoAPI.account.studentName;
            }
            if (File.Exists("classContact.json"))
            {
                StreamReader streamReader = new StreamReader("classContact.json", Encoding.UTF8);
                classContactList = JsonConvert.DeserializeObject<List<GakujoAPI.ClassContact>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            if (File.Exists("report.json"))
            {
                StreamReader streamReader = new StreamReader("report.json", Encoding.UTF8);
                reportList = JsonConvert.DeserializeObject<List<GakujoAPI.Report>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            if (File.Exists("quiz.json"))
            {
                StreamReader streamReader = new StreamReader("quiz.json", Encoding.UTF8);
                quizList = JsonConvert.DeserializeObject<List<GakujoAPI.Quiz>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            if (File.Exists("schoolContact.json"))
            {
                StreamReader streamReader = new StreamReader("schoolContact.json", Encoding.UTF8);
                schoolContactList = JsonConvert.DeserializeObject<List<GakujoAPI.SchoolContact>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            if (File.Exists("classSharedFile.json"))
            {
                StreamReader streamReader = new StreamReader("classSharedFile.json", Encoding.UTF8);
                classSharedFileList = JsonConvert.DeserializeObject<List<GakujoAPI.ClassSharedFile>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            if (File.Exists("schoolSharedFile.json"))
            {
                StreamReader streamReader = new StreamReader("schoolSharedFile.json", Encoding.UTF8);
                schoolSharedFileList = JsonConvert.DeserializeObject<List<GakujoAPI.SchoolSharedFile>>(streamReader.ReadToEnd());
                streamReader.Close();
            }
        }

        private void buttonTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/xyzyxJP");
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
            LoadJson();
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                gakujoLogin = await Task.Run(() => gakujoAPI.SetCookies(progress));
                progressBox.Close();
            }
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                if (gakujoLogin)
                {
                    textOutputBox.Set("GakujoGUI", "キャッシュログインに成功しました。", MessageBoxButtons.OK);
                    textOutputBox.ShowDialog();
                }
                else
                {
                    textOutputBox.Set("GakujoGUI", "キャッシュログインに失敗しました。", MessageBoxButtons.OK);
                    textOutputBox.ShowDialog();
                }
            }
        }

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
                GakujoAPI.ClassContact classContact = new GakujoAPI.ClassContact { classSubjects = "", title = "", contactTime = "" }; ;
                if (classContactList.Count != 0)
                {
                    classContact = classContactList[0];
                }
                List<GakujoAPI.ClassContact> tempClassContactList = await Task.Run(() => gakujoAPI.GetClassContactList(progress, classContact));
                tempClassContactList.AddRange(classContactList);
                classContactList = tempClassContactList;
                progressBox.Close();
            }
            classContactList = classContactList;
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", classContactList.Count + "件の授業連絡を取得しました。", MessageBoxButtons.OK);
                textOutputBox.ShowDialog();
            }
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
            Point point = listViewClassContact.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewClassContact.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
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
            Point point = listViewClassContact.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewClassContact.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
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
                                GakujoAPI.ClassContact classContact = await Task.Run(() => gakujoAPI.GetClassContact(progress, classContactList[selectIndex], selectIndex, checkBoxClassContactFileDownload.Checked, downloadPath));
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
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                reportList = await Task.Run(() => gakujoAPI.GetReportList(progress, 0));
                StreamWriter streamWriter = new StreamWriter("report.json", false, Encoding.UTF8);
                streamWriter.WriteLine(JsonConvert.SerializeObject(reportList, Formatting.None));
                streamWriter.Close();
                progressBox.Close();
            }
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", reportList.Count + "件のレポートを取得しました。", MessageBoxButtons.OK);
                textOutputBox.ShowDialog();
            }
            buttonRefreshReport.Enabled = true;
        }

        private void listViewReport_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = listViewReport.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewReport.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);

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
            int selectIndex = listViewReport.SelectedItems[0].Index;
            Point point = listViewReport.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewReport.HitTest(point);
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
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
                    reportHtml = Task.Run(() => gakujoAPI.GetReportDetail(progress, reportList[selectIndex].id)).Result;
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
                            Task.Run(() => gakujoAPI.SubmitReport(progress, reportList[selectIndex].id, new string[] { fileTextInputBox.inputFile }, fileTextInputBox.inputText));
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
                            gakujoAPI.CancelReport(progress, reportList[selectIndex].id);
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
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                quizList = await Task.Run(() => gakujoAPI.GetQuizList(progress, 0));
                StreamWriter streamWriter = new StreamWriter("quiz.json", false, Encoding.UTF8);
                streamWriter.WriteLine(JsonConvert.SerializeObject(quizList, Formatting.None));
                streamWriter.Close();
                progressBox.Close();
            }
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", quizList.Count + "件の小テストを取得しました。", MessageBoxButtons.OK);
                textOutputBox.ShowDialog();
            }
            buttonRefreshQuiz.Enabled = true;
        }

        private void listViewQuiz_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = listViewQuiz.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewQuiz.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
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
            int selectIndex = listViewQuiz.SelectedItems[0].Index;
            Point point = listViewQuiz.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewQuiz.HitTest(point);
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
            List<GakujoAPI.Quiz> tempQuizList = quizList.Where(quiz => (checkBoxAllVisible.Checked || (!quiz.invisible && !checkBoxAllVisible.Checked))).ToList();
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
                    foreach (GakujoAPI.Quiz quiz in quizList)
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
                    foreach (GakujoAPI.Quiz quiz in quizList.Where(quiz => quiz.invisible == false))
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
                foreach (GakujoAPI.Quiz quiz in quizList)
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
                foreach (GakujoAPI.Quiz quiz in quizList.Where(quiz => quiz.invisible == false))
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
                GakujoAPI.SchoolContact schoolContact = new GakujoAPI.SchoolContact { title = "", contactTime = "" }; ;
                if (schoolContactList.Count != 0)
                {
                    schoolContact = schoolContactList[0];
                }
                List<GakujoAPI.SchoolContact> tempSchoolContactList = await Task.Run(() => gakujoAPI.GetSchoolContactList(progress, schoolContact));
                tempSchoolContactList.AddRange(schoolContactList);
                schoolContactList = tempSchoolContactList;
                progressBox.Close();
            }
            schoolContactList = schoolContactList;
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", schoolContactList.Count + "件の学内連絡を取得しました。", MessageBoxButtons.OK);
                textOutputBox.ShowDialog();
            }
            buttonRefreshSchoolContact.Enabled = true;
        }

        private void listViewSchoolContact_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = listViewSchoolContact.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewSchoolContact.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
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
            Point point = listViewSchoolContact.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewSchoolContact.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
            if (listViewSchoolContact.SelectedItems.Count != 1 || (columnIndex != 2 && columnIndex != 3))
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
                                GakujoAPI.SchoolContact schoolContact = await Task.Run(() => gakujoAPI.GetSchoolContact(progress, schoolContactList[selectIndex], selectIndex, checkBoxSchoolContactFileDownload.Checked, downloadPath));
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
                GakujoAPI.ClassSharedFile classSharedFile = new GakujoAPI.ClassSharedFile { classSubjects = "", title = "" }; ;
                if (classSharedFileList.Count != 0)
                {
                    classSharedFile = classSharedFileList[0];
                }
                List<GakujoAPI.ClassSharedFile> tempClassSharedFileList = await Task.Run(() => gakujoAPI.GetClassSharedFileList(progress, classSharedFile));
                tempClassSharedFileList.AddRange(classSharedFileList);
                classSharedFileList = tempClassSharedFileList;
                progressBox.Close();
            }
            classSharedFileList = classSharedFileList;
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", classSharedFileList.Count + "件の授業共有ファイルを取得しました。", MessageBoxButtons.OK);
                textOutputBox.ShowDialog();
            }
            buttonRefreshClassSharedFile.Enabled = true;
        }

        private void listViewClassSharedFile_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = listViewClassSharedFile.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewClassSharedFile.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
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
            Point point = listViewClassSharedFile.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewClassSharedFile.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
            if (listViewClassSharedFile.SelectedItems.Count != 1 || (columnIndex != 2 && columnIndex != 3))
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
                                GakujoAPI.ClassSharedFile classSharedFile = await Task.Run(() => gakujoAPI.GetClassSharedFile(progress, classSharedFileList[selectIndex], selectIndex, true, downloadPath));
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
                GakujoAPI.SchoolSharedFile schoolSharedFile = new GakujoAPI.SchoolSharedFile { category = "", title = "" }; ;
                if (schoolSharedFileList.Count != 0)
                {
                    schoolSharedFile = schoolSharedFileList[0];
                }
                List<GakujoAPI.SchoolSharedFile> tempSchoolSharedFileList = await Task.Run(() => gakujoAPI.GetSchoolSharedFileList(progress, schoolSharedFile));
                tempSchoolSharedFileList.AddRange(schoolSharedFileList);
                schoolSharedFileList = tempSchoolSharedFileList;
                progressBox.Close();
            }
            schoolSharedFileList = schoolSharedFileList;
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", schoolSharedFileList.Count + "件の学内共有ファイルを取得しました。", MessageBoxButtons.OK);
                textOutputBox.ShowDialog();
            }
            buttonRefreshSchoolSharedFile.Enabled = true;
        }

        private void listViewSchoolSharedFile_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = listViewSchoolSharedFile.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewSchoolSharedFile.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
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
            Point point = listViewSchoolSharedFile.PointToClient(MousePosition);
            ListViewHitTestInfo listViewHitTestInfo = listViewSchoolSharedFile.HitTest(point);
            if (listViewHitTestInfo.Item == null)
            {
                return;
            }
            int selectIndex = listViewHitTestInfo.Item.Index;
            int columnIndex = listViewHitTestInfo.Item.SubItems.IndexOf(listViewHitTestInfo.SubItem);
            if (listViewSchoolSharedFile.SelectedItems.Count != 1 || (columnIndex != 2 && columnIndex != 3))
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
                                GakujoAPI.SchoolSharedFile schoolSharedFile = await Task.Run(() => gakujoAPI.GetSchoolSharedFile(progress, schoolSharedFileList[selectIndex], selectIndex, true, downloadPath));
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
    }
}
