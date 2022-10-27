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
    public partial class EditorFkDataGrid : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public EditorFkDataGrid()
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
                chkVisible.Checked = Data.Visible; 
            }
        }

        void IFkData.DataFlush()
        {
            Data.Visible = chkVisible.Checked; 
        }

        void IFkData.ShowEdit()
        {
        }
    }
}
