namespace JSFW.Fake.Editor
{
    partial class EditorFkDataGrid
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.chkRequird = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoAlignRIGHT);
            this.panel1.Controls.Add(this.rdoAlignCENTER);
            this.panel1.Controls.Add(this.rdoAlignLEFT);
            this.panel1.Location = new System.Drawing.Point(3, 2);
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
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 34);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(331, 54);
            this.textBox1.TabIndex = 3;
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(278, 14);
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
            this.chkRequird.Location = new System.Drawing.Point(3, 94);
            this.chkRequird.Name = "chkRequird";
            this.chkRequird.Size = new System.Drawing.Size(48, 16);
            this.chkRequird.TabIndex = 6;
            this.chkRequird.Text = "필수";
            this.chkRequird.UseVisualStyleBackColor = true;
            // 
            // EditorFkLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkRequird);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkVisible);
            this.Name = "EditorFkLabel";
            this.Size = new System.Drawing.Size(337, 113);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoAlignRIGHT;
        private System.Windows.Forms.RadioButton rdoAlignCENTER;
        private System.Windows.Forms.RadioButton rdoAlignLEFT;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.CheckBox chkRequird;
    }
}
