using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpShell.SharpPropertySheet;
using System.Security.Cryptography;
using System.IO;

namespace CatswordsTab
{
    public partial class CatswordsTabPage : SharpPropertyPage
    {
        private string filePath;
        private string fileMd5;
        private string fileSha1;
        private string fileExt;
        private string fileFirst32;
        private string baseUrl = "https://exts.kr/api/v2/?route=tab";
        public CatswordsTabPage()
        {
            InitializeComponent();

            PageTitle = "Community";
            InitializeLocalzation();
        }

        private void InitializeLocalzation()
        {
            PageTitle = "커뮤니티";
            btnAdd.Text = "의견작성";
            btnAuth.Text = "로그인";
            labelTitle.Text = "커뮤니티";
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            CatswordsTabHelper HelperInstance = new CatswordsTabHelper();

            SimpleRest restInstance = new SimpleRest();
            filePath = parent.SelectedItemPaths.First();
            fileMd5 = HelperInstance.GetFileMd5(filePath);
            fileSha1 = HelperInstance.GetFileSha1(filePath);
            fileExt = HelperInstance.GetFileExtension(filePath);
            fileFirst32 = HelperInstance.GetFileHead32(filePath);
 
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("action", "read");
            dataDict.Add("md5", fileMd5);
            dataDict.Add("sha1", fileSha1);
            dataDict.Add("extension", fileExt);
            dataDict.Add("first32", fileFirst32);

            string requestUrl = baseUrl;
            string requestData = ConvertDictToJson(dataDict);
            string responseText = restInstance.Post(requestUrl, requestData);
            txtTerminal.Text = responseText;
            txtTerminal.ScrollBars = ScrollBars.Vertical;
        }

        protected override void OnPropertySheetApply()
        {
        }

        protected override void OnPropertySheetOK()
        {
        }

        private string ConvertDictToJson(Dictionary<string, string> dataDict)
        {
            StringBuilder jsonData = new StringBuilder();
            jsonData.Append("{");

            int i = 0;
            foreach (KeyValuePair<string, string> entry in dataDict)
            {
                jsonData.Append(string.Format("\"{0}\":\"{1}\"", entry.Key, entry.Value));
                if(i < (dataDict.Count - 1))
                {
                    jsonData.Append(",");
                }
                i++;
            }

            jsonData.Append("}");

            return jsonData.ToString();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(txtTerminal.Text.ToCharArray()));

            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("action", "write");
            dataDict.Add("md5", fileMd5);
            dataDict.Add("sha1", fileSha1);
            dataDict.Add("extension", fileExt);
            dataDict.Add("first32", fileFirst32);
            dataDict.Add("message", message);
   
            SimpleRest restInstance = new SimpleRest();
            string requestUrl = baseUrl;
            string requestData = ConvertDictToJson(dataDict);
            string responseText = restInstance.Post(requestUrl, requestData);
            txtTerminal.Text = responseText;
        }

        // https://stackoverflow.com/questions/10520048/calculate-md5-checksum-for-a-file
        private string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private string CalculateSHA1(string filename)
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = sha1.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        // https://stackoverflow.com/questions/7514101/how-do-i-read-exactly-n-bytes-from-a-stream
        private string ReadFirst32(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                int count = 32;
                
                byte[] buffer = new byte[count];
                int offset = 0;
                while (offset < count)
                {
                    int read = stream.Read(buffer, offset, count - offset);
                    if (read == 0)
                        throw new System.IO.EndOfStreamException();
                    offset += read;
                }
                System.Diagnostics.Debug.Assert(offset == count);

                return Convert.ToBase64String(buffer);
            }
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            CatswordsTabAuth authForm = new CatswordsTabAuth();
            authForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CatswordsTabWriter writerForm = new CatswordsTabWriter();
            writerForm.Show();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void CatswordsTabPage_Load(object sender, EventArgs e)
        {

        }

    }
}
