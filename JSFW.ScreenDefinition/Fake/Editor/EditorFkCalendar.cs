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
    public partial class EditorFkCalendar : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public EditorFkCalendar()
        {
            InitializeComponent();
            this.Disposed += EditorFkCalendar_Disposed;
        }

        private void EditorFkCalendar_Disposed(object sender, EventArgs e)
        {
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
                    chkVisible.Checked = Data.Visible;
                    rdoYYYY_MM_DD.Checked = false;
                    rdoYYYY_MM.Checked = false;
                    rdoYYYY.Checked = false;

                    if (Data.Text == "YYYY_MM_DD")
                    {
                        rdoYYYY_MM_DD.Checked = true;
                    }
                    else if (Data.Text == "YYYY_MM")
                    {
                        rdoYYYY_MM.Checked = true;
                    }
                    else
                    {
                        rdoYYYY.Checked = true;
                    }
                }
                finally
                {
                    IsDataBinding = false;
                }
            }
        }

        void IFkData.DataFlush()
        {
            if (rdoYYYY_MM_DD.Checked)
            {
                Data.Text = "YYYY_MM_DD";
            }
            else if (rdoYYYY_MM.Checked)
            {
                Data.Text = "YYYY_MM";
            }
            else
            {
                Data.Text = "YYYY";
            }
            Data.Visible = chkVisible.Checked;
        }

        private void rdoYYYY_MM_DD_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;
            SendKeys.SendWait("{TAB}");
        }

        private void rdoYYYY_MM_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;
            SendKeys.SendWait("{TAB}");
        }

        private void rdoYYYY_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;
            SendKeys.SendWait("{TAB}");
        }

        void IFkData.ShowEdit()
        {
        }
    }
}
