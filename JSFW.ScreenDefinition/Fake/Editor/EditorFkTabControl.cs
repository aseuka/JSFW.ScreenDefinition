using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Fake.Editor
{
    public partial class EditorFkTabControl : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = null;

        public EditorFkTabControl()
        {
            InitializeComponent();
            this.Disposed += EditorFkTabControl_Disposed;
        }

        private void EditorFkTabControl_Disposed(object sender, EventArgs e)
        {
            this.Data = null;
        }

        void IFkData.SetData(FkData data)
        {
            Data = data;
            if (Data != null)
            {
                try
                {
                    chkTabVisible.Checked = Data.Visible;
                    pnlTabPageList.SuspendLayout();

                    for (int loop = pnlTabPageList.Controls.Count - 1; loop >= 0; loop--)
                    {
                        using (pnlTabPageList.Controls[loop])
                        {
                            pnlTabPageList.Controls[loop].Tag = null;
                            pnlTabPageList.Controls[loop].Click -= LbTabPage_Click;
                            pnlTabPageList.Controls.RemoveAt(loop);
                        }
                    }

                    foreach (var tp in Data.Childs)
                    {
                        JSFW.Label lbTabPage = new Label();
                        lbTabPage.Tag = tp;
                        lbTabPage.AutoSize = false;
                        lbTabPage.BackColor = Color.White;
                        lbTabPage.Text = tp.Text;
                        if (string.IsNullOrWhiteSpace(lbTabPage.Text))
                        {
                            lbTabPage.Text = "미지정";
                        }
                        pnlTabPageList.Controls.Add(lbTabPage);
                        lbTabPage.Dock = DockStyle.Top;
                        lbTabPage.BringToFront();
                        lbTabPage.Click += LbTabPage_Click;
                    }
                }
                finally {
                    pnlTabPageList.ResumeLayout(false);
                }

            }
        }

        JSFW.Label CurrentTabPage = null;

        private void LbTabPage_Click(object sender, EventArgs e)
        {
            SetCurrentTabPage(sender as JSFW.Label);
        }

        private void SetCurrentTabPage(Label lb)
        {
            if (CurrentTabPage == lb) return;

            if (CurrentTabPage != null)
            {
                CurrentTabPage.ForeColor = Color.Black;
                CurrentTabPage.BackColor = Color.White;
                GetTabPageInfo();
            } 

            CurrentTabPage = lb;
 
            if (CurrentTabPage != null)
            {
                CurrentTabPage.ForeColor = Color.White;
                CurrentTabPage.BackColor = Color.DodgerBlue; 
            }
            SetTabPageInfo();
        }

        private void GetTabPageInfo()
        {
            FkData data = CurrentTabPage?.Tag as FkData;
            if (data != null)
            {
                data.Text = txtTitle.Text;
                CurrentTabPage.Text = data.Text;
                data.Visible = chkPanelVisible.Checked;

                data.HeaderBackColor = txtTitle.BackColor;
                data.HeaderForeColor = txtTitle.ForeColor;
            }
        }

        private void SetTabPageInfo()
        {
            txtTitle.Text = "";
            chkPanelVisible.Checked = false; 
            FkData data = CurrentTabPage?.Tag as FkData;
            if (data != null)
            {
                txtTitle.Text = data.Text;
                chkPanelVisible.Checked = data.Visible;

                txtTitle.BackColor = data.HeaderBackColor;
                txtTitle.ForeColor = data.HeaderForeColor;

                txtTitle.Focus();
                txtTitle.SelectAll();
            }
        }

        void IFkData.DataFlush()
        {
            Data.Visible = chkTabVisible.Checked;

            List<FkData> tabs = new List<FkData>();

            SetCurrentTabPage(null);

            foreach (JSFW.Label lb in pnlTabPageList.Controls)
            {
                FkData _data = lb.Tag as FkData;
                if (_data != null)
                {
                    tabs.Add(_data.Clone() as FkData);
                }
            }
            tabs.Reverse();
            Data.Childs.Clear();
            Data.Childs.AddRange(tabs); 
        }

        private void rdoWhiteBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWhiteBlack.Checked)
            {
                txtTitle.ForeColor = rdoWhiteBlack.ForeColor;
                txtTitle.BackColor = rdoWhiteBlack.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoBlackWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBlackWhite.Checked)
            {
                txtTitle.ForeColor = rdoBlackWhite.ForeColor;
                txtTitle.BackColor = rdoBlackWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoCoralWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCoralWhite.Checked)
            {
                txtTitle.ForeColor = rdoCoralWhite.ForeColor;
                txtTitle.BackColor = rdoCoralWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoOrangeRedWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOrangeRedWhite.Checked)
            {
                txtTitle.ForeColor = rdoOrangeRedWhite.ForeColor;
                txtTitle.BackColor = rdoOrangeRedWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoDeepSkyBlueWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDeepSkyBlueWhite.Checked)
            {
                txtTitle.ForeColor = rdoDeepSkyBlueWhite.ForeColor;
                txtTitle.BackColor = rdoDeepSkyBlueWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoDodgerBlueWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDodgerBlueWhite.Checked)
            {
                txtTitle.ForeColor = rdoDodgerBlueWhite.ForeColor;
                txtTitle.BackColor = rdoDodgerBlueWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void rdoGrayWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGrayWhite.Checked)
            {
                txtTitle.ForeColor = rdoGrayWhite.ForeColor;
                txtTitle.BackColor = rdoGrayWhite.FlatAppearance.CheckedBackColor;
            }
        }

        private void btnAddTabPage_Click(object sender, EventArgs e)
        {
            // 추가.
            SetCurrentTabPage(null);
            FkData tabInfo = new FkData()
            {
                TypeName = typeof(FkTabPage).FullName,
                Text = "탭 페이지",
                Visible = true,
                Left = 0,
                Top = 0,
                Width = 150,
                Height = 70,
                HeaderBackColor = txtTitle.BackColor,
                HeaderForeColor = txtTitle.ForeColor
            };

            JSFW.Label lbTabPage = new Label();
            lbTabPage.Tag = tabInfo;
            lbTabPage.AutoSize = false;
            lbTabPage.BackColor = Color.White;
            lbTabPage.Text = tabInfo.Text;
            if (string.IsNullOrWhiteSpace(lbTabPage.Text))
            {
                lbTabPage.Text = "미지정";
            }
            pnlTabPageList.Controls.Add(lbTabPage);
            lbTabPage.Dock = DockStyle.Top;
            lbTabPage.BringToFront();
            lbTabPage.Click += LbTabPage_Click;
            SetCurrentTabPage(lbTabPage);
        }

        private void btnDelTabPage_Click(object sender, EventArgs e)
        {
            // 삭제
            if (CurrentTabPage == null)
            {
                "삭제할 대상 탭 페이지를 선택".Alert();
                return;
            }

            if ("탭 삭제?".Confirm() == DialogResult.No) return;

            SetCurrentTabPage(null);
            using (CurrentTabPage)
            {
                pnlTabPageList.Controls.Remove(CurrentTabPage);
                CurrentTabPage.Click -= LbTabPage_Click;
                FkData data = CurrentTabPage.Tag as FkData;
                if (data != null)
                {
                    Data.Childs.Remove(data);
                }
                CurrentTabPage.Tag = null;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        { 
            if (CurrentTabPage == null) return;

            int idx = pnlTabPageList.Controls.IndexOf(CurrentTabPage);

            if (pnlTabPageList.Controls.Count <= (idx + 1)) return;
            pnlTabPageList.Controls.SetChildIndex(CurrentTabPage, idx + 1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (CurrentTabPage == null) return;

            int idx = pnlTabPageList.Controls.IndexOf(CurrentTabPage);

            if ((idx - 1) < 0) return;
            pnlTabPageList.Controls.SetChildIndex(CurrentTabPage, idx - 1); 
        }

        void IFkData.ShowEdit()
        {
        }
    }
}
