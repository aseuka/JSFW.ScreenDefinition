using JSFW.ScreenDefinition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW
{
    public partial class SetBackgroundImageFm : Form
    {
        public string ImagePath { get => lbImagePath.Text.TrimEnd(); }

        public bool dirtyDesignCapture = false;

        string _DesignFilePath { get; set; }

        public SetBackgroundImageFm()
        {
            InitializeComponent();
            this.Disposed += SetBackgroundImageFm_Disposed;
        }

        private void SetBackgroundImageFm_Disposed(object sender, EventArgs e)
        {
            using (pictureBox1.Image) { }
            pictureBox1.Image = null;
        }

        public void SetData(Slide slide, Graffity graffity)
        {
            _DesignFilePath = slide.BackgroundImagePath;
            lbImagePath.Text = graffity.BackgroundImagePath;
            needCopyFile = false;
            dirtyDesignCapture = false;
        }
 
        private void btnEmpty_Click(object sender, EventArgs e)
        {
            lbImagePath.Text = "";
            needCopyFile = false;
            dirtyDesignCapture = false;
        }

        private void btnDesignFile_Click(object sender, EventArgs e)
        {
            lbImagePath.Text = _DesignFilePath;
            needCopyFile = false;
            dirtyDesignCapture = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public bool needCopyFile = false;
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    lbImagePath.Text = ofd.FileName;
                    needCopyFile = true;
                }
            }
        }

        private void lbImagePath_TextChanged(object sender, EventArgs e)
        {
            string filepath = lbImagePath.Text.TrimEnd();

            using (pictureBox1.Image) { }
            pictureBox1.Image = null;
            GC.Collect();

            if (string.IsNullOrWhiteSpace(filepath)) return;

            if (File.Exists(filepath) == false) return;

            using( Image img = Image.FromFile( filepath))
            {
                pictureBox1.Image = img.Clone() as Image;
            }
        }
    }
}
