using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JSFW.Fake.Editor;
using PopupControl;

namespace JSFW.Fake
{
    public partial class FkImage : UserControl, IFkData
    {
        Popup Editor = null;
        EditorFkImage ImageEditor = null;

        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkImage).FullName,
            Text = "이미지",
            Visible = true,
            Left = 0,
            Top = 0,
            Width = 151,
            Height = 109,
        };

        bool isDataBinding = false;
        public void SetData(FkData data)
        {
            Data = data;

            try
            {
                isDataBinding = true;
                this.Left = Data.Left;
                this.Top = Data.Top;
                this.Width = Data.Width;
                this.Height = Data.Height;
            }
            finally
            {
                isDataBinding = false;
            }
            Invalidate();
        }

        public void DataFlush()
        {
            Data.Left = this.Left;
            Data.Top = this.Top;
            Data.Width = this.Width;
            Data.Height = this.Height;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (isDataBinding || Data == null) return;
            Data.Width = this.Width;
            Data.Height = this.Height;
        }

        public FkImage()
        {
            InitializeComponent();

            DoubleBuffered = true;

            Editor = new Popup(ImageEditor = new EditorFkImage());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = ImageEditor;
            ied.DataFlush();
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = ImageEditor;
            ied.SetData(Data);
        }
         
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle imageBox = Rectangle.FromLTRB(
                  DisplayRectangle.Left + 2,
                  DisplayRectangle.Top + 2,
                  DisplayRectangle.Width - 3,
                  DisplayRectangle.Height - 3);

            Rectangle textRect = Rectangle.FromLTRB(
                imageBox.Left + (int)(imageBox.Width * 0.3), imageBox.Top +(int)(imageBox.Height * 0.3),
                imageBox.Right - (int)(imageBox.Width * 0.3), imageBox.Bottom - (int)(imageBox.Height * 0.3));

            e.Graphics.DrawRectangle(Pens.DimGray, imageBox);
            e.Graphics.DrawLine(Pens.DimGray,
                new Point(imageBox.Left, imageBox.Top),
                new Point(imageBox.Right, imageBox.Bottom));
            e.Graphics.DrawLine(Pens.DimGray,
                new Point(imageBox.Right, imageBox.Top),
                new Point(imageBox.Left, imageBox.Bottom));


            e.Graphics.FillRectangle( Brushes.White, textRect);
            TextRenderer.DrawText(e.Graphics, "이미지"+ Height, Font, textRect,
                 ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

            bool vis = Data.Visible;
            if (vis == false)
            {
                FkCtrlUx.UnVisibleDraw(this, e.Graphics);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (e.Button == MouseButtons.Left)
            {
                ((IFkData)this)?.ShowEdit();
            }
        }

        void IFkData.ShowEdit()
        {
            Editor.Show(this);
        }
    } 

}
