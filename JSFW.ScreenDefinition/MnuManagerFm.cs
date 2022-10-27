using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.ScreenDefinition
{
    public partial class MnuManagerFm : Form
    {
        List<Mnu> Menus { get; set; }

        public List<Mnu> MnuSelected { get; private set; } = new List<Mnu>();

        public bool HasCheckBoxs { get => lvMnu.CheckBoxes; set => lvMnu.CheckBoxes = value; }

        DialogResult dr = DialogResult.None;

        public MnuManagerFm()
        {
            IsDataBinding = true;

            InitializeComponent();

            Menus = Ux.LoadFile<List<Mnu>>($"{MainForm.__ROOT_DIR}{MainForm.__MENULIST_FILENAME}");
            if (Menus == null)
            {
                Menus = new List<Mnu>();
            }

            //Menus.Add(new Mnu() { GroupName = "경비", Name = "M01", Text = "경비 메뉴001" });
            //Menus.Add(new Mnu() { GroupName = "경비", Name = "M02", Text = "경비 메뉴002" });
            //Menus.Add(new Mnu() { GroupName = "경비", Name = "M03", Text = "경비 메뉴003" });

            //Menus.Add(new Mnu() { GroupName = "공통", Name = "G01", Text = "공통 메뉴001" });
            //Menus.Add(new Mnu() { GroupName = "공통", Name = "G02", Text = "공통 메뉴001" });

            lvMnu.Columns.Clear();
            lvMnu.Columns.Add("ID").Width = 0;
            lvMnu.Columns.Add("Eng").Width = 220;
            lvMnu.Columns.Add("Kor").Width = 330;

            lvMnu.Groups.Clear();
            foreach (var g in Menus.GroupBy(m => m.GroupName))
            {
                lvMnu.Groups.Add( g.Key, g.Key);
            }

            foreach (var m in Menus)
            {
                ListViewGroup g = lvMnu.Groups[m.GroupName];
                ListViewItem item = lvMnu.Items.Add(m.GUID);
                item.Group = g;
                item.SubItems.Add(m.Name);
                item.SubItems.Add(m.Text);
                item.Tag = m;
            }
        }

        bool IsDataBinding = false;
        internal void SetMenus(List<Mnu> menus)
        {
            try
            {
                lvMnu.Columns[0].Width = 18;//ID
                foreach (var mnu in menus)
                {
                    foreach (ListViewItem lvItem in lvMnu.Items)
                    {
                        if (lvItem.Text == mnu.GUID)
                        {
                            lvItem.Checked = true;
                        }
                    }
                }
            }
            finally
            {
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            IsDataBinding = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            DialogResult = dr;
            foreach (ListViewItem item in lvMnu.Items)
            {
                if (item.Checked)
                {
                    MnuSelected.Add(item.Tag as Mnu);
                    DialogResult = DialogResult.OK;
                }
                item.Tag = null;
            }

            if (DialogResult == DialogResult.None)
            {
                DialogResult = DialogResult.Cancel;
            }
            Ux.SaveFile<List<Mnu>>(Menus, $"{MainForm.__ROOT_DIR}{MainForm.__MENULIST_FILENAME}");
        }

        private void lvMnu_MouseDown(object sender, MouseEventArgs e)
        {
            var hitInfo = lvMnu.HitTest(e.Location);

            try
            {
                IsDataBinding = true;

                txtGroupName.Text = "";
                lbGUID.Text = "";
                txtEng.Text = "";
                txtKor.Text = "";

                if (hitInfo.Item == null)//그룹
                {
                    if (!chkNew.Checked) return;

                    ListViewItem currentItem = null;
                    int pt_X = e.X + 5;
                    int pt_Y = e.Y + 5;
                    do
                    {
                        currentItem = lvMnu.GetItemAt(pt_X, pt_Y);
                        pt_X += 5; pt_Y += 5;
                        if (lvMnu.Height < pt_Y) break;
                    } while (currentItem == null);

                    if (currentItem == null) return;

                    bool isEdit = IsEditLock;
                    IsEditLock = true;
                    txtGroupName.Text = currentItem.Group.Header;
                    IsEditLock = isEdit;
                    if (chkNew.Checked)
                    {
                        txtEng.Focus();
                        return;
                    }

                    lbGUID.Text = "";
                    txtEng.Text = "";
                    txtKor.Text = "";
                }
                else
                {
                    bool isEdit = IsEditLock;
                    ListViewItem currentItem = hitInfo.Item;
                    IsEditLock = true;

                    if (currentItem.Group != null)
                    {
                        txtGroupName.Text = currentItem.Group.Header;
                    }
                    IsEditLock = isEdit;
                    if (chkNew.Checked)
                    {
                        txtEng.Focus();
                        return;
                    }

                    if (IsEditLock)
                    {
                        delayTime = 0;
                        SetReadOnly();
                    }
                    txtGroupName.ReadOnly = true;
                    txtEng.ReadOnly = true;
                    txtKor.ReadOnly = true;

                    lbGUID.Text = currentItem.Text;
                    txtEng.Text = currentItem.SubItems[1].Text;
                    txtKor.Text = currentItem.SubItems[2].Text;
                }
            }
            finally {
                IsDataBinding = false;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //삭제
            if (0 < lvMnu.SelectedItems.Count &&
                MessageBox.Show("삭제?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                IsDataBinding = true;

                txtGroupName.Text = "";
                lbGUID.Text = "";
                txtEng.Text = "";
                txtKor.Text = "";

                if (IsEditLock)
                {
                    delayTime = 0;
                    SetReadOnly();
                }
                txtGroupName.ReadOnly = true;
                txtEng.ReadOnly = true;
                txtKor.ReadOnly = true;

                for (int loop = lvMnu.SelectedItems.Count - 1; loop >= 0; loop--)
                {
                    ListViewItem item = lvMnu.SelectedItems[loop];
                    Mnu mnu = item.Tag as Mnu;
                    if (mnu != null && Menus.Contains(mnu))
                    {
                        Menus?.Remove(mnu);
                        dr = DialogResult.OK;
                    }
                    lvMnu.Items.Remove(item);
                    item.Tag = null;
                }

                for (int loop = lvMnu.Groups.Count - 1; loop >= 0; loop--)
                {
                    if (lvMnu.Groups[loop].Items.Count <= 0)
                    {
                        lvMnu.Groups.RemoveAt(loop);
                    }
                }
            }
            finally
            {
                IsDataBinding = false;
            }
        }

        bool isInput = false;
        private void chkNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNew.Checked)
            {
                if (isInput) return;

                lbGUID.Text = "";
                txtGroupName.Text = "";
                txtEng.Text = "";
                txtKor.Text = "";

                if (IsEditLock)
                {
                    delayTime = 0;
                    SetReadOnly();
                }
                txtGroupName.ReadOnly = false;
                txtEng.ReadOnly = false;
                txtKor.ReadOnly = false;
                isInput = true;
                lvMnu.SelectedItems.Clear();

                txtGroupName.Focus();
            }
            else
            {
                if (isCancel) return;

                if (string.IsNullOrWhiteSpace(txtEng.Text))
                {
                    MessageBox.Show("메뉴(ENG)필요");
                    chkNew.Checked = isInput;
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtKor.Text))
                {
                    MessageBox.Show("메뉴(Kor)필요");
                    chkNew.Checked = isInput;
                    return;
                }
                AddMnu(txtGroupName.Text.Trim(), txtEng.Text.Trim(), txtKor.Text.Trim());
                if (IsEditLock)
                {
                    delayTime = 0;
                    SetReadOnly();
                }
                isInput = false;
            }
        }

        private void AddMnu(string groupName, string mnuEng, string mnuKor)
        {
            ListViewGroup group = null;
            foreach (ListViewGroup g in lvMnu.Groups)
            {
                if (groupName == g.Header)
                {
                    group = g;
                    break;
                }
            }

            Mnu newMnu = new Mnu() { GroupName = groupName, Name = mnuEng, Text = mnuKor };
            Menus.Add(newMnu); dr = DialogResult.OK;

            if (!string.IsNullOrWhiteSpace(groupName) && group == null)
            {
               group = lvMnu.Groups.Add(groupName, groupName);
            }
            ListViewItem item = lvMnu.Items.Add(newMnu.GUID);
            item.Group = group;
            item.SubItems.Add(newMnu.Name);
            item.SubItems.Add(newMnu.Text);
            item.Tag = newMnu;
            lvMnu.Refresh();
        }

        bool isCancel = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lvMnu.SelectedItems.Clear();
                isCancel = true;
                isInput = false;
                chkNew.Checked = false;

                txtGroupName.Text = "";
                lbGUID.Text = "";
                txtEng.Text = "";
                txtKor.Text = "";

                if (IsEditLock)
                {
                    delayTime = 0;
                    SetReadOnly();
                }
                txtGroupName.ReadOnly = true;
                txtEng.ReadOnly = true;
                txtKor.ReadOnly = true;
            }
            finally
            {
                isCancel = false;
            }
        }

        private void txtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            { 
                txtGroupName.ReadOnly = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void txtEng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtEng.ReadOnly = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void txtKor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtKor.ReadOnly = false;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (chkNew.Checked)
                {
                    chkNew.Checked = false;
                }
            }
        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {
            if (isCancel) return;
            if (isInput) return;
            if (IsDataBinding) return;

            SetReadOnlyProperty();
        }

        private void txtEng_TextChanged(object sender, EventArgs e)
        {
            if (isCancel) return;
            if (isInput) return;
            if (IsDataBinding) return;
            
            SetReadOnlyProperty();
        }

        private void txtKor_TextChanged(object sender, EventArgs e)
        {
            if (isCancel) return;
            if (isInput) return;
            if (IsDataBinding) return;

            SetReadOnlyProperty();
        }

        int delayTime = 3 * 1000; // 3초
        bool IsEditLock = false;
        private void SetReadOnlyProperty()
        {
            if (chkNew.Checked) return;

            delayTime = 3 * 1000;
            if (IsEditLock == false)
            {
                IsEditLock = true;
                Ux.AsyncCall(SetReadOnly);
            }
        }

        private void SetReadOnly()
        {
            while (0 < delayTime)
            {
                System.Threading.Thread.Sleep(100);
                delayTime -= 100;
            }

            this.DoInvoke(fm =>
            {
                txtGroupName.ReadOnly = true;
                txtEng.ReadOnly = true;
                txtKor.ReadOnly = true;
                if (!string.IsNullOrWhiteSpace(lbGUID.Text))
                {
                    Mnu editMnu = Menus.FirstOrDefault(f => f.GUID.Trim() == lbGUID.Text.Trim());
                    if (editMnu == null) return;

                    bool changeGroup = false;
                    bool changeEng = false;
                    bool changeKor = false;

                    if (editMnu.GroupName.Trim() != txtGroupName.Text.Trim())
                    {
                        changeGroup = true;
                        dr = DialogResult.OK;
                    }

                    if (editMnu.Name.Trim() != txtEng.Text.Trim())
                    {
                        changeEng = true;
                        dr = DialogResult.OK;
                    }

                    if (editMnu.Text.Trim() != txtKor.Text.Trim())
                    {
                        changeKor = true;
                        dr = DialogResult.OK;
                    }

                    editMnu.GroupName = txtGroupName.Text.Trim();
                    editMnu.Name = txtEng.Text.Trim();
                    editMnu.Text = txtKor.Text.Trim();
                     
                    if (changeGroup || changeEng || changeKor)
                    {
                        foreach (ListViewItem lvItem in lvMnu.Items)
                        {
                            if (lvItem.Text == lbGUID.Text)
                            {
                                lvItem.Group = lvMnu.Groups[editMnu.GroupName];
                                lvItem.SubItems[1].Text = editMnu.Name;
                                lvItem.SubItems[2].Text = editMnu.Text;
                                break;
                            }
                        }
                    }
                }
            });
            IsEditLock = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        readonly int __MAX_WIDTH = 1250;
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            Screen currentScreen = Screen.FromControl(this);
            this.MaximumSize = new Size(__MAX_WIDTH, (int)(currentScreen.WorkingArea.Height * 0.9) + 16);
        }

        private void lvMnu_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (IsDataBinding) return;

            dr = DialogResult.OK;
        }

        private void txtEng_Leave(object sender, EventArgs e)
        {
            delayTime = 0;            
        } 

        private void txtGroupName_Leave(object sender, EventArgs e)
        {
            delayTime = 0;
        }

        private void txtKor_Leave(object sender, EventArgs e)
        {
            delayTime = 0;
        }

        string oldMenuSearch = "aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbcccccccccccccccddddddddddddddeeeeeeeeeee";
        int oldMenuSearchIndex = -1;
        private void btnMenuSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtMenuSearch.Text.Trim().ToUpper();

            if (oldMenuSearch != searchText)
            {
                oldMenuSearchIndex = 0;
            }
            bool isFinded = false;
            int idx = -1;

            foreach (ListViewItem item in lvMnu.Items)
            {
                idx++;
                if (idx < (oldMenuSearchIndex + 1)) continue;

                Mnu mnu = item.Tag as Mnu;
                if (mnu != null)
                {
                    if (mnu.Name.ToUpper().Contains(searchText) || mnu.Text.ToUpper().Contains(searchText))
                    {
                        isFinded = true;
                        oldMenuSearchIndex = idx;
                        oldMenuSearch = searchText;

                        lvMnu.SelectedIndices.Clear();
                        item.Selected = true;
                        item.EnsureVisible();
                        break;
                    }
                }
            }

            if (isFinded)
            {
                return;
            }
            else
            {
                oldMenuSearch = "aaaaaaaaaaaaaabbbbbbbbbbbbbbbbbcccccccccccccccddddddddddddddeeeeeeeeeee";
                oldMenuSearchIndex = 0;
            }
        }

        private void txtMenuSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnMenuSearch.PerformClick();
            }
        }

        private void txtMenuSearch_TextChanged(object sender, EventArgs e)
        {
            oldMenuSearch = "";
        }
    }


    public class Mnu
    {
        public string GUID { get; set; }

        public Mnu()
        {
            GUID = Guid.NewGuid().ToString("N");
        }

        public string GroupName { get; set; }

        public string Name { get; set; } 

        public string Text { get; set; }
    }
}
