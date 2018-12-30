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
        private string baseUrl = "https://exts.kr/api/v2/?route=tab";
  
        public CatswordsTabPage()
        {
            InitializeComponent();
            PageTitle = "CatswordsTab ";
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            filePath = parent.SelectedItemPaths.First();
            fileMd5 = CalculateMD5(filePath);
            fileSha1 = CalculateSHA1(filePath);

            SimpleRest restInstance = new SimpleRest();
            string requestUrl = baseUrl + "&md5=" + fileMd5 + "&sha1=" + fileSha1;
            string responseText = restInstance.Get(requestUrl);
            textBox1.Text = responseText;
        }

        protected override void OnPropertySheetApply()
        {
        }

        protected override void OnPropertySheetOK()
        {
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
    }
}
