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
    public partial class EditorFkCodeFind : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public EditorFkCodeFind()
        {
            InitializeComponent();
            this.Disposed += EditorFkCodeFind_Disposed;
        }

        private void EditorFkCodeFind_Disposed(object sender, EventArgs e)
        {
            this.Data = null;
        }

        void IFkData.SetData(FkData data)
        {
            Data = data;
            if (Data != null)
            {
                txtCodeFindSPName.Text = Data.Text;
                chkVisible.Checked = Data.Visible;

                rdoCodeFind.Checked = Data.IsCodeFind;
                rdoAddr.Checked = !rdoCodeFind.Checked;
            }
        }

        void IFkData.DataFlush()
        {
            Data.Text = txtCodeFindSPName.Text.Trim();
            Data.Visible = chkVisible.Checked;
            Data.IsCodeFind = rdoCodeFind.Checked;
        }
         
        private void txtCodeFindSPName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{ESC}");
            }
        }

        void IFkData.ShowEdit()
        {
        }
    }
}
