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
    public partial class SlideItemView : UserControl
    {
        public Slide Data { get; internal set; }

        public bool IsDelete { get => chkDel.Checked; set => chkDel.Checked = value; }
         
        public SlideItemView()
        {
            InitializeComponent();
            this.Disposed += SlideItemView_Disposed;
        }

        private void SlideItemView_Disposed(object sender, EventArgs e)
        {
            Data = null;
        }

        public void SetData(Slide data)
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
            string txt = (Data?.Title ?? "미지정");
            string vs = $"{(Data?.Order ?? 1)}";

            Rectangle textRectangle = Rectangle.FromLTRB(
                DisplayRectangle.Left + 20,
                DisplayRectangle.Top,
                DisplayRectangle.Right,
                DisplayRectangle.Bottom );

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
            TextRenderer.DrawText(e.Graphics, $"{vs}.{txt}", Font, textRectangle, Color.Maroon, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        public void UseDelete(bool show = false)
        {
            chkDel.Checked = false;
            chkDel.Visible = show;
        }



        public event EventHandler<UpDnEventArgs> UpDownMoved = null;
        private void btnUP_Click(object sender, EventArgs e)
        {
            UpDownMoved?.Invoke(this, new UpDnEventArgs(+1));
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            UpDownMoved?.Invoke(this, new UpDnEventArgs(-1));
        }

        internal void ChangeOrder(bool visibled)
        {
            btnUP.Visible = visibled;
            btnDN.Visible = visibled;
        }
    }

    public class UpDnEventArgs : EventArgs
    {
        public int Increase { get; private set; } = 0;

        public UpDnEventArgs(int inc ) : base()
        {
            Increase = inc;
        }
    }
}
