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
    public partial class NumberMemo : UserControl
    {
        public Memo Data { get; private set; }

        public event Action StateChanged = null;
             
        public NumberMemo()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.Disposed += NumberMemo_Disposed;
        }

        private void NumberMemo_Disposed(object sender, EventArgs e)
        {
            Data = null;
        }

        bool IsDataBindings = false;
        public void SetData(Memo data)
        {
            Data = data;
            try
            {
                IsDataBindings = true;

                this.Left = Data.Left;
                this.Top = Data.Top;
                this.Visible = Data.UseNumber;
                if (Data.NumberIsTextViewMode)
                {
                    this.MaximumSize = new Size(0, 0);
                    SizeF sz = TextRenderer.MeasureText(Data.Text, Font);
                    if (sz.Width < 150)
                    {
                        this.Width = 150;
                    }
                    else
                    {                        
                        this.Width = (int)sz.Width;                    
                    }
                    this.Height = ResizeTextBoxHight();
                    this.MaximumSize = new Size(this.Width, this.Height);
                    BackColor = Color.FromArgb(100, Color.White);
                }
                else
                {
                    this.MaximumSize = new Size(19, 19);
                    this.Width = 19;
                    this.Height = 19;
                    BackColor = Color.OrangeRed;
                }

                if (Left < 0) Left = 0;
                if (Top < 0) Top = 0;

                if (EditSlide.DrawWidth < Left)
                {
                    Left = EditSlide.DrawWidth - Width - 2;
                }

                if (EditSlide.DrawHeight < Top)
                {
                    Top = EditSlide.DrawHeight - Height - 2;
                }
                Data.Left = Left;
                Data.Top = Top;
            }
            finally
            {
                IsDataBindings = false;
            }
            Invalidate();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);

            if (IsDataBindings) return;

            if (Left < 0) Left = 0;
            if (Top < 0) Top = 0;

            if (EditSlide.DrawWidth < Left)
            {
                Left = EditSlide.DrawWidth - Width - 2;
            }
            if (EditSlide.DrawHeight < Top)
            {
                Top = EditSlide.DrawHeight - Height - 2;
            }

            Data.Left = Left;
            Data.Top = Top;
        }

        Pen BoxPen = new Pen(Color.OrangeRed, 3f);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Data.NumberIsTextViewMode)
            {
                string txt = ("" + Data?.Text);

                Rectangle rct = Rectangle.FromLTRB(
                        DisplayRectangle.Left, 
                        DisplayRectangle.Top,
                        DisplayRectangle.Right -1,
                        DisplayRectangle.Bottom -1
                    );

                e.Graphics.DrawRectangle(BoxPen, rct);
                TextRenderer.DrawText(e.Graphics, txt, Font, ClientRectangle, Color.OrangeRed, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
            else
            {
                string txt = ("" + Data?.Number);
                TextRenderer.DrawText(e.Graphics, txt, Font, ClientRectangle, ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
        }

        private void NumberMemo_VisibleChanged(object sender, EventArgs e)
        {
            Data.UseNumber = Visible;
            StateChanged?.Invoke();
        }

        bool isDown = false;
        Point pt;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            isDown = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isDown = true;
                pt = e.Location;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isDown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (isDown)
            {
                this.Left += e.Location.X - pt.X;
                this.Top += e.Location.Y - pt.Y;
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            Data.NumberIsTextViewMode = !Data.NumberIsTextViewMode;
            StateChanged?.Invoke();

            if (Data.NumberIsTextViewMode)
            {
                this.MaximumSize = new Size(0, 0);
                SizeF sz = TextRenderer.MeasureText(Data.Text, Font);
                if (sz.Width < 150)
                {
                    this.Width = 150;
                }
                else
                {
                    this.Width = (int)sz.Width;
                }
                this.Height = ResizeTextBoxHight();
                this.MaximumSize = new Size(this.Width, this.Height);
                BackColor = Color.FromArgb(100, Color.White);
            }
            else
            {
                this.MaximumSize = new Size(19, 19);
                this.Width = 19;
                this.Height = 19;
                BackColor = Color.OrangeRed;
            }
            Invalidate();
        }

        private int ResizeTextBoxHight()
        {
            int basicHeight = 24;
            int h = TextRenderer.MeasureText(Data.Text, Font).Height + 6;
            if (h < basicHeight)
            {
                h = basicHeight + 6;//padding 2더하고 보더값 상하 1씩 (=2) 인가보다
            }
            return h;
        }
    }
}
