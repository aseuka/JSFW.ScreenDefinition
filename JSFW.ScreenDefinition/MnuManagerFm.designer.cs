namespace JSFW.ScreenDefinition
{
    partial class MnuManagerFm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvMnu = new System.Windows.Forms.ListView();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.txtEng = new System.Windows.Forms.TextBox();
            this.txtKor = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.chkNew = new System.Windows.Forms.CheckBox();
            this.lbGUID = new JSFW.Label();
            this.label4 = new JSFW.Label();
            this.label3 = new JSFW.Label();
            this.label2 = new JSFW.Label();
            this.label1 = new JSFW.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMenuSearch = new System.Windows.Forms.Button();
            this.txtMenuSearch = new System.Windows.Forms.TextBox();
            this.label5 = new JSFW.Label();
            this.SuspendLayout();
            // 
            // lvMnu
            // 
            this.lvMnu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMnu.CheckBoxes = true;
            this.lvMnu.FullRowSelect = true;
            this.lvMnu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvMnu.HideSelection = false;
            this.lvMnu.Location = new System.Drawing.Point(1, 41);
            this.lvMnu.MultiSelect = false;
            this.lvMnu.Name = "lvMnu";
            this.lvMnu.Size = new System.Drawing.Size(755, 619);
            this.lvMnu.TabIndex = 999;
            this.lvMnu.TabStop = false;
            this.lvMnu.UseCompatibleStateImageBehavior = false;
            this.lvMnu.View = System.Windows.Forms.View.Details;
            this.lvMnu.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvMnu_ItemChecked);
            this.lvMnu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvMnu_MouseDown);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroupName.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtGroupName.Location = new System.Drawing.Point(837, 67);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.ReadOnly = true;
            this.txtGroupName.Size = new System.Drawing.Size(279, 21);
            this.txtGroupName.TabIndex = 0;
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            this.txtGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupName_KeyDown);
            this.txtGroupName.Leave += new System.EventHandler(this.txtGroupName_Leave);
            // 
            // txtEng
            // 
            this.txtEng.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEng.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtEng.Location = new System.Drawing.Point(837, 90);
            this.txtEng.Name = "txtEng";
            this.txtEng.ReadOnly = true;
            this.txtEng.Size = new System.Drawing.Size(279, 21);
            this.txtEng.TabIndex = 1;
            this.txtEng.TextChanged += new System.EventHandler(this.txtEng_TextChanged);
            this.txtEng.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEng_KeyDown);
            this.txtEng.Leave += new System.EventHandler(this.txtEng_Leave);
            // 
            // txtKor
            // 
            this.txtKor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKor.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtKor.Location = new System.Drawing.Point(837, 113);
            this.txtKor.Name = "txtKor";
            this.txtKor.ReadOnly = true;
            this.txtKor.Size = new System.Drawing.Size(279, 21);
            this.txtKor.TabIndex = 2;
            this.txtKor.TextChanged += new System.EventHandler(this.txtKor_TextChanged);
            this.txtKor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKor_KeyDown);
            this.txtKor.Leave += new System.EventHandler(this.txtKor_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(1123, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.White;
            this.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Location = new System.Drawing.Point(837, 140);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(94, 23);
            this.btnDel.TabIndex = 3;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "삭제";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // chkNew
            // 
            this.chkNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNew.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkNew.BackColor = System.Drawing.Color.White;
            this.chkNew.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.chkNew.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chkNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkNew.Location = new System.Drawing.Point(1122, 67);
            this.chkNew.Name = "chkNew";
            this.chkNew.Size = new System.Drawing.Size(104, 67);
            this.chkNew.TabIndex = 4;
            this.chkNew.TabStop = false;
            this.chkNew.Text = "등록";
            this.chkNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkNew.UseVisualStyleBackColor = false;
            this.chkNew.CheckedChanged += new System.EventHandler(this.chkNew_CheckedChanged);
            // 
            // lbGUID
            // 
            this.lbGUID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGUID.Location = new System.Drawing.Point(837, 41);
            this.lbGUID.Name = "lbGUID";
            this.lbGUID.Size = new System.Drawing.Size(389, 23);
            this.lbGUID.TabIndex = 1;
            this.lbGUID.Text = "GUID";
            this.lbGUID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(762, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Kor";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(762, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Eng";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(762, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "그룹명";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(759, 10);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(471, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "메뉴 관리";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1008, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(218, 33);
            this.btnClose.TabIndex = 1000;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMenuSearch
            // 
            this.btnMenuSearch.Location = new System.Drawing.Point(351, 11);
            this.btnMenuSearch.Name = "btnMenuSearch";
            this.btnMenuSearch.Size = new System.Drawing.Size(75, 23);
            this.btnMenuSearch.TabIndex = 1004;
            this.btnMenuSearch.Text = "검색";
            this.btnMenuSearch.UseVisualStyleBackColor = true;
            this.btnMenuSearch.Click += new System.EventHandler(this.btnMenuSearch_Click);
            // 
            // txtMenuSearch
            // 
            this.txtMenuSearch.Location = new System.Drawing.Point(139, 12);
            this.txtMenuSearch.Name = "txtMenuSearch";
            this.txtMenuSearch.Size = new System.Drawing.Size(206, 21);
            this.txtMenuSearch.TabIndex = 1003;
            this.txtMenuSearch.TextChanged += new System.EventHandler(this.txtMenuSearch_TextChanged);
            this.txtMenuSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMenuSearch_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(18, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "메뉴ID 또는 메뉴명";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MnuManagerFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 661);
            this.Controls.Add(this.btnMenuSearch);
            this.Controls.Add(this.txtMenuSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkNew);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtKor);
            this.Controls.Add(this.txtEng);
            this.Controls.Add(this.lbGUID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvMnu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MnuManagerFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "메뉴 화면관리";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMnu;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.TextBox txtGroupName;
        private Label label3;
        private System.Windows.Forms.TextBox txtEng;
        private Label label4;
        private System.Windows.Forms.TextBox txtKor;
        private Label lbGUID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.CheckBox chkNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMenuSearch;
        private System.Windows.Forms.TextBox txtMenuSearch;
        private Label label5;
    }
}