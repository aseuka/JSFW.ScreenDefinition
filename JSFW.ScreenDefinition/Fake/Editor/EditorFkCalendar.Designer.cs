namespace JSFW.Fake.Editor
{
    partial class EditorFkCalendar
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
            this.rdoYYYY = new System.Windows.Forms.RadioButton();
            this.rdoYYYY_MM = new System.Windows.Forms.RadioButton();
            this.rdoYYYY_MM_DD = new System.Windows.Forms.RadioButton();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rdoYYYY
            // 
            this.rdoYYYY.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoYYYY.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoYYYY.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoYYYY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoYYYY.Location = new System.Drawing.Point(189, 4);
            this.rdoYYYY.Name = "rdoYYYY";
            this.rdoYYYY.Size = new System.Drawing.Size(47, 24);
            this.rdoYYYY.TabIndex = 3;
            this.rdoYYYY.TabStop = true;
            this.rdoYYYY.Text = "YYYY";
            this.rdoYYYY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoYYYY.UseVisualStyleBackColor = true;
            this.rdoYYYY.CheckedChanged += new System.EventHandler(this.rdoYYYY_CheckedChanged);
            // 
            // rdoYYYY_MM
            // 
            this.rdoYYYY_MM.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoYYYY_MM.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoYYYY_MM.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoYYYY_MM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoYYYY_MM.Location = new System.Drawing.Point(108, 4);
            this.rdoYYYY_MM.Name = "rdoYYYY_MM";
            this.rdoYYYY_MM.Size = new System.Drawing.Size(76, 24);
            this.rdoYYYY_MM.TabIndex = 4;
            this.rdoYYYY_MM.TabStop = true;
            this.rdoYYYY_MM.Text = "YYYY_MM";
            this.rdoYYYY_MM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoYYYY_MM.UseVisualStyleBackColor = true;
            this.rdoYYYY_MM.CheckedChanged += new System.EventHandler(this.rdoYYYY_MM_CheckedChanged);
            // 
            // rdoYYYY_MM_DD
            // 
            this.rdoYYYY_MM_DD.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoYYYY_MM_DD.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.rdoYYYY_MM_DD.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.rdoYYYY_MM_DD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoYYYY_MM_DD.Location = new System.Drawing.Point(6, 4);
            this.rdoYYYY_MM_DD.Name = "rdoYYYY_MM_DD";
            this.rdoYYYY_MM_DD.Size = new System.Drawing.Size(97, 24);
            this.rdoYYYY_MM_DD.TabIndex = 5;
            this.rdoYYYY_MM_DD.TabStop = true;
            this.rdoYYYY_MM_DD.Text = "YYYY_MM_DD";
            this.rdoYYYY_MM_DD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoYYYY_MM_DD.UseVisualStyleBackColor = true;
            this.rdoYYYY_MM_DD.CheckedChanged += new System.EventHandler(this.rdoYYYY_MM_DD_CheckedChanged);
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(242, 9);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(48, 16);
            this.chkVisible.TabIndex = 6;
            this.chkVisible.Text = "표시";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // EditorFkCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoYYYY);
            this.Controls.Add(this.rdoYYYY_MM);
            this.Controls.Add(this.rdoYYYY_MM_DD);
            this.Controls.Add(this.chkVisible);
            this.Name = "EditorFkCalendar";
            this.Size = new System.Drawing.Size(296, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoYYYY;
        private System.Windows.Forms.RadioButton rdoYYYY_MM;
        private System.Windows.Forms.RadioButton rdoYYYY_MM_DD;
        private System.Windows.Forms.CheckBox chkVisible;
    }
}
