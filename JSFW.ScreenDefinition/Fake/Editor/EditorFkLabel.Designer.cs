namespace JSFW.Fake.Editor
{
    partial class EditorFkLabel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoAlignRIGHT = new System.Windows.Forms.RadioButton();
            this.rdoAlignCENTER = new System.Windows.Forms.RadioButton();
            this.rdoAlignLEFT = new System.Windows.Forms.RadioButton();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.chkRequird = new System.Windows.Forms.CheckBox();
            this.rdoDodgerBlueWhite = new System.Windows.Forms.RadioButton();
            this.rdoOrangeRedWhite = new System.Windows.Forms.RadioButton();
            this.rdoCoralWhite = new System.Windows.Forms.RadioButton();
            this.rdoDeepSkyBlueWhite = new System.Windows.Forms.RadioButton();
            this.rdoGrayWhite = new System.Windows.Forms.RadioButton();
            this.rdoBlackWhite = new System.Windows.Forms.RadioButton();
            this.rdoWhiteBlack = new System.Windows.Forms.RadioButton();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoAlignRIGHT);
            this.panel1.Controls.Add(this.rdoAlignCENTER);
            this.panel1.Controls.Add(this.rdoAlignLEFT);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 30);
            this.panel1.TabIndex = 4;
            // 
            // rdoAlignRIGHT
            // 
            this.rdoAlignRIGHT.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAlignRIGHT.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoAlignRIGHT.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoAlignRIGHT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoAlignRIGHT.Location = new System.Drawing.Point(175, 3);
            this.rdoAlignRIGHT.Name = "rdoAlignRIGHT";
            this.rdoAlignRIGHT.Size = new System.Drawing.Size(80, 24);
            this.rdoAlignRIGHT.TabIndex = 0;
            this.rdoAlignRIGHT.TabStop = true;
            this.rdoAlignRIGHT.Text = "오른쪽";
            this.rdoAlignRIGHT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoAlignRIGHT.UseVisualStyleBackColor = true;
            // 
            // rdoAlignCENTER
            // 
            this.rdoAlignCENTER.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAlignCENTER.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoAlignCENTER.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoAlignCENTER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoAlignCENTER.Location = new System.Drawing.Point(89, 3);
            this.rdoAlignCENTER.Name = "rdoAlignCENTER";
            this.rdoAlignCENTER.Size = new System.Drawing.Size(80, 24);
            this.rdoAlignCENTER.TabIndex = 0;
            this.rdoAlignCENTER.TabStop = true;
            this.rdoAlignCENTER.Text = "가운데";
            this.rdoAlignCENTER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAlignCENTER.UseVisualStyleBackColor = true;
            // 
            // rdoAlignLEFT
            // 
            this.rdoAlignLEFT.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAlignLEFT.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoAlignLEFT.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoAlignLEFT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoAlignLEFT.Location = new System.Drawing.Point(3, 3);
            this.rdoAlignLEFT.Name = "rdoAlignLEFT";
            this.rdoAlignLEFT.Size = new System.Drawing.Size(80, 24);
            this.rdoAlignLEFT.TabIndex = 0;
            this.rdoAlignLEFT.TabStop = true;
            this.rdoAlignLEFT.Text = "왼쪽";
            this.rdoAlignLEFT.UseVisualStyleBackColor = true;
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(3, 35);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(331, 75);
            this.txtContent.TabIndex = 3;
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(276, 3);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(48, 16);
            this.chkVisible.TabIndex = 5;
            this.chkVisible.Text = "표시";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // chkRequird
            // 
            this.chkRequird.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRequird.AutoSize = true;
            this.chkRequird.Location = new System.Drawing.Point(4, 121);
            this.chkRequird.Name = "chkRequird";
            this.chkRequird.Size = new System.Drawing.Size(48, 16);
            this.chkRequird.TabIndex = 6;
            this.chkRequird.Text = "필수";
            this.chkRequird.UseVisualStyleBackColor = true;
            // 
            // rdoDodgerBlueWhite
            // 
            this.rdoDodgerBlueWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoDodgerBlueWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDodgerBlueWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoDodgerBlueWhite.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rdoDodgerBlueWhite.FlatAppearance.BorderSize = 2;
            this.rdoDodgerBlueWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.rdoDodgerBlueWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.rdoDodgerBlueWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoDodgerBlueWhite.ForeColor = System.Drawing.Color.White;
            this.rdoDodgerBlueWhite.Location = new System.Drawing.Point(306, 116);
            this.rdoDodgerBlueWhite.Name = "rdoDodgerBlueWhite";
            this.rdoDodgerBlueWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoDodgerBlueWhite.TabIndex = 7;
            this.rdoDodgerBlueWhite.TabStop = true;
            this.rdoDodgerBlueWhite.Text = "ㄷ";
            this.rdoDodgerBlueWhite.UseVisualStyleBackColor = false;
            this.rdoDodgerBlueWhite.CheckedChanged += new System.EventHandler(this.rdoDodgerBlueWhite_CheckedChanged);
            // 
            // rdoOrangeRedWhite
            // 
            this.rdoOrangeRedWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoOrangeRedWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoOrangeRedWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoOrangeRedWhite.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.rdoOrangeRedWhite.FlatAppearance.BorderSize = 2;
            this.rdoOrangeRedWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.OrangeRed;
            this.rdoOrangeRedWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
            this.rdoOrangeRedWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoOrangeRedWhite.ForeColor = System.Drawing.Color.White;
            this.rdoOrangeRedWhite.Location = new System.Drawing.Point(246, 116);
            this.rdoOrangeRedWhite.Name = "rdoOrangeRedWhite";
            this.rdoOrangeRedWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoOrangeRedWhite.TabIndex = 8;
            this.rdoOrangeRedWhite.TabStop = true;
            this.rdoOrangeRedWhite.Text = "ㄴ";
            this.rdoOrangeRedWhite.UseVisualStyleBackColor = false;
            this.rdoOrangeRedWhite.CheckedChanged += new System.EventHandler(this.rdoOrangeRedWhite_CheckedChanged);
            // 
            // rdoCoralWhite
            // 
            this.rdoCoralWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoCoralWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoCoralWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoCoralWhite.FlatAppearance.BorderColor = System.Drawing.Color.Coral;
            this.rdoCoralWhite.FlatAppearance.BorderSize = 2;
            this.rdoCoralWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.Coral;
            this.rdoCoralWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.rdoCoralWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoCoralWhite.ForeColor = System.Drawing.Color.White;
            this.rdoCoralWhite.Location = new System.Drawing.Point(216, 116);
            this.rdoCoralWhite.Name = "rdoCoralWhite";
            this.rdoCoralWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoCoralWhite.TabIndex = 9;
            this.rdoCoralWhite.TabStop = true;
            this.rdoCoralWhite.Text = "ㄴ";
            this.rdoCoralWhite.UseVisualStyleBackColor = false;
            this.rdoCoralWhite.CheckedChanged += new System.EventHandler(this.rdoCoralWhite_CheckedChanged);
            // 
            // rdoDeepSkyBlueWhite
            // 
            this.rdoDeepSkyBlueWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoDeepSkyBlueWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDeepSkyBlueWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoDeepSkyBlueWhite.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.rdoDeepSkyBlueWhite.FlatAppearance.BorderSize = 2;
            this.rdoDeepSkyBlueWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.rdoDeepSkyBlueWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.rdoDeepSkyBlueWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoDeepSkyBlueWhite.ForeColor = System.Drawing.Color.White;
            this.rdoDeepSkyBlueWhite.Location = new System.Drawing.Point(276, 116);
            this.rdoDeepSkyBlueWhite.Name = "rdoDeepSkyBlueWhite";
            this.rdoDeepSkyBlueWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoDeepSkyBlueWhite.TabIndex = 10;
            this.rdoDeepSkyBlueWhite.TabStop = true;
            this.rdoDeepSkyBlueWhite.Text = "ㄴ";
            this.rdoDeepSkyBlueWhite.UseVisualStyleBackColor = false;
            this.rdoDeepSkyBlueWhite.CheckedChanged += new System.EventHandler(this.rdoDeepSkyBlueWhite_CheckedChanged);
            // 
            // rdoGrayWhite
            // 
            this.rdoGrayWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoGrayWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoGrayWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoGrayWhite.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.rdoGrayWhite.FlatAppearance.BorderSize = 2;
            this.rdoGrayWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.rdoGrayWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.rdoGrayWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoGrayWhite.ForeColor = System.Drawing.Color.White;
            this.rdoGrayWhite.Location = new System.Drawing.Point(186, 116);
            this.rdoGrayWhite.Name = "rdoGrayWhite";
            this.rdoGrayWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoGrayWhite.TabIndex = 11;
            this.rdoGrayWhite.TabStop = true;
            this.rdoGrayWhite.Text = "ㄱ";
            this.rdoGrayWhite.UseVisualStyleBackColor = false;
            this.rdoGrayWhite.CheckedChanged += new System.EventHandler(this.rdoGrayWhite_CheckedChanged);
            // 
            // rdoBlackWhite
            // 
            this.rdoBlackWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoBlackWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBlackWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoBlackWhite.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rdoBlackWhite.FlatAppearance.BorderSize = 2;
            this.rdoBlackWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.rdoBlackWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.rdoBlackWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoBlackWhite.ForeColor = System.Drawing.Color.Yellow;
            this.rdoBlackWhite.Location = new System.Drawing.Point(156, 116);
            this.rdoBlackWhite.Name = "rdoBlackWhite";
            this.rdoBlackWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoBlackWhite.TabIndex = 12;
            this.rdoBlackWhite.TabStop = true;
            this.rdoBlackWhite.Text = "ㄱ";
            this.rdoBlackWhite.UseVisualStyleBackColor = false;
            this.rdoBlackWhite.CheckedChanged += new System.EventHandler(this.rdoBlackWhite_CheckedChanged);
            // 
            // rdoWhiteBlack
            // 
            this.rdoWhiteBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoWhiteBlack.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoWhiteBlack.BackColor = System.Drawing.Color.Silver;
            this.rdoWhiteBlack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.rdoWhiteBlack.FlatAppearance.BorderSize = 2;
            this.rdoWhiteBlack.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.rdoWhiteBlack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.rdoWhiteBlack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoWhiteBlack.Location = new System.Drawing.Point(126, 116);
            this.rdoWhiteBlack.Name = "rdoWhiteBlack";
            this.rdoWhiteBlack.Size = new System.Drawing.Size(24, 24);
            this.rdoWhiteBlack.TabIndex = 13;
            this.rdoWhiteBlack.TabStop = true;
            this.rdoWhiteBlack.Text = "ㄱ";
            this.rdoWhiteBlack.UseVisualStyleBackColor = false;
            this.rdoWhiteBlack.CheckedChanged += new System.EventHandler(this.rdoWhiteBlack_CheckedChanged);
            // 
            // chkBold
            // 
            this.chkBold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBold.AutoSize = true;
            this.chkBold.Location = new System.Drawing.Point(58, 121);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(48, 16);
            this.chkBold.TabIndex = 6;
            this.chkBold.Text = "굵게";
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.chkBold_CheckedChanged);
            // 
            // EditorFkLabel
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
            this.Controls.Add(this.chkBold);
            this.Controls.Add(this.chkRequird);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.chkVisible);
            this.Name = "EditorFkLabel";
            this.Size = new System.Drawing.Size(337, 143);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoAlignRIGHT;
        private System.Windows.Forms.RadioButton rdoAlignCENTER;
        private System.Windows.Forms.RadioButton rdoAlignLEFT;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.CheckBox chkRequird;
        private System.Windows.Forms.RadioButton rdoDodgerBlueWhite;
        private System.Windows.Forms.RadioButton rdoOrangeRedWhite;
        private System.Windows.Forms.RadioButton rdoCoralWhite;
        private System.Windows.Forms.RadioButton rdoDeepSkyBlueWhite;
        private System.Windows.Forms.RadioButton rdoGrayWhite;
        private System.Windows.Forms.RadioButton rdoBlackWhite;
        private System.Windows.Forms.RadioButton rdoWhiteBlack;
        private System.Windows.Forms.CheckBox chkBold;
    }
}
