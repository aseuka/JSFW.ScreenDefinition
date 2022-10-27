namespace JSFW.ScreenDefinition
{
    partial class EditMemo
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
            this.lbNumber = new JSFW.Label();
            this.chkDel = new System.Windows.Forms.CheckBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbNumber);
            this.panel1.Controls.Add(this.chkDel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(29, 51);
            this.panel1.TabIndex = 0;
            // 
            // lbNumber
            // 
            this.lbNumber.BackColor = System.Drawing.Color.OrangeRed;
            this.lbNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbNumber.Font = new System.Drawing.Font("굴림체", 8F);
            this.lbNumber.ForeColor = System.Drawing.Color.White;
            this.lbNumber.Location = new System.Drawing.Point(2, 26);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(25, 23);
            this.lbNumber.TabIndex = 1;
            this.lbNumber.Text = "01";
            this.lbNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNumber.DoubleClick += new System.EventHandler(this.lbNumber_DoubleClick);
            this.lbNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbNumber_MouseDown);
            this.lbNumber.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbNumber_MouseMove);
            this.lbNumber.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbNumber_MouseUp);
            // 
            // chkDel
            // 
            this.chkDel.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkDel.Location = new System.Drawing.Point(2, 2);
            this.chkDel.Name = "chkDel";
            this.chkDel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkDel.Size = new System.Drawing.Size(25, 24);
            this.chkDel.TabIndex = 0;
            this.chkDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDel.UseVisualStyleBackColor = true;
            this.chkDel.Visible = false;
            // 
            // txtMemo
            // 
            this.txtMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMemo.Location = new System.Drawing.Point(31, 2);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMemo.Size = new System.Drawing.Size(218, 51);
            this.txtMemo.TabIndex = 1;
            this.txtMemo.TextChanged += new System.EventHandler(this.txtMemo_TextChanged);
            // 
            // EditMemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(50, 30);
            this.Name = "EditMemo";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(251, 55);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Label lbNumber;
        private System.Windows.Forms.CheckBox chkDel;
        private System.Windows.Forms.TextBox txtMemo;
    }
}
