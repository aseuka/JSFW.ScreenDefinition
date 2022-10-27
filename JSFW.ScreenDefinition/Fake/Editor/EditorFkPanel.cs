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
    public partial class EditorFkPanel : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public EditorFkPanel()
        {
            InitializeComponent();
            this.Disposed += EditorFkPanel_Disposed;
        }

        private void EditorFkPanel_Disposed(object sender, EventArgs e)
        {
            this.Data = null;
        }

        void IFkData.SetData(FkData data)
        {
            Data = data;
            if (Data != null)
            {
                txtTitle.Text = Data.Text; 
                chkVisible.Checked = Data.Visible;
                txtTitle.ForeColor = Data.HeaderForeColor;
                txtTitle.BackColor = Data.HeaderBackColor;
            }
        }

        void IFkData.DataFlush()
        {
            Data.Text = txtTitle.Text; 
            Data.Visible = chkVisible.Checked;

           Data.HeaderForeColor = txtTitle.ForeColor;
           Data.HeaderBackColor = txtTitle.BackColor;
        }

        private void rdoWhiteBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWhiteBlack.Checked)
            {
                txtTitle.ForeColor = rdoWhiteBlack.ForeColor;
                txtTitle.BackColor = rdoWhiteBlack.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoBlackWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBlackWhite.Checked)
            {
                txtTitle.ForeColor = rdoBlackWhite.ForeColor;
                txtTitle.BackColor = rdoBlackWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoCoralWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCoralWhite.Checked)
            {
                txtTitle.ForeColor = rdoCoralWhite.ForeColor;
                txtTitle.BackColor = rdoCoralWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoOrangeRedWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOrangeRedWhite.Checked)
            {
                txtTitle.ForeColor = rdoOrangeRedWhite.ForeColor;
                txtTitle.BackColor = rdoOrangeRedWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoDeepSkyBlueWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDeepSkyBlueWhite.Checked)
            {
                txtTitle.ForeColor = rdoDeepSkyBlueWhite.ForeColor;
                txtTitle.BackColor = rdoDeepSkyBlueWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoDodgerBlueWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDodgerBlueWhite.Checked)
            {
                txtTitle.ForeColor = rdoDodgerBlueWhite.ForeColor;
                txtTitle.BackColor = rdoDodgerBlueWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoGrayWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGrayWhite.Checked)
            {
                txtTitle.ForeColor = rdoGrayWhite.ForeColor;
                txtTitle.BackColor = rdoGrayWhite.FlatAppearance.CheckedBackColor;
            }
        }

        void IFkData.ShowEdit()
        {
        }
    }
}
