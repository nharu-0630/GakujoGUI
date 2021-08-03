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
        private List<MaterialFlatButton> fileButtonList = new List<MaterialFlatButton> { };
        private readonly string downloadPath = Environment.CurrentDirectory + "/download/";
        private bool gakujoLogin = false;

        #endregion

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            buttonLogin.Enabled = false;
            gakujoAPI.userId = textBoxUserId.Text;
            gakujoAPI.passWord = textBoxPassWord.Text;
            gakujoAPI.studentName = textBoxStudentName.Text;
            gakujoAPI.studentCode = textBoxStudentCode.Text;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            textBoxUserId.Text = Properties.Settings.Default.userId;
            textBoxPassWord.Text = Properties.Settings.Default.passWord;
            textBoxStudentName.Text = Properties.Settings.Default.studentName;
            textBoxStudentCode.Text = Properties.Settings.Default.studentCode;
            checkBoxAutoLogin.Checked = Properties.Settings.Default.autoLogin;
            checkBoxClassContactFileDownload.Checked = Properties.Settings.Default.classContactFileDownload;
            Task task = Task.Run(() => LoadJson());
            if (checkBoxAutoLogin.Checked)
            {
                buttonLogin.PerformClick();
            }
            task.Wait();
        }

        private void LoadJson()
        {
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
                List<GakujoAPI.ClassContact> tempClassContactList = await Task.Run(() => gakujoAPI.GetClassContactList(progress, checkBoxClassContactFileDownload.Checked, downloadPath, classContact));
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
            if (File.Exists(downloadPath + ((Button)sender)))
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
                        case DialogResult.No:
                            return;
                    }
                }
            }
            labelClassContactTitle.Text = classContactList[selectIndex].title;
            labelClassContactContent.Text = classContactList[selectIndex].content;
            foreach (MaterialFlatButton flatButton in fileButtonList)
            {
                flatButton.Dispose();
            }
            fileButtonList.Clear();
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
                    if (fileButtonList.Count == 0)
                    {
                        fileButton.Location = buttonFile.Location;
                    }
                    else
                    {
                        fileButton.Location = new Point(fileButtonList[fileButtonList.Count - 1].Location.X + fileButtonList[fileButtonList.Count - 1].Size.Width, fileButtonList[fileButtonList.Count - 1].Location.Y);
                    }
                    fileButton.Click += FileButton_Click;
                    splitContainerClassContact.Panel2.Controls.Add(fileButton);
                    fileButton.BringToFront();
                    fileButtonList.Add(fileButton);
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
            if (columnIndex == 6 && (reportList[selectIndex].operation == "提出開始" || reportList[selectIndex].operation == "提出取消"))
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
            if (columnIndex == 6 && reportList[selectIndex].operation == "提出開始")
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
            if ((columnIndex == 7 && (quizList.Where(quiz => (checkBoxAllVisible.Checked || (!quiz.invisible && !checkBoxAllVisible.Checked))).ToArray()[selectIndex].operation == "提出開始" || quizList.Where(quiz => (checkBoxAllVisible.Checked || (!quiz.invisible && !checkBoxAllVisible.Checked))).ToArray()[selectIndex].operation == "提出取消")) || (columnIndex == 1))
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

        private void buttonTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/xyzyxJP");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.userId = textBoxUserId.Text;
            Properties.Settings.Default.passWord = textBoxPassWord.Text;
            Properties.Settings.Default.studentName = textBoxStudentName.Text;
            Properties.Settings.Default.studentCode = textBoxStudentCode.Text;
            Properties.Settings.Default.autoLogin = checkBoxAutoLogin.Checked;
            Properties.Settings.Default.classContactFileDownload = checkBoxClassContactFileDownload.Checked;
            Properties.Settings.Default.Save();
        }

    }
}
