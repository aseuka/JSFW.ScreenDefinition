namespace JSFW
{
    partial class FunctionDefinitionItemControl
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
            this.txtContent = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkConfirm = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkDel
            // 
            this.chkDel.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDel.Location = new System.Drawing.Point(0, 0);
            this.chkDel.MaximumSize = new System.Drawing.Size(19, 19);
            this.chkDel.MinimumSize = new System.Drawing.Size(19, 19);
            this.chkDel.Name = "chkDel";
            this.chkDel.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.chkDel.Size = new System.Drawing.Size(19, 19);
            this.chkDel.TabIndex = 0;
            this.chkDel.TabStop = false;
            this.chkDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDel.UseVisualStyleBackColor = true;
            this.chkDel.Visible = false;
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("굴림체", 9F);
            this.txtContent.Location = new System.Drawing.Point(19, 0);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(514, 30);
            this.txtContent.TabIndex = 1;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            this.txtContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContent_KeyDown);
            this.txtContent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtContent_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(533, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 30);
            this.panel1.TabIndex = 2;
            // 
            // chkConfirm
            // 
            this.chkConfirm.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkConfirm.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.chkConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkConfirm.Location = new System.Drawing.Point(0, 0);
            this.chkConfirm.MaximumSize = new System.Drawing.Size(80, 25);
            this.chkConfirm.MinimumSize = new System.Drawing.Size(80, 25);
            this.chkConfirm.Name = "chkConfirm";
            this.chkConfirm.Size = new System.Drawing.Size(80, 25);
            this.chkConfirm.TabIndex = 0;
            this.chkConfirm.TabStop = false;
            this.chkConfirm.Text = "확인";
            this.chkConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkConfirm.UseVisualStyleBackColor = true;
            this.chkConfirm.CheckedChanged += new System.EventHandler(this.chkConfirm_CheckedChanged);
            // 
            // FunctionDefinitionItemControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkDel);
            this.Name = "FunctionDefinitionItemControl";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Size = new System.Drawing.Size(613, 32);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDel;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkConfirm;
    }
}
