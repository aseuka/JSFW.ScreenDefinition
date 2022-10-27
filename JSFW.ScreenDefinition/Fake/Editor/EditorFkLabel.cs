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
    public partial class EditorFkLabel : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public EditorFkLabel()
        {
            InitializeComponent();
            this.Disposed += EditorFkLabel_Disposed;
        }

        private void EditorFkLabel_Disposed(object sender, EventArgs e)
        {
            this.Data = null;
        }

        void IFkData.SetData(FkData data)
        {
            Data = data;
            if (Data != null)
            {
                txtContent.Text = Data.Text;
                rdoAlignLEFT.Checked = true;
                rdoAlignCENTER.Checked = false;
                rdoAlignRIGHT.Checked = false;

                chkVisible.Checked = Data.Visible;
                chkRequird.Checked = Data.Required;

                if (Data.TextAlign == FkDataTextAlign.Center)
                {
                    rdoAlignCENTER.Checked = true;
                }
                else if (Data.TextAlign == FkDataTextAlign.Right)
                {
                    rdoAlignRIGHT.Checked = true;
                }
                txtContent.ForeColor = Data.ForeColor;
                txtContent.BackColor = Data.BackColor;
                chkBold.Checked = Data.Bold;
            }
        }

        void IFkData.DataFlush()
        {
            Data.Text = txtContent?.Text.Trim();

            if (rdoAlignCENTER.Checked)
            {
                Data.TextAlign = FkDataTextAlign.Center;
            }
            else if (rdoAlignRIGHT.Checked)
            {
                Data.TextAlign = FkDataTextAlign.Right;
            }
            else
            {
                Data.TextAlign = FkDataTextAlign.Left;
            }

            Data.Visible = chkVisible.Checked;
            Data.Required = chkRequird.Checked;

            Data.Bold = chkBold.Checked;
            Data.ForeColor = txtContent.ForeColor;
            Data.BackColor = txtContent.BackColor;
        }

        private void rdoWhiteBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWhiteBlack.Checked)
            {
                txtContent.ForeColor = rdoWhiteBlack.ForeColor;
                txtContent.BackColor = rdoWhiteBlack.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoBlackWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBlackWhite.Checked)
            {
                txtContent.ForeColor = rdoBlackWhite.ForeColor;
                txtContent.BackColor = rdoBlackWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoCoralWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCoralWhite.Checked)
            {
                txtContent.ForeColor = rdoCoralWhite.ForeColor;
                txtContent.BackColor = rdoCoralWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoOrangeRedWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOrangeRedWhite.Checked)
            {
                txtContent.ForeColor = rdoOrangeRedWhite.ForeColor;
                txtContent.BackColor = rdoOrangeRedWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoDeepSkyBlueWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDeepSkyBlueWhite.Checked)
            {
                txtContent.ForeColor = rdoDeepSkyBlueWhite.ForeColor;
                txtContent.BackColor = rdoDeepSkyBlueWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoDodgerBlueWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDodgerBlueWhite.Checked)
            {
                txtContent.ForeColor = rdoDodgerBlueWhite.ForeColor;
                txtContent.BackColor = rdoDodgerBlueWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoGrayWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGrayWhite.Checked)
            {
                txtContent.ForeColor = rdoGrayWhite.ForeColor;
                txtContent.BackColor = rdoGrayWhite.FlatAppearance.CheckedBackColor;
            }
        }

        void IFkData.ShowEdit()
        {
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
