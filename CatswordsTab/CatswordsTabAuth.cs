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
    public partial class CatswordsTabAuth : Form
    {
        public CatswordsTabAuth()
        {
            InitializeComponent();
            InitializeLocalization();
        }

        private void InitializeLocalization()
        {
            btnApply.Text = "가입";
            btnForgot.Text = "찾기";
            btnLogin.Text = "로그인";
            labelUsername.Text = "사용자 이메일";
            labelPassword.Text = "사용자 열쇠글";
            labelTitle.Text = "인증";
            labelCopyright.Text = "(c) 2019 Catswords Research.";
        }

        private void CatswordsTabAuth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
