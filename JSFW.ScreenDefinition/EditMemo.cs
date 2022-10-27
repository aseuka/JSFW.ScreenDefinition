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
    public partial class EditMemo : UserControl
    {
        bool IsDataBinding = false;
        public Memo Data { get; internal set; }

        public bool IsDelete { get => chkDel.Checked; set => chkDel.Checked = value; }

        public Action ToSave = null;
         
        public Action<Memo> ToDelNumber = null;

        public void DelNumber()
        {
            ToDelNumber?.Invoke(Data);
        }

        protected void OnSave()
        {
            ToSave?.Invoke(); 
        }

        public EditMemo()
        {
            InitializeComponent();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            txtMemo.Focus();
        }

        public void SetData(Memo data)
        {
            Data = data;
            try
            {
                IsDataBinding = true;
                txtMemo.Text = Data.Text;
                lbNumber.Text = $"{Data.Number}";
                if (Data.UseNumber)
                {
                    lbNumber.ForeColor = Color.White;
                }
                else
                {
                    lbNumber.ForeColor = Color.LightGray;
                }
            }
            finally
            {
                IsDataBinding = false; 
            }
        }

        public void UseDelete(bool show = false)
        {
            chkDel.Checked = false;
            chkDel.Visible = show;
            lbNumber.Visible = !show;
        }

        private void txtMemo_TextChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            Data.Text = txtMemo.Text;
            OnSave();
        }

        internal void SetNumber(int idx)
        {
            Data.Number = idx;
        }

        bool isMv = false;
        Point pt;
        private void lbNumber_MouseDown(object sender, MouseEventArgs e)
        {
            isMv = e.Button == MouseButtons.Left && !Data.UseNumber;
            pt = e.Location; 
        }

        private void lbNumber_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMv)
            {
                int x = e.Location.X - pt.X;
                int y = e.Location.Y - pt.Y;
                int z = (int)Math.Sqrt(Math.Pow((double)Math.Abs(x), 2d) + Math.Pow((double)Math.Abs(y), 2d));

                if (4 < z)
                {
                    DoDragDrop(Data, DragDropEffects.Link);
                    if (Data.UseNumber)
                    {
                        isMv = false;
                        lbNumber.ForeColor = Color.White;
                    }
                    else
                    {
                        lbNumber.ForeColor = Color.LightGray;
                    }
                }
            }
        }

        private void lbNumber_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isMv = false;
        }

        private void lbNumber_DoubleClick(object sender, EventArgs e)
        {
            if (Data.UseNumber)
            {
                // 삭제 처리
                DelNumber();

                if (Data.UseNumber)
                {
                    lbNumber.ForeColor = Color.White;
                }
                else
                {
                    lbNumber.ForeColor = Color.LightGray;
                }
            }
        }
    }
}
