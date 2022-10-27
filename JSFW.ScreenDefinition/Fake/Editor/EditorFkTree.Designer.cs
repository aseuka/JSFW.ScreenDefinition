namespace JSFW.Fake.Editor
{
    partial class EditorFkTree
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
            this.txtContent = new System.Windows.Forms.TextBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.label1 = new JSFW.Label();
            this.rdoTree = new System.Windows.Forms.RadioButton();
            this.rdoList = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(3, 34);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(177, 118);
            this.txtContent.TabIndex = 3;
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(4, 11);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(48, 16);
            this.chkVisible.TabIndex = 5;
            this.chkVisible.Text = "표시";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림체", 9F);
            this.label1.Location = new System.Drawing.Point(184, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 86);
            this.label1.TabIndex = 6;
            this.label1.Text = "#LV1\r\n##LV2-1\r\n##LV2-2\r\n###LV2-2-1\r\n##LV2-3\r\n###LV2-3-1\r\n###LV2-3-1";
            // 
            // rdoTree
            // 
            this.rdoTree.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoTree.Checked = true;
            this.rdoTree.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.rdoTree.FlatAppearance.CheckedBackColor = System.Drawing.Color.OrangeRed;
            this.rdoTree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoTree.Location = new System.Drawing.Point(73, 6);
            this.rdoTree.Name = "rdoTree";
            this.rdoTree.Size = new System.Drawing.Size(51, 24);
            this.rdoTree.TabIndex = 7;
            this.rdoTree.TabStop = true;
            this.rdoTree.Text = "트리";
            this.rdoTree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoTree.UseVisualStyleBackColor = true;
            // 
            // rdoList
            // 
            this.rdoList.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoList.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.rdoList.FlatAppearance.CheckedBackColor = System.Drawing.Color.OrangeRed;
            this.rdoList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoList.Location = new System.Drawing.Point(128, 6);
            this.rdoList.Name = "rdoList";
            this.rdoList.Size = new System.Drawing.Size(51, 24);
            this.rdoList.TabIndex = 7;
            this.rdoList.Text = "리스트";
            this.rdoList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoList.UseVisualStyleBackColor = true;
            // 
            // EditorFkTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoList);
            this.Controls.Add(this.rdoTree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.chkVisible);
            this.Name = "EditorFkTree";
            this.Size = new System.Drawing.Size(265, 155);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.CheckBox chkVisible;
        private Label label1;
        private System.Windows.Forms.RadioButton rdoTree;
        private System.Windows.Forms.RadioButton rdoList;
    }
}
