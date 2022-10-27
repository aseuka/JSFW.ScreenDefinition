namespace JSFW.Fake.Editor
{
    partial class EditorFkButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorFkButton));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.rdoDodgerBlueWhite = new System.Windows.Forms.RadioButton();
            this.rdoOrangeRedWhite = new System.Windows.Forms.RadioButton();
            this.rdoCoralWhite = new System.Windows.Forms.RadioButton();
            this.rdoDeepSkyBlueWhite = new System.Windows.Forms.RadioButton();
            this.rdoGrayWhite = new System.Windows.Forms.RadioButton();
            this.rdoBlackWhite = new System.Windows.Forms.RadioButton();
            this.rdoWhiteBlack = new System.Windows.Forms.RadioButton();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnClip = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnExe = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(149, 21);
            this.textBox1.TabIndex = 3;
            // 
            // chkVisible
            // 
            this.chkVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVisible.AutoSize = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(158, 5);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(48, 16);
            this.chkVisible.TabIndex = 5;
            this.chkVisible.Text = "표시";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // rdoDodgerBlueWhite
            // 
            this.rdoDodgerBlueWhite.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDodgerBlueWhite.BackColor = System.Drawing.Color.Silver;
            this.rdoDodgerBlueWhite.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.rdoDodgerBlueWhite.FlatAppearance.BorderSize = 2;
            this.rdoDodgerBlueWhite.FlatAppearance.CheckedBackColor = System.Drawing.Color.ForestGreen;
            this.rdoDodgerBlueWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.rdoDodgerBlueWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoDodgerBlueWhite.ForeColor = System.Drawing.Color.White;
            this.rdoDodgerBlueWhite.Location = new System.Drawing.Point(185, 27);
            this.rdoDodgerBlueWhite.Name = "rdoDodgerBlueWhite";
            this.rdoDodgerBlueWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoDodgerBlueWhite.TabIndex = 14;
            this.rdoDodgerBlueWhite.TabStop = true;
            this.rdoDodgerBlueWhite.Text = "ㄷ";
            this.rdoDodgerBlueWhite.UseVisualStyleBackColor = false;
            this.rdoDodgerBlueWhite.CheckedChanged += new System.EventHandler(this.rdoDodgerBlueWhite_CheckedChanged);
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
            this.rdoOrangeRedWhite.Location = new System.Drawing.Point(125, 27);
            this.rdoOrangeRedWhite.Name = "rdoOrangeRedWhite";
            this.rdoOrangeRedWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoOrangeRedWhite.TabIndex = 15;
            this.rdoOrangeRedWhite.TabStop = true;
            this.rdoOrangeRedWhite.Text = "ㄴ";
            this.rdoOrangeRedWhite.UseVisualStyleBackColor = false;
            this.rdoOrangeRedWhite.CheckedChanged += new System.EventHandler(this.rdoOrangeRedWhite_CheckedChanged);
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
            this.rdoCoralWhite.Location = new System.Drawing.Point(95, 27);
            this.rdoCoralWhite.Name = "rdoCoralWhite";
            this.rdoCoralWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoCoralWhite.TabIndex = 16;
            this.rdoCoralWhite.TabStop = true;
            this.rdoCoralWhite.Text = "ㄴ";
            this.rdoCoralWhite.UseVisualStyleBackColor = false;
            this.rdoCoralWhite.CheckedChanged += new System.EventHandler(this.rdoCoralWhite_CheckedChanged);
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
            this.rdoDeepSkyBlueWhite.Location = new System.Drawing.Point(155, 27);
            this.rdoDeepSkyBlueWhite.Name = "rdoDeepSkyBlueWhite";
            this.rdoDeepSkyBlueWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoDeepSkyBlueWhite.TabIndex = 17;
            this.rdoDeepSkyBlueWhite.TabStop = true;
            this.rdoDeepSkyBlueWhite.Text = "ㄴ";
            this.rdoDeepSkyBlueWhite.UseVisualStyleBackColor = false;
            this.rdoDeepSkyBlueWhite.CheckedChanged += new System.EventHandler(this.rdoDeepSkyBlueWhite_CheckedChanged);
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
            this.rdoGrayWhite.Location = new System.Drawing.Point(65, 27);
            this.rdoGrayWhite.Name = "rdoGrayWhite";
            this.rdoGrayWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoGrayWhite.TabIndex = 18;
            this.rdoGrayWhite.TabStop = true;
            this.rdoGrayWhite.Text = "ㄱ";
            this.rdoGrayWhite.UseVisualStyleBackColor = false;
            this.rdoGrayWhite.CheckedChanged += new System.EventHandler(this.rdoGrayWhite_CheckedChanged);
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
            this.rdoBlackWhite.ForeColor = System.Drawing.Color.Yellow;
            this.rdoBlackWhite.Location = new System.Drawing.Point(35, 27);
            this.rdoBlackWhite.Name = "rdoBlackWhite";
            this.rdoBlackWhite.Size = new System.Drawing.Size(24, 24);
            this.rdoBlackWhite.TabIndex = 19;
            this.rdoBlackWhite.TabStop = true;
            this.rdoBlackWhite.Text = "ㄱ";
            this.rdoBlackWhite.UseVisualStyleBackColor = false;
            this.rdoBlackWhite.CheckedChanged += new System.EventHandler(this.rdoBlackWhite_CheckedChanged);
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
            this.rdoWhiteBlack.Location = new System.Drawing.Point(5, 27);
            this.rdoWhiteBlack.Name = "rdoWhiteBlack";
            this.rdoWhiteBlack.Size = new System.Drawing.Size(24, 24);
            this.rdoWhiteBlack.TabIndex = 20;
            this.rdoWhiteBlack.TabStop = true;
            this.rdoWhiteBlack.Text = "ㄱ";
            this.rdoWhiteBlack.UseVisualStyleBackColor = false;
            this.rdoWhiteBlack.CheckedChanged += new System.EventHandler(this.rdoWhiteBlack_CheckedChanged);
            // 
            // btnNone
            // 
            this.btnNone.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNone.Location = new System.Drawing.Point(5, 83);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(24, 24);
            this.btnNone.TabIndex = 21;
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnClip
            // 
            this.btnClip.BackgroundImage = global::JSFW.Properties.Resources.Clip;
            this.btnClip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClip.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnClip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClip.Location = new System.Drawing.Point(65, 83);
            this.btnClip.Name = "btnClip";
            this.btnClip.Size = new System.Drawing.Size(24, 24);
            this.btnClip.TabIndex = 21;
            this.btnClip.UseVisualStyleBackColor = true;
            this.btnClip.Click += new System.EventHandler(this.btnClip_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImage = global::JSFW.Properties.Resources.Settings;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Location = new System.Drawing.Point(125, 83);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(24, 24);
            this.btnSetting.TabIndex = 21;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnExe
            // 
            this.btnExe.BackgroundImage = global::JSFW.Properties.Resources.Play;
            this.btnExe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExe.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnExe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExe.Location = new System.Drawing.Point(95, 83);
            this.btnExe.Name = "btnExe";
            this.btnExe.Size = new System.Drawing.Size(24, 24);
            this.btnExe.TabIndex = 21;
            this.btnExe.UseVisualStyleBackColor = true;
            this.btnExe.Click += new System.EventHandler(this.btnExe_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::JSFW.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(95, 57);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.TabIndex = 21;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackgroundImage = global::JSFW.Properties.Resources.Find;
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFind.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Location = new System.Drawing.Point(5, 57);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(24, 24);
            this.btnFind.TabIndex = 21;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.BackgroundImage = global::JSFW.Properties.Resources.delete;
            this.btnMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinus.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinus.Location = new System.Drawing.Point(65, 57);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(24, 24);
            this.btnMinus.TabIndex = 21;
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::JSFW.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(35, 83);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::JSFW.Properties.Resources.excel;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(155, 57);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 21;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::JSFW.Properties.Resources.Print;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(125, 57);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(24, 24);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlus.BackgroundImage")));
            this.btnPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlus.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Location = new System.Drawing.Point(35, 57);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(24, 24);
            this.btnPlus.TabIndex = 21;
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // EditorFkButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClip);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnExe);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.rdoDodgerBlueWhite);
            this.Controls.Add(this.rdoOrangeRedWhite);
            this.Controls.Add(this.rdoCoralWhite);
            this.Controls.Add(this.rdoDeepSkyBlueWhite);
            this.Controls.Add(this.rdoGrayWhite);
            this.Controls.Add(this.rdoBlackWhite);
            this.Controls.Add(this.rdoWhiteBlack);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkVisible);
            this.Name = "EditorFkButton";
            this.Size = new System.Drawing.Size(215, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.RadioButton rdoDodgerBlueWhite;
        private System.Windows.Forms.RadioButton rdoOrangeRedWhite;
        private System.Windows.Forms.RadioButton rdoCoralWhite;
        private System.Windows.Forms.RadioButton rdoDeepSkyBlueWhite;
        private System.Windows.Forms.RadioButton rdoGrayWhite;
        private System.Windows.Forms.RadioButton rdoBlackWhite;
        private System.Windows.Forms.RadioButton rdoWhiteBlack;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnExe;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnClip;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
    }
}
