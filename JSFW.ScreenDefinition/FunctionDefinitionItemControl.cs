using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW
{
    public partial class FunctionDefinitionItemControl : UserControl
    {
        public bool IsDelete { get => chkDel.Checked; set => chkDel.Checked = value; }
         
        public int OrderNo { get; set; } = 0;

        /// <summary>
        /// 컨텐츠 잘라서 아래로 분리한다. 
        /// </summary>
        public event EventHandler<SplitContentEventArgs> SplitContentEvent = null;

        public event EventHandler ContentsChanged = null;
        

        public override string Text
        {
            get
            {
                return txtContent.Text;
            }

            set
            {
                txtContent.Text = value.Trim();
            }
        }

        public bool IsConfirm
        {
            get => chkConfirm.Checked; set => chkConfirm.Checked = value;
        }

        public FunctionDefinitionItemControl()
        {
            InitializeComponent();
            UseDelete(false);
        }

        bool isCancel = false;
        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            if (isCancel) return;
            CalcHeight();
            ContentsChanged?.Invoke(txtContent, e);
        }

        void CalcHeight()
        {
            int h = TextRenderer.MeasureText(txtContent.Text, txtContent.Font).Height + 8;
            if (32 < h)
            {
                this.Height = h;
            }
            else
            {
                this.Height = (29 + 3);
            }
        }

        private void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && e.Control)
            {
                // 내용을 잘라. 분리한다. 
                Dictionary<int, string> split = new Dictionary<int, string>();
                string a1 = txtContent.Text.Substring(txtContent.SelectionStart + txtContent.SelectionLength, txtContent.TextLength - (txtContent.SelectionStart + txtContent.SelectionLength)).Trim();
                if (string.IsNullOrEmpty(a1) == false) split.Add(1, a1);
                string a2 = txtContent.Text.Substring(0, txtContent.SelectionStart).Trim();
                if (string.IsNullOrEmpty(a2) == false) split.Add(-1, a2);
                string a3 = txtContent.Text.Substring(txtContent.SelectionStart, txtContent.SelectionLength).Trim();
                if (string.IsNullOrEmpty(a3) == false) split.Add(0, a3);

                if (2 < split.Count)
                {
                    foreach (var item in split)
                    {
                        if (string.IsNullOrEmpty(item.Value.Trim())) continue;

                        switch (item.Key)
                        {
                            case -1:
                                OnSplitContentEvent(item.Key, item.Value.Trim());
                                break;
                            case 0:
                                try
                                {
                                    isCancel = true;
                                    txtContent.ResetText();
                                    txtContent.Text = item.Value.Trim();
                                }
                                finally
                                {
                                    isCancel = false;
                                }
                                break;
                            case 1:
                                OnSplitContentEvent(item.Key, item.Value.Trim());
                                break;
                        }
                    }                  
                }
                else if (1 < split.Count)
                {
                    foreach (var item in split)
                    {
                        if (string.IsNullOrEmpty(item.Value.Trim())) continue;

                        switch (item.Key)
                        {
                            case -1:
                            case 0:
                                OnSplitContentEvent(-1, item.Value.Trim());
                                break;
                            case 1:
                                try
                                {
                                    isCancel = true;
                                    txtContent.ResetText();
                                    txtContent.Text = item.Value.Trim();
                                }
                                finally
                                {
                                    isCancel = false;
                                }
                                break;
                                //case 1:
                                //    OnSplitContentEvent(item.Key, item.Value.Trim());
                                //    break;
                        }
                    }
                }
                e.Handled = true;
            }
        }

        protected void OnSplitContentEvent(int offsetIndex, string splitContent)
        {
            if (splitContent == null) splitContent = "";

            if (SplitContentEvent != null && string.IsNullOrEmpty(splitContent) == false)
            {
                SplitContentEvent(this, new SplitContentEventArgs(offsetIndex, splitContent));
            }
        }

        public void UseDelete(bool show = false)
        {
            chkDel.Checked = false;
            chkDel.Visible = show;
        }

        private void txtContent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                try
                {
                    isCancel = true;
                    Text = txtContent.Text.Trim();
                    CalcHeight();
                }
                finally
                {
                    isCancel = false;
                }
            }
        }

        private void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (isCancel) return;
            ContentsChanged?.Invoke(txtContent, e);
        }

        public void SetData(int order, string text, bool isConfirm)
        {
            try
            {
                isCancel = true;
                OrderNo = order;
                Text = text;
                IsConfirm = isConfirm;
            }
            finally
            {
                isCancel = false;

            }
        }
    }

    public class SplitContentEventArgs : EventArgs
    {
        public SplitContentEventArgs(int idx, string txt) : base()
        {
            OffsetIndex = idx;
            Text = txt;
        }
        public int OffsetIndex { get; protected set; }
        public string Text { get; protected set; }
    }
}
