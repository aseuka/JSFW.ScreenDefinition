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
    public partial class FkLabel : UserControl, IFkData
    {
        Popup Editor = null;
        EditorFkLabel LabelEditor = null;

        public FkData Data { get; internal set; } = new FkData() { 
                        TypeName = typeof(FkLabel).FullName, 
                        Text = "라벨", 
                        TextAlign = FkDataTextAlign.Left,
                        BackColor = Color.White,
                        Visible = true,
                        Left = 0,
                        Top = 0,
                        Width = 100,
                        Height = 25,
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
                this.ForeColor = Data.ForeColor;
                this.BackColor = Data.BackColor;
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

            Data.BackColor = this.BackColor;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (isDataBinding || Data == null) return;
            Data.Width = this.Width;
            Data.Height = this.Height;
        }

        public FkLabel()
        {
            InitializeComponent();

            DoubleBuffered = true;

            Editor = new Popup(LabelEditor = new EditorFkLabel());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = LabelEditor;
            ied.DataFlush();
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = LabelEditor;
            ied.SetData(Data);
        }

        Font RequiredFont = new Font("굴림체", 9f, FontStyle.Regular);
        Font RequiredBoldFont = new Font("굴림체", 9f, FontStyle.Bold);
        Font NomalFont = new Font("굴림체", 9f, FontStyle.Regular);
        Font NomalBoldFont = new Font("굴림체", 9f, FontStyle.Bold);

        Pen BolderPen = new Pen(Color.LightGray, 1f) 
        {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        };

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle textRect = Rectangle.FromLTRB(
                DisplayRectangle.Left + Margin.Left,
                DisplayRectangle.Top + Margin.Top,
                DisplayRectangle.Right - Margin.Right,
                DisplayRectangle.Bottom - Margin.Bottom);
            
            string txt = ("" + Data?.Text);
            Color foreClr = ForeColor;

            TextFormatFlags TextAlign = TextFormatFlags.Left;
             
            e.Graphics.DrawRectangle(BolderPen, 
                Rectangle.FromLTRB(DisplayRectangle.Left, DisplayRectangle.Top, 
                                   DisplayRectangle.Right-1, DisplayRectangle.Bottom-1));
              
            bool req = Data.Required;
              
            SizeF sz = TextRenderer.MeasureText(txt, req ? RequiredFont : (Data.Bold ? NomalBoldFont : NomalFont));
            Rectangle rect = DisplayRectangle;
            Rectangle txtrect = DisplayRectangle;

            switch ((Data?.TextAlign ?? FkDataTextAlign.Left))
            {
                case FkDataTextAlign.Left:
                    TextAlign = TextFormatFlags.Left;
                    rect = new Rectangle(
                     DisplayRectangle.Left,
                     DisplayRectangle.Top,
                     DisplayRectangle.Right,
                     DisplayRectangle.Bottom);

                    txtrect = new Rectangle(
                       DisplayRectangle.Left + 8,
                       DisplayRectangle.Top,
                       DisplayRectangle.Right,
                       DisplayRectangle.Bottom);
                    break;
                case FkDataTextAlign.Right:
                    TextAlign = TextFormatFlags.Right;
                    rect = new Rectangle(
                     DisplayRectangle.Right - (int)sz.Width - 8,
                     DisplayRectangle.Top,
                     DisplayRectangle.Right,
                     DisplayRectangle.Bottom);

                    txtrect = new Rectangle(
                       DisplayRectangle.Left,
                       DisplayRectangle.Top,
                       DisplayRectangle.Right,
                       DisplayRectangle.Bottom);
                    break;
                case FkDataTextAlign.Center:
                    TextAlign = TextFormatFlags.HorizontalCenter;
                    rect = new Rectangle(
                        DisplayRectangle.Left + (int)(DisplayRectangle.Width / 2 - sz.Width / 2) - 8,
                        DisplayRectangle.Top,
                        DisplayRectangle.Right,
                        DisplayRectangle.Bottom);

                    txtrect = new Rectangle(
                       DisplayRectangle.Left,
                       DisplayRectangle.Top,
                       DisplayRectangle.Right,
                       DisplayRectangle.Bottom);
                    break;
            }

            if (req)
            {
                TextRenderer.DrawText(e.Graphics, "*", RequiredFont, rect,
                        (BackColor == Color.OrangeRed || BackColor == Color.Coral) ? Color.Black : Color.Red, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                TextRenderer.DrawText(e.Graphics, txt, req ? (Data.Bold ? RequiredBoldFont : RequiredFont)  : (Data.Bold ? NomalBoldFont : NomalFont), txtrect, foreClr, TextFormatFlags.VerticalCenter | TextAlign);
            }
            else 
            {
                TextRenderer.DrawText(e.Graphics, txt, (Data.Bold ? NomalBoldFont : NomalFont), textRect,
                  foreClr, TextFormatFlags.VerticalCenter | TextAlign);
            }

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
