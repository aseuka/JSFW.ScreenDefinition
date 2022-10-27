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
    public partial class EditorFkTextBox : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public EditorFkTextBox()
        {
            InitializeComponent();
            this.Disposed += EditorFkTextBox_Disposed;
        }

        private void EditorFkTextBox_Disposed(object sender, EventArgs e)
        {
            this.Data = null;
        }

        void IFkData.SetData(FkData data)
        {
            Data = data;
            if (Data != null)
            {
                textBox1.Text = Data.Text;
                rdoAlignLEFT.Checked = true;
                rdoAlignCENTER.Checked = false;
                rdoAlignRIGHT.Checked = false;

                chkVisible.Checked = Data.Visible;

                if (Data.TextAlign == FkDataTextAlign.Center)
                {
                    rdoAlignCENTER.Checked = true;
                }
                else if (Data.TextAlign == FkDataTextAlign.Right)
                {
                    rdoAlignRIGHT.Checked = true;
                }
            }
        }

        void IFkData.DataFlush()
        {
            Data.Text = textBox1.Text;

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
        }

        private void rdoEmpty_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoEmpty.Checked)
            {
                textBox1.Text = "";
            }
        }

        private void rdoNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNumber.Checked)
            {
                textBox1.Text = "#,###";
                if (0 < numericUpDown1.Value)
                {
                    textBox1.Text += $".{new string('#', (int)numericUpDown1.Value)}";
                }
            }
        }

        private void rdoPostNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPostNumber.Checked)
            {
                textBox1.Text = "우편번호";
            }
        }

        private void rdoTelNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTelNumber.Checked)
            {
                textBox1.Text = "전화번호";
            }
        }

        private void rdoHP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHP.Checked)
            {
                textBox1.Text = "HP";
            }
        }

        void IFkData.ShowEdit()
        {
        }
    }
}
