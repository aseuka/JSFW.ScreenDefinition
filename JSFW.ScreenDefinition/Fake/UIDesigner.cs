using JSFW.Fake;
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
    public partial class UIDesigner : Form
    {
        internal Slide Slide { get; private set; }

        bool IsDebugMode = false;

        public UIDesigner(bool debugMode = false)
        {
            IsDebugMode = debugMode;
            InitializeComponent();

            DoubleBuffered = true;
            
            this.Disposed += UIDesigner_Disposed;
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            Screen currentScreen = Screen.FromControl(this);
            this.MaximumSize = new Size(currentScreen.WorkingArea.Width, (int)(currentScreen.WorkingArea.Height * 0.99) + 16);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (!IsDebugMode && 
                designer1.NeedSaving() && 
                "저장 후 닫으시겠습니까?".Confirm() == DialogResult.Yes)
            {
                try
                {
                    designer1.Save();
                    int cnt = 10;
                    while (designer1.NeedSaving() && 0 < cnt)
                    {
                        System.Threading.Thread.Sleep(100);
                        cnt--;
                    }
                    this.Close();
                }
                catch { 
                    // 안닫혀?
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            FkCtrlUx.DataChanged = null;
        }

        private void UIDesigner_Disposed(object sender, EventArgs e)
        {
            Slide = null;
        }

        private void UIDesigner_Resize(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        internal void SetData(Slide slide)
        {
            Slide = slide;
            designer1.SetData(Slide);
        }
    }
}
