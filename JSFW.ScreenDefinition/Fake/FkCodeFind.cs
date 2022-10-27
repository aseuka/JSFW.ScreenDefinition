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
    public partial class FkCodeFind : UserControl, IFkData
    {
        Popup Editor = null;
        EditorFkCodeFind CodeFindEditor = null;

        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkCodeFind).FullName,
            Text = "",
            Visible = true,
            Left = 0,
            Top = 0,
            Width = 150,
            Height = 25,
            IsCodeFind = true,
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

        public FkCodeFind()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Editor = new Popup(CodeFindEditor = new EditorFkCodeFind());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = CodeFindEditor;
            ied.DataFlush();
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = CodeFindEditor;
            ied.SetData(Data);
        }

        Font Fnt = new Font("굴림체", 9F, FontStyle.Bold);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle codeRect = Rectangle.FromLTRB(
                DisplayRectangle.Left,
                DisplayRectangle.Top,
                67,
                DisplayRectangle.Bottom);

            Rectangle searchBtnRect = Rectangle.FromLTRB(
              DisplayRectangle.Left + 67,
              DisplayRectangle.Top - 1,
              DisplayRectangle.Left + 67 + 33,
              DisplayRectangle.Bottom + 1);

            Rectangle descRect = Rectangle.FromLTRB(
                DisplayRectangle.Left + 67 + 33,
                DisplayRectangle.Top,
                (DisplayRectangle.Right),
                DisplayRectangle.Bottom);

            TextBoxRenderer.DrawTextBox(e.Graphics, codeRect, System.Windows.Forms.VisualStyles.TextBoxState.Normal );
            ButtonRenderer.DrawButton(e.Graphics, searchBtnRect, System.Windows.Forms.VisualStyles.PushButtonState.Normal);
            TextBoxRenderer.DrawTextBox(e.Graphics, descRect, System.Windows.Forms.VisualStyles.TextBoxState.Normal);

            if (Data?.IsCodeFind ?? true)
            {
                TextRenderer.DrawText(e.Graphics, "검색", Fnt, searchBtnRect, ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
            else
            {
                searchBtnRect = Rectangle.FromLTRB(
                      DisplayRectangle.Left + 72,
                      DisplayRectangle.Top - 1,
                      DisplayRectangle.Left + 67 + 28,
                      DisplayRectangle.Bottom + 1);

                e.Graphics.DrawImage(Resources.Post, searchBtnRect);
            }
            TextRenderer.DrawText(e.Graphics, ( Data?.Text ?? ""), Fnt, codeRect, Color.Coral, TextFormatFlags.VerticalCenter );

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
