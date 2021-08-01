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

        private GakujoAPI.GakujoAPI gakujoAPI = new GakujoAPI.GakujoAPI();
        private List<GakujoAPI.ClassContact> classContactList = new List<GakujoAPI.ClassContact> { };
        private List<GakujoAPI.Report> reportList = new List<GakujoAPI.Report> { };
        private List<GakujoAPI.Quiz> quizList = new List<GakujoAPI.Quiz> { };
        private List<MaterialFlatButton> fileButtonList = new List<MaterialFlatButton> { };
        private readonly string downloadPath = Environment.CurrentDirectory + "/download/";
        private bool gakujoLogin = false;

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxUserId.Text = Properties.Settings.Default.userId;
            textBoxPassWord.Text = Properties.Settings.Default.passWord;
            textBoxStudentName.Text = Properties.Settings.Default.studentName;
            textBoxStudentCode.Text = Properties.Settings.Default.studentCode;
            checkBoxAutoLogin.Checked = Properties.Settings.Default.autoLogin;
            checkBoxClassContactFileDownload.Checked = Properties.Settings.Default.classContactFileDownload;
            textBoxClassContactLimit.Text = Properties.Settings.Default.classContactLimit.ToString();
            textBoxClassContactDetail.Text = Properties.Settings.Default.classContactDetail.ToString();
            if (checkBoxAutoLogin.Checked)
            {
                buttonLogin.PerformClick();
            }
        }

        private async void buttonRefreshClassContact_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                classContactList = await Task.Run(() => gakujoAPI.GetClassContactList(progress, int.Parse(textBoxClassContactLimit.Text), int.Parse(textBoxClassContactDetail.Text), checkBoxClassContactFileDownload.Checked, downloadPath));
                progressBox.Close();
            }
            listViewClassContact.Items.Clear();
            foreach (GakujoAPI.ClassContact classContact in classContactList)
            {
                listViewClassContact.Items.Add(new ListViewItem(new string[] { "", classContact.classSubjects, classContact.title, classContact.content, classContact.contactTime }));
            }
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", classContactList.Count + "件の授業連絡を取得しました。", MessageBoxButtons.OK);
                textOutputBox.ShowDialog();
            }
        }

        private async void buttonRefreshReport_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                reportList = await Task.Run(() => gakujoAPI.GetReportList(progress, 0));
                progressBox.Close();
            }
            listViewReport.Items.Clear();
            foreach (GakujoAPI.Report report in reportList)
            {
                listViewReport.Items.Add(new ListViewItem(new string[] { "", report.classSubjects, report.title, report.status, report.submissionPeriod, report.lastSubmissionTime, report.operation }));
            }
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", reportList.Count + "件のレポートを取得しました。", MessageBoxButtons.OK);
                textOutputBox.ShowDialog();
            }
        }

        private async void buttonRefreshQuiz_Click(object sender, EventArgs e)
        {
            if (!gakujoLogin)
            {
                return;
            }
            using (ProgressBox progressBox = new ProgressBox())
            {
                progressBox.Set("GakujoGUI", "");
                progressBox.Show();
                Progress<double> progress = new Progress<double>(progressBox.Update);
                quizList = await Task.Run(() => gakujoAPI.GetQuizList(progress, 0));
                progressBox.Close();
            }
            listViewQuiz.Items.Clear();
            foreach (GakujoAPI.Quiz quiz in quizList.Where(quiz => quiz.invisible == false))
            {
                listViewQuiz.Items.Add(new ListViewItem(new string[] { "", "非表示", quiz.classSubjects, quiz.title, quiz.status, quiz.submissionPeriod, quiz.submissionStatus, quiz.operation }));
            }
            using (TextOutputBox textOutputBox = new TextOutputBox())
            {
                textOutputBox.Set("GakujoGUI", quizList.Count + "件の小テストを取得しました。", MessageBoxButtons.OK);
                textOutputBox.ShowDialog();
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
                                Progress<double> progress = new Progress<double>(progressBox.Update);
                                GakujoAPI.ClassContact classContact = await Task.Run(() => gakujoAPI.GetClassContact(progress, classContactList[selectIndex], selectIndex, checkBoxClassContactFileDownload.Checked, downloadPath));
                                progressBox.Close();
                                listViewClassContact.Items[selectIndex] = new ListViewItem(new string[] { "", classContact.classSubjects, classContact.title, classContact.content, classContact.contactTime });
                                classContactList[selectIndex] = classContact;
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

        private void FileButton_Click(object sender, EventArgs e)
        {
            Process.Start(downloadPath + ((Button)sender).Text);
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
                            Progress<double> progress = new Progress<double>(progressBox.Update);
                            Task.Run(() => gakujoAPI.SubmitReport(progress, reportList[selectIndex].id, new string[] { fileTextInputBox.inputFile }, fileTextInputBox.inputText));
                            progressBox.Close();
                        }
                        using (TextOutputBox textOutputBox = new TextOutputBox())
                        {
                            textOutputBox.Set("GakujoGUI", "提出が完了しました。", MessageBoxButtons.OK);
                            textOutputBox.ShowDialog();
                        }
                    }
                }
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
            if (columnIndex == 7 && quizList.Where(quiz => (checkBoxAllVisible.Checked || (!quiz.invisible && !checkBoxAllVisible.Checked))).ToArray()[selectIndex].operation == "提出開始")
            {
                using (QuizForm quizForm = new QuizForm())
                {
                    using (ProgressBox progressBox = new ProgressBox())
                    {
                        progressBox.Set("GakujoGUI", "");
                        Progress<double> progress = new Progress<double>(progressBox.Update);
                        quizForm.Set("GakujoGUI", "<script type=\"text/javascript\">function GetOutputText(){ var outputText = \"\"; for (var i = 10; true; i++){ var jLimit = document.getElementsByName(\"value\" + i).length; if (jLimit === 0){ break; } for (var j = 0; j < jLimit; j++){ if (document.getElementsByName(\"value\" + i)[j].checked){ outputText = outputText + \"&value\" + i + \"=\"; outputText = outputText +document.getElementsByName(\"value\" + i)[j].value; } } } return outputText;}</script>" + (await Task.Run(() => gakujoAPI.GetQuizDetail(progress, quizList[selectIndex].id))).Replace("<a href=\"javascript:void(0);\" class=\"btn_large\" onclick=\"formSubmit('tempSaveAction')\"><span class=\"btn-side\"><span class=\"icon-save_temp\">一時保存</span></span></a>", "").Replace("<a href=\"javascript:void(0);\" class=\"btn_large ml20\" onclick=\"formSubmit('confirmAction')\"><span class=\"btn-side\"><span class=\"icon-confirm\">確認</span></span></a>", "").Replace("<a href=\"javascript:void(0);\" class=\"btn\" onclick=\"formSubmit('backScreen')\"><span class=\"btn-side\"><span class=\"icon-back\">戻る</span></span></a>", "<a href=\"javascript:void(0);\" class=\"btn\" onclick=\"window.chrome.webview.postMessage(GetOutputText())\"><span class=\"btn-side\"><span class=\"icon-back\">登録</span></span></a>"));
                        progressBox.Close();
                    }
                    if (quizForm.ShowDialog() == DialogResult.OK)
                    {
                        using (ProgressBox progressBox = new ProgressBox())
                        {
                            progressBox.Set("GakujoGUI", "");
                            Progress<double> progress = new Progress<double>(progressBox.Update);
                            gakujoAPI.SubmitQuiz(progress, quizList[selectIndex].id, quizForm.outputText);
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

        private void textBoxClassContactLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBoxClassContactDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
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
            if (columnIndex == 6 && reportList[selectIndex].operation == "提出開始")
            {
                listViewReport.Cursor = Cursors.Hand;
            }
            else
            {
                listViewReport.Cursor = Cursors.Default;
            }
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
            if ((columnIndex == 7 && quizList.Where(quiz => (checkBoxAllVisible.Checked || (!quiz.invisible && !checkBoxAllVisible.Checked))).ToArray()[selectIndex].operation == "提出開始") || (columnIndex == 1))
            {
                listViewQuiz.Cursor = Cursors.Hand;
            }
            else
            {
                listViewQuiz.Cursor = Cursors.Default;
            }
        }

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
            Properties.Settings.Default.classContactLimit = int.Parse(textBoxClassContactLimit.Text);
            Properties.Settings.Default.classContactDetail = int.Parse(textBoxClassContactDetail.Text);
            Properties.Settings.Default.Save();
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
    }
}
