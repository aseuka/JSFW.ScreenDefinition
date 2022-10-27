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

namespace JSFW.ScreenDefinition
{
    public partial class SDTopView : UserControl
    {
        Popup pathPopup = null;

        ListView lvMnu = null;

        public string SystemMenuPath { get => txtSystemMenuPath.Text; }

        public string ScreenDesignID { get => txtScreenDesignID.Text; }

        public Action<string> ScreenDesignIDSelected = null;

        public Action ToSave = null;
         
        protected void OnSave()
        {
            ToSave?.Invoke();
        }

        public SDTopView()
        {
            InitializeComponent();
            pathPopup = new Popup(lvMnu = new ListView() { Width = 570, Height = 650, Dock = DockStyle.Fill});
            pathPopup.AutoClose = true;
            pathPopup.Opening += Editor_Opening;
            pathPopup.Closing += Editor_Closing;

            lvMnu.HeaderStyle = ColumnHeaderStyle.None;
            lvMnu.MultiSelect = false;
            lvMnu.FullRowSelect = true;
            lvMnu.View = View.Details;

            var Menus = Ux.LoadFile<List<Mnu>>($"{MainForm.__ROOT_DIR}{MainForm.__MENULIST_FILENAME}");
            if (Menus == null)
            {
                Menus = new List<Mnu>();
            }

            lvMnu.Columns.Clear();
            lvMnu.Columns.Add("ID").Width = 0;
            lvMnu.Columns.Add("Eng").Width = 220;
            lvMnu.Columns.Add("Kor").Width = 330;

            lvMnu.Groups.Clear();
            foreach (var g in Menus.GroupBy(m => m.GroupName))
            {
                lvMnu.Groups.Add(g.Key, g.Key);
            }

            foreach (var m in Menus)
            {
                ListViewGroup g = lvMnu.Groups[m.GroupName];
                ListViewItem item = lvMnu.Items.Add(m.GUID);
                item.Group = g;
                item.SubItems.Add(m.Name);
                item.SubItems.Add(m.Text);
            }

            lvMnu.MouseDoubleClick += LvMnu_MouseDoubleClick;

            this.Disposed += SDTopView_Disposed;
        }

        private void SDTopView_Disposed(object sender, EventArgs e)
        {
            pathPopup?.Dispose();
            lvMnu?.Dispose();
            pathPopup = null;
            lvMnu = null;
        }

        private void LvMnu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hitInfo = lvMnu.HitTest(e.X, e.Y);
            if (hitInfo.Item != null)
            {
                txtSystemMenuPath.Text = (hitInfo.Item.Group?.Header ?? "").Trim();
                txtScreenDesignID.Text = hitInfo.Item.SubItems[1].Text.Trim();
                ScreenDesignIDSelected?.Invoke(hitInfo.Item.SubItems[2].Text.Trim());
                pathPopup.Close(ToolStripDropDownCloseReason.ItemClicked);
            }
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            lvMnu.SelectedItems.Clear();
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            
        }

        bool IsDataBinding = false;
        internal void SetData(ScreenDocumentHeader data)
        {
            if (data == null) return;
            try
            {
                IsDataBinding = true;
                lbDocumentTitle.Text = data.DocumentTitle;
                txtSystemMenuPath.Text = data.SystemMenuPath;
                lbWriteInfo.Text = $"{data.Writer}   {data.UpdateDate}";
                lbVersion.Text = $"{data.Version}";
                txtScreenDesignID.Text = "";
            }
            finally {
                IsDataBinding = false;
            }
        }

        public void SetScreenID(Slide slide)
        {
            
            try
            {
                IsDataBinding = true; 
                txtScreenDesignID.Text = slide?.ScreenDesignID;
            }
            finally
            {
                IsDataBinding = false;
            }
        }

        internal void SetSystemMenuPath(string path)
        {
            try
            {
                IsDataBinding = true;
                txtSystemMenuPath.Text = path;
            }
            finally
            {
                IsDataBinding = false;
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void lbDocumentTitle_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSystemMenuPath_TextChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            SetReadOnlyProperty();
            OnSave();
        }

        private void txtSystemMenuPath_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.F2)
            {
                txtSystemMenuPath.ReadOnly = false;
                pathPopup.Show(txtSystemMenuPath);
                SetReadOnlyProperty();
            }
        } 

        int delayTime = 3 * 1000; // 3초
        bool IsEditLock = false;
        private void SetReadOnlyProperty()
        {
            delayTime = 3 * 1000;
            if (IsEditLock == false)
            {
                IsEditLock = true;
                Ux.AsyncCall(() => SetReadOnly());
            }
        }
        private void SetReadOnly()
        {
            while (0 < delayTime)
            {
                System.Threading.Thread.Sleep(200);
                delayTime -= 200;
            }
            this.DoInvoke(fm =>
            {
                txtSystemMenuPath.ReadOnly = true;
                pathPopup?.Close(ToolStripDropDownCloseReason.AppFocusChange);
            });
            IsEditLock = false;
        }

        private void txtScreenID_TextChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return; 

            OnSave();
        }

        private void txtScreenID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtScreenDesignID.ReadOnly = false;
                txtScreenDesignID.Focus();
                pathPopup.Show(txtScreenDesignID);
            }
        }

        private void txtScreenID_Leave(object sender, EventArgs e)
        {
            txtScreenDesignID.ReadOnly = true;
            pathPopup?.Close( ToolStripDropDownCloseReason.AppFocusChange );
        }
          
        private void txtSystemMenuPath_Click(object sender, EventArgs e)
        {
            if (txtSystemMenuPath.ReadOnly == false)
            {
                pathPopup.Show(txtSystemMenuPath);
            }
        }

        private void txtScreenDesignID_Click(object sender, EventArgs e)
        {
            if (txtScreenDesignID.ReadOnly == false)
            {
                pathPopup.Show(txtScreenDesignID);
            }
        }
    }
}
