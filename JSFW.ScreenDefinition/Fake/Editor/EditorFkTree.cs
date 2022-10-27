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
    public partial class EditorFkTree : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public EditorFkTree()
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
                txtContent.Text = Data.TreeContents; 
                chkVisible.Checked = Data.Visible;

                rdoTree.Checked = Data.IsTree;
                rdoList.Checked = !rdoTree.Checked;
            }
        }

        void IFkData.DataFlush()
        {
            Data.TreeContents = txtContent.Text;
            Data.Visible = chkVisible.Checked;

            Data.IsTree = rdoTree.Checked;
        }
         
        void IFkData.ShowEdit()
        {
        }
    }
}
