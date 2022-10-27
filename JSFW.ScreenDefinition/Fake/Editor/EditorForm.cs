using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Fake.Editor
{
    [Obsolete("POPUP 으로 필요없게 되었음.")]
    public partial class EditorForm : Form
    {
        public Func<Control> SetEditor { get; internal set; }

        public EditorForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Control c = SetEditor();
            panel1.Controls.Add(c);
            base.OnLoad(e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
    /*
        private void ShowEdit(IFkData ifk)
        {
            ifk?.DataFlush();
            FkData dt = ifk?.Data.Clone() as FkData;
            if (dt != null)
            {
                using (EditorForm edit = new EditorForm())
                {
                    using (EditorFkTextBox editor = new EditorFkTextBox())
                    {
                        edit.SetEditor = () =>
                        {
                            IFkData ieditor = editor as IFkData;
                            ieditor.SetData(dt);
                            return editor;
                        };

                        if (edit.ShowDialog() == DialogResult.OK)
                        {
                            IFkData ieditor = editor as IFkData;
                            ieditor.DataFlush(); 
                            SetData(ieditor.Data);
                        }
                    }
                }
            }
        }
     */
}
