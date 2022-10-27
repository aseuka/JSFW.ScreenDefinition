namespace JSFW.ScreenDefinition
{
    partial class SDTopView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtScreenDesignID = new System.Windows.Forms.TextBox();
            this.label1 = new JSFW.Label();
            this.label2 = new JSFW.Label();
            this.label5 = new JSFW.Label();
            this.lbVersion = new JSFW.Label();
            this.label4 = new JSFW.Label();
            this.lbDocumentTitle = new JSFW.Label();
            this.lbWriteInfo = new JSFW.Label();
            this.txtSystemMenuPath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtScreenDesignID, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbVersion, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDocumentTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbWriteInfo, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSystemMenuPath, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1250, 28);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // txtScreenDesignID
            // 
            this.txtScreenDesignID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScreenDesignID.Location = new System.Drawing.Point(544, 4);
            this.txtScreenDesignID.Name = "txtScreenDesignID";
            this.txtScreenDesignID.ReadOnly = true;
            this.txtScreenDesignID.Size = new System.Drawing.Size(214, 21);
            this.txtScreenDesignID.TabIndex = 4;
            this.txtScreenDesignID.TabStop = false;
            this.txtScreenDesignID.Click += new System.EventHandler(this.txtScreenDesignID_Click);
            this.txtScreenDesignID.TextChanged += new System.EventHandler(this.txtScreenID_TextChanged);
            this.txtScreenDesignID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScreenID_KeyDown);
            this.txtScreenDesignID.Leave += new System.EventHandler(this.txtScreenID_Leave);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "문서명";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(222, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "시스템 메뉴경로";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(1146, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "버젼";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbVersion
            // 
            this.lbVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbVersion.Location = new System.Drawing.Point(1199, 1);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(47, 26);
            this.lbVersion.TabIndex = 0;
            this.lbVersion.Text = "1.0";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(839, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "작성자 && 작성일";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDocumentTitle
            // 
            this.lbDocumentTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDocumentTitle.Location = new System.Drawing.Point(61, 1);
            this.lbDocumentTitle.Name = "lbDocumentTitle";
            this.lbDocumentTitle.Size = new System.Drawing.Size(154, 26);
            this.lbDocumentTitle.TabIndex = 1;
            this.lbDocumentTitle.Text = " = 문서명";
            this.lbDocumentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDocumentTitle.DoubleClick += new System.EventHandler(this.lbDocumentTitle_DoubleClick);
            // 
            // lbWriteInfo
            // 
            this.lbWriteInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbWriteInfo.Location = new System.Drawing.Point(945, 1);
            this.lbWriteInfo.Name = "lbWriteInfo";
            this.lbWriteInfo.Size = new System.Drawing.Size(194, 26);
            this.lbWriteInfo.TabIndex = 2;
            this.lbWriteInfo.Text = "= 작성자 정보";
            this.lbWriteInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSystemMenuPath
            // 
            this.txtSystemMenuPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSystemMenuPath.Location = new System.Drawing.Point(323, 4);
            this.txtSystemMenuPath.Name = "txtSystemMenuPath";
            this.txtSystemMenuPath.ReadOnly = true;
            this.txtSystemMenuPath.Size = new System.Drawing.Size(214, 21);
            this.txtSystemMenuPath.TabIndex = 3;
            this.txtSystemMenuPath.TabStop = false;
            this.txtSystemMenuPath.Click += new System.EventHandler(this.txtSystemMenuPath_Click);
            this.txtSystemMenuPath.TextChanged += new System.EventHandler(this.txtSystemMenuPath_TextChanged);
            this.txtSystemMenuPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSystemMenuPath_KeyDown);
            // 
            // SDTopView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SDTopView";
            this.Size = new System.Drawing.Size(1250, 28);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label lbVersion;
        private Label label4;
        private Label lbDocumentTitle;
        private Label lbWriteInfo;
        private System.Windows.Forms.TextBox txtSystemMenuPath;
        private System.Windows.Forms.TextBox txtScreenDesignID;
    }
}
