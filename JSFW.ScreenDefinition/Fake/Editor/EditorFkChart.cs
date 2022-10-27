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
    public partial class EditorFkChart : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public EditorFkChart()
        {
            InitializeComponent();
            this.Disposed += EditorFkChart_Disposed;
        }

        private void EditorFkChart_Disposed(object sender, EventArgs e)
        {
            this.Data = null;
        }

        void IFkData.SetData(FkData data)
        {
            Data = data;
            if (Data != null)
            {
                txtX축.Text = Data.X축;
                txtSeries.Text = Data.Series;
                chkVisible.Checked = Data.Visible;
            }
        }

        void IFkData.DataFlush()
        {
            Data.X축 = txtX축.Text;
            Data.Series = txtSeries.Text;
            Data.Visible = chkVisible.Checked;
        }

        void IFkData.ShowEdit()
        {
        }

        private void txtX축_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{SPACE}");
            }
        }
    }
}
