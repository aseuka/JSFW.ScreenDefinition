using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JSFW.Fake;
using JSFW.Fake.ToolBox;
using JSFW.ScreenDefinition;
using System.IO;

namespace JSFW.Fake
{
    public partial class Designer : UserControl
    {
        internal Slide Slide { get; private set; }
         
        public Designer()
        {
            InitializeComponent();

            DoubleBuffered = true;

            Ux.SetNonPublicProperty(fkUc, "DoubleBuffered", true);

            List<ScreenSize> ssItems = new List<ScreenSize>()
            {
                new ScreenSize(){ Width = 1024, Height = 768 },  // 0
                new ScreenSize(){ Width = 1280, Height = 720 },  // 1
                new ScreenSize(){ Width = 1280, Height = 768 },  // 2
                new ScreenSize(){ Width = 1280, Height = 800 },  // 3
                new ScreenSize(){ Width = 1366, Height = 768 },  // 4
                new ScreenSize(){ Width = 1440, Height = 900 },  // 5
                new ScreenSize(){ Width = 1600, Height = 900 },  // 6
                new ScreenSize(){ Width = 1600, Height = 1200 }, // 7
                new ScreenSize(){ Width = 1920, Height = 1080 }, // 8 : 기본값
                new ScreenSize(){ Width = 1920, Height = 1200 }  // 9
            };

            cboScreenSize.DataSource = ssItems;
            cboScreenSize.SelectedIndex = 8;
             
            InitControls();
             
            FkCtrlUx.DataChanged = FkCtrlUx_DataChanged;

            this.Disposed += Designer_Disposed;
        }

        private void InitControls()
        {
            try
            {

                pnlToolBoxItems.SuspendLayout();
                pnlTemplate.SuspendLayout();

                ToolBoxItem toolBoxItem_label = new ToolBoxItem() { HeaderText = "라벨" };
                toolBoxItem_label.TypeName = typeof(FkLabel).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_label);
                toolBoxItem_label.Dock = DockStyle.Top;
                toolBoxItem_label.BringToFront();

                ToolBoxItem toolBoxItem_textBox = new ToolBoxItem() { HeaderText = "텍스트박스" };
                toolBoxItem_textBox.TypeName = typeof(FkTextBox).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_textBox);
                toolBoxItem_textBox.Dock = DockStyle.Top;
                toolBoxItem_textBox.BringToFront();

                ToolBoxItem toolBoxItem_button = new ToolBoxItem() { HeaderText = "버튼" };
                toolBoxItem_button.TypeName = typeof(FkButton).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_button);
                toolBoxItem_button.Dock = DockStyle.Top;
                toolBoxItem_button.BringToFront();

                ToolBoxItem toolBoxItem_codeFind = new ToolBoxItem() { HeaderText = "코드파인드" };
                toolBoxItem_codeFind.TypeName = typeof(FkCodeFind).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_codeFind);
                toolBoxItem_codeFind.Dock = DockStyle.Top;
                toolBoxItem_codeFind.BringToFront();

                ToolBoxItem toolBoxItem_calendar = new ToolBoxItem() { HeaderText = "달력" };
                toolBoxItem_calendar.TypeName = typeof(FkCalendar).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_calendar);
                toolBoxItem_calendar.Dock = DockStyle.Top;
                toolBoxItem_calendar.BringToFront();

                ToolBoxItem toolBoxItem_combobox = new ToolBoxItem() { HeaderText = "콤보박스" };
                toolBoxItem_combobox.TypeName = typeof(FkComboBox).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_combobox);
                toolBoxItem_combobox.Dock = DockStyle.Top;
                toolBoxItem_combobox.BringToFront();

                ToolBoxItem toolBoxItem_datagrid = new ToolBoxItem() { HeaderText = "데이타 그리드" };
                toolBoxItem_datagrid.TypeName = typeof(FkDataGrid).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_datagrid);
                toolBoxItem_datagrid.Dock = DockStyle.Top;
                toolBoxItem_datagrid.BringToFront();

                ToolBoxItem toolBoxItem_panel = new ToolBoxItem() { HeaderText = "판넬" };
                toolBoxItem_panel.TypeName = typeof(FkPanel).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_panel);
                toolBoxItem_panel.Dock = DockStyle.Top;
                toolBoxItem_panel.BringToFront();

                ToolBoxItem toolBoxItem_tabcontrol = new ToolBoxItem() { HeaderText = "탭" };
                toolBoxItem_tabcontrol.TypeName = typeof(FkTabControl).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_tabcontrol);
                toolBoxItem_tabcontrol.Dock = DockStyle.Top;
                toolBoxItem_tabcontrol.BringToFront();

                ToolBoxItem toolBoxItem_checkbox = new ToolBoxItem() { HeaderText = "체크박스" };
                toolBoxItem_checkbox.TypeName = typeof(FkCheckBox).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_checkbox);
                toolBoxItem_checkbox.Dock = DockStyle.Top;
                toolBoxItem_checkbox.BringToFront();

                ToolBoxItem toolBoxItem_radiobutton = new ToolBoxItem() { HeaderText = "라디오버튼" };
                toolBoxItem_radiobutton.TypeName = typeof(FkRadioButton).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_radiobutton);
                toolBoxItem_radiobutton.Dock = DockStyle.Top;
                toolBoxItem_radiobutton.BringToFront();

                ToolBoxItem toolBoxItem_chart = new ToolBoxItem() { HeaderText = "챠트" };
                toolBoxItem_chart.TypeName = typeof(FkChart).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_chart);
                toolBoxItem_chart.Dock = DockStyle.Top;
                toolBoxItem_chart.BringToFront();

                ToolBoxItem toolBoxItem_tree = new ToolBoxItem() { HeaderText = "트리" };
                toolBoxItem_tree.TypeName = typeof(FkTree).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_tree);
                toolBoxItem_tree.Dock = DockStyle.Top;
                toolBoxItem_tree.BringToFront();

                ToolBoxItem toolBoxItem_img = new ToolBoxItem() { HeaderText = "이미지" };
                toolBoxItem_img.TypeName = typeof(FkImage).FullName;
                pnlToolBoxItems.Controls.Add(toolBoxItem_img);
                toolBoxItem_img.Dock = DockStyle.Top;
                toolBoxItem_img.BringToFront();

                LoadTemplates();
            }
            finally
            {
                pnlTemplate.ResumeLayout(false);
                pnlToolBoxItems.ResumeLayout(false);
                pnlTemplate.PerformLayout();
                pnlToolBoxItems.PerformLayout();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                if (FkCtrlUx.SelectedFkControls != null)
                {
                    for (int loop = FkCtrlUx.SelectedFkControls.Count - 1; loop >= 0; loop--)
                    {
                        Control prnt = FkCtrlUx.SelectedFkControls[loop].Parent;
                        using (FkCtrlUx.SelectedFkControls[loop])
                        {
                            prnt.Controls.Remove(FkCtrlUx.SelectedFkControls[loop]);
                            FkCtrlUx_DataChanged(null, "delete");
                        }
                    }
                    FkCtrlUx.SelectedFkControls.Clear();
                    Invalidate(true);
                }
            }
            else if (keyData == (Keys.Left | Keys.Control))
            {
                LRReSize(-1);
            }
            else if (keyData == (Keys.Right | Keys.Control))
            {
                LRReSize(1);
            }
            else if (keyData == (Keys.Up | Keys.Control))
            {
                UDReSize(-1);
            }
            else if (keyData == (Keys.Down | Keys.Control))
            {
                UDReSize(1);
            }
            else if (keyData == (Keys.Left | Keys.Control | Keys.Shift))
            {
                LRPixelReSize(-1);
            }
            else if (keyData == (Keys.Right | Keys.Control | Keys.Shift))
            {
                LRPixelReSize(1);
            }
            else if (keyData == (Keys.Up | Keys.Control | Keys.Shift))
            {
                UDPixelReSize(-1);
            }
            else if (keyData == (Keys.Down | Keys.Control | Keys.Shift))
            {
                UDPixelReSize(1);
            }
            else if (keyData == (Keys.Left | Keys.Shift))
            {
                LRPixelMoving(-1);
            }
            else if (keyData == (Keys.Right | Keys.Shift))
            {
                LRPixelMoving(1);
            }
            else if (keyData == (Keys.Up | Keys.Shift))
            {
                UDPixelMoving(-1);
            }
            else if (keyData == (Keys.Down | Keys.Shift))
            {
                UDPixelMoving(1);
            }
            else if (keyData == Keys.Left)
            {
                LRMoving(-1);
            }
            else if (keyData == Keys.Right)
            {
                LRMoving(1);
            }
            else if (keyData == Keys.Up)
            {
                UDMoving(-1);
            }
            else if (keyData == Keys.Down)
            {
                UDMoving(1);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UDPixelMoving(int pos)
        {
            foreach (Control ctrl in FkCtrlUx.SelectedFkControls)
            {
                Control prnt = ctrl.Parent;
                ctrl.Top += pos;
                if (0 < pos && (prnt.Height - ctrl.Height) < ctrl.Top)
                {
                    ctrl.Top -= pos;
                }
                else if (pos < 0 && ctrl.Top < 0)
                {
                    ctrl.Top = 0;
                }
            }

            Invalidate(true);
        }

        private void LRPixelMoving(int pos)
        {
            foreach (Control ctrl in FkCtrlUx.SelectedFkControls)
            {
                Control prnt = ctrl.Parent;
                ctrl.Left += pos;
                if (0 < pos && (prnt.Width - ctrl.Width) < ctrl.Left)
                {
                    ctrl.Left -= pos;
                }
                else if (pos < 0 && ctrl.Left < 0)
                {
                    ctrl.Left = 0;
                }
            }

            Invalidate(true);
        }

        private void UDPixelReSize(int pos)
        {
            foreach (Control ctrl in FkCtrlUx.SelectedFkControls)
            {
                Control prnt = ctrl.Parent;

                int hg = ctrl.Height;

                if (0 < pos)  // 증가
                {
                    hg += pos;

                    if (prnt.Height < hg)
                    {
                        break;
                    }
                    ctrl.Height = hg;
                }
                else if (pos < 0) // 감소
                {
                    hg += pos;

                    if (hg < FkPanel.__GridRowHeight) break;
                     
                    ctrl.Height = hg;
                }
            }
            Invalidate(true);
        }

        private void LRPixelReSize(int pos)
        {
            foreach (Control ctrl in FkCtrlUx.SelectedFkControls)
            {
                int wd = ctrl.Width;

                if (0 < pos)  // 증가
                {
                    wd += pos;
                    ctrl.Width = wd;
                }
                else if (pos < 0) // 감소
                {
                    if (wd < FkPanel._Width) break;

                    wd += pos;

                    if (wd < 15)
                    {
                        wd = 15;
                    }
                    ctrl.Width = wd;
                }
            }
            Invalidate(true);
        }
         
        private void UDReSize(int pos)
        {
            foreach (Control ctrl in FkCtrlUx.SelectedFkControls)
            {
                Control prnt = ctrl.Parent;

                int hg = ctrl.Height;

                if (0 < pos)  // 증가
                {
                    hg = (((ctrl.Height - (ctrl is FkPanel ? 3 : 0)) / FkPanel.__GridRowHeight) + pos) * FkPanel.__GridRowHeight + FkPanel.__GridRowHeight;

                    if (prnt.Height < hg)
                    {
                        break;
                    }

                    if (ctrl is FkPanel)
                    {
                        hg += 7;
                    }

                    ctrl.Height = hg - 2 - (prnt is FkPanel? 1 : 0);
                }
                else if (pos < 0) // 감소
                {
                    if (hg < FkPanel.__GridRowHeight) break;

                    hg = (((ctrl.Height - (ctrl is FkPanel ? 7 : 0)) / FkPanel.__GridRowHeight) - pos) * FkPanel.__GridRowHeight - FkPanel.__GridRowHeight;

                    if ((hg - 2 ) < 0)
                    {
                        hg = FkPanel.__GridRowHeight - 2;
                    }

                    if (ctrl is FkPanel)
                    {
                        hg += 8;
                    }

                    ctrl.Height = hg - 2 - (prnt is FkPanel ? 1 : 0);
                }
               
            }
            Invalidate(true);
        }

        private void LRReSize(int pos)
        {
            foreach (Control ctrl in FkCtrlUx.SelectedFkControls)
            {
                int wd = ctrl.Width;

                if (0 < pos)  // 증가
                {
                    wd = ((ctrl.Width / FkPanel._Width) + pos) * FkPanel._Width + FkPanel._Width - 2;
                    ctrl.Width = wd;
                }
                else if( pos < 0) // 감소
                {
                    if (wd < FkPanel._Width) break;

                    wd = ((ctrl.Width / FkPanel._Width) - pos) * FkPanel._Width - FkPanel._Width - 2;

                    if (wd < 0)
                    {
                        wd = FkPanel._Width;
                    }
                    ctrl.Width = wd;
                }
            }
            Invalidate(true);
        }

        private void UDMoving(int pos)
        {
            foreach (Control ctrl in FkCtrlUx.SelectedFkControls)
            {
                Control prnt = ctrl.Parent;
                IFkData prntdata = prnt as IFkData;
                IFkData data = ctrl as IFkData;
                int xpos = 0;
                int ypos = 0;
                int xcnt = 0;
                int ycnt = prnt.Height / FkPanel.__GridRowHeight;

                if (data != null)
                {
                    xpos = (data.Data.CellIndex % data.Data.ColsCount);
                    ypos = (data.Data.CellIndex / data.Data.ColsCount);
                    xcnt = data.Data.ColsCount;
                }

                // 판넬인경우 헤더가 있으면 위로 침범 못함.
                if (pos < 0 && (ypos <= ( prnt is FkPanel && !string.IsNullOrWhiteSpace( prntdata.Data.Text ) ? 1 : 0 ) || xcnt <= 0)) // 위로
                {
                    break;
                }

                if (0 < pos && ycnt <= (ypos + pos)) // 아래로
                {
                    break;
                }

                int top = (ypos + pos) * FkPanel.__GridRowHeight;
                if (top < 0) top = 0;
                if (prnt.Height <= top)
                {
                    top = prnt.Height - ctrl.Height;
                }
                data.Data.CellIndex = ((ypos + pos) * xcnt) + xpos;
                ctrl.Top = (FkPanel.OFFSET - 3) + top;
                Log($"(({ypos} + {pos}) * {xcnt}) + {xpos} = {data.Data.CellIndex}");
            }
            Invalidate(true);
        }

        private void LRMoving(int pos)
        {
            foreach (Control ctrl in FkCtrlUx.SelectedFkControls)
            {
                Control prnt = ctrl.Parent;
                IFkData data = ctrl as IFkData;
                int xpos = -1;
                int ypos = 0;
                int xcnt = 0;

                if (data != null)
                {
                    xpos = (data.Data.CellIndex % data.Data.ColsCount);
                    ypos = (data.Data.CellIndex / data.Data.ColsCount);
                    xcnt = data.Data.ColsCount;
                }

                if (pos < 0 && (xpos == 0 || xcnt <= 0)) // 왼쪽
                {
                    break;
                }

                if (0 < pos && xcnt <= (xpos + pos)) // 오른쪽
                {
                    break;
                }

                int left = (xpos + pos) * FkPanel._Width;
                if (left < 0) left = 0;
                if (prnt.Width <= left)
                {
                    left = prnt.Width - ctrl.Width;
                }
                data.Data.CellIndex = (ypos * xcnt) + (xpos + pos);
                ctrl.Left = (FkPanel.OFFSET - 3) + left;
                Log($"({ypos} * {xcnt}) + ({xpos} + {pos}) = {data.Data.CellIndex}");
            }
            Invalidate(true);
        }

        public void Log(string obj)
        {
            System.Diagnostics.Debug.WriteLine(obj);
        }

        private void Designer_Disposed(object sender, EventArgs e)
        {
            FkCtrlUx.DataChanged = null;
        }

        private void FkCtrlUx_DataChanged(FkData data, string propertyName)
        {
            btnSave.BackColor = Color.Coral;
        }
         
        internal void SetData(Slide slide)
        {
            Slide = slide; 
            try
            {
                Slide.DesignChanged = false;
                FkCtrlUx.IgnoreDataChangeEvent = true;

                lbSystemMenuPath.Text = $"{Slide.SystemMenuPath} [{Slide.Title}]";

                FkData newData = null;
                string filePath = $"{MainForm.__DESIGN_DIR}{Slide.ID}.jsdesign";
                string jsdesignJson = "";
                if (File.Exists(filePath))
                {
                    jsdesignJson = File.ReadAllText(filePath);
                }

                if (string.IsNullOrWhiteSpace(jsdesignJson))
                {
                    newData = new FkData()
                    {
                        TypeName = typeof(FkUserControl).FullName,
                        Text = "",
                        Visible = true,
                        Left = 0,
                        Top = 0,
                        Width = 1250,
                        Height = 700, 
                        GridLine = false
                    };
                }
                else
                {
                    newData = Newtonsoft.Json.JsonConvert.DeserializeObject<FkData>(jsdesignJson);
                }
                newData.ScreenDocumentID = slide.ScreenDocumentID;
                newData.SlideID = slide.ID;
                newData.SlideTitle = slide.Title;
                newData.ScreenDesignID = Slide.ScreenDesignID;
                fkUc.SetData(newData);
                fkUc.Left = 5;
                fkUc.Top = 5;

                List<ScreenSize> ssItems = cboScreenSize.DataSource as List<ScreenSize>;
                if (ssItems != null && slide.ScreenSize != null)
                {
                    ScreenSize sz = ssItems.FirstOrDefault(itm => itm.Width == Slide.ScreenSize.Width && itm.Height == Slide.ScreenSize.Height);
                    cboScreenSize.SelectedItem = sz;
                    fkUc.Width = sz.Width;
                    fkUc.Height = sz.Height;
                }
                else
                {
                    cboScreenSize.SelectedIndex = -1;
                    cboScreenSize.SelectedIndex = 2;

                    ScreenSize ss = cboScreenSize.SelectedItem as ScreenSize;
                    if (ss != null)
                    {
                        fkUc.Width = ss.Width - SystemInformation.VerticalScrollBarWidth;
                        fkUc.Height = ss.Height - SystemInformation.HorizontalScrollBarHeight;
                    }
                    Slide.ScreenSize = ss;
                }
            }
            finally {
                FkCtrlUx.IgnoreDataChangeEvent = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (NeedSaving())
            {
                Save();
            }
        }

        public bool NeedSaving()
        {
            return btnSave.BackColor != Color.White;
        }
        
        internal void Save()
        {
            FkCtrlUx.SelectedFkControls.Clear();
            Invalidate(true); // 선택 모두 제거

            FkData data = FkCtrlUx.DataFlush(fkUc);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            // 저장경로는 MainForm에 주석처럼 화면!!
            /*  ROOT: JSFW\ScreenDefinition\
                                              Design\ 화면목록
                                                      슬라이드ID.jsdesign                 --디자인소스
                                              화면정의서목록
                                              화면정의서ID\
                                                              슬라이드목록
                                                              슬라이드ID.jsslide
                                                              슬라이드ID.SCREEN.png   -- 화면 (이미지)
                                                              슬라이드ID.GBT01.png    -- 낙서판
            */
            //저장은 Slide.ScreenDocumentID 로 Design\아래 저장하고
            string filePath = $"{MainForm.__DESIGN_DIR}{Slide.ID}.jsdesign";
            File.WriteAllText(filePath, json); 
            try
            {
                needMessageBox = false;
                btnScreenShot.PerformClick();
            }
            finally
            {
                needMessageBox = true;
            }
            Clipboard.Clear();
            GC.Collect();

            Slide.DesignChanged = true;
            btnSave.BackColor = Color.White;
        }

        private void btnScreenShot_Click(object sender, EventArgs e)
        {
            // 스샷!
            string path = $"{MainForm.__ROOT_DIR}{Slide.ScreenDocumentID}\\{Slide.ID}\\{Slide.ID}";
            string bigImagePath = path + ".SCREEN.png";
            string thumnailPath = path + ".SCREEN.THUMBNAIL.bmp";
            ScreenShot(bigImagePath, thumnailPath); 
            Slide.BackgroundImagePath = bigImagePath;
        }

        bool needMessageBox = true;

        private void ScreenShot(string bigImagePath, string thumnailPath)
        {
            Control ShotTarget = fkUc;

            if (ShotTarget == null) return;

            for (int loop = ShotTarget.Controls.Count - 1; loop >= 0; loop--)
            {
                ShotTarget.Controls[loop].SendToBack();
            }

            using (Image thumbnail = ShotTarget.ControlShot(0))
            {
                try
                {
                    // JSFW.PRJ.Diagram에서 화면정보를 보여줄 이미지로 사용함!
                    // C:\JSFW\MenuDetail\menuName

                    if (File.Exists(bigImagePath))
                    {
                        File.Delete(bigImagePath);
                    }
                    if (File.Exists(thumnailPath))
                    {
                        File.Delete(thumnailPath);
                    }
                    thumbnail.Save(thumnailPath, System.Drawing.Imaging.ImageFormat.Bmp);
                    // 화면정의 프로그램에서 사용할 큰 사이즈 이미지
                    Clipboard.GetImage().Save(bigImagePath, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("배경이미지 다시 지정해야 합니다.\r\n[예전버젼으로 이미지 사용중!]");
                    throw ex;
                }
                finally
                {
                    for (int loop = ShotTarget.Controls.Count - 1; loop >= 0; loop--)
                    {
                        ShotTarget.Controls[loop].SendToBack();
                    }
                } 
                if (needMessageBox)
                    "ClipBoard 복사 - [Image]".Alert();
            }
        }

        private void btnSetScreenSize_Click(object sender, EventArgs e)
        {
            ScreenSize ss = cboScreenSize.SelectedItem as ScreenSize;
            if( ss != null )
            { 
                fkUc.Width = ss.Width - SystemInformation.VerticalScrollBarWidth;
                fkUc.Height = ss.Height - SystemInformation.HorizontalScrollBarHeight;
            }
            Slide.ScreenSize = ss;
            fkUc.Left = 5;
            fkUc.Top = 5;
        }

        private void btnFront_Click(object sender, EventArgs e)
        {
            FkCtrlUx.SelectedFkControls.ForEach(c => c.BringToFront());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FkCtrlUx.SelectedFkControls.ForEach(c => c.SendToBack());
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // 기존 디자인 가져오기. 
            using (OpenSlideUIScreenListFrom fm = new OpenSlideUIScreenListFrom())
            {
                FkCtrlUx.IgnoreDataChangeEvent = true; // 저장필요 무시
                fm.Location = this.FindForm().Location;
                fm.Size = this.FindForm().Size;
                try
                {
                    if (fm.ShowDialog(this) == DialogResult.OK)
                    {
                        FkCtrlUx.IgnoreDataChangeEvent = false; // 저장필요 무시
                        if (0 < fkUc.Controls.Count && "기존 내용 삭제 후 가져오시겠습니까? ".Confirm() == DialogResult.No)
                        {
                            return;
                        }
                        FkData newData = fm.SelectData;
                        newData.ScreenDesignID = Slide.ScreenDesignID;
                        fkUc.SetData(newData);
                        fkUc.Left = 5;
                        fkUc.Top = 5;
                    }
                }
                finally
                {
                    FkCtrlUx.IgnoreDataChangeEvent = false; // 저장필요 무시
                }
            }
        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            // 가져오기. ( 저장 ) 
            if (FkCtrlUx.SelectedFkControls.Count <= 0)
            {
                "선택된 컨트롤이 없음.".Alert();
                return;
            }

            using (CreateTemplateForm ctf = new CreateTemplateForm())
            {
                Control ctrl = FkCtrlUx.SelectedFkControls[0]; 
                List<DragDropFkData> Datas = new List<DragDropFkData>();
                foreach (Control inner in FkCtrlUx.SelectedFkControls)
                {
                    IFkData content = inner as IFkData;
                    Datas.Add(new DragDropFkData(content.Data.Clone() as FkData)
                    {
                        OffsetX = inner.Left - ctrl.Left,
                        OffsetY = inner.Top - ctrl.Top
                    });
                }

                TemplateFkData templateData = new TemplateFkData(Datas);

                ctf.SetData(templateData);

                if (ctf.ShowDialog(this) == DialogResult.OK)
                {
                    // 템플렛 로딩!
                    ToolBoxItem_Template newTemplate = new ToolBoxItem_Template();
                    newTemplate.HeaderText = ctf.Data.Name;
                    newTemplate.Data = ctf.Data;
                    pnlTemplate.Controls.Add(newTemplate);
                    newTemplate.Dock = DockStyle.Top;
                    newTemplate.BringToFront();
                }
            }
        }

        private void LoadTemplates()
        {
            FkCtrlUx.IgnoreDataChangeEvent = true;
            ClearTemplate();
            string path = $"{MainForm.__DESIGN_TEMPLATE_DIR}";

            string[] files = Directory.GetFiles(path, "*.jsdesigntmp");
            foreach (string file in files)
            {
                TemplateFkData data = Ux.LoadFile<TemplateFkData>(file);
                ToolBoxItem_Template newTemplate = new ToolBoxItem_Template();
                newTemplate.HeaderText = data.Name;
                newTemplate.Data = data;
                pnlTemplate.Controls.Add(newTemplate);
                newTemplate.Dock = DockStyle.Top;
                newTemplate.BringToFront();
            }
            FkCtrlUx.IgnoreDataChangeEvent = false;
        }

        private void ClearTemplate()
        {
            for (int loop = pnlTemplate.Controls.Count - 1; loop >= 0; loop--)
            {
                using (pnlTemplate.Controls[loop])
                { }
            }
        }

        private void btnDelTemplate_Click(object sender, EventArgs e)
        { 
            btnDelOKTemplate.BringToFront();
            btnDelCancelTemplate.BringToFront();
            foreach (ToolBoxItem_Template tmp in pnlTemplate.Controls)
            {
                tmp.UseDelete(true);
            }
        }

        private void btnDelOKTemplate_Click(object sender, EventArgs e)
        {
            if ("템플릿을 삭제?".Confirm() == DialogResult.No) return;

            List<ToolBoxItem_Template> dels = new List<ToolBoxItem_Template>();
            foreach (ToolBoxItem_Template tmp in pnlTemplate.Controls)
            {
                if (tmp.IsDelete)
                {
                    dels.Add(tmp);
                }
            }

            if (0 < dels.Count)
            {
                for (int loop = dels.Count - 1; loop >= 0; loop--)
                {
                    ToolBoxItem_Template tmp = dels[loop];
                    using (tmp)
                    {
                        pnlTemplate.Controls.Remove(tmp);
                        string file = $"{MainForm.__DESIGN_TEMPLATE_DIR}{tmp.Data.ID}.jsdesigntmp";
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    }
                }
            }

            foreach (ToolBoxItem_Template tmp in pnlTemplate.Controls)
            {
                tmp.UseDelete(false);
            }

            btnAddTemplate.BringToFront();
            btnDelTemplate.BringToFront();
        }

        private void btnDelCancelTemplate_Click(object sender, EventArgs e)
        {
            foreach (ToolBoxItem_Template tmp in pnlTemplate.Controls)
            {
                tmp.UseDelete(false);
            }
            btnAddTemplate.BringToFront();
            btnDelTemplate.BringToFront();
        }
    }

    public class ScreenSize
    { 
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return $"{Width} x {Height}";
        }
    }
}
