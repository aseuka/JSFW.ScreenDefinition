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
    public partial class NewSD : Form
    {
        public string Title { get; private set; }

        public string SystemMenuPath { get; private set; }

        public string Writer { get; private set; } = "나";

        public decimal Version { get; private set; } = 1.0m;

        public decimal OldVersion { get; private set; } = 1.0m;

        public NewSD()
        {
            InitializeComponent();
        }

        public NewSD(bool IsNew = true) : this()
        {
            if (IsNew)
            {
                Text = "새 화면정의서 등록";
            }
            else
            {
                Text = "화면정의서 제목 수정";
                txtWriter.ReadOnly = true;
                txtVersion.ReadOnly = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("화면정의서 제목이 필수임.");
                return;
            }
            Title = txtTitle.Text;
            SystemMenuPath = txtSystemMenuPath.Text;
            Writer = txtWriter.Text;
            decimal _version = 1.0m;
            if (!decimal.TryParse(txtVersion.Text, out _version))
            {
                _version = 1.0m;
            }            
            Version = _version;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Title = "";
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        internal void SetData(ScreenDocumentHeader data)
        {
            txtTitle.Text = data.DocumentTitle;
            txtSystemMenuPath.Text = data.SystemMenuPath;
            txtWriter.Text = data.Writer;
            OldVersion = data.Version;
            txtVersion.Text = "" +(data.Version + 0.1m);
        }

        private void txtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{TAB}");
            }
        }
    }
}
