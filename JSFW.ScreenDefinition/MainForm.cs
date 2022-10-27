using JSFW.Fake;
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

/*
    DRIVE : ( D: ?? C: )
    ROOT : JSFW\ScreenDefinition\
                                    Design\ 화면목록
                                            화면ID.jsdesign
                                    화면정의서목록
                                    화면정의서ID\
                                                    슬라이드목록
                                                    슬라이드ID.jsslide
                                                    슬라이드ID.SCREEN     -- 화면
                                                    슬라이드ID.GBT01      -- 낙서판
*/

namespace JSFW.ScreenDefinition
{
    public partial class MainForm : Form
    {
        static string _DRIVE = GetDrive(@"D:\");

        private static string GetDrive(string drive)
        {
            if (!Directory.GetLogicalDrives().Contains(drive))
            {
                drive = Directory.GetLogicalDrives()[0];
            }
            return drive;
        }

        /// <summary>
        /// D:\JSFW\ScreenDefinition\
        /// </summary>
        internal static readonly string __ROOT_DIR = _DRIVE + @"JSFW\ScreenDefinition\";

        /// <summary>
        /// D:\JSFW\ScreenDefinition\Design\
        /// </summary>
        internal static readonly string __DESIGN_DIR = __ROOT_DIR + @"Design\";

        /// <summary>
        /// D:\JSFW\ScreenDefinition\Design\Template\
        /// </summary>
        internal static readonly string __DESIGN_TEMPLATE_DIR = __DESIGN_DIR + @"Template\";

        /// <summary>
        /// menuList.txt
        /// </summary>
        internal static readonly string __MENULIST_FILENAME = "menuList.txt";

        List<ScreenDocumentHeader> Datas { get; set; } = null;

        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            if (Directory.Exists(__DESIGN_TEMPLATE_DIR) == false)
            {
                Directory.CreateDirectory(__DESIGN_TEMPLATE_DIR);
            }
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            Screen currentScreen = Screen.FromControl(this);
            this.MaximumSize = new Size(currentScreen.WorkingArea.Width, (int)(currentScreen.WorkingArea.Height * 0.99) + 16);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DataLoad();
        }

        private void DataLoad()
        {
            if (Datas != null)
            {
                // js? 초기화
                Datas.Clear();
                Datas = null;
            }
            string path = $"{__ROOT_DIR}화면목록.jssc";
            Datas = Ux.LoadFile<List<ScreenDocumentHeader>>(path);

            if (Datas == null)
            {
                Datas = new List<ScreenDocumentHeader>();
            }

            foreach (ScreenDocumentHeader sd in Datas)
            {
                SDMiniView sdmv = new SDMiniView();
                sdmv.SetData(sd);
                flowLayoutPanel1.Controls.Add(sdmv);
                sdmv.UseDelete(false);
                sdmv.MouseDoubleClick += Sdmv_MouseDoubleClick;
            }
        }

        private void DataSave()
        {
            string path = $"{__ROOT_DIR}화면목록.jssc";
            Ux.SaveFile<List<ScreenDocumentHeader>>(Datas, path);
        }

        private void Sdmv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Control)
                {
                    SDMiniView sdmv = sender as SDMiniView;
                    if (sdmv != null)
                    {
                        using (NewSD nsd = new NewSD(false))
                        {
                            nsd.SetData(sdmv.Data);
                            if (nsd.ShowDialog() == DialogResult.OK)
                            {
                                sdmv.Data.DocumentTitle = nsd.Title;
                                sdmv.Data.SystemMenuPath = nsd.SystemMenuPath;
                                sdmv.Data.Writer = nsd.Writer;
                                sdmv.Data.Version = nsd.Version;
                                sdmv.Data.UpdateDate = $"{DateTime.Now}";
                                sdmv.SetData(sdmv.Data);

                                if (nsd.OldVersion < nsd.Version)
                                { 
                                    // directory copy
                                    
                                }
                                DataSave();
                            }
                        }
                    }
                }
                else
                { 
                    SDMiniView sdmv = sender as SDMiniView;
                    if (sdmv != null)
                    {
                        using (EditScreenDocumentDetail detail = new EditScreenDocumentDetail())
                        {
                            detail.SetData(sdmv.Data);
                            detail.Location = this.Location;
                            detail.Size = this.Size;
                            detail.Shown += (ss, ee) => { this.Hide(); };
                            detail.ToSave = () => {
                                DataSave();
                            };
                            if (detail.ShowDialog(this) == DialogResult.OK)
                            {
                                //js? 음... ok! not ok! 구분?
                            }
                        }
                        this.Show();
                    }
                }
            }
        }



        private void btnDelCancel_Click(object sender, EventArgs e)
        {
            // 취소
            foreach (SDMiniView sdmv in flowLayoutPanel1.Controls)
            {
                sdmv.UseDelete(false);
            }
            btnAdd.BringToFront();
            btnDel.BringToFront();
        }

        private void btnDelOK_Click(object sender, EventArgs e)
        {
            // 삭제 OK
            List<SDMiniView> dels = new List<SDMiniView>();
            foreach (SDMiniView sdmv in flowLayoutPanel1.Controls)
            {
                if (sdmv.IsDelete)
                {
                    dels.Add(sdmv);
                }
                sdmv.UseDelete(true);
            }

            for (int loop = dels.Count - 1; loop >= 0; loop--)
            {
                SDMiniView sdmv = dels[loop] as SDMiniView;
                if (sdmv == null) continue;

                using (sdmv)
                { 
                    Datas.Remove(sdmv.Data);
                    flowLayoutPanel1.Controls.Remove(dels[loop]);
                    dels[loop].MouseDoubleClick -= Sdmv_MouseDoubleClick;
                }
            }
            if (0 < dels.Count)
            {
                DataSave();
            }
            btnAdd.BringToFront();
            btnDel.BringToFront();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // 삭제
            foreach (SDMiniView sdmv in flowLayoutPanel1.Controls)
            {
                sdmv.UseDelete(true);
            }
            btnDelOK.BringToFront();
            btnDelCancel.BringToFront();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 추가
            using (NewSD nsd = new NewSD())
            {
                if (nsd.ShowDialog() == DialogResult.OK)
                {
                    ScreenDocumentHeader sd = new ScreenDocumentHeader();
                    sd.DocumentTitle = nsd.Title;
                    sd.SystemMenuPath = nsd.SystemMenuPath;
                    sd.Writer = nsd.Writer;
                    sd.Version = nsd.Version;
                    sd.WriteDate = $"{DateTime.Now}";
                    sd.UpdateDate = sd.WriteDate;

                    Datas.Add(sd);
                    SDMiniView sdmv = new SDMiniView();
                    sdmv.SetData(sd);
                    flowLayoutPanel1.Controls.Add(sdmv);
                    sdmv.UseDelete(false);
                    sdmv.MouseDoubleClick += Sdmv_MouseDoubleClick;
                    DataSave();
                }
            }
        }

        private void btnMnu_Click(object sender, EventArgs e)
        {
            //메뉴관리.
            using (MnuManagerFm mmf = new MnuManagerFm())
            {
                mmf.ShowDialog(this);
            }
        }
    }


    public class ScreenDocumentHeader
    { 
        public string ID { get; set; }

        public ScreenDocumentHeader()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        public string DocumentTitle { get; set; }

        public string SystemMenuPath { get; set; }

        public string Writer { get; set; }

        public string WriteDate { get; set; }

        public string UpdateDate { get; set; }

        public Decimal Version { get; set; } = 1.0m;
    }

    public class ScreenDocumentDetail
    {
        public string ID { get; set; }

        public ScreenDocumentDetail(string id)
        {
            ID = id;
        }  
        public List<Slide> Slides { get; set; } = new List<Slide>();
    }
     
    public class Slide
    {
        public string ScreenDocumentID { get; set; }

        public string ID { get; set; }

        public Slide()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        public string ScreenDesignID { get; set; }

        public int Order { get; set; } = 0;

        /// <summary>
        /// 슬라이드 타이틀
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 설명
        /// </summary>
        public string Tip { get; set; }

        public List<FunctionDefinition> Functions { get; set; } = new List<FunctionDefinition>();

        public List<Memo> Memos { get; set; } = new List<Memo>();
        
        public List<Graffity> Graffities { get; set; } = new List<Graffity>();

        public string BackgroundImagePath { get; set; }

        public string SystemMenuPath { get; set; }

        /// <summary>
        /// 디자이너에서 변경되는 경우
        /// </summary>
        public bool DesignChanged { get; set; }
         
        public ScreenSize ScreenSize { get; set; }

        internal void CreateDirectory()
        {
            string dir = $"{MainForm.__ROOT_DIR}{ScreenDocumentID}\\{ID}\\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        internal void CreateGrffity(Graffity beforeGraffity = null)
        {
            Graffity grff = new Graffity();
            grff.ScreenDocumentID = ScreenDocumentID;
            grff.SlideID = ID;
            grff.BackgroundImagePath = beforeGraffity?.BackgroundImagePath; //배경이미지 전달.
            string imgPath = grff.ImagePath;
            if (!File.Exists(imgPath))
            {
                using (Bitmap bmp = new Bitmap(EditSlide.DrawWidth, EditSlide.DrawHeight))
                {
                    bmp.MakeTransparent();
                    bmp.Save(imgPath, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            Graffities.Add(grff);
        } 
    }

    public class FunctionDefinition
    {
        public int OrderNo { get; set; }

        public string Text { get; set; }

        public bool IsConfirm { get; set; } = false;
    }

    public class TestResult : IFormattable
    {
        public string ID { get; set; }

        public TestResult()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        public string Date { get; set; }

        public List<FunctionDefinition> Funcs { get; set; } = new List<FunctionDefinition>();

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == "RESULT")
            {
                int ss = Funcs.Count(f => f.IsConfirm);
                return $"{Date} ({ss,2}/{Funcs.Count,2})";
            }
            else
            {
                return base.ToString();
            }
        }
    }

    public class Memo
    {
        public string ID { get; set; }

        public Memo()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        public bool UseNumber { get; set; } = false;

        public int Number { get; set; }

        public string Text { get; set; }

        public int Left { get; set; }

        public int Top { get; set; }

        /// <summary>
        /// false: 숫자모드, true : 텍스트 모드
        /// </summary>
        public bool NumberIsTextViewMode { get; set; }
    }


    public class Graffity
    {
        public string ScreenDocumentID { get; set; }
         
        public string SlideID { get; set; }

        public string ID { get; set; }

        public Graffity()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        public string BackgroundImagePath { get; set; } = null;

        public string ImagePath { get => GetImagePath(); }
      
        private string GetImagePath()
        {
            string dir = $"{MainForm.__ROOT_DIR}{ScreenDocumentID}\\{SlideID}\\";
            string fileName = $"{dir}{SlideID}.GVT_{ID}.png";
            return fileName;
        }
    }
}
