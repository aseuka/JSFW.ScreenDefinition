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
    public partial class FkComboBox : UserControl, IFkData
    {
        Popup Editor = null;
        EditorFkComboBox ComboBoxEditor = null;

        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkComboBox).FullName,
            Text = "콤보",
            Visible = true,
            Left = 0,
            Top = 0,
            Width = 100,
            Height = 27,
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

        public FkComboBox()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Editor = new Popup(ComboBoxEditor = new EditorFkComboBox());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = ComboBoxEditor;
            ied.DataFlush();
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = ComboBoxEditor;
            ied.SetData(Data);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle textRect = Rectangle.FromLTRB(
                DisplayRectangle.Left + Margin.Left,
                DisplayRectangle.Top + Margin.Top,
                (DisplayRectangle.Right - Margin.Right) - 22,
                DisplayRectangle.Bottom - Margin.Bottom);

            Rectangle dropbuttonRect = Rectangle.FromLTRB(
               (DisplayRectangle.Right + Margin.Left) - 22,
               DisplayRectangle.Top + Margin.Top,
               DisplayRectangle.Right - Margin.Right,
               DisplayRectangle.Bottom - Margin.Bottom);

            TextBoxRenderer.DrawTextBox(e.Graphics, DisplayRectangle, System.Windows.Forms.VisualStyles.TextBoxState.Normal);

            string txt = ("" + Data?.Text);
            Color foreClr = ForeColor;
            if (!string.IsNullOrWhiteSpace(txt))
            {
                TextRenderer.DrawText(e.Graphics, txt, Font, textRect, foreClr, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
            ComboBoxRenderer.DrawDropDownButton(e.Graphics, dropbuttonRect, System.Windows.Forms.VisualStyles.ComboBoxState.Normal);
             
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
