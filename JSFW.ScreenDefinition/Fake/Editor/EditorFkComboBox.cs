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
    public partial class EditorFkComboBox : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public EditorFkComboBox()
        {
            InitializeComponent();
            this.Disposed += EditorFkCheck_Disposed;
        }

        private void EditorFkCheck_Disposed(object sender, EventArgs e)
        {
            this.Data = null;
        }

        void IFkData.SetData(FkData data)
        {
            Data = data;
            if (Data != null)
            {
                textBox1.Text = Data.Text;
                chkVisible.Checked = Data.Visible;
            }
        }

        void IFkData.DataFlush()
        {
            Data.Text = textBox1.Text?.Trim();
            Data.Visible = chkVisible.Checked; 
        }

        void IFkData.ShowEdit()
        {
        }
    }
}
