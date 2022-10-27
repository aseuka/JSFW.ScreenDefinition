using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Fake.Editor
{
    public partial class EditorFkButton : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public string ImageType { get; set; } = null;

        public EditorFkButton()
        {
            InitializeComponent();
            this.Disposed += EditorFkButton_Disposed;
        }

        private void EditorFkButton_Disposed(object sender, EventArgs e)
        {
            crntButton = null;
            this.Data = null;
        }

        bool IsDataBinding = false;
        void IFkData.SetData(FkData data)
        {
            Data = data;
            if (Data != null)
            {
                try
                {
                    IsDataBinding = true;
                    textBox1.Text = Data.Text;
                    chkVisible.Checked = Data.Visible;

                    textBox1.ForeColor = Data.ForeColor;
                    textBox1.BackColor = Data.BackColor;
                }
                finally
                {
                    IsDataBinding = false;
                }
            }
        }

        void IFkData.DataFlush()
        {
            Data.Text = textBox1.Text;            
            Data.Visible = chkVisible.Checked;

            Data.ForeColor = textBox1.ForeColor;
            Data.BackColor = textBox1.BackColor;

            if (ImageType != null)
            {
                Data.ImageType = ImageType;
            }
        }

        void IFkData.ShowEdit()
        {
        }

        private void rdoWhiteBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWhiteBlack.Checked)
            {
                textBox1.ForeColor = rdoWhiteBlack.ForeColor;
                textBox1.BackColor = rdoWhiteBlack.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoBlackWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBlackWhite.Checked)
            {
                textBox1.ForeColor = rdoBlackWhite.ForeColor;
                textBox1.BackColor = rdoBlackWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoCoralWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCoralWhite.Checked)
            {
                textBox1.ForeColor = rdoCoralWhite.ForeColor;
                textBox1.BackColor = rdoCoralWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoOrangeRedWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOrangeRedWhite.Checked)
            {
                textBox1.ForeColor = rdoOrangeRedWhite.ForeColor;
                textBox1.BackColor = rdoOrangeRedWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoDeepSkyBlueWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDeepSkyBlueWhite.Checked)
            {
                textBox1.ForeColor = rdoDeepSkyBlueWhite.ForeColor;
                textBox1.BackColor = rdoDeepSkyBlueWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoDodgerBlueWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDodgerBlueWhite.Checked)
            {
                textBox1.ForeColor = rdoDodgerBlueWhite.ForeColor;
                textBox1.BackColor = rdoDodgerBlueWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoGrayWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGrayWhite.Checked)
            {
                textBox1.ForeColor = rdoGrayWhite.ForeColor;
                textBox1.BackColor = rdoGrayWhite.FlatAppearance.CheckedBackColor;
            }
        }
        
        Button crntButton = null;
        void SetCurnButton(Button btn)
        {
            if (btn == crntButton) return;

            if (crntButton != null)
            {
                crntButton.BackColor = SystemColors.Control;
            } 
            crntButton = btn;
            if (crntButton != null)
            {
                crntButton.BackColor = Color.Coral;
            }
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            ImageType = "";
            SetCurnButton(sender as Button); 
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ImageType = "FIND";
            SetCurnButton(sender as Button);
        }

        private void btnExe_Click(object sender, EventArgs e)
        {
            ImageType = "EXE";
            SetCurnButton(sender as Button);
        }

        private void btnClip_Click(object sender, EventArgs e)
        {
            ImageType = "CLIP";
            SetCurnButton(sender as Button);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ImageType = "SETTING";
            SetCurnButton(sender as Button);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            ImageType = "ADD";
            SetCurnButton(sender as Button);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            ImageType = "DEL";
            SetCurnButton(sender as Button);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ImageType = "PRINT";
            SetCurnButton(sender as Button);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ImageType = "EXCEL";
            SetCurnButton(sender as Button);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ImageType = "REFRESH";
            SetCurnButton(sender as Button);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ImageType = "SAVE";
            SetCurnButton(sender as Button);
        }
    }
}
