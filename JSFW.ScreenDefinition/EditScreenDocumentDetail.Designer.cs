namespace JSFW.ScreenDefinition
{
    partial class EditScreenDocumentDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.editSlide1 = new JSFW.ScreenDefinition.EditSlide();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flpTestLog = new System.Windows.Forms.FlowLayoutPanel();
            this.flpFunctionList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkTesting = new System.Windows.Forms.CheckBox();
            this.btnSaveFunctionDefinition = new System.Windows.Forms.Button();
            this.label1 = new JSFW.Label();
            this.btnDelFunction = new System.Windows.Forms.Button();
            this.btnAddFunction = new System.Windows.Forms.Button();
            this.btnDelCancelFunction = new System.Windows.Forms.Button();
            this.btnDelOKFunction = new System.Windows.Forms.Button();
            this.sdTopView1 = new JSFW.ScreenDefinition.SDTopView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(218, 633);
            this.panel1.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(218, 28);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 633);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(221, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1013, 633);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.editSlide1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1005, 607);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "화면 정의서";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // editSlide1
            // 
            this.editSlide1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editSlide1.Location = new System.Drawing.Point(3, 3);
            this.editSlide1.Name = "editSlide1";
            this.editSlide1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.editSlide1.PageIndex = 0;
            this.editSlide1.Size = new System.Drawing.Size(999, 601);
            this.editSlide1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flpTestLog);
            this.tabPage2.Controls.Add(this.flpFunctionList);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1005, 607);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "기능 정의서";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flpTestLog
            // 
            this.flpTestLog.AutoScroll = true;
            this.flpTestLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTestLog.Location = new System.Drawing.Point(633, 28);
            this.flpTestLog.Name = "flpTestLog";
            this.flpTestLog.Size = new System.Drawing.Size(369, 576);
            this.flpTestLog.TabIndex = 2;
            // 
            // flpFunctionList
            // 
            this.flpFunctionList.AutoScroll = true;
            this.flpFunctionList.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpFunctionList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpFunctionList.Location = new System.Drawing.Point(3, 28);
            this.flpFunctionList.Name = "flpFunctionList";
            this.flpFunctionList.Size = new System.Drawing.Size(630, 576);
            this.flpFunctionList.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkTesting);
            this.panel2.Controls.Add(this.btnSaveFunctionDefinition);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnDelFunction);
            this.panel2.Controls.Add(this.btnAddFunction);
            this.panel2.Controls.Add(this.btnDelCancelFunction);
            this.panel2.Controls.Add(this.btnDelOKFunction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(999, 25);
            this.panel2.TabIndex = 0;
            // 
            // chkTesting
            // 
            this.chkTesting.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkTesting.FlatAppearance.CheckedBackColor = System.Drawing.Color.OrangeRed;
            this.chkTesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTesting.Location = new System.Drawing.Point(540, -1);
            this.chkTesting.Name = "chkTesting";
            this.chkTesting.Size = new System.Drawing.Size(89, 25);
            this.chkTesting.TabIndex = 3;
            this.chkTesting.Text = "테스트 시작";
            this.chkTesting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTesting.UseVisualStyleBackColor = true;
            this.chkTesting.CheckedChanged += new System.EventHandler(this.chkTesting_CheckedChanged);
            // 
            // btnSaveFunctionDefinition
            // 
            this.btnSaveFunctionDefinition.BackColor = System.Drawing.Color.White;
            this.btnSaveFunctionDefinition.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSaveFunctionDefinition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFunctionDefinition.Location = new System.Drawing.Point(198, 0);
            this.btnSaveFunctionDefinition.Name = "btnSaveFunctionDefinition";
            this.btnSaveFunctionDefinition.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFunctionDefinition.TabIndex = 2;
            this.btnSaveFunctionDefinition.Text = "저장";
            this.btnSaveFunctionDefinition.UseVisualStyleBackColor = false;
            this.btnSaveFunctionDefinition.Click += new System.EventHandler(this.btnSaveFunctionDefinition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(297, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "[Control + ↓] 문단 자르기";
            // 
            // btnDelFunction
            // 
            this.btnDelFunction.BackColor = System.Drawing.Color.White;
            this.btnDelFunction.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDelFunction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelFunction.Location = new System.Drawing.Point(83, 0);
            this.btnDelFunction.Name = "btnDelFunction";
            this.btnDelFunction.Size = new System.Drawing.Size(75, 23);
            this.btnDelFunction.TabIndex = 0;
            this.btnDelFunction.Text = "삭제";
            this.btnDelFunction.UseVisualStyleBackColor = false;
            this.btnDelFunction.Click += new System.EventHandler(this.btnDelFunction_Click);
            // 
            // btnAddFunction
            // 
            this.btnAddFunction.BackColor = System.Drawing.Color.White;
            this.btnAddFunction.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAddFunction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFunction.Location = new System.Drawing.Point(2, 0);
            this.btnAddFunction.Name = "btnAddFunction";
            this.btnAddFunction.Size = new System.Drawing.Size(75, 23);
            this.btnAddFunction.TabIndex = 0;
            this.btnAddFunction.Text = "추가";
            this.btnAddFunction.UseVisualStyleBackColor = false;
            this.btnAddFunction.Click += new System.EventHandler(this.btnAddFunction_Click);
            // 
            // btnDelCancelFunction
            // 
            this.btnDelCancelFunction.BackColor = System.Drawing.Color.White;
            this.btnDelCancelFunction.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDelCancelFunction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelCancelFunction.Location = new System.Drawing.Point(83, 0);
            this.btnDelCancelFunction.Name = "btnDelCancelFunction";
            this.btnDelCancelFunction.Size = new System.Drawing.Size(75, 23);
            this.btnDelCancelFunction.TabIndex = 0;
            this.btnDelCancelFunction.Text = "취소";
            this.btnDelCancelFunction.UseVisualStyleBackColor = false;
            this.btnDelCancelFunction.Click += new System.EventHandler(this.btnDelCancelFunction_Click);
            // 
            // btnDelOKFunction
            // 
            this.btnDelOKFunction.BackColor = System.Drawing.Color.White;
            this.btnDelOKFunction.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDelOKFunction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelOKFunction.Location = new System.Drawing.Point(2, 0);
            this.btnDelOKFunction.Name = "btnDelOKFunction";
            this.btnDelOKFunction.Size = new System.Drawing.Size(75, 23);
            this.btnDelOKFunction.TabIndex = 0;
            this.btnDelOKFunction.Text = "확인";
            this.btnDelOKFunction.UseVisualStyleBackColor = false;
            this.btnDelOKFunction.Click += new System.EventHandler(this.btnDelOKFunction_Click);
            // 
            // sdTopView1
            // 
            this.sdTopView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sdTopView1.Location = new System.Drawing.Point(0, 0);
            this.sdTopView1.Name = "sdTopView1";
            this.sdTopView1.Size = new System.Drawing.Size(1234, 28);
            this.sdTopView1.TabIndex = 0;
            this.sdTopView1.TabStop = false;
            this.sdTopView1.DoubleClick += new System.EventHandler(this.sdTopView1_DoubleClick);
            // 
            // EditScreenDocumentDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1234, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sdTopView1);
            this.Name = "EditScreenDocumentDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "화면정의 프로그램";
            this.VisibleChanged += new System.EventHandler(this.EditScreenDocumentDetail_VisibleChanged);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SDTopView sdTopView1;
        private EditSlide editSlide1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flpFunctionList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelCancelFunction;
        private System.Windows.Forms.Button btnDelOKFunction;
        private System.Windows.Forms.Button btnDelFunction;
        private System.Windows.Forms.Button btnAddFunction;
        private System.Windows.Forms.FlowLayoutPanel flpTestLog;
        private Label label1;
        private System.Windows.Forms.Button btnSaveFunctionDefinition;
        private System.Windows.Forms.CheckBox chkTesting;
    }
}