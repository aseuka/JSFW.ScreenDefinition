using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.ScreenDefinition
{
    public partial class SDMiniView : UserControl
    {
        public ScreenDocumentHeader Data { get; internal set; }

        public bool IsDelete { get => chkDel.Checked; set => chkDel.Checked = value; }

        public SDMiniView()
        {
            InitializeComponent();

            this.Disposed += SDMiniView_Disposed;
        }

        private void SDMiniView_Disposed(object sender, EventArgs e)
        {
            Data = null;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        public void SetData(ScreenDocumentHeader data)
        {
            Data = data;
            if (Data != null)
            {
             
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            string txt = (Data?.DocumentTitle ?? "미지정");
            string vs = $"v{(Data?.Version ?? 1.0m)}";
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
            TextRenderer.DrawText(e.Graphics, $"{txt}{Environment.NewLine}{vs}", Font, DisplayRectangle, Color.Maroon, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        public void UseDelete(bool show = false)
        {
            chkDel.Checked = false;
            chkDel.Visible = show;
        }
    }
}
