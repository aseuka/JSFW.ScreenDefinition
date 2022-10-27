namespace JSFW.Fake
{
    partial class Designer
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
            this.pnlToolBar = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnFront = new System.Windows.Forms.Button();
            this.btnSetScreenSize = new System.Windows.Forms.Button();
            this.cboScreenSize = new System.Windows.Forms.ComboBox();
            this.btnScreenShot = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbSystemMenuPath = new JSFW.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlTemplate = new System.Windows.Forms.Panel();
            this.btnDelTemplate = new System.Windows.Forms.Button();
            this.btnAddTemplate = new System.Windows.Forms.Button();
            this.btnDelCancelTemplate = new System.Windows.Forms.Button();
            this.btnDelOKTemplate = new System.Windows.Forms.Button();
            this.label2 = new JSFW.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlToolBoxItems = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new JSFW.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fkUc = new JSFW.Fake.FkUserControl();
            this.pnlToolBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.BackColor = System.Drawing.Color.Gray;
            this.pnlToolBar.Controls.Add(this.btnLoad);
            this.pnlToolBar.Controls.Add(this.btnBack);
            this.pnlToolBar.Controls.Add(this.btnFront);
            this.pnlToolBar.Controls.Add(this.btnSetScreenSize);
            this.pnlToolBar.Controls.Add(this.cboScreenSize);
            this.pnlToolBar.Controls.Add(this.btnScreenShot);
            this.pnlToolBar.Controls.Add(this.btnSave);
            this.pnlToolBar.Controls.Add(this.lbSystemMenuPath);
            this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(934, 28);
            this.pnlToolBar.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(365, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 21);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "가져오기";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(689, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(51, 23);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "맨뒤로";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnFront
            // 
            this.btnFront.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFront.BackColor = System.Drawing.Color.White;
            this.btnFront.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnFront.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFront.Location = new System.Drawing.Point(619, 4);
            this.btnFront.Name = "btnFront";
            this.btnFront.Size = new System.Drawing.Size(64, 23);
            this.btnFront.TabIndex = 9;
            this.btnFront.Text = "맨앞으로";
            this.btnFront.UseVisualStyleBackColor = false;
            this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
            // 
            // btnSetScreenSize
            // 
            this.btnSetScreenSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetScreenSize.BackColor = System.Drawing.Color.White;
            this.btnSetScreenSize.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSetScreenSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetScreenSize.Location = new System.Drawing.Point(549, 5);
            this.btnSetScreenSize.Name = "btnSetScreenSize";
            this.btnSetScreenSize.Size = new System.Drawing.Size(54, 21);
            this.btnSetScreenSize.TabIndex = 8;
            this.btnSetScreenSize.Text = "설정";
            this.btnSetScreenSize.UseVisualStyleBackColor = false;
            this.btnSetScreenSize.Click += new System.EventHandler(this.btnSetScreenSize_Click);
            // 
            // cboScreenSize
            // 
            this.cboScreenSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboScreenSize.FormattingEnabled = true;
            this.cboScreenSize.Location = new System.Drawing.Point(446, 5);
            this.cboScreenSize.Name = "cboScreenSize";
            this.cboScreenSize.Size = new System.Drawing.Size(99, 20);
            this.cboScreenSize.TabIndex = 7;
            // 
            // btnScreenShot
            // 
            this.btnScreenShot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenShot.BackColor = System.Drawing.Color.White;
            this.btnScreenShot.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnScreenShot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScreenShot.Location = new System.Drawing.Point(746, 5);
            this.btnScreenShot.Name = "btnScreenShot";
            this.btnScreenShot.Size = new System.Drawing.Size(107, 21);
            this.btnScreenShot.TabIndex = 4;
            this.btnScreenShot.Text = "캡쳐(클립보드)";
            this.btnScreenShot.UseVisualStyleBackColor = false;
            this.btnScreenShot.Click += new System.EventHandler(this.btnScreenShot_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(870, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 21);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbSystemMenuPath
            // 
            this.lbSystemMenuPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSystemMenuPath.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbSystemMenuPath.ForeColor = System.Drawing.Color.White;
            this.lbSystemMenuPath.Location = new System.Drawing.Point(0, 0);
            this.lbSystemMenuPath.Name = "lbSystemMenuPath";
            this.lbSystemMenuPath.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbSystemMenuPath.Size = new System.Drawing.Size(934, 28);
            this.lbSystemMenuPath.TabIndex = 6;
            this.lbSystemMenuPath.Text = "시스템 메뉴 경로";
            this.lbSystemMenuPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.pnlToolBoxItems);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(937, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 617);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pnlTemplate);
            this.panel4.Controls.Add(this.btnDelTemplate);
            this.panel4.Controls.Add(this.btnAddTemplate);
            this.panel4.Controls.Add(this.btnDelCancelTemplate);
            this.panel4.Controls.Add(this.btnDelOKTemplate);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 332);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 285);
            this.panel4.TabIndex = 4;
            // 
            // pnlTemplate
            // 
            this.pnlTemplate.AutoScroll = true;
            this.pnlTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTemplate.Location = new System.Drawing.Point(0, 31);
            this.pnlTemplate.Name = "pnlTemplate";
            this.pnlTemplate.Size = new System.Drawing.Size(200, 254);
            this.pnlTemplate.TabIndex = 5;
            // 
            // btnDelTemplate
            // 
            this.btnDelTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelTemplate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDelTemplate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDelTemplate.Location = new System.Drawing.Point(136, 4);
            this.btnDelTemplate.Name = "btnDelTemplate";
            this.btnDelTemplate.Size = new System.Drawing.Size(57, 24);
            this.btnDelTemplate.TabIndex = 7;
            this.btnDelTemplate.Text = "삭제";
            this.btnDelTemplate.UseVisualStyleBackColor = false;
            this.btnDelTemplate.Click += new System.EventHandler(this.btnDelTemplate_Click);
            // 
            // btnAddTemplate
            // 
            this.btnAddTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTemplate.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAddTemplate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddTemplate.Location = new System.Drawing.Point(67, 4);
            this.btnAddTemplate.Name = "btnAddTemplate";
            this.btnAddTemplate.Size = new System.Drawing.Size(68, 24);
            this.btnAddTemplate.TabIndex = 6;
            this.btnAddTemplate.Text = "가져오기";
            this.btnAddTemplate.UseVisualStyleBackColor = false;
            this.btnAddTemplate.Click += new System.EventHandler(this.btnAddTemplate_Click);
            // 
            // btnDelCancelTemplate
            // 
            this.btnDelCancelTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCancelTemplate.BackColor = System.Drawing.Color.DarkGreen;
            this.btnDelCancelTemplate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelCancelTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelCancelTemplate.ForeColor = System.Drawing.Color.White;
            this.btnDelCancelTemplate.Location = new System.Drawing.Point(136, 4);
            this.btnDelCancelTemplate.Name = "btnDelCancelTemplate";
            this.btnDelCancelTemplate.Size = new System.Drawing.Size(57, 24);
            this.btnDelCancelTemplate.TabIndex = 9;
            this.btnDelCancelTemplate.Text = "Cancel";
            this.btnDelCancelTemplate.UseVisualStyleBackColor = false;
            this.btnDelCancelTemplate.Click += new System.EventHandler(this.btnDelCancelTemplate_Click);
            // 
            // btnDelOKTemplate
            // 
            this.btnDelOKTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelOKTemplate.BackColor = System.Drawing.Color.DarkGreen;
            this.btnDelOKTemplate.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelOKTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelOKTemplate.ForeColor = System.Drawing.Color.White;
            this.btnDelOKTemplate.Location = new System.Drawing.Point(67, 4);
            this.btnDelOKTemplate.Name = "btnDelOKTemplate";
            this.btnDelOKTemplate.Size = new System.Drawing.Size(68, 24);
            this.btnDelOKTemplate.TabIndex = 8;
            this.btnDelOKTemplate.Text = "OK";
            this.btnDelOKTemplate.UseVisualStyleBackColor = false;
            this.btnDelOKTemplate.Click += new System.EventHandler(this.btnDelOKTemplate_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(200, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "템플릿";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 329);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(200, 3);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // pnlToolBoxItems
            // 
            this.pnlToolBoxItems.AutoScroll = true;
            this.pnlToolBoxItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolBoxItems.Location = new System.Drawing.Point(0, 28);
            this.pnlToolBoxItems.Name = "pnlToolBoxItems";
            this.pnlToolBoxItems.Size = new System.Drawing.Size(200, 301);
            this.pnlToolBoxItems.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 28);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(200, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "도구상자";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Gray;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(934, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 617);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.fkUc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(934, 589);
            this.panel2.TabIndex = 3;
            // 
            // fkUc
            // 
            this.fkUc.AllowDrop = true;
            this.fkUc.BackColor = System.Drawing.Color.White;
            this.fkUc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fkUc.Cursor = System.Windows.Forms.Cursors.Default;
            this.fkUc.Location = new System.Drawing.Point(5, 5);
            this.fkUc.Name = "fkUc";
            this.fkUc.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.fkUc.Size = new System.Drawing.Size(1250, 740);
            this.fkUc.TabIndex = 0;
            // 
            // Designer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlToolBar);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "Designer";
            this.Size = new System.Drawing.Size(1137, 617);
            this.pnlToolBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnScreenShot;
        private System.Windows.Forms.Button btnSave;
        private JSFW.Fake.FkUserControl fkUc;
        private System.Windows.Forms.Panel panel3;
        private Label label1;
        private Label lbSystemMenuPath;
        private System.Windows.Forms.Button btnSetScreenSize;
        private System.Windows.Forms.ComboBox cboScreenSize;
        private System.Windows.Forms.Panel pnlToolBoxItems;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnFront;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAddTemplate;
        private System.Windows.Forms.Panel pnlTemplate;
        private Label label2;
        private System.Windows.Forms.Button btnDelTemplate;
        private System.Windows.Forms.Button btnDelCancelTemplate;
        private System.Windows.Forms.Button btnDelOKTemplate;
        private System.Windows.Forms.Splitter splitter2;
    }
}
