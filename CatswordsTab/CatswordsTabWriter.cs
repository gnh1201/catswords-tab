using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatswordsTab
{
    public partial class CatswordsTabWriter : Form
    {
        public CatswordsTabWriter()
        {
            InitializeComponent();
            InitializeLocalization();
        }

        private void InitializeLocalization()
        {
            btnSend.Text = "전송";
            labelTitle.Text = "의견작성";
            labelEmail.Text = "이메일 주소";
            labelMessage.Text = "남기실 말";
            cbPrivacy.Text = "개인정보 수집에 동의합니다.";
        }

        private void CatswordsTabWriter_Load(object sender, EventArgs e)
        {

        }

        private void CatswordsTabWriter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
