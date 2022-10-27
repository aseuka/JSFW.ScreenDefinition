using JSFW.ScreenDefinition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Fake
{
    public partial class OpenSlideUIScreenListFrom : Form
    {
        public FkData SelectData { get; set; } = null;

        public OpenSlideUIScreenListFrom()
        {
            InitializeComponent();

            this.Disposed += OpenSlideUIScreenListFrom_Disposed;
        }

        private void OpenSlideUIScreenListFrom_Disposed(object sender, EventArgs e)
        {
            SelectData = null;
            listBox1.DataSource = null;
        }

        protected override void OnShown(EventArgs e)
        {
            btnRefresh.PerformClick();
            base.OnShown(e);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // 선택
            SelectData = listBox1.SelectedItem as FkData;
            if (SelectData != null)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // 새로고침
            DataLoad();
        }

        private void DataLoad()
        {
            string dir = $"{MainForm.__DESIGN_DIR}";

            string[] files = Directory.GetFiles(dir, "*.jsdesign");
            List<FkData> fkDatas = new List<FkData>();

            foreach (string file in files)
            {
                string jsdesignJson = "";
                if (File.Exists(file))
                {
                    jsdesignJson = File.ReadAllText(file);
                }
                if (string.IsNullOrWhiteSpace(jsdesignJson)) continue;

                try
                {
                    fkDatas.Add( Newtonsoft.Json.JsonConvert.DeserializeObject<FkData>(jsdesignJson));
                }
                catch (Exception)
                { }
            }
            listBox1.DataSource = fkDatas;
            listBox1.ValueMember = "ScreenDesignID";
            listBox1.DisplayMember = "DisplaySlideInfo";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectData = null;
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = "";
            using (pictureBox1.Image) { }
            pictureBox1.Image = null;

            FkData data = listBox1.SelectedItem as FkData;
            if (data == null) return;
            path = $"{MainForm.__ROOT_DIR}{data.ScreenDocumentID}\\{data.SlideID}\\{data.SlideID}.SCREEN.png";

            if (File.Exists(path))
            {
                using (Image img = Image.FromFile(path)) 
                {
                    pictureBox1.Image = img.Clone() as Image;
                }
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            findIndex = 0;
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtFind.Text))
                {
                    btnFind.PerformClick();
                }
            }
        }

        int findIndex = 0;
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFind.Text))
            {
                List<FkData> fkDatas = listBox1.DataSource as List<FkData>;
                if (fkDatas != null)
                {
                    bool haveFinding = false;     // 찾았다면.
                    bool haveNextFinding = false; // 다음에 못찾은경우 위에서 새로 검색하기 위해
                    int beforeFindIndex = findIndex;
                    try
                    {
                        for (int loop = findIndex; loop < fkDatas.Count; loop++)
                        {
                            if (fkDatas[loop].DisplaySlideInfo.ToUpper().Contains(txtFind.Text.Trim().ToUpper()))
                            {
                                if (haveFinding == false)
                                {
                                    haveFinding = true;
                                    listBox1.SelectedItem = fkDatas[loop];
                                    findIndex = loop + 1;
                                }
                                else
                                {
                                    haveNextFinding = true;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (haveNextFinding == false || 
                            beforeFindIndex == findIndex || 
                            fkDatas.Count <= findIndex)
                        {
                            findIndex = 0;
                        }
                    }
                }
            }
            else 
            {
                listBox1.SelectedIndex = -1;
                findIndex = 0;
            }
        }
    }
}
