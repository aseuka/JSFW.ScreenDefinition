namespace JSFW.ScreenDefinition
{
    partial class SlideItemView
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
            this.chkDel = new System.Windows.Forms.CheckBox();
            this.btnUP = new System.Windows.Forms.Button();
            this.btnDN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkDel
            // 
            this.chkDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDel.Location = new System.Drawing.Point(3, 3);
            this.chkDel.MaximumSize = new System.Drawing.Size(22, 22);
            this.chkDel.MinimumSize = new System.Drawing.Size(22, 22);
            this.chkDel.Name = "chkDel";
            this.chkDel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.chkDel.Size = new System.Drawing.Size(22, 22);
            this.chkDel.TabIndex = 1;
            this.chkDel.TabStop = false;
            this.chkDel.UseVisualStyleBackColor = true;
            this.chkDel.Visible = false;
            // 
            // btnUP
            // 
            this.btnUP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUP.BackgroundImage = global::JSFW.Properties.Resources.ArrowUPGray;
            this.btnUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUP.Font = new System.Drawing.Font("굴림", 7F);
            this.btnUP.Location = new System.Drawing.Point(4, 4);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(16, 16);
            this.btnUP.TabIndex = 2;
            this.btnUP.UseVisualStyleBackColor = true;
            this.btnUP.Visible = false;
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnDN
            // 
            this.btnDN.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDN.BackgroundImage = global::JSFW.Properties.Resources.ArrowDownGray;
            this.btnDN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDN.Font = new System.Drawing.Font("굴림", 7F);
            this.btnDN.Location = new System.Drawing.Point(300, 4);
            this.btnDN.Name = "btnDN";
            this.btnDN.Size = new System.Drawing.Size(16, 16);
            this.btnDN.TabIndex = 2;
            this.btnDN.UseVisualStyleBackColor = true;
            this.btnDN.Visible = false;
            this.btnDN.Click += new System.EventHandler(this.btnDN_Click);
            // 
            // SlideItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUP);
            this.Controls.Add(this.btnDN);
            this.Controls.Add(this.chkDel);
            this.Name = "SlideItemView";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.Size = new System.Drawing.Size(319, 36);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDel;
        private System.Windows.Forms.Button btnDN;
        private System.Windows.Forms.Button btnUP;
    }
}
