namespace JSFW.Fake.Editor
{
    partial class EditorFkPanel
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
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.rdoWhiteBlack = new System.Windows.Forms.RadioButton();
            this.rdoDeepSkyBlueWhite = new System.Windows.Forms.RadioButton();
            this.rdoDodgerBlueWhite = new System.Windows.Forms.RadioButton();
            this.rdoCoralWhite = new System.Windows.Forms.RadioButton();
            this.rdoOrangeRedWhite = new System.Windows.Forms.RadioButton();
            this.rdoBlackWhite = new System.Windows.Forms.RadioButton();
            this.rdoGrayWhite = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(3, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTitle.Size = new System.Drawing.Size(151, 21);
            this.txtTitle.TabIndex = 3;
            // 
            // chkVisible
            // 
            this.chkVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVisible.AutoSize = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(160, 7);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(48, 16);
            this.chkVisible.TabIndex = 5;
            this.chkVisible.Text = "표시";
            this.chkVisible.UseVisualStyleBackColor = true;
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
            this.rdoWhiteBlack.Location = new System.Drawing.Point(3, 26);
            this.rdoWhiteBlack.Name = "rdoWhiteBlack";
            this.rdoWhiteBlack.Size = new System.Drawing.Size(24, 24);
            this.rdoWhiteBlack.TabIndex = 6;
            this.rdoWhiteBlack.TabStop = true;
            this.rdoWhiteBlack.Text = "ㄱ";
            this.rdoWhiteBlack.UseVisualStyleBackColor = false;
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
            this.rdoDeepSkyBlueWhite.Location = new System.Drawing.Point(153, 26);
            this.rdoDeepSkyBlueWhite.Name = "rdoDeepSkyBlueWhite";
            this.rdoDeepSkyBlueWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoDeepSkyBlueWhite.TabIndex = 6;
            this.rdoDeepSkyBlueWhite.TabStop = true;
            this.rdoDeepSkyBlueWhite.Text = "ㄴ";
            this.rdoDeepSkyBlueWhite.UseVisualStyleBackColor = false;
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
            this.rdoDodgerBlueWhite.Location = new System.Drawing.Point(183, 26);
            this.rdoDodgerBlueWhite.Name = "rdoDodgerBlueWhite";
            this.rdoDodgerBlueWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoDodgerBlueWhite.TabIndex = 6;
            this.rdoDodgerBlueWhite.TabStop = true;
            this.rdoDodgerBlueWhite.Text = "ㄷ";
            this.rdoDodgerBlueWhite.UseVisualStyleBackColor = false;
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
            this.rdoCoralWhite.Location = new System.Drawing.Point(93, 26);
            this.rdoCoralWhite.Name = "rdoCoralWhite";
            this.rdoCoralWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoCoralWhite.TabIndex = 6;
            this.rdoCoralWhite.TabStop = true;
            this.rdoCoralWhite.Text = "ㄴ";
            this.rdoCoralWhite.UseVisualStyleBackColor = false;
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
            this.rdoOrangeRedWhite.Location = new System.Drawing.Point(123, 26);
            this.rdoOrangeRedWhite.Name = "rdoOrangeRedWhite";
            this.rdoOrangeRedWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoOrangeRedWhite.TabIndex = 6;
            this.rdoOrangeRedWhite.TabStop = true;
            this.rdoOrangeRedWhite.Text = "ㄴ";
            this.rdoOrangeRedWhite.UseVisualStyleBackColor = false;
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
            this.rdoBlackWhite.Location = new System.Drawing.Point(33, 26);
            this.rdoBlackWhite.Name = "rdoBlackWhite";
            this.rdoBlackWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoBlackWhite.TabIndex = 6;
            this.rdoBlackWhite.TabStop = true;
            this.rdoBlackWhite.Text = "ㄱ";
            this.rdoBlackWhite.UseVisualStyleBackColor = false;
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
            this.rdoGrayWhite.Location = new System.Drawing.Point(63, 26);
            this.rdoGrayWhite.Name = "rdoGrayWhite";
            this.rdoGrayWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoGrayWhite.TabIndex = 6;
            this.rdoGrayWhite.TabStop = true;
            this.rdoGrayWhite.Text = "ㄱ";
            this.rdoGrayWhite.UseVisualStyleBackColor = false;
            this.rdoGrayWhite.CheckedChanged += new System.EventHandler(this.rdoGrayWhite_CheckedChanged);
            // 
            // EditorFkPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoDodgerBlueWhite);
            this.Controls.Add(this.rdoOrangeRedWhite);
            this.Controls.Add(this.rdoCoralWhite);
            this.Controls.Add(this.rdoDeepSkyBlueWhite);
            this.Controls.Add(this.rdoGrayWhite);
            this.Controls.Add(this.rdoBlackWhite);
            this.Controls.Add(this.rdoWhiteBlack);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.chkVisible);
            this.Name = "EditorFkPanel";
            this.Size = new System.Drawing.Size(211, 52);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.RadioButton rdoWhiteBlack;
        private System.Windows.Forms.RadioButton rdoDeepSkyBlueWhite;
        private System.Windows.Forms.RadioButton rdoDodgerBlueWhite;
        private System.Windows.Forms.RadioButton rdoCoralWhite;
        private System.Windows.Forms.RadioButton rdoOrangeRedWhite;
        private System.Windows.Forms.RadioButton rdoBlackWhite;
        private System.Windows.Forms.RadioButton rdoGrayWhite;
    }
}
