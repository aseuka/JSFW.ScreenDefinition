using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopupControl;
using JSFW.Fake.Editor;
using JSFW.Properties;

namespace JSFW.Fake
{
    public partial class FkButton : UserControl, IFkData
    {
        Popup Editor = null;
        EditorFkButton ButtonEditor = null;

        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkButton).FullName,
            Text = "버튼",
            Visible = true,
            Left = 0,
            Top = 0,
            Width = 50,
            Height = 25,
        };

        Image img = null;

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

                if (BackColorBrush.Color != this.BackColor)
                {
                    BackColorBrush = new SolidBrush(this.BackColor);
                }

                if (!string.IsNullOrWhiteSpace(Data?.ImageType))
                {
                    switch (Data?.ImageType)
                    {
                        case "FIND":
                            img = Resources.Find;
                            break;
                        case "EXE":
                            img = Resources.Play;
                            break;
                        case "CLIP":
                            img = Resources.Clip;
                            break;
                        case "SETTING":
                            img = Resources.Settings;
                            break;
                        case "ADD":
                            img = Resources.add;
                            break;
                        case "DEL":
                            img = Resources.delete;
                            break;
                        case "PRINT":
                            img = Resources.Print;
                            break;
                        case "EXCEL":
                            img = Resources.excel;
                            break;
                        case "REFRESH":
                            img = Resources.refresh;
                            break;
                        case "SAVE":
                            img = Resources.save;
                            break;
                    }
                }
                else
                {
                    img = null;
                }

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

        public FkButton()
        {
            InitializeComponent();

            DoubleBuffered = true;
            Editor = new Popup(ButtonEditor = new EditorFkButton());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = ButtonEditor;
            ied.DataFlush(); 
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = ButtonEditor;
            ied.SetData(Data);
        }

        SolidBrush BackColorBrush = new SolidBrush( Color.White ); 
        Pen BolderPen = new Pen(Color.Gray, 3f)
        {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        };

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
             
            Rectangle DisplayRect = Rectangle.FromLTRB(
               DisplayRectangle.Left ,
               DisplayRectangle.Top,
               DisplayRectangle.Right - 1,
               DisplayRectangle.Bottom - 1);
            //ButtonRenderer.DrawButton(e.Graphics, DisplayRectangle, System.Windows.Forms.VisualStyles.PushButtonState.Normal);
            e.Graphics.FillRectangle(BackColorBrush, DisplayRect);
            e.Graphics.DrawRectangle(BolderPen, DisplayRect);

            if (img != null)
            {
                Rectangle imgRect = Rectangle.FromLTRB(DisplayRectangle.Left + 2, DisplayRectangle.Top + 4, DisplayRectangle.Left + 2 + 16, DisplayRectangle.Top + 4 + 16);
                e.Graphics.DrawImage(img, imgRect);
            }

            string txt = ("" + Data?.Text);
            Color foreClr = ForeColor;
            if (!string.IsNullOrWhiteSpace(txt))
            {
                if (img != null)
                {
                    Rectangle textRect = Rectangle.FromLTRB(
                        DisplayRectangle.Left + Margin.Left + 2 + 16 + 2,
                        DisplayRectangle.Top + Margin.Top,
                        DisplayRectangle.Right - Margin.Right,
                        DisplayRectangle.Bottom - Margin.Bottom);

                    TextRenderer.DrawText(e.Graphics, txt, Font, textRect,
                        foreClr, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }
                else
                {
                    Rectangle textRect = Rectangle.FromLTRB(
                            DisplayRectangle.Left + Margin.Left,
                            DisplayRectangle.Top + Margin.Top,
                            DisplayRectangle.Right - Margin.Right,
                            DisplayRectangle.Bottom - Margin.Bottom);

                    TextRenderer.DrawText(e.Graphics, txt, Font, textRect,
                        foreClr, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }
            }
             
            bool vis = (Data?.Visible ?? false);
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
