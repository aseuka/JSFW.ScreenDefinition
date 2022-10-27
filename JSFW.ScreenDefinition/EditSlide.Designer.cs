namespace JSFW.ScreenDefinition
{
    partial class EditSlide
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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.chUsePen = new System.Windows.Forms.CheckBox();
            this.btnSetBackGroundImage = new System.Windows.Forms.Button();
            this.btnUIDesign = new System.Windows.Forms.Button();
            this.btnAllErase = new System.Windows.Forms.Button();
            this.lbPenColor = new JSFW.Label();
            this.tbPenWidth = new System.Windows.Forms.TrackBar();
            this.rdoErase = new System.Windows.Forms.RadioButton();
            this.rdoPen = new System.Windows.Forms.RadioButton();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.pnlAttribute = new System.Windows.Forms.Panel();
            this.pnlMemo = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelMemo = new System.Windows.Forms.Button();
            this.btnAddMemo = new System.Windows.Forms.Button();
            this.btnDelMemoCancel = new System.Windows.Forms.Button();
            this.btnDelMemoOK = new System.Windows.Forms.Button();
            this.label2 = new JSFW.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txtTip = new System.Windows.Forms.TextBox();
            this.label1 = new JSFW.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnFirstMove = new System.Windows.Forms.Button();
            this.btnDelGraffity = new System.Windows.Forms.Button();
            this.lbLRIndex = new JSFW.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPenWidth)).BeginInit();
            this.pnlAttribute.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlToolbar);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(1054, 27);
            this.panel1.TabIndex = 0;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.chUsePen);
            this.pnlToolbar.Controls.Add(this.btnSetBackGroundImage);
            this.pnlToolbar.Controls.Add(this.btnUIDesign);
            this.pnlToolbar.Controls.Add(this.btnAllErase);
            this.pnlToolbar.Controls.Add(this.lbPenColor);
            this.pnlToolbar.Controls.Add(this.tbPenWidth);
            this.pnlToolbar.Controls.Add(this.rdoErase);
            this.pnlToolbar.Controls.Add(this.rdoPen);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlToolbar.Location = new System.Drawing.Point(213, 2);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(837, 21);
            this.pnlToolbar.TabIndex = 1;
            // 
            // chUsePen
            // 
            this.chUsePen.Appearance = System.Windows.Forms.Appearance.Button;
            this.chUsePen.BackColor = System.Drawing.Color.Transparent;
            this.chUsePen.BackgroundImage = global::JSFW.Properties.Resources.Lock;
            this.chUsePen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chUsePen.FlatAppearance.BorderSize = 0;
            this.chUsePen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chUsePen.Location = new System.Drawing.Point(178, 0);
            this.chUsePen.Name = "chUsePen";
            this.chUsePen.Size = new System.Drawing.Size(21, 21);
            this.chUsePen.TabIndex = 7;
            this.chUsePen.UseVisualStyleBackColor = false;
            this.chUsePen.CheckedChanged += new System.EventHandler(this.chUsePen_CheckedChanged);
            // 
            // btnSetBackGroundImage
            // 
            this.btnSetBackGroundImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetBackGroundImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetBackGroundImage.Location = new System.Drawing.Point(640, 0);
            this.btnSetBackGroundImage.Name = "btnSetBackGroundImage";
            this.btnSetBackGroundImage.Size = new System.Drawing.Size(75, 21);
            this.btnSetBackGroundImage.TabIndex = 6;
            this.btnSetBackGroundImage.Text = "배경이미지";
            this.btnSetBackGroundImage.UseVisualStyleBackColor = true;
            this.btnSetBackGroundImage.Click += new System.EventHandler(this.btnSetBackGroundImage_Click);
            // 
            // btnUIDesign
            // 
            this.btnUIDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUIDesign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUIDesign.Location = new System.Drawing.Point(738, 0);
            this.btnUIDesign.Name = "btnUIDesign";
            this.btnUIDesign.Size = new System.Drawing.Size(98, 21);
            this.btnUIDesign.TabIndex = 5;
            this.btnUIDesign.Text = "UI 디자이너";
            this.btnUIDesign.UseVisualStyleBackColor = true;
            this.btnUIDesign.Click += new System.EventHandler(this.btnUIDesign_Click);
            // 
            // btnAllErase
            // 
            this.btnAllErase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllErase.Location = new System.Drawing.Point(398, 0);
            this.btnAllErase.Name = "btnAllErase";
            this.btnAllErase.Size = new System.Drawing.Size(75, 21);
            this.btnAllErase.TabIndex = 4;
            this.btnAllErase.Text = "전체지우기";
            this.btnAllErase.UseVisualStyleBackColor = true;
            this.btnAllErase.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbPenColor
            // 
            this.lbPenColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPenColor.Location = new System.Drawing.Point(205, 0);
            this.lbPenColor.Name = "lbPenColor";
            this.lbPenColor.Size = new System.Drawing.Size(21, 21);
            this.lbPenColor.TabIndex = 3;
            this.lbPenColor.Click += new System.EventHandler(this.lbPenColor_Click);
            // 
            // tbPenWidth
            // 
            this.tbPenWidth.AutoSize = false;
            this.tbPenWidth.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbPenWidth.LargeChange = 60;
            this.tbPenWidth.Location = new System.Drawing.Point(0, 0);
            this.tbPenWidth.Maximum = 1000;
            this.tbPenWidth.Minimum = 60;
            this.tbPenWidth.Name = "tbPenWidth";
            this.tbPenWidth.Size = new System.Drawing.Size(170, 21);
            this.tbPenWidth.SmallChange = 30;
            this.tbPenWidth.TabIndex = 2;
            this.tbPenWidth.TabStop = false;
            this.tbPenWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbPenWidth.Value = 90;
            this.tbPenWidth.Scroll += new System.EventHandler(this.tbPenWidth_Scroll);
            // 
            // rdoErase
            // 
            this.rdoErase.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoErase.BackColor = System.Drawing.Color.Transparent;
            this.rdoErase.FlatAppearance.CheckedBackColor = System.Drawing.Color.OrangeRed;
            this.rdoErase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoErase.Location = new System.Drawing.Point(302, 0);
            this.rdoErase.Name = "rdoErase";
            this.rdoErase.Size = new System.Drawing.Size(90, 21);
            this.rdoErase.TabIndex = 1;
            this.rdoErase.TabStop = true;
            this.rdoErase.Text = "지우개 Alt+2";
            this.rdoErase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoErase.UseVisualStyleBackColor = false;
            this.rdoErase.CheckedChanged += new System.EventHandler(this.rdoErase_CheckedChanged);
            // 
            // rdoPen
            // 
            this.rdoPen.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoPen.BackColor = System.Drawing.Color.Transparent;
            this.rdoPen.FlatAppearance.CheckedBackColor = System.Drawing.Color.Coral;
            this.rdoPen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoPen.Location = new System.Drawing.Point(232, 0);
            this.rdoPen.Name = "rdoPen";
            this.rdoPen.Size = new System.Drawing.Size(64, 21);
            this.rdoPen.TabIndex = 0;
            this.rdoPen.TabStop = true;
            this.rdoPen.Text = "펜 Alt+1";
            this.rdoPen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoPen.UseVisualStyleBackColor = false;
            this.rdoPen.CheckedChanged += new System.EventHandler(this.rdoPen_CheckedChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTitle.Location = new System.Drawing.Point(2, 2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(211, 21);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // pnlAttribute
            // 
            this.pnlAttribute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAttribute.Controls.Add(this.pnlMemo);
            this.pnlAttribute.Controls.Add(this.panel2);
            this.pnlAttribute.Controls.Add(this.splitter1);
            this.pnlAttribute.Controls.Add(this.txtTip);
            this.pnlAttribute.Controls.Add(this.label1);
            this.pnlAttribute.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAttribute.Location = new System.Drawing.Point(854, 32);
            this.pnlAttribute.Name = "pnlAttribute";
            this.pnlAttribute.Size = new System.Drawing.Size(200, 504);
            this.pnlAttribute.TabIndex = 1;
            // 
            // pnlMemo
            // 
            this.pnlMemo.AutoScroll = true;
            this.pnlMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMemo.Location = new System.Drawing.Point(0, 199);
            this.pnlMemo.Name = "pnlMemo";
            this.pnlMemo.Size = new System.Drawing.Size(198, 303);
            this.pnlMemo.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelMemo);
            this.panel2.Controls.Add(this.btnAddMemo);
            this.panel2.Controls.Add(this.btnDelMemoCancel);
            this.panel2.Controls.Add(this.btnDelMemoOK);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 27);
            this.panel2.TabIndex = 0;
            // 
            // btnDelMemo
            // 
            this.btnDelMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelMemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelMemo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelMemo.Location = new System.Drawing.Point(149, 0);
            this.btnDelMemo.Name = "btnDelMemo";
            this.btnDelMemo.Size = new System.Drawing.Size(46, 25);
            this.btnDelMemo.TabIndex = 0;
            this.btnDelMemo.Text = "-";
            this.btnDelMemo.UseVisualStyleBackColor = true;
            this.btnDelMemo.Click += new System.EventHandler(this.btnDelMemo_Click);
            // 
            // btnAddMemo
            // 
            this.btnAddMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMemo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddMemo.Location = new System.Drawing.Point(97, 0);
            this.btnAddMemo.Name = "btnAddMemo";
            this.btnAddMemo.Size = new System.Drawing.Size(46, 25);
            this.btnAddMemo.TabIndex = 0;
            this.btnAddMemo.Text = "+";
            this.btnAddMemo.UseVisualStyleBackColor = true;
            this.btnAddMemo.Click += new System.EventHandler(this.btnAddMemo_Click);
            // 
            // btnDelMemoCancel
            // 
            this.btnDelMemoCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelMemoCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelMemoCancel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelMemoCancel.Location = new System.Drawing.Point(149, 0);
            this.btnDelMemoCancel.Name = "btnDelMemoCancel";
            this.btnDelMemoCancel.Size = new System.Drawing.Size(46, 25);
            this.btnDelMemoCancel.TabIndex = 0;
            this.btnDelMemoCancel.Text = "X";
            this.btnDelMemoCancel.UseVisualStyleBackColor = true;
            this.btnDelMemoCancel.Click += new System.EventHandler(this.btnDelMemoCancel_Click);
            // 
            // btnDelMemoOK
            // 
            this.btnDelMemoOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelMemoOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelMemoOK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelMemoOK.Location = new System.Drawing.Point(97, 0);
            this.btnDelMemoOK.Name = "btnDelMemoOK";
            this.btnDelMemoOK.Size = new System.Drawing.Size(46, 25);
            this.btnDelMemoOK.TabIndex = 0;
            this.btnDelMemoOK.Text = "O";
            this.btnDelMemoOK.UseVisualStyleBackColor = true;
            this.btnDelMemoOK.Click += new System.EventHandler(this.btnDelMemoOK_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(198, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "메모";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 169);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(198, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // txtTip
            // 
            this.txtTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTip.Location = new System.Drawing.Point(0, 27);
            this.txtTip.Multiline = true;
            this.txtTip.Name = "txtTip";
            this.txtTip.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTip.Size = new System.Drawing.Size(198, 142);
            this.txtTip.TabIndex = 0;
            this.txtTip.TextChanged += new System.EventHandler(this.txtTip_TextChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(198, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "설명";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.pictureBox1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 32);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(854, 472);
            this.pnlContent.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1600, 1200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            this.pictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragEnter);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.btnFirstMove);
            this.pnlBottom.Controls.Add(this.btnDelGraffity);
            this.pnlBottom.Controls.Add(this.lbLRIndex);
            this.pnlBottom.Controls.Add(this.btnLeft);
            this.pnlBottom.Controls.Add(this.btnRight);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 504);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(854, 32);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnFirstMove
            // 
            this.btnFirstMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstMove.BackColor = System.Drawing.Color.White;
            this.btnFirstMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstMove.Location = new System.Drawing.Point(617, 3);
            this.btnFirstMove.Name = "btnFirstMove";
            this.btnFirstMove.Size = new System.Drawing.Size(125, 25);
            this.btnFirstMove.TabIndex = 7;
            this.btnFirstMove.Text = "대표 페이지로 이동";
            this.btnFirstMove.UseVisualStyleBackColor = false;
            this.btnFirstMove.Click += new System.EventHandler(this.btnFirstMove_Click);
            // 
            // btnDelGraffity
            // 
            this.btnDelGraffity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelGraffity.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDelGraffity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelGraffity.Location = new System.Drawing.Point(762, 3);
            this.btnDelGraffity.Name = "btnDelGraffity";
            this.btnDelGraffity.Size = new System.Drawing.Size(85, 25);
            this.btnDelGraffity.TabIndex = 6;
            this.btnDelGraffity.Text = "그림판 삭제";
            this.btnDelGraffity.UseVisualStyleBackColor = true;
            this.btnDelGraffity.Click += new System.EventHandler(this.btnDelGraffity_Click);
            // 
            // lbLRIndex
            // 
            this.lbLRIndex.Location = new System.Drawing.Point(40, 3);
            this.lbLRIndex.Name = "lbLRIndex";
            this.lbLRIndex.Size = new System.Drawing.Size(53, 25);
            this.lbLRIndex.TabIndex = 5;
            this.lbLRIndex.Text = "? / ?";
            this.lbLRIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.White;
            this.btnLeft.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLeft.Image = global::JSFW.Properties.Resources.Left2424;
            this.btnLeft.Location = new System.Drawing.Point(7, 1);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(29, 29);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.TabStop = false;
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.White;
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRight.Image = global::JSFW.Properties.Resources.Right2424;
            this.btnRight.Location = new System.Drawing.Point(98, 1);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(29, 29);
            this.btnRight.TabIndex = 4;
            this.btnRight.TabStop = false;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // EditSlide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlAttribute);
            this.Controls.Add(this.panel1);
            this.Name = "EditSlide";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.Size = new System.Drawing.Size(1054, 536);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbPenWidth)).EndInit();
            this.pnlAttribute.ResumeLayout(false);
            this.pnlAttribute.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Panel pnlAttribute;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar tbPenWidth;
        private System.Windows.Forms.RadioButton rdoErase;
        private System.Windows.Forms.RadioButton rdoPen;
        private Label lbPenColor;
        private Label lbLRIndex;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnAllErase;
        private System.Windows.Forms.TextBox txtTip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelMemo;
        private System.Windows.Forms.Button btnAddMemo;
        private System.Windows.Forms.Button btnDelMemoCancel;
        private System.Windows.Forms.Button btnDelMemoOK;
        private System.Windows.Forms.Panel pnlMemo;
        private Label label2;
        private System.Windows.Forms.Splitter splitter1;
        private Label label1;
        private System.Windows.Forms.Button btnUIDesign;
        private System.Windows.Forms.Button btnSetBackGroundImage;
        private System.Windows.Forms.Button btnDelGraffity;
        private System.Windows.Forms.CheckBox chUsePen;
        private System.Windows.Forms.Button btnFirstMove;
    }
}
