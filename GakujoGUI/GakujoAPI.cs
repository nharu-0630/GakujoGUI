using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.IO;
using System.Web;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;

namespace GakujoAPI
{
    class GakujoAPI
    {
        static CookieContainer cookieContainer;
        static HttpClientHandler httpClientHandler;
        static HttpClient httpClient;
        static HttpRequestMessage httpRequestMessage;
        static HttpResponseMessage httpResponse;

        public string userId;
        public string passWord;
        public string studentName;
        public string studentCode;
        static string apacheToken;

        public bool Login(IProgress<double> progress)
        {
            progress.Report(100 * 0 / 9);
            cookieContainer = new CookieContainer();
            httpClientHandler = new HttpClientHandler();
            httpClientHandler.AutomaticDecompression = ~DecompressionMethods.None;
            httpClientHandler.CookieContainer = cookieContainer;
            httpClient = new HttpClient(httpClientHandler);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("GET"), "https://gakujo.shizuoka.ac.jp/portal/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            progress.Report(100 * 1 / 9);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/login/preLogin/preLogin"); httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "application/json, text/javascript, */*; q=0.01");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja");
            httpRequestMessage.Content = new StringContent("mistakeChecker=0");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            progress.Report(100 * 2 / 9);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("GET"), "https://gakujo.shizuoka.ac.jp/UI/jsp/topPage/topPage.jsp?_=" + (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html, */*; q=0.01");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            progress.Report(100 * 3 / 9);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/shibbolethlogin/shibbolethLogin/initLogin/sso");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("selectLocale=ja&mistakeChecker=0&EXCLUDE_SET=");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            progress.Report(100 * 4 / 9);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("GET"), "https://idp.shizuoka.ac.jp/idp/profile/SAML2/Redirect/SSO?execution=e1s1");
            httpResponse.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpResponse.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpResponse.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpResponse.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpResponse.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/");
            httpResponse.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            progress.Report(100 * 5 / 9);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://idp.shizuoka.ac.jp/idp/profile/SAML2/Redirect/SSO?execution=e1s1");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://idp.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://idp.shizuoka.ac.jp/idp/profile/SAML2/Redirect/SSO?execution=e1s1");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("j_username=" + userId + "&j_password=" + passWord + "&_eventId_proceed=");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            if (HttpUtility.HtmlDecode(httpResponse.Content.ReadAsStringAsync().Result).Contains("ユーザ名またはパスワードが正しくありません。"))
            {
                progress.Report(100 * 9 / 9);
                return false;
            }
            else
            {
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
                string relayState = htmlDocument.DocumentNode.SelectNodes("/html/body/form/div/input[1]")[0].Attributes["value"].Value;
                relayState = relayState.Replace("&#x3a;", ":");
                string SAMLResponse = htmlDocument.DocumentNode.SelectNodes("/html/body/form/div/input[2]")[0].Attributes["value"].Value;
                relayState = Uri.EscapeDataString(relayState);
                SAMLResponse = Uri.EscapeDataString(SAMLResponse);
                progress.Report(100 * 6 / 9);
                httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/Shibboleth.sso/SAML2/POST");
                httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
                httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://idp.shizuoka.ac.jp");
                httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
                httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://idp.shizuoka.ac.jp/");
                httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
                httpRequestMessage.Content = new StringContent("RelayState=" + relayState + "&SAMLResponse=" + SAMLResponse);
                httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
                progress.Report(100 * 7 / 9);
                httpRequestMessage = new HttpRequestMessage(new HttpMethod("GET"), "https://gakujo.shizuoka.ac.jp/portal/shibbolethlogin/shibbolethLogin/initLogin/sso");
                httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
                httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
                httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://idp.shizuoka.ac.jp/");
                httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
                httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
                progress.Report(100 * 8 / 9);
                httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/home/home/initialize");
                httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
                httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
                httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
                httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/shibbolethlogin/shibbolethLogin/initLogin/sso");
                httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
                httpRequestMessage.Content = new StringContent("EXCLUDE_SET=");
                httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
                htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
                apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/div[1]/form[1]/div/input")[0].Attributes["value"].Value;
                progress.Report(100 * 9 / 9);
            }
            return true;
        }

        public List<Report> GetReportList(IProgress<double> progress, int limitCount = 0)
        {
            progress.Report(100 * 0 / 2);
            List<Report> reportList = new List<Report> { };
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/common/generalPurpose/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/common/generalPurpose/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&headTitle=授業サポート&menuCode=A02&nextPath=/report/student/searchList/initialize&_screenIdentifier=&_screenInfoDisp=&_scrollTop=0");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            progress.Report(100 * 1 / 2);
            apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/div[1]/form[1]/div/input")[0].Attributes["value"].Value;
            if (limitCount == 0)
            {
                limitCount = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr").Count;
            }
            limitCount = Math.Min(htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr").Count, limitCount);
            for (int i = 0; i < limitCount; i++)
            {
                progress.Report((100 * 1 / 2) + (50 * i / limitCount));
                Report report = new Report();
                report.classSubjects = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[0].InnerText.Replace("\r", "").Replace("\n", "").Trim();
                report.classSubjects = System.Text.RegularExpressions.Regex.Replace(report.classSubjects, @"\s+", " ");
                report.title = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[1].SelectSingleNode("a").InnerText.Trim();
                report.id = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[1].SelectSingleNode("a").Attributes["onclick"].Value.Split(',')[1].Replace("'", "").Trim();
                report.status = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[2].InnerText.Trim();
                report.submissionPeriod = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[3].InnerText.Trim();
                report.lastSubmissionTime = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[4].InnerText.Trim();
                report.implementationFormat = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[5].InnerText.Trim();
                report.operation = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[6].InnerText.Trim();
                reportList.Add(report);
            }
            progress.Report(100 * 2 / 2);
            return reportList;
        }

        public List<Quiz> GetQuizList(IProgress<double> progress, int limitCount = 0)
        {
            progress.Report(100 * 0 / 2);
            List<Quiz> quizList = new List<Quiz> { };
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/common/generalPurpose/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/common/generalPurpose/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&headTitle=小テスト一覧&menuCode=A03&nextPath=/test/student/searchList/initialize&_searchConditionDisp.accordionSearchCondition=false&_screenIdentifier=&_screenInfoDisp=&_scrollTop=0");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            progress.Report(100 * 1 / 2);
            apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/div[1]/form[1]/div/input")[0].Attributes["value"].Value;
            if (limitCount == 0)
            {
                limitCount = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr").Count;
            }
            limitCount = Math.Min(htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr").Count, limitCount);
            for (int i = 0; i < limitCount; i++)
            {
                progress.Report((100 * 1 / 2) + (50 * i / limitCount));
                Quiz quiz = new Quiz();
                quiz.classSubjects = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[0].InnerText.Replace("\r", "").Replace("\n", "").Trim();
                quiz.classSubjects = System.Text.RegularExpressions.Regex.Replace(quiz.classSubjects, @"\s+", " ");
                quiz.title = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[1].SelectSingleNode("a").InnerText.Trim();
                quiz.status = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[2].InnerText.Trim();
                quiz.submissionPeriod = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[3].InnerText.Trim();
                quiz.submissionStatus = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[4].InnerText.Trim();
                quiz.implementationFormat = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[5].InnerText.Trim();
                quiz.operation = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[6].InnerText.Trim();
                quiz.id = htmlDocument.GetElementbyId("searchList").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[1].SelectSingleNode("a").Attributes["onclick"].Value.Split(',')[1].Replace("'", "").Trim();
                quizList.Add(quiz);
            }
            progress.Report(100 * 2 / 2);
            return quizList;
        }

        public List<ClassContact> GetClassContactList(IProgress<double> progress, int limitCount = 0, int detailCount = 10, bool fileDownload = true, string downloadPath = "download/")
        {
            progress.Report(100 * 0 / 2);
            List<ClassContact> classContactList = new List<ClassContact> { };
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/common/generalPurpose/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/common/generalPurpose/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&headTitle=授業連絡一覧&menuCode=A01&nextPath=/classcontact/classContactList/initialize&_searchConditionDisp.accordionSearchCondition=false&_screenIdentifier=&_screenInfoDisp=true&_scrollTop=0");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            progress.Report(100 * 1 / 2);
            apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/div[1]/form[1]/div/input")[0].Attributes["value"].Value;
            if (limitCount == 0)
            {
                limitCount = htmlDocument.GetElementbyId("tbl_A01_01").SelectSingleNode("tbody").SelectNodes("tr").Count;
            }
            limitCount = Math.Min(htmlDocument.GetElementbyId("tbl_A01_01").SelectSingleNode("tbody").SelectNodes("tr").Count, limitCount);
            for (int i = 0; i < limitCount; i++)
            {
                progress.Report((100 * 1 / 2) + (50 * i / limitCount));
                ClassContact classContact = new ClassContact();
                classContact.classSubjects = htmlDocument.GetElementbyId("tbl_A01_01").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[1].InnerText.Replace("\r", "").Replace("\n", "").Trim();
                classContact.classSubjects = System.Text.RegularExpressions.Regex.Replace(classContact.classSubjects, @"\s+", " ");
                classContact.responsibleTeacherFullName = htmlDocument.GetElementbyId("tbl_A01_01").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[2].InnerText.Trim();
                classContact.title = HttpUtility.HtmlDecode(htmlDocument.GetElementbyId("tbl_A01_01").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[3].SelectSingleNode("a").InnerText).Trim();
                classContact.targetDate = htmlDocument.GetElementbyId("tbl_A01_01").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[5].InnerText.Trim();
                classContact.contactTime = htmlDocument.GetElementbyId("tbl_A01_01").SelectSingleNode("tbody").SelectNodes("tr")[i].SelectNodes("td")[6].InnerText.Trim();
                classContactList.Add(classContact);
            }
            if (detailCount == 0)
            {
                detailCount = classContactList.Count;
            }
            detailCount = Math.Min(classContactList.Count, detailCount);
            for (int i = 0; i < detailCount; i++)
            {
                progress.Report((100 * 1 / 2) + (50 * i / detailCount));
                httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/classcontact/classContactList/goDetail/" + i);
                httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
                httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
                httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
                httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/classcontact/classContactDetail/goBack");
                httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
                httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&teacherCode=&schoolYear=2021&semesterCode=1&subjectDispCode=&searchKeyWord=&checkSearchKeywordTeacherUserName=on&checkSearchKeywordSubjectName=on&checkSearchKeywordTitle=on&contactKindCode=&targetDateStart=&targetDateEnd=&reportDateStart=" + DateTime.Now.Year + "/01/01&reportDateEnd=&requireResponse=&studentCode=&studentName=&tbl_A01_01_length=-1&_searchConditionDisp.accordionSearchCondition=false&_screenIdentifier=SC_A01_01&_screenInfoDisp=true&_scrollTop=0");
                httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
                htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
                apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/div[1]/form[1]/div/input")[0].Attributes["value"].Value;
                classContactList[i].contactType = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[0].SelectSingleNode("td").InnerText;
                classContactList[i].content = HttpUtility.HtmlDecode(htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[2].SelectSingleNode("td").InnerText);
                classContactList[i].content = System.Text.RegularExpressions.Regex.Replace(classContactList[i].content, "[\\r\\n]+", Environment.NewLine, System.Text.RegularExpressions.RegexOptions.Multiline);
                classContactList[i].file = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[3].SelectSingleNode("td").InnerText;
                classContactList[i].fileLinkRelease = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[4].SelectSingleNode("td").InnerText;
                classContactList[i].referenceURL = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[5].SelectSingleNode("td").InnerText;
                classContactList[i].severity = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[6].SelectSingleNode("td").InnerText;
                classContactList[i].webReplyRequest = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[8].SelectSingleNode("td").InnerText;
                if (htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[3].SelectSingleNode("td/div").SelectNodes("div") != null)
                {
                    string file = "";
                    foreach (var item in htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[3].SelectSingleNode("td/div").SelectNodes("div"))
                    {
                        if (fileDownload)
                        {
                            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/common/fileUploadDownload/fileDownLoad?EXCLUDE_SET=&prefix=" + item.SelectSingleNode("a").Attributes["onclick"].Value.Split(',')[0].Replace("fileDownLoad('", "").Replace("'", "") + "&no=" + item.SelectSingleNode("a").Attributes["onclick"].Value.Split(',')[1].Replace("');", "").Replace("'", "").Trim() + "&EXCLUDE_SET=");
                            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
                            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
                            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
                            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/classcontact/classContactList/goDetail/" + i);
                            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
                            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&prefix=default&sequence=&webspaceTabDisplayFlag=&screenName=&fileNameAutonumberFlag=&fileNameDisplayFlag=");
                            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
                            var stream = httpResponse.Content.ReadAsStreamAsync().Result;
                            if (!Directory.Exists(downloadPath))
                            {
                                Directory.CreateDirectory(downloadPath);
                            }
                            using (FileStream fileStream = File.Create(downloadPath + item.SelectSingleNode("a").InnerText.Trim()))
                            {
                                stream.Seek(0, SeekOrigin.Begin);
                                stream.CopyTo(fileStream);
                            }
                        }
                        file += item.SelectSingleNode("a").InnerText.Trim() + Environment.NewLine;
                    }
                    classContactList[i].file = file;
                }
                else
                {
                    classContactList[i].file = "";
                }
            }
            progress.Report(100 * 2 / 2);
            return classContactList;
        }

        public ClassContact GetClassContact(IProgress<double> progress, ClassContact classContact, int indexCount, bool fileDownload = true, string downloadPath = "download/")
        {
            progress.Report(100 * 0 / 2);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/classcontact/classContactList/goDetail/" + indexCount);
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/classcontact/classContactDetail/goBack");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&teacherCode=&schoolYear=2021&semesterCode=1&subjectDispCode=&searchKeyWord=&checkSearchKeywordTeacherUserName=on&checkSearchKeywordSubjectName=on&checkSearchKeywordTitle=on&contactKindCode=&targetDateStart=&targetDateEnd=&reportDateStart=" + DateTime.Now.Year + "/01/01&reportDateEnd=&requireResponse=&studentCode=&studentName=&tbl_A01_01_length=-1&_searchConditionDisp.accordionSearchCondition=false&_screenIdentifier=SC_A01_01&_screenInfoDisp=true&_scrollTop=0");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            progress.Report(100 * 1 / 2);
            apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/div[1]/form[1]/div/input")[0].Attributes["value"].Value;
            classContact.contactType = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[0].SelectSingleNode("td").InnerText;
            //classContactList[i].title = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[1].SelectSingleNode("td").InnerText.Replace("&nbsp;", "").Replace("nbsp;", "");
            classContact.content = HttpUtility.HtmlDecode(htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[2].SelectSingleNode("td").InnerText);
            classContact.content = System.Text.RegularExpressions.Regex.Replace(classContact.content, "[\\r\\n]+", Environment.NewLine, System.Text.RegularExpressions.RegexOptions.Multiline);
            classContact.file = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[3].SelectSingleNode("td").InnerText;
            classContact.fileLinkRelease = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[4].SelectSingleNode("td").InnerText;
            classContact.referenceURL = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[5].SelectSingleNode("td").InnerText;
            classContact.severity = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[6].SelectSingleNode("td").InnerText;
            classContact.webReplyRequest = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[8].SelectSingleNode("td").InnerText;
            if (htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[3].SelectSingleNode("td/div").SelectNodes("div") != null)
            {
                string file = "";
                foreach (var item in htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div/div/form/div[3]/div/div/div/table")[0].SelectNodes("tr")[3].SelectSingleNode("td/div").SelectNodes("div"))
                {
                    if (fileDownload)
                    {
                        httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/common/fileUploadDownload/fileDownLoad?EXCLUDE_SET=&prefix=" + item.SelectSingleNode("a").Attributes["onclick"].Value.Split(',')[0].Replace("fileDownLoad('", "").Replace("'", "") + "&no=" + item.SelectSingleNode("a").Attributes["onclick"].Value.Split(',')[1].Replace("');", "").Replace("'", "").Trim() + "&EXCLUDE_SET=");
                        httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                        httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
                        httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
                        httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
                        httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                        httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/classcontact/classContactList/goDetail/" + indexCount);
                        httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
                        httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&prefix=default&sequence=&webspaceTabDisplayFlag=&screenName=&fileNameAutonumberFlag=&fileNameDisplayFlag=");
                        httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                        httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
                        var stream = httpResponse.Content.ReadAsStreamAsync().Result;
                        if (!Directory.Exists(downloadPath))
                        {
                            Directory.CreateDirectory(downloadPath);
                        }
                        using (FileStream fileStream = File.Create(downloadPath + item.SelectSingleNode("a").InnerText.Trim()))
                        {
                            stream.Seek(0, SeekOrigin.Begin);
                            stream.CopyTo(fileStream);
                        }
                    }
                    file += item.SelectSingleNode("a").InnerText.Trim() + Environment.NewLine;
                }
                classContact.file = file;
            }
            else
            {
                classContact.file = "";
            }
            progress.Report(100 * 2 / 2);
            return classContact;
        }

        public string GetQuizDetail(IProgress<double> progress, string testId)
        {
            progress.Report(100 * 0 / 1);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/test/student/searchList/forwardSubmit");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36 Edg/92.0.902.55");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/common/generalPurpose/");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&testId=" + testId + "&hidSchoolYear=&hidSemesterCode=&hidSubjectCode=&hidClassCode=&entranceDiv=&backPath=&schoolYear=" + DateTime.Now.Year + "&semesterCode=1&subjectDispCode=&operationFormat=1&operationFormat=2&searchList_length=10&_searchConditionDisp.accordionSearchCondition=false&_screenIdentifier=SC_A03_01_G&_screenInfoDisp=&_scrollTop=0");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            progress.Report(100 * 1 / 1);
            apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/form[1]/div/input")[0].Attributes["value"].Value;
            return htmlDocument.DocumentNode.SelectSingleNode("/html/body/div[2]/div[1]/div/form").InnerHtml;
        }

        public bool SubmitQuiz(IProgress<double> progress, string testId, string outputText)
        {
            progress.Report(100 * 0 / 2);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/test/student/submit/confirmAction");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36 Edg/92.0.902.55");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/test/student/searchList/forwardSubmit");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&studentCode=" + studentCode + "&testId=" + testId + "&questionNumber=&selectedKey=&backPath=/test/student/searchList/selfForward" + Uri.EscapeUriString(outputText) + "&maxFileSize=5&_screenIdentifier=SC_A03_02_G&_screenInfoDisp=&_scrollTop=2510");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/form[1]/div/input")[0].Attributes["value"].Value;
            progress.Report(100 * 1 / 2);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/test/student/submitConfirm/confirmAction");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36 Edg/92.0.902.55");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/test/student/submit/confirmAction");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&studentCode=" + studentCode + "&testId=" + testId + "&questionNumber=/test/student/submit/selfForward&maxFileSize=5&_screenIdentifier=SC_A03_03_G&_screenInfoDisp=&_scrollTop=2309");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            progress.Report(100 * 2 / 2);
            Login(progress);
            return true;
        }

        public bool CancelQuiz(IProgress<double> progress, string testId)
        {
            progress.Report(100 * 0 / 1);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/test/student/searchList/submitCancel");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36 Edg/92.0.902.62");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/test/student/submitConfirm/confirmAction");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&testId=" + testId + "&hidSchoolYear=&hidSemesterCode=&hidSubjectCode=&hidClassCode=&entranceDiv=&backPath=/test/student/submit/selfForward&schoolYear=" + DateTime.Now.Year + "&semesterCode=1&subjectDispCode=&operationFormat=1&operationFormat=2&searchList_length=10&_searchConditionDisp.accordionSearchCondition=false&_screenIdentifier=SC_A03_01_G&_screenInfoDisp=&_scrollTop=0");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/form[1]/div/input")[0].Attributes["value"].Value;
            progress.Report(100 * 1 / 1);
            return true;
        }

        public bool SubmitReport(IProgress<double> progress, string reportId, string[] fileArray, string comment)
        {
            progress.Report(100 * 0 / 4);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/report/student/searchList/forwardSubmit");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/report/student/reportEntry/backScreen");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&reportId=" + reportId + "&hidSchoolYear=&hidSemesterCode=&hidSubjectCode=&hidClassCode=&entranceDiv=&backPath=&schoolYear=" + DateTime.Now.Year + "&semesterCode=1&subjectDispCode=&operationFormat=1&operationFormat=2&searchList_length=10&_searchConditionDisp.accordionSearchCondition=false&_screenIdentifier=SC_A02_01_G&_screenInfoDisp=&_scrollTop=0");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/form[1]/div/input")[0].Attributes["value"].Value;
            progress.Report(100 * 1 / 4);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/common/fileUpload/fileUploadInit");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/portaltopcommon/submissionStatusDeadlineForTop/deadLineForTop");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&prefix=reportFile&sequence=true&webspaceTabDisplayFlag=true&screenName=ファイル添付&fileNameAutonumberFlag=true&fileNameDisplayFlag=true");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/div/div/div/div[3]/div/div/div[1]/div[2]/form/div[1]/input")[0].Attributes["value"].Value;
            progress.Report(100 * 2 / 4);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/common/fileUploadLocal/fileUploadLocal");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "application/json, text/javascript, */*; q=0.01");
            httpRequestMessage.Headers.TryAddWithoutValidation("X-Requested-With", "XMLHttpRequest");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/common/fileUpload/fileDelete");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken));
            using (FileStream fileStream = new FileStream(fileArray[0], FileMode.Open, FileAccess.Read))
            {
                StreamContent streamContent = new StreamContent(fileStream);
                streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "formFile",
                    FileName = Path.GetFileName(fileArray[0])
                };
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(Path.GetFileName(fileArray[0])));
                multipartFormDataContent.Add(streamContent);
                httpRequestMessage.Content = multipartFormDataContent;
                httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            }
            progress.Report(100 * 3 / 4);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/report/student/reportEntry/regist");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.164 Safari/537.36 Edg/91.0.864.71");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/report/student/searchList/forwardSubmit");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&studentName=" + studentName + "&studentCode=" + studentCode + "&submitNo=&fileNo=&backPath=/report/student/searchList/selfForward&submitFileHidden=&maxFileSize=10&comment=" + Uri.EscapeUriString(comment) + "&_screenIdentifier=SC_A02_02_G&_screenInfoDisp=&_scrollTop=0");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            progress.Report(100 * 4 / 4);
            Login(progress);
            return true;
        }

        public bool CancelReport(IProgress<double> progress, string reportId)
        {
            progress.Report(100 * 0 / 1);
            httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), "https://gakujo.shizuoka.ac.jp/portal/report/student/searchList/submitCancel");
            httpRequestMessage.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            httpRequestMessage.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.TryAddWithoutValidation("Origin", "https://gakujo.shizuoka.ac.jp");
            httpRequestMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36 Edg/92.0.902.62");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpRequestMessage.Headers.TryAddWithoutValidation("Referer", "https://gakujo.shizuoka.ac.jp/portal/report/student/reportEntry/backScreen");
            httpRequestMessage.Headers.TryAddWithoutValidation("Accept-Language", "ja,en;q=0.9,en-GB;q=0.8,en-US;q=0.7");
            httpRequestMessage.Content = new StringContent("org.apache.struts.taglib.html.TOKEN=" + apacheToken + "&reportId=" + reportId + "&hidSchoolYear=&hidSemesterCode=&hidSubjectCode=&hidClassCode=&entranceDiv=&backPath=&schoolYear=" + DateTime.Now.Year + "&semesterCode=1&subjectDispCode=&operationFormat=1&operationFormat=2&searchList_length=10&_searchConditionDisp.accordionSearchCondition=false&_screenIdentifier=SC_A02_01_G&_screenInfoDisp=&_scrollTop=0");
            httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            httpResponse = httpClient.SendAsync(httpRequestMessage).Result;
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(httpResponse.Content.ReadAsStringAsync().Result);
            apacheToken = htmlDocument.DocumentNode.SelectNodes("/html/body/form[1]/div/input")[0].Attributes["value"].Value;
            progress.Report(100 * 1 / 1);
            return true;
        }

        public IEnumerable<Cookie> GetCookies(IProgress<double> progress)
        {
            Hashtable k = (Hashtable)cookieContainer.GetType().GetField("m_domainTable", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(cookieContainer);
            foreach (DictionaryEntry element in k)
            {
                SortedList l = (SortedList)element.Value.GetType().GetField("m_list", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(element.Value);
                foreach (var e in l)
                {
                    var cl = (CookieCollection)((DictionaryEntry)e).Value;
                    foreach (Cookie fc in cl)
                    {
                        yield return fc;
                    }
                }
            }
        }
    }

    //レポート
    [JsonObject]
    class Report
    {
        //授業科目 学期/曜日時限
        [JsonProperty("classSubjects")]
        public string classSubjects { get; set; }
        //タイトル
        [JsonProperty("title")]
        public string title { get; set; }
        //状態
        [JsonProperty("status")]
        public string status { get; set; }
        //提出期間
        [JsonProperty("submissionPeriod")]
        public string submissionPeriod { get; set; }
        //最終提出日時
        [JsonProperty("lastSubmissionTime")]
        public string lastSubmissionTime { get; set; }
        //実施形式
        [JsonProperty("implementationFormat")]
        public string implementationFormat { get; set; }
        //操作
        [JsonProperty("operation")]
        public string operation { get; set; }
        //ID
        [JsonProperty("id")]
        public string id { get; set; }
    }

    //小テスト
    [JsonObject]
    class Quiz
    {
        //授業科目 学期/曜日時限
        [JsonProperty("classSubjects")]
        public string classSubjects { get; set; }
        //タイトル
        [JsonProperty("title")]
        public string title { get; set; }
        //状態
        [JsonProperty("status")]
        public string status { get; set; }
        //提出期間
        [JsonProperty("submissionPeriod")]
        public string submissionPeriod { get; set; }
        //提出状況
        [JsonProperty("submissionStatus")]
        public string submissionStatus { get; set; }
        //実施形式
        [JsonProperty("implementationFormat")]
        public string implementationFormat { get; set; }
        //操作
        [JsonProperty("operation")]
        public string operation { get; set; }
        //GUI
        [JsonProperty("invisible")]
        public bool invisible { get; set; }
        //ID
        [JsonProperty("id")]
        public string id { get; set; }
    }

    //授業連絡
    [JsonObject]
    class ClassContact
    {
        //授業科目 学期/曜日時限
        [JsonProperty("classSubjects")]
        public string classSubjects { get; set; }
        //担当教員氏名
        [JsonProperty("responsibleTeacherFullName")]
        public string responsibleTeacherFullName { get; set; }
        //連絡種別
        [JsonProperty("contactType")]
        public string contactType { get; set; }
        //タイトル
        [JsonProperty("title")]
        public string title { get; set; }
        //内容
        [JsonProperty("content")]
        public string content { get; set; }
        //ファイル
        [JsonProperty("file")]
        public string file { get; set; }
        //ファイルリンク公開
        [JsonProperty("fileLinkRelease")]
        public string fileLinkRelease { get; set; }
        //参考URL
        [JsonProperty("referenceURL")]
        public string referenceURL { get; set; }
        //重要度
        [JsonProperty("severity")]
        public string severity { get; set; }
        //対象日
        [JsonProperty("targetDate")]
        public string targetDate { get; set; }
        //連絡日時
        [JsonProperty("contactTime")]
        public string contactTime { get; set; }
        //WEB返信要求
        [JsonProperty("webReplyRequest")]
        public string webReplyRequest { get; set; }
    }

}
