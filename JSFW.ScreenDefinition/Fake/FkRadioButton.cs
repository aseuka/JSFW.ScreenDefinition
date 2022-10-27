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

namespace JSFW.Fake
{
    public partial class FkRadioButton : UserControl, IFkData
    {
        Popup Editor = null;
        EditorFkCheck CheckEditor = null;

        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkRadioButton).FullName,
            Text = "라디오버튼",
            Checked = false,
            Visible = true,
            Left = 0,
            Top = 0,
            Width = 25,
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

        public FkRadioButton()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Editor = new Popup(CheckEditor = new EditorFkCheck());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = CheckEditor;
            ied.DataFlush();
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = CheckEditor;
            ied.SetData(Data);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle textRect = Rectangle.FromLTRB(
                DisplayRectangle.Left + Margin.Left + 16,
                DisplayRectangle.Top + Margin.Top,
                DisplayRectangle.Right - Margin.Right,
                DisplayRectangle.Bottom - Margin.Bottom);

            Point pt = new Point(DisplayRectangle.Left + Margin.Left + 1,
                                 DisplayRectangle.Top + Margin.Top + 3);

            ControlPaint.DrawBorder(e.Graphics, DisplayRectangle, Color.Gray, ButtonBorderStyle.Dashed);

            RadioButtonRenderer.DrawRadioButton(e.Graphics, pt,
                (Data?.Checked ?? false) ?
                System.Windows.Forms.VisualStyles.RadioButtonState.CheckedNormal : System.Windows.Forms.VisualStyles.RadioButtonState.UncheckedNormal);

            string txt = ("" + Data?.Text);
            Color foreClr = ForeColor;
            if (!string.IsNullOrWhiteSpace(txt))
            {
                TextRenderer.DrawText(e.Graphics, txt, Font, textRect,
                    foreClr, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
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
