namespace JSFW.Fake.Editor
{
    partial class EditorFkTabControl
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.chkPanelVisible = new System.Windows.Forms.CheckBox();
            this.rdoWhiteBlack = new System.Windows.Forms.RadioButton();
            this.rdoDeepSkyBlueWhite = new System.Windows.Forms.RadioButton();
            this.rdoDodgerBlueWhite = new System.Windows.Forms.RadioButton();
            this.rdoCoralWhite = new System.Windows.Forms.RadioButton();
            this.rdoOrangeRedWhite = new System.Windows.Forms.RadioButton();
            this.rdoBlackWhite = new System.Windows.Forms.RadioButton();
            this.rdoGrayWhite = new System.Windows.Forms.RadioButton();
            this.pnlTabPageList = new System.Windows.Forms.Panel();
            this.btnDelTabPage = new System.Windows.Forms.Button();
            this.btnAddTabPage = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.chkTabVisible = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(180, 32);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTitle.Size = new System.Drawing.Size(205, 21);
            this.txtTitle.TabIndex = 3;
            // 
            // chkPanelVisible
            // 
            this.chkPanelVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPanelVisible.AutoSize = true;
            this.chkPanelVisible.Checked = true;
            this.chkPanelVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPanelVisible.Location = new System.Drawing.Point(308, 59);
            this.chkPanelVisible.Name = "chkPanelVisible";
            this.chkPanelVisible.Size = new System.Drawing.Size(76, 16);
            this.chkPanelVisible.TabIndex = 5;
            this.chkPanelVisible.Text = "판넬 표시";
            this.chkPanelVisible.UseVisualStyleBackColor = true;
            // 
            // rdoWhiteBlack
            // 
            this.rdoWhiteBlack.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoWhiteBlack.BackColor = System.Drawing.Color.Silver;
            this.rdoWhiteBlack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.rdoWhiteBlack.FlatAppearance.BorderSize = 2;
            this.rdoWhiteBlack.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.rdoWhiteBlack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.rdoWhiteBlack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoWhiteBlack.Location = new System.Drawing.Point(180, 156);
            this.rdoWhiteBlack.Name = "rdoWhiteBlack";
            this.rdoWhiteBlack.Size = new System.Drawing.Size(24, 24);
            this.rdoWhiteBlack.TabIndex = 6;
            this.rdoWhiteBlack.TabStop = true;
            this.rdoWhiteBlack.Text = "ㄱ";
            this.rdoWhiteBlack.UseVisualStyleBackColor = false;
            this.rdoWhiteBlack.Visible = false;
            this.rdoWhiteBlack.CheckedChanged += new System.EventHandler(this.rdoWhiteBlack_CheckedChanged);
            // 
            // rdoDeepSkyBlueWhite
            // 
            this.rdoDeepSkyBlueWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDeepSkyBlueWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoDeepSkyBlueWhite.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.rdoDeepSkyBlueWhite.FlatAppearance.BorderSize = 2;
            this.rdoDeepSkyBlueWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.rdoDeepSkyBlueWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.rdoDeepSkyBlueWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoDeepSkyBlueWhite.ForeColor = System.Drawing.Color.White;
            this.rdoDeepSkyBlueWhite.Location = new System.Drawing.Point(330, 156);
            this.rdoDeepSkyBlueWhite.Name = "rdoDeepSkyBlueWhite";
            this.rdoDeepSkyBlueWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoDeepSkyBlueWhite.TabIndex = 6;
            this.rdoDeepSkyBlueWhite.TabStop = true;
            this.rdoDeepSkyBlueWhite.Text = "ㄴ";
            this.rdoDeepSkyBlueWhite.UseVisualStyleBackColor = false;
            this.rdoDeepSkyBlueWhite.Visible = false;
            this.rdoDeepSkyBlueWhite.CheckedChanged += new System.EventHandler(this.rdoDeepSkyBlueWhite_CheckedChanged);
            // 
            // rdoDodgerBlueWhite
            // 
            this.rdoDodgerBlueWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDodgerBlueWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoDodgerBlueWhite.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdoDodgerBlueWhite.FlatAppearance.BorderSize = 2;
            this.rdoDodgerBlueWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.rdoDodgerBlueWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.rdoDodgerBlueWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoDodgerBlueWhite.ForeColor = System.Drawing.Color.White;
            this.rdoDodgerBlueWhite.Location = new System.Drawing.Point(360, 156);
            this.rdoDodgerBlueWhite.Name = "rdoDodgerBlueWhite";
            this.rdoDodgerBlueWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoDodgerBlueWhite.TabIndex = 6;
            this.rdoDodgerBlueWhite.TabStop = true;
            this.rdoDodgerBlueWhite.Text = "ㄷ";
            this.rdoDodgerBlueWhite.UseVisualStyleBackColor = false;
            this.rdoDodgerBlueWhite.Visible = false;
            this.rdoDodgerBlueWhite.CheckedChanged += new System.EventHandler(this.rdoDodgerBlueWhite_CheckedChanged);
            // 
            // rdoCoralWhite
            // 
            this.rdoCoralWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoCoralWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoCoralWhite.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.rdoCoralWhite.FlatAppearance.BorderSize = 2;
            this.rdoCoralWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.Coral;
            this.rdoCoralWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.rdoCoralWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoCoralWhite.ForeColor = System.Drawing.Color.White;
            this.rdoCoralWhite.Location = new System.Drawing.Point(270, 156);
            this.rdoCoralWhite.Name = "rdoCoralWhite";
            this.rdoCoralWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoCoralWhite.TabIndex = 6;
            this.rdoCoralWhite.TabStop = true;
            this.rdoCoralWhite.Text = "ㄴ";
            this.rdoCoralWhite.UseVisualStyleBackColor = false;
            this.rdoCoralWhite.Visible = false;
            this.rdoCoralWhite.CheckedChanged += new System.EventHandler(this.rdoCoralWhite_CheckedChanged);
            // 
            // rdoOrangeRedWhite
            // 
            this.rdoOrangeRedWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoOrangeRedWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoOrangeRedWhite.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.rdoOrangeRedWhite.FlatAppearance.BorderSize = 2;
            this.rdoOrangeRedWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.OrangeRed;
            this.rdoOrangeRedWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.rdoOrangeRedWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoOrangeRedWhite.ForeColor = System.Drawing.Color.White;
            this.rdoOrangeRedWhite.Location = new System.Drawing.Point(300, 156);
            this.rdoOrangeRedWhite.Name = "rdoOrangeRedWhite";
            this.rdoOrangeRedWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoOrangeRedWhite.TabIndex = 6;
            this.rdoOrangeRedWhite.TabStop = true;
            this.rdoOrangeRedWhite.Text = "ㄴ";
            this.rdoOrangeRedWhite.UseVisualStyleBackColor = false;
            this.rdoOrangeRedWhite.Visible = false;
            this.rdoOrangeRedWhite.CheckedChanged += new System.EventHandler(this.rdoOrangeRedWhite_CheckedChanged);
            // 
            // rdoBlackWhite
            // 
            this.rdoBlackWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBlackWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoBlackWhite.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rdoBlackWhite.FlatAppearance.BorderSize = 2;
            this.rdoBlackWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.rdoBlackWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.rdoBlackWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoBlackWhite.ForeColor = System.Drawing.Color.White;
            this.rdoBlackWhite.Location = new System.Drawing.Point(210, 156);
            this.rdoBlackWhite.Name = "rdoBlackWhite";
            this.rdoBlackWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoBlackWhite.TabIndex = 6;
            this.rdoBlackWhite.TabStop = true;
            this.rdoBlackWhite.Text = "ㄱ";
            this.rdoBlackWhite.UseVisualStyleBackColor = false;
            this.rdoBlackWhite.Visible = false;
            this.rdoBlackWhite.CheckedChanged += new System.EventHandler(this.rdoBlackWhite_CheckedChanged);
            // 
            // rdoGrayWhite
            // 
            this.rdoGrayWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoGrayWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoGrayWhite.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.rdoGrayWhite.FlatAppearance.BorderSize = 2;
            this.rdoGrayWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.rdoGrayWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.rdoGrayWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoGrayWhite.ForeColor = System.Drawing.Color.White;
            this.rdoGrayWhite.Location = new System.Drawing.Point(240, 156);
            this.rdoGrayWhite.Name = "rdoGrayWhite";
            this.rdoGrayWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoGrayWhite.TabIndex = 6;
            this.rdoGrayWhite.TabStop = true;
            this.rdoGrayWhite.Text = "ㄱ";
            this.rdoGrayWhite.UseVisualStyleBackColor = false;
            this.rdoGrayWhite.Visible = false;
            this.rdoGrayWhite.CheckedChanged += new System.EventHandler(this.rdoGrayWhite_CheckedChanged);
            // 
            // pnlTabPageList
            // 
            this.pnlTabPageList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTabPageList.AutoScroll = true;
            this.pnlTabPageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTabPageList.Location = new System.Drawing.Point(4, 31);
            this.pnlTabPageList.Name = "pnlTabPageList";
            this.pnlTabPageList.Size = new System.Drawing.Size(172, 149);
            this.pnlTabPageList.TabIndex = 7;
            // 
            // btnDelTabPage
            // 
            this.btnDelTabPage.BackColor = System.Drawing.Color.White;
            this.btnDelTabPage.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDelTabPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelTabPage.Location = new System.Drawing.Point(330, 88);
            this.btnDelTabPage.Name = "btnDelTabPage";
            this.btnDelTabPage.Size = new System.Drawing.Size(54, 23);
            this.btnDelTabPage.TabIndex = 999;
            this.btnDelTabPage.TabStop = false;
            this.btnDelTabPage.Text = "삭제";
            this.btnDelTabPage.UseVisualStyleBackColor = false;
            this.btnDelTabPage.Click += new System.EventHandler(this.btnDelTabPage_Click);
            // 
            // btnAddTabPage
            // 
            this.btnAddTabPage.BackColor = System.Drawing.Color.White;
            this.btnAddTabPage.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAddTabPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTabPage.Location = new System.Drawing.Point(270, 88);
            this.btnAddTabPage.Name = "btnAddTabPage";
            this.btnAddTabPage.Size = new System.Drawing.Size(54, 23);
            this.btnAddTabPage.TabIndex = 9;
            this.btnAddTabPage.Text = "추가";
            this.btnAddTabPage.UseVisualStyleBackColor = false;
            this.btnAddTabPage.Click += new System.EventHandler(this.btnAddTabPage_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(180, 59);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 23);
            this.btnUp.TabIndex = 1000;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(180, 88);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 23);
            this.btnDown.TabIndex = 1000;
            this.btnDown.Text = "▼";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // chkTabVisible
            // 
            this.chkTabVisible.AutoSize = true;
            this.chkTabVisible.Checked = true;
            this.chkTabVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTabVisible.Location = new System.Drawing.Point(5, 7);
            this.chkTabVisible.Name = "chkTabVisible";
            this.chkTabVisible.Size = new System.Drawing.Size(64, 16);
            this.chkTabVisible.TabIndex = 5;
            this.chkTabVisible.Text = "탭 표시";
            this.chkTabVisible.UseVisualStyleBackColor = true;
            // 
            // EditorFkTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnAddTabPage);
            this.Controls.Add(this.btnDelTabPage);
            this.Controls.Add(this.pnlTabPageList);
            this.Controls.Add(this.rdoDodgerBlueWhite);
            this.Controls.Add(this.rdoOrangeRedWhite);
            this.Controls.Add(this.rdoCoralWhite);
            this.Controls.Add(this.rdoDeepSkyBlueWhite);
            this.Controls.Add(this.rdoGrayWhite);
            this.Controls.Add(this.rdoBlackWhite);
            this.Controls.Add(this.rdoWhiteBlack);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.chkTabVisible);
            this.Controls.Add(this.chkPanelVisible);
            this.Name = "EditorFkTabControl";
            this.Size = new System.Drawing.Size(388, 183);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckBox chkPanelVisible;
        private System.Windows.Forms.RadioButton rdoWhiteBlack;
        private System.Windows.Forms.RadioButton rdoDeepSkyBlueWhite;
        private System.Windows.Forms.RadioButton rdoDodgerBlueWhite;
        private System.Windows.Forms.RadioButton rdoCoralWhite;
        private System.Windows.Forms.RadioButton rdoOrangeRedWhite;
        private System.Windows.Forms.RadioButton rdoBlackWhite;
        private System.Windows.Forms.RadioButton rdoGrayWhite;
        private System.Windows.Forms.Panel pnlTabPageList;
        private System.Windows.Forms.Button btnDelTabPage;
        private System.Windows.Forms.Button btnAddTabPage;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.CheckBox chkTabVisible;
    }
}
