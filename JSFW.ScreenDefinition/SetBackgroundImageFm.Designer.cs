namespace JSFW
{
    partial class SetBackgroundImageFm
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
            this.btnEmpty = new System.Windows.Forms.Button();
            this.btnDesignFile = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbImagePath = new JSFW.Label();
            this.rdoNomal = new System.Windows.Forms.RadioButton();
            this.rdoStretchImage = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(11, 7);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(124, 27);
            this.btnEmpty.TabIndex = 0;
            this.btnEmpty.Text = "빈 페이지";
            this.btnEmpty.UseVisualStyleBackColor = true;
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // btnDesignFile
            // 
            this.btnDesignFile.Location = new System.Drawing.Point(141, 7);
            this.btnDesignFile.Name = "btnDesignFile";
            this.btnDesignFile.Size = new System.Drawing.Size(124, 27);
            this.btnDesignFile.TabIndex = 0;
            this.btnDesignFile.Text = "디자인 캡쳐";
            this.btnDesignFile.UseVisualStyleBackColor = true;
            this.btnDesignFile.Click += new System.EventHandler(this.btnDesignFile_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(271, 7);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(124, 27);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "가져오기";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(12, 633);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "배경이미지 경로";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1126, 588);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(401, 7);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(124, 27);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "캡쳐";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(457, 652);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(115, 37);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "적용";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(578, 652);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 37);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbImagePath
            // 
            this.lbImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbImagePath.AutoEllipsis = true;
            this.lbImagePath.Location = new System.Drawing.Point(118, 633);
            this.lbImagePath.Name = "lbImagePath";
            this.lbImagePath.Size = new System.Drawing.Size(949, 16);
            this.lbImagePath.TabIndex = 2;
            this.lbImagePath.Text = "경로";
            this.lbImagePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbImagePath.TextChanged += new System.EventHandler(this.lbImagePath_TextChanged);
            // 
            // rdoNomal
            // 
            this.rdoNomal.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoNomal.Checked = true;
            this.rdoNomal.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rdoNomal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoNomal.Location = new System.Drawing.Point(924, 10);
            this.rdoNomal.Name = "rdoNomal";
            this.rdoNomal.Size = new System.Drawing.Size(104, 24);
            this.rdoNomal.TabIndex = 6;
            this.rdoNomal.TabStop = true;
            this.rdoNomal.Text = "일반 보기";
            this.rdoNomal.UseVisualStyleBackColor = true;
            this.rdoNomal.CheckedChanged += new System.EventHandler(this.rdoNomal_CheckedChanged);
            // 
            // rdoStretchImage
            // 
            this.rdoStretchImage.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoStretchImage.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rdoStretchImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdoStretchImage.Location = new System.Drawing.Point(1034, 10);
            this.rdoStretchImage.Name = "rdoStretchImage";
            this.rdoStretchImage.Size = new System.Drawing.Size(104, 24);
            this.rdoStretchImage.TabIndex = 6;
            this.rdoStretchImage.Text = "꽉 차게 보기";
            this.rdoStretchImage.UseVisualStyleBackColor = true;
            this.rdoStretchImage.CheckedChanged += new System.EventHandler(this.rdoStretchImage_CheckedChanged);
            // 
            // SetBackgroundImageFm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1150, 693);
            this.Controls.Add(this.rdoStretchImage);
            this.Controls.Add(this.rdoNomal);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbImagePath);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnDesignFile);
            this.Controls.Add(this.btnEmpty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(725, 725);
            this.Name = "SetBackgroundImageFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "배경이미지 설정";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmpty;
        private System.Windows.Forms.Button btnDesignFile;
        private System.Windows.Forms.Button btnOpenFile;
        private Label lbImagePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rdoNomal;
        private System.Windows.Forms.RadioButton rdoStretchImage;
    }
}