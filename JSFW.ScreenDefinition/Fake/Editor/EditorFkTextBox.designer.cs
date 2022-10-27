namespace JSFW.Fake.Editor
{
    partial class EditorFkTextBox
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoAlignRIGHT = new System.Windows.Forms.RadioButton();
            this.rdoAlignCENTER = new System.Windows.Forms.RadioButton();
            this.rdoAlignLEFT = new System.Windows.Forms.RadioButton();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.rdoHP = new System.Windows.Forms.RadioButton();
            this.rdoTelNumber = new System.Windows.Forms.RadioButton();
            this.rdoPostNumber = new System.Windows.Forms.RadioButton();
            this.rdoNumber = new System.Windows.Forms.RadioButton();
            this.rdoEmpty = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(4, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(336, 68);
            this.textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoAlignRIGHT);
            this.panel1.Controls.Add(this.rdoAlignCENTER);
            this.panel1.Controls.Add(this.rdoAlignLEFT);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 30);
            this.panel1.TabIndex = 1;
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
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(272, 12);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(48, 16);
            this.chkVisible.TabIndex = 2;
            this.chkVisible.Text = "표시";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.rdoHP);
            this.panel2.Controls.Add(this.rdoTelNumber);
            this.panel2.Controls.Add(this.rdoPostNumber);
            this.panel2.Controls.Add(this.rdoNumber);
            this.panel2.Controls.Add(this.rdoEmpty);
            this.panel2.Location = new System.Drawing.Point(4, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 30);
            this.panel2.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(101, 6);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 21);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rdoHP
            // 
            this.rdoHP.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoHP.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoHP.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoHP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoHP.Location = new System.Drawing.Point(289, 4);
            this.rdoHP.Name = "rdoHP";
            this.rdoHP.Size = new System.Drawing.Size(34, 24);
            this.rdoHP.TabIndex = 0;
            this.rdoHP.TabStop = true;
            this.rdoHP.Text = "HP";
            this.rdoHP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoHP.UseVisualStyleBackColor = true;
            this.rdoHP.CheckedChanged += new System.EventHandler(this.rdoHP_CheckedChanged);
            // 
            // rdoTelNumber
            // 
            this.rdoTelNumber.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoTelNumber.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoTelNumber.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoTelNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoTelNumber.Location = new System.Drawing.Point(218, 4);
            this.rdoTelNumber.Name = "rdoTelNumber";
            this.rdoTelNumber.Size = new System.Drawing.Size(65, 24);
            this.rdoTelNumber.TabIndex = 0;
            this.rdoTelNumber.TabStop = true;
            this.rdoTelNumber.Text = "전화번호";
            this.rdoTelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoTelNumber.UseVisualStyleBackColor = true;
            this.rdoTelNumber.CheckedChanged += new System.EventHandler(this.rdoTelNumber_CheckedChanged);
            // 
            // rdoPostNumber
            // 
            this.rdoPostNumber.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoPostNumber.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoPostNumber.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoPostNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoPostNumber.Location = new System.Drawing.Point(147, 4);
            this.rdoPostNumber.Name = "rdoPostNumber";
            this.rdoPostNumber.Size = new System.Drawing.Size(65, 24);
            this.rdoPostNumber.TabIndex = 0;
            this.rdoPostNumber.TabStop = true;
            this.rdoPostNumber.Text = "우편번호";
            this.rdoPostNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoPostNumber.UseVisualStyleBackColor = true;
            this.rdoPostNumber.CheckedChanged += new System.EventHandler(this.rdoPostNumber_CheckedChanged);
            // 
            // rdoNumber
            // 
            this.rdoNumber.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoNumber.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoNumber.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoNumber.Location = new System.Drawing.Point(52, 4);
            this.rdoNumber.Name = "rdoNumber";
            this.rdoNumber.Size = new System.Drawing.Size(43, 24);
            this.rdoNumber.TabIndex = 0;
            this.rdoNumber.TabStop = true;
            this.rdoNumber.Text = "숫자";
            this.rdoNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoNumber.UseVisualStyleBackColor = true;
            this.rdoNumber.CheckedChanged += new System.EventHandler(this.rdoNumber_CheckedChanged);
            // 
            // rdoEmpty
            // 
            this.rdoEmpty.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoEmpty.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoEmpty.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoEmpty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoEmpty.Location = new System.Drawing.Point(3, 4);
            this.rdoEmpty.Name = "rdoEmpty";
            this.rdoEmpty.Size = new System.Drawing.Size(43, 24);
            this.rdoEmpty.TabIndex = 0;
            this.rdoEmpty.TabStop = true;
            this.rdoEmpty.Text = "빈칸";
            this.rdoEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoEmpty.UseVisualStyleBackColor = true;
            this.rdoEmpty.CheckedChanged += new System.EventHandler(this.rdoEmpty_CheckedChanged);
            // 
            // EditorFkTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkVisible);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Name = "EditorFkTextBox";
            this.Size = new System.Drawing.Size(343, 139);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoAlignRIGHT;
        private System.Windows.Forms.RadioButton rdoAlignCENTER;
        private System.Windows.Forms.RadioButton rdoAlignLEFT;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton rdoHP;
        private System.Windows.Forms.RadioButton rdoTelNumber;
        private System.Windows.Forms.RadioButton rdoPostNumber;
        private System.Windows.Forms.RadioButton rdoNumber;
        private System.Windows.Forms.RadioButton rdoEmpty;
    }
}
