using JSFW.ScreenDefinition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Fake
{
    public partial class CreateTemplateForm : Form
    {
        public TemplateFkData Data { get; private set; } = null;

        public CreateTemplateForm()
        {
            InitializeComponent();
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTemplateName.Text))
            {
                "템플릿이름은 필수!".Alert();
                return;
            }
            Data.Name = txtTemplateName.Text.Trim();
            string path = $"{MainForm.__DESIGN_TEMPLATE_DIR}{Data.ID}.jsdesigntmp";
            Ux.SaveFile(Data, path);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        Rectangle rct = Rectangle.Empty;
        internal void SetData(TemplateFkData data)
        {
            Data = data;

            fkPanel1.Data.Childs.Clear(); 
            rct = Rectangle.Empty;

            //좌표 offset 계산
            data.Data.ForEach(d =>
            {
                if (rct == Rectangle.Empty)
                {
                    rct = Rectangle.FromLTRB(d.Data.Left, d.Data.Top, d.Data.Left + d.Data.Width, d.Data.Top + d.Data.Height);
                }
                else
                {
                    Rectangle tmpRect = Rectangle.FromLTRB(d.Data.Left, d.Data.Top, d.Data.Left + d.Data.Width, d.Data.Top + d.Data.Height);

                    rct = Rectangle.FromLTRB(
                        tmpRect.Left < rct.Left ? tmpRect.Left : rct.Left,
                        tmpRect.Top < rct.Top ? tmpRect.Top : rct.Top,
                        rct.Right < tmpRect.Right ? tmpRect.Right : rct.Right,
                        rct.Bottom < tmpRect.Bottom ? tmpRect.Bottom : rct.Bottom);
                }
            });

            //좌표 offset 이동.
            foreach (DragDropFkData d in data.Data)
            {                 
                d.Data.Left -= rct.Left - 3;
                d.Data.Top -= rct.Top - 3;
                fkPanel1.Data.Childs.Add(d.Data);
            }
            fkPanel1.SetData(fkPanel1.Data);
        }

        private void txtTemplateName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{TAB}");
            }
        }
    }
}
