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
    public partial class FkCalendar : UserControl, IFkData
    {
        Popup Editor = null;
        EditorFkCalendar CalendarEditor = null;

        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkCalendar).FullName,
            Text = $"YYYY_MM_DD",
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

        public FkCalendar()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Editor = new Popup(CalendarEditor = new EditorFkCalendar());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = CalendarEditor;
            ied.DataFlush();
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = CalendarEditor;
            ied.SetData(Data);
        }

        Font Fnt = new Font("굴림체", 8f);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle codeRect = Rectangle.FromLTRB(
                DisplayRectangle.Left,
                DisplayRectangle.Top,
                70,
                DisplayRectangle.Bottom);

            Rectangle searchBtnRect = Rectangle.FromLTRB(
              DisplayRectangle.Left + 70,
              DisplayRectangle.Top - 1,
              DisplayRectangle.Left + 70 + 30,
              DisplayRectangle.Bottom + 1);

            Rectangle imgBtnRect = Rectangle.FromLTRB(
             DisplayRectangle.Left + 70 + 7,
             DisplayRectangle.Top - 1 + 6,
             DisplayRectangle.Left + 70 + 30 - 7,
             DisplayRectangle.Bottom + 1 - 6);

            string txt = (Data?.Text ?? "");
            TextBoxRenderer.DrawTextBox(e.Graphics, codeRect, System.Windows.Forms.VisualStyles.TextBoxState.Normal );
            TextRenderer.DrawText(e.Graphics, $"{txt}", Fnt, codeRect, ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
             
            ButtonRenderer.DrawButton(e.Graphics, searchBtnRect, System.Windows.Forms.VisualStyles.PushButtonState.Normal);

            e.Graphics.DrawImage(Resources.calendar, imgBtnRect);
            //TextRenderer.DrawText(e.Graphics, "▒", Font, searchBtnRect, ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            
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
