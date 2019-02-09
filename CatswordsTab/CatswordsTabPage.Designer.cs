﻿namespace CatswordsTab
{
    partial class CatswordsTabPage
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAuth = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.txtTerminal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAuth
            // 
            this.btnAuth.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAuth.FlatAppearance.BorderSize = 0;
            this.btnAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuth.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.btnAuth.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAuth.Image = global::CatswordsTab.Properties.Resources.IconLogin32;
            this.btnAuth.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAuth.Location = new System.Drawing.Point(254, 25);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(127, 40);
            this.btnAuth.TabIndex = 0;
            this.btnAuth.Text = "btnAuth";
            this.btnAuth.UseVisualStyleBackColor = false;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAdd.Image = global::CatswordsTab.Properties.Resources.IconPencli32;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAdd.Location = new System.Drawing.Point(254, 73);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(127, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.labelTitle.Location = new System.Drawing.Point(74, 55);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(126, 37);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "labelTitle";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // txtTerminal
            // 
            this.txtTerminal.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtTerminal.Location = new System.Drawing.Point(15, 122);
            this.txtTerminal.Multiline = true;
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.Size = new System.Drawing.Size(366, 335);
            this.txtTerminal.TabIndex = 3;
            // 
            // CatswordsTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::CatswordsTab.Properties.Resources.IconDialogue128;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.txtTerminal);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnAuth);
            this.Name = "CatswordsTabPage";
            this.Size = new System.Drawing.Size(396, 500);
            this.Load += new System.EventHandler(this.CatswordsTabPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox txtTerminal;
    }
}
