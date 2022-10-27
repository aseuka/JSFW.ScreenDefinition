namespace JSFW.Fake.Editor
{
    partial class EditorFkChart
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
            this.txtX축 = new System.Windows.Forms.TextBox();
            this.txtSeries = new System.Windows.Forms.TextBox();
            this.label3 = new JSFW.Label();
            this.label2 = new JSFW.Label();
            this.label1 = new JSFW.Label();
            this.SuspendLayout();
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
            // txtX축
            // 
            this.txtX축.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtX축.Location = new System.Drawing.Point(48, 36);
            this.txtX축.Name = "txtX축";
            this.txtX축.Size = new System.Drawing.Size(278, 21);
            this.txtX축.TabIndex = 6;
            this.txtX축.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtX축_KeyDown);
            // 
            // txtSeries
            // 
            this.txtSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeries.Location = new System.Drawing.Point(48, 63);
            this.txtSeries.Multiline = true;
            this.txtSeries.Name = "txtSeries";
            this.txtSeries.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSeries.Size = new System.Drawing.Size(278, 47);
            this.txtSeries.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림체", 9F);
            this.label3.Location = new System.Drawing.Point(46, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 36);
            this.label3.TabIndex = 7;
            this.label3.Text = "예) x축 : AA BB CC DD EE\r\n Series : #Line|Red|20,60,10,50,90\r\n          #Column|Bla" +
    "ck|50,20,90,60,5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Series";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "X축";
            // 
            // EditorFkChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSeries);
            this.Controls.Add(this.txtX축);
            this.Controls.Add(this.chkVisible);
            this.Name = "EditorFkChart";
            this.Size = new System.Drawing.Size(337, 153);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.TextBox txtX축;
        private Label label1;
        private System.Windows.Forms.TextBox txtSeries;
        private Label label2;
        private Label label3;
    }
}
