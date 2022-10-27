namespace JSFW.Fake.Editor
{
    partial class EditorFkCodeFind
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
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.txtCodeFindSPName = new System.Windows.Forms.TextBox();
            this.rdoCodeFind = new System.Windows.Forms.RadioButton();
            this.rdoAddr = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(246, 7);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(48, 16);
            this.chkVisible.TabIndex = 6;
            this.chkVisible.Text = "표시";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // txtCodeFindSPName
            // 
            this.txtCodeFindSPName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeFindSPName.Location = new System.Drawing.Point(3, 28);
            this.txtCodeFindSPName.Name = "txtCodeFindSPName";
            this.txtCodeFindSPName.Size = new System.Drawing.Size(291, 21);
            this.txtCodeFindSPName.TabIndex = 7;
            this.txtCodeFindSPName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodeFindSPName_KeyDown);
            // 
            // rdoCodeFind
            // 
            this.rdoCodeFind.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoCodeFind.Checked = true;
            this.rdoCodeFind.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoCodeFind.FlatAppearance.CheckedBackColor = System.Drawing.Color.OrangeRed;
            this.rdoCodeFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoCodeFind.Location = new System.Drawing.Point(4, 52);
            this.rdoCodeFind.Name = "rdoCodeFind";
            this.rdoCodeFind.Size = new System.Drawing.Size(76, 24);
            this.rdoCodeFind.TabIndex = 8;
            this.rdoCodeFind.TabStop = true;
            this.rdoCodeFind.Text = "코드파인드";
            this.rdoCodeFind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCodeFind.UseVisualStyleBackColor = true;
            // 
            // rdoAddr
            // 
            this.rdoAddr.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAddr.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoAddr.FlatAppearance.CheckedBackColor = System.Drawing.Color.OrangeRed;
            this.rdoAddr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoAddr.Location = new System.Drawing.Point(86, 52);
            this.rdoAddr.Name = "rdoAddr";
            this.rdoAddr.Size = new System.Drawing.Size(68, 24);
            this.rdoAddr.TabIndex = 8;
            this.rdoAddr.Text = "주소검색";
            this.rdoAddr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAddr.UseVisualStyleBackColor = true;
            // 
            // EditorFkCodeFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoAddr);
            this.Controls.Add(this.rdoCodeFind);
            this.Controls.Add(this.txtCodeFindSPName);
            this.Controls.Add(this.chkVisible);
            this.Name = "EditorFkCodeFind";
            this.Size = new System.Drawing.Size(297, 79);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.TextBox txtCodeFindSPName;
        private System.Windows.Forms.RadioButton rdoCodeFind;
        private System.Windows.Forms.RadioButton rdoAddr;
    }
}
