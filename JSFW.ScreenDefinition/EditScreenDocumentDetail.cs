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
    public partial class EditScreenDocumentDetail : Form
    {
        public Action ToSave = null;

        protected void OnSave(bool isSlideChanged = false)
        { 
            ToSave?.Invoke();

            string filePath = $"{MainForm.__ROOT_DIR}{Header.ID}\\화면정의서상세.jsdefine";
            Ux.SaveFile<ScreenDocumentDetail>(Detail,filePath);

            if (isSlideChanged)
            {
                OnShownSlideListView();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (editSlide1.IsDirty)
            {
                "저장중입니다.".Alert();
                e.Cancel = true;
                return;
            }
 
            if (btnSaveFunctionDefinition.BackColor == Color.Coral)
            {
                if ("기능정의서 변경내용을 저장하시겠습니까?".Confirm() == DialogResult.Yes)
                {
                    GetheringFunctionDefinition();
                    OnSave(true);
                }
            }
        }

        public EditScreenDocumentDetail()
        {
            InitializeComponent();

            this.Disposed += EditScreenDocumentDetail_Disposed;

            editSlide1.ToSave = () =>
            {
                //내용저장.
                GetheringFunctionDefinition();

                OnSave(true);
                SetFunctionDefinitionSaveState(Color.White);
                btnDelCancelFunction.PerformClick();
            };

            sdTopView1.ScreenDesignIDSelected = (nm) =>
            {
                editSlide1.SetDocumentName(nm);
            };

            sdTopView1.ToSave = () =>
            {
                if (SlideData != null)
                {
                    SlideData.SystemMenuPath = sdTopView1.SystemMenuPath;
                    SlideData.ScreenDesignID = sdTopView1.ScreenDesignID;
                    editSlide1.TriggerSaving();
                }
            };
        }
         
        private void EditScreenDocumentDetail_Disposed(object sender, EventArgs e)
        {
            editSlide1.ToSave = null;
            SlideData = null;
            Header = null;
            Detail = null;
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            Screen currentScreen = Screen.FromControl(this);
            this.MaximumSize = new Size(currentScreen.WorkingArea.Width, (int)(currentScreen.WorkingArea.Height * 0.99) + 16);
        }

        public ScreenDocumentHeader Header { get; internal set; }
        public ScreenDocumentDetail Detail { get; internal set; }
        internal void SetData(ScreenDocumentHeader header)
        {
            Header = header; 
            sdTopView1.SetData(Header);
            string filePath = $"{MainForm.__ROOT_DIR}{Header.ID}\\화면정의서상세.jsdefine";
            Detail = Ux.LoadFile<ScreenDocumentDetail>(filePath);
            if (Detail == null)
            {
                Detail = new ScreenDocumentDetail(Header.ID);
                OnSave(); //처음이면... 첫 데이타 저장.
            } 
            editSlide1.Enabled = false;
        }

        EditScreenDocumentSlideList SlideListView { get; set; } = null;

        private void sdTopView1_DoubleClick(object sender, EventArgs e)
        {
            OnShownSlideListView();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            OnShownSlideListView();
        }

        private void OnShownSlideListView()
        {
            if (SlideListView == null)
            {
                SlideListView = new EditScreenDocumentSlideList();
                SlideListView.ToSave = () => {
                    OnSave();
                };
                SlideListView.SlideSelected += SlideListView_SlideSelected;
                SlideListView.FormClosed += ( ss, ee )=> {
                    SlideListView = null;
                    // 슬라이드 초기화 
                };
            }
            SlideListView.SetData(Header, Detail, SlideData);
            if (SlideListView.Visible)
            {
                SlideListView.Activate();
                return;
            }
            SlideListView.Show();
            SlideListView.Left = this.Left - SlideListView.Width;
            if (SlideListView.Left < 0)
            {
                SlideListView.Left = 0;
            }
            SlideListView.Top = this.Top;
            SlideListView.TopLevel = false;
            if (panel1.Controls.Contains(SlideListView) == false)
            {
                panel1.Controls.Add(SlideListView);
            }
            SlideListView.Dock = DockStyle.Fill;
            this.Activate();
        }

        private Slide SlideData { get; set; } = null;

        /// <summary>
        /// 테스트 취소
        /// </summary>
        bool isCancelTesting = false;
        private void SlideListView_SlideSelected(Slide obj)
        {
            // 변경! 
            // 슬라이드 초기화
            // 비교
            try
            {
                isCancelTesting = true;
                chkTesting.Checked = false;
                
                editSlide1.Enabled = obj != null;
                if (obj == null)
                {
                    SetFunctions(null);
                    sdTopView1.SetScreenID(null);
                    editSlide1.SetData(null);
                    return;
                }
                if (SlideData == obj)
                {
                    return;
                }

                SlideData = obj;
                // 바인딩.
                sdTopView1.SetSystemMenuPath(SlideData.SystemMenuPath);
                editSlide1.SetData(SlideData);
                sdTopView1.SetScreenID(SlideData);
                SetFunctions(SlideData);
            }
            finally {
                isCancelTesting = false;
            }
        }
         
        private void EditScreenDocumentDetail_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (SlideListView != null) SlideListView.Show();
            }
            else
            {
                if (SlideListView != null) SlideListView.Hide();
            }
        }

        //###################################################################  기능 !!!
        private void btnAddFunction_Click(object sender, EventArgs e)
        {
            int orderNo = 0;
            foreach (FunctionDefinitionItemControl fnc in flpFunctionList.Controls)
            {
                if (orderNo < fnc.OrderNo)
                {
                    orderNo = fnc.OrderNo;
                }
            }
            FunctionDefinitionItemControl fc = new FunctionDefinitionItemControl()
            {
                OrderNo = ++orderNo,
                Text = ""
            };
            flpFunctionList.Controls.Add(fc);
            fc.SplitContentEvent += Fc_SplitContentEvent;
            fc.ContentsChanged += Fc_ContentsChanged;
            ReOrderNo();
            fc.Focus();
            SetFunctionDefinitionSaveState(Color.Coral);
        }

        private void SetFunctionDefinitionSaveState(Color backcolor)
        {
            if (btnSaveFunctionDefinition.Enabled)
            {
                btnSaveFunctionDefinition.BackColor = backcolor;
            }
        }

        private void Fc_ContentsChanged(object sender, EventArgs e)
        {
            if (btnSaveFunctionDefinition.Enabled)
            {
                SetFunctionDefinitionSaveState(Color.Coral);
            }
        }

        private void Fc_SplitContentEvent(object sender, SplitContentEventArgs e)
        {
            int idx = flpFunctionList.Controls.GetChildIndex(sender as Control);
            int orderNo = 0;
            if (0 <= idx)
            {
                FunctionDefinitionItemControl CurrentFuncEdit = flpFunctionList.Controls[idx] as FunctionDefinitionItemControl;
                orderNo = CurrentFuncEdit.OrderNo;
            }
            FunctionDefinitionItemControl fc = new FunctionDefinitionItemControl()
            {
                OrderNo = orderNo + e.OffsetIndex,
                Text = e.Text.TrimEnd()
            };
            flpFunctionList.Controls.Add(fc); 
            fc.SplitContentEvent += Fc_SplitContentEvent;
            fc.ContentsChanged += Fc_ContentsChanged;
            ReOrderNo();
            SetFunctionDefinitionSaveState(Color.Coral);
        }

        private void ReOrderNo()
        {
            // reorder!
            List<FunctionDefinitionItemControl> lst = new List<FunctionDefinitionItemControl>();
            for (int loop = 0; loop < flpFunctionList.Controls.Count; loop++)
            {
                lst.Add(flpFunctionList.Controls[loop] as FunctionDefinitionItemControl);
            }

            int reIndex = 0;
            foreach (var item in lst.OrderBy(f => f.OrderNo))
            {
                item.TabIndex = reIndex;
                item.OrderNo = (1 + reIndex) * 10;
                flpFunctionList.Controls.SetChildIndex(item, reIndex++);
            }
            lst.Clear();
            lst = null;
        }

        private void btnSaveFunctionDefinition_Click(object sender, EventArgs e)
        {
            // 저장.
            if (btnSaveFunctionDefinition.BackColor == Color.Coral)
            { 
                editSlide1.TriggerSaving();
            }
        }

        private void SetFunctions(Slide slide)
        { 
            ClearFunction();
            if (slide == null) return;

            foreach (var fnc in slide.Functions)
            {
                FunctionDefinitionItemControl fc = new FunctionDefinitionItemControl();
                fc.SetData( 
                    fnc.OrderNo,
                    fnc.Text,
                    fnc.IsConfirm
                );
                flpFunctionList.Controls.Add(fc);
                fc.SplitContentEvent += Fc_SplitContentEvent;
                fc.ContentsChanged += Fc_ContentsChanged;
            }

            LoadTesting();
        }

        private void LoadTesting()
        {
            string path = $"{MainForm.__ROOT_DIR}{SlideData.ScreenDocumentID}\\{SlideData.ID}\\Test\\";
            if (System.IO.Directory.Exists(path) == false)
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string[] testFiles = System.IO.Directory.GetFiles(path, "*.jsfnc");
            foreach (var file in testFiles)
            {
                TestResult testResult = Ux.LoadFile<TestResult>(file);
                Label testLogItem = new Label()
                {
                    AutoSize = false,
                    Text = $"{testResult:RESULT}", TextAlign = ContentAlignment.MiddleCenter,
                    Width = 170, Height = 30,
                    Margin = new Padding(3, 10, 3, 10),
                    Tag = file
                };
                flpTestLog.Controls.Add(testLogItem);
                testLogItem.Click += FlpTestLog_Click;
            }
        }

        private void ClearFunction()
        {
            SetFunctionDefinitionSaveState(Color.White);
            for (int loop = flpFunctionList.Controls.Count - 1; loop >= 0; loop--)
            {
                using (flpFunctionList.Controls[loop])
                {
                    FunctionDefinitionItemControl fc = flpFunctionList.Controls[loop] as FunctionDefinitionItemControl;
                    if (fc != null)
                    {
                        fc.SplitContentEvent -= Fc_SplitContentEvent;
                        fc.ContentsChanged -= Fc_ContentsChanged;
                    }
                    flpFunctionList.Controls.RemoveAt(loop);
                }
            }

            for (int loop = flpTestLog.Controls.Count - 1; loop >= 0; loop--)
            { 
                using (flpTestLog.Controls[loop])
                {
                    flpTestLog.Controls[loop].Click -= FlpTestLog_Click;
                    flpTestLog.Controls[loop].Tag = null;
                    flpTestLog.Controls.RemoveAt(loop);
                }
            }
        }

        private void btnDelFunction_Click(object sender, EventArgs e)
        {
            foreach (FunctionDefinitionItemControl fc in flpFunctionList.Controls)
            {
                fc.UseDelete(true);
            } 
            btnDelOKFunction.BringToFront();
            btnDelCancelFunction.BringToFront();
        }

        private void btnDelOKFunction_Click(object sender, EventArgs e)
        {
            List<FunctionDefinitionItemControl> dels = new List<FunctionDefinitionItemControl>();
            foreach (FunctionDefinitionItemControl fc in flpFunctionList.Controls)
            {
                if( fc.IsDelete )
                {
                    dels.Add(fc);
                }
            }

            if (0 < dels.Count)
            {
                for (int loop = dels.Count - 1; loop >= 0; loop--)
                {
                    using (dels[loop])
                    {
                        FunctionDefinitionItemControl fc = dels[loop];
                        if (fc != null)
                        {
                            fc.SplitContentEvent -= Fc_SplitContentEvent;
                            fc.ContentsChanged -= Fc_ContentsChanged;
                        }
                        flpFunctionList.Controls.Remove(fc);
                    }
                }
                SetFunctionDefinitionSaveState(Color.Coral);
            }

            foreach (FunctionDefinitionItemControl fc in flpFunctionList.Controls)
            {
                fc.UseDelete(false);
            }
            btnAddFunction.BringToFront();
            btnDelFunction.BringToFront();
        }

        private void btnDelCancelFunction_Click(object sender, EventArgs e)
        { 
            foreach (FunctionDefinitionItemControl fc in flpFunctionList.Controls)
            {
                fc.UseDelete(false);
            } 
            btnAddFunction.BringToFront();
            btnDelFunction.BringToFront();
        }

        private void GetheringFunctionDefinition()
        {
            if (btnSaveFunctionDefinition.BackColor == Color.Coral)
            {
                List<FunctionDefinition> fns = new List<FunctionDefinition>();
                foreach (FunctionDefinitionItemControl funcItem in flpFunctionList.Controls)
                {
                    fns.Add(new FunctionDefinition()
                    {
                        OrderNo = funcItem.OrderNo,
                        Text = funcItem.Text,
                        IsConfirm = funcItem.IsConfirm
                    });
                }
                SlideData.Functions.Clear();
                SlideData.Functions.AddRange(fns);
            }
        }

        private void chkTesting_CheckedChanged(object sender, EventArgs e)
        {
            bool isTesting = chkTesting.Checked;
            btnAddFunction.Enabled = !isTesting;
            btnDelFunction.Enabled = !isTesting;
            btnDelOKFunction.Enabled = !isTesting;
            btnDelCancelFunction.Enabled = !isTesting;

            btnSaveFunctionDefinition.Enabled = !isTesting;
            btnSaveFunctionDefinition.BackColor = Color.White;

            if (isTesting)
            {
                chkTesting.Text = "테스트 종료";
                foreach (FunctionDefinitionItemControl funcItem in flpFunctionList.Controls)
                { 
                    funcItem.IsConfirm = false; // 초기화
                }
            }
            else
            {
                chkTesting.Text = "테스트 시작";
            }

            if (isCancelTesting) return;

            if (!isTesting)
            {
                // 테스트 - 완료
                SaveTestResult();
            }
            btnSaveFunctionDefinition.BackColor = Color.White;
        }

        private void SaveTestResult()
        {
            string path = $"{MainForm.__ROOT_DIR}{SlideData.ScreenDocumentID}\\{SlideData.ID}\\Test\\";
            if (System.IO.Directory.Exists(path) == false)
            {
                System.IO.Directory.CreateDirectory(path);
            }
            TestResult testResult = new TestResult()
            { 
                Date = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}"
            };

            foreach (FunctionDefinitionItemControl funcItem in flpFunctionList.Controls)
            {
                testResult.Funcs.Add(new FunctionDefinition()
                {
                    OrderNo = funcItem.OrderNo,
                    Text = funcItem.Text,
                    IsConfirm = funcItem.IsConfirm
                });
                funcItem.IsConfirm = false; // 초기화
            }

            Label testLogItem = new Label()
            {
                AutoSize = false,
                Text = $"{testResult:RESULT}", TextAlign = ContentAlignment.MiddleCenter,
                Width = 170, Height = 30,
                Margin = new Padding(3, 10, 3, 10),
                Tag = $"{path}{testResult.ID}.jsfnc"
            };
            flpTestLog.Controls.Add(testLogItem);
            testLogItem.Click += FlpTestLog_Click;
            Ux.SaveFile<TestResult>(testResult, $"{path}{testResult.ID}.jsfnc");
        }

        private void FlpTestLog_Click(object sender, EventArgs e)
        {
            Label testLogItem = sender as Label;
            if (testLogItem != null)
            {
                //("" + testLogItem.Tag).Alert();
                using (TestLogViewFm ff = new TestLogViewFm())
                {
                    ff.SetData("" + testLogItem.Tag);
                    ff.ShowDialog(this);
                }
            }
        }
    }
}
