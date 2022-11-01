using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Ink;
using System.IO;
using JSFW.Properties;
using GreenshotPlugin.Controls;
using System.Diagnostics.CodeAnalysis;
using GreenshotPlugin.UnmanagedHelpers;

namespace JSFW.ScreenDefinition
{
    public partial class EditSlide : UserControl
    {
        bool IsDataBinding = false;

        public Slide Slide { get; internal set; }

        public Action ToSave = null;

        protected void OnSave()
        {
            ToSave?.Invoke();
            IsDirty = false;
        }

        PenDraw pd;

        public static readonly int DrawWidth = 1600;
        public static readonly int DrawHeight = 1200;

        public EditSlide()
        {
            InitializeComponent();

            DoubleBuffered = true;
            pd = new PenDraw();

            pictureBox1.Left = 3;
            pictureBox1.Top = 3;
            pictureBox1.Size = new Size(DrawWidth, DrawHeight);
            pictureBox1.AllowDrop = true;


            this.Disposed += EditSlide_Disposed;

            HotkeyControl.RegisterHotkeyHwnd(Handle);

            bool ignoreFailedRegistration = false;
            bool raiseSendKeys = false;

            if (!RegisterWrapper(Keys.Alt, Keys.Oemtilde, Handle, () => {
                chUsePen.Checked = !chUsePen.Checked;
            }, ignoreFailedRegistration)) { }

            if (!RegisterWrapper(Keys.Alt, Keys.D1, Handle, () => {
                if (chUsePen.Checked)
                {
                    rdoPen.Checked = true;

                    if (raiseSendKeys == false)
                    {
                        raiseSendKeys = true;
                        SendKeys.SendWait("%{1}");
                    }
                    raiseSendKeys = false;
                }
            }, ignoreFailedRegistration)) { }

            if (!RegisterWrapper(Keys.Alt, Keys.D2, Handle, () => {
                if (chUsePen.Checked)
                {
                    rdoErase.Checked = true;
                    if (raiseSendKeys == false)
                    {
                        raiseSendKeys = true;
                        SendKeys.SendWait("%{2}");
                    }
                    raiseSendKeys = false;
                }
            }, ignoreFailedRegistration)) { }
        }

        private void EditSlide_Disposed(object sender, EventArgs e)
        {
            pd.SaveImage(true);
            using (pd) { }
            Slide = null;

            UnregisterHotkeys();
        }

        [DllImport("user32.dll")]
        private static extern uint GetMessageExtraInfo();

        internal void SetDocumentName(string nm)
        {
            txtTitle.Text = nm;
        }

        /// <summary>
        /// Determines what input device triggered the mouse event.
        /// </summary>
        /// <returns>
        /// A result indicating whether the last mouse event was triggered
        /// by a touch, pen or the mouse.
        /// </returns>
        public static TabletDeviceKind GetMouseEventSource()
        {
            //터치인지 펜인지 구분
            //https://www.codefull.org/2015/07/distinguish-between-touchpen-and-mouse-input-in-winforms/
            uint extra = GetMessageExtraInfo();
            bool isTouchOrPen = ((extra & 0xFFFFFF00) == 0xFF515700);

            if (!isTouchOrPen)
                return TabletDeviceKind.Mouse;

            bool isTouch = ((extra & 0x00000080) == 0x00000080);

            return isTouch ? TabletDeviceKind.Touch : TabletDeviceKind.Pen;
        }


        int delayTime = 2 * 1000; // 3초
        bool IsSaving = false;

        internal bool IsDirty = false;
        internal void TriggerSaving()
        {
            IsDirty = true;
            delayTime = 2 * 1000;
            // 시간차 ( 10초 이내 입력 없으면 초기화 )
            if (IsSaving == false)
            {
                pnlBottom.BackColor = Color.Coral;
                IsSaving = true;
                Ux.AsyncCall(() => RaiseOnSaving());
            }
        }

        private void RaiseOnSaving()
        {
            while (0 < delayTime)
            {
                System.Threading.Thread.Sleep(200);
                delayTime -= 200;
            }
            this.DoInvoke(fm =>
            {
                OnSave();
                pnlBottom.BackColor = SystemColors.Control;
            });
            IsSaving = false;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            Slide.Title = txtTitle.Text;
            TriggerSaving();
        }

        internal void SetData(Slide slide, int pgIndex = 0)
        {
            if (pd.ImageDataChanged)
            {
                pd.SaveImage(true);
            }
            IsDataBinding = true;
            Enabled = slide != null;

            try
            {
                Slide = slide;
                pd.Init(pictureBox1, DrawWidth, DrawHeight);
                pd.BackgroundImagePath = null;
                lbPenColor.BackColor = Color.OrangeRed;
                pd.SetPen(lbPenColor.BackColor, pd.PenWidth);

                PageIndex = pgIndex;

                chUsePen.Checked = false;
                rdoErase.Enabled = chUsePen.Checked;
                btnAllErase.Enabled = chUsePen.Checked;
                lbPenColor.Enabled = chUsePen.Checked;
                rdoPen.Enabled = chUsePen.Checked;
                tbPenWidth.Enabled = chUsePen.Checked;
                pd.Enabled = chUsePen.Checked;

                ClearMemos();

                if (Slide != null)
                {
                    txtTitle.Text = Slide.Title; txtTitle.ReadOnly = false;
                    pictureBox1.Enabled = true;

                    var grff = Get();
                    txtTip.Text = grff.Tip;
                    pd.ImagePath = grff.ImagePath;
                    pd.BackgroundImagePath = grff.BackgroundImagePath; // 화면캡쳐, 디자인 캡쳐.

                    try
                    {
                        foreach (Memo mm in grff.Memos)
                        {
                            EditMemo em = new EditMemo();
                            em.SetData(mm);
                            pnlMemo.Controls.Add(em);
                            em.Dock = DockStyle.Top;
                            em.BringToFront();
                            em.ToSave = () =>
                            {
                                TriggerSaving();
                                foreach (NumberMemo nmm in pictureBox1.Controls)
                                {
                                    nmm.SetData(nmm.Data);
                                }
                            };
                            em.ToDelNumber = (_mm) =>
                            {
                                for (int loop = pictureBox1.Controls.Count - 1; loop >= 0; loop--)
                                {
                                    NumberMemo nmm = pictureBox1.Controls[loop] as NumberMemo;
                                    if (nmm != null)
                                    {
                                        if (nmm.Data.ID == _mm.ID)
                                        {
                                            using (nmm)
                                            {
                                                pictureBox1.Controls.Remove(nmm);
                                                nmm.Move -= Nummm_Move;
                                                nmm.StateChanged -= Nummm_StateChanged;
                                            }
                                            _mm.UseNumber = false;
                                            TriggerSaving();
                                            // break;
                                        }
                                    }
                                }
                            };

                            if (mm.UseNumber)
                            {
                                NumberMemo nummm = new NumberMemo();
                                pictureBox1.Controls.Add(nummm);
                                nummm.SetData(mm);
                                nummm.Move += Nummm_Move;
                                nummm.StateChanged += Nummm_StateChanged;
                            }
                            em.Focus();
                        }
                    }
                    finally
                    {

                    }
                }
                else
                {
                    pictureBox1.Enabled = false;
                    txtTitle.Clear(); txtTitle.ReadOnly = true;
                }
                Parent.Focus();
            }
            finally
            {
                IsDataBinding = false;
            }
        }

        private void Nummm_StateChanged()
        {
            TriggerSaving();
        }

        private void Nummm_Move(object sender, EventArgs e)
        {
            TriggerSaving();
        }

        internal void ClearMemos()
        {
            try
            {
                pictureBox1.SuspendLayout();
                pnlMemo.SuspendLayout();
                for (int loop = pnlMemo.Controls.Count - 1; loop >= 0; loop--)
                {
                    EditMemo emm = pnlMemo.Controls[loop] as EditMemo;
                    if (emm != null)
                    {
                        using (emm)
                        {
                            pnlMemo.Controls.Remove(emm);
                            emm.ToSave = null;
                            emm.ToDelNumber = null;
                        }
                    }
                }

                for (int loop = pictureBox1.Controls.Count - 1; loop >= 0; loop--)
                {
                    NumberMemo nmm = pictureBox1.Controls[loop] as NumberMemo;
                    if (nmm != null)
                    {
                        using (nmm)
                        {
                            nmm.Move -= Nummm_Move;
                            nmm.StateChanged -= Nummm_StateChanged;
                            pictureBox1.Controls.Remove(nmm);
                        }
                    }
                }
            }
            finally
            {
                pictureBox1.ResumeLayout(false);
                pnlMemo.ResumeLayout(false);
            }
        }

        Graffity CurrentGraffity { get; set; } = null;

        public int PageIndex { get; set; } = 0;

        public void GoLeft()
        {
            if (0 <= (PageIndex - 1))
            {
                OnSave();
                pd.SaveImage(true);
                pd.ClearQue();
                PageIndex--;
                var grff = Get();

                SetData(Slide, PageIndex);
                 
                if (rdoErase.Checked)
                {
                    pd.SetEraser();
                    tbPenWidth.Enabled = false;
                }
                else
                {
                    pd.SetPen(lbPenColor.BackColor, tbPenWidth.Value);
                    tbPenWidth.Enabled = true;
                }

                Parent.Focus();
            }
        }

        public bool GoRight()
        {
            bool isNew = false;
            if (Slide.Graffities.Count <= (PageIndex + 1))
            {
                // 새로 만듬
                Slide.CreateGrffity(CurrentGraffity);
                isNew = true;
            }

            if ((PageIndex + 1) < Slide.Graffities.Count)
            {
                OnSave();
                pd.SaveImage(true);
                pd.ClearQue();

                PageIndex++;
                var grff = Get();

                SetData(Slide, PageIndex);
                 
                if (rdoErase.Checked)
                {
                    pd.SetEraser();
                    tbPenWidth.Enabled = false;
                }
                else
                {
                    pd.SetPen(lbPenColor.BackColor, tbPenWidth.Value);
                    tbPenWidth.Enabled = true;
                }
                if (isNew)
                {
                    btnSetBackGroundImage.PerformClick();
                }
                Parent.Focus();
            }
            return isNew;
        }

        internal Graffity Get()
        {
            CurrentGraffity = Slide.Graffities[PageIndex];
            lbLRIndex.Text = $"{PageIndex + 1,3}/{ Slide.Graffities.Count,3}";
            return CurrentGraffity;
        }

        private void rdoPen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPen.Checked)
            {
                pd.SetPen(lbPenColor.BackColor, tbPenWidth.Value);
                tbPenWidth.Enabled = true;
                pictureBox1.Invalidate();
            }
            Log($"rdoPen.Checked={rdoPen.Checked}");
        }

        private void rdoErase_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoErase.Checked)
            {
                pd.SetEraser();
                tbPenWidth.Enabled = false;
                pictureBox1.Invalidate();
            }
            Log($"rdoErase.Checked={rdoErase.Checked}");
        }

        private void tbPenWidth_Scroll(object sender, EventArgs e)
        {
            pd.SetPen(pd.Color, tbPenWidth.Value);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            GoLeft();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if ((Slide.Graffities.Count <= (PageIndex + 1)) &&
                MessageBox.Show("다음 페이지를 생성?", "추가",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            GoRight();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("전체 지우기?", "전체 지우기", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            pd.ClearQue();
            pd.AllErase();
            pictureBox1.Invalidate();
        }

        private void txtTip_TextChanged(object sender, EventArgs e)
        {
            if (IsDataBinding) return;

            CurrentGraffity.Tip = txtTip.Text;
            TriggerSaving();
        }

        private void btnDelMemoOK_Click(object sender, EventArgs e)
        {
            List<EditMemo> dels = new List<EditMemo>();
            foreach (EditMemo emm in pnlMemo.Controls)
            {
                if (emm.IsDelete)
                {
                    dels.Add(emm);
                }
                emm.UseDelete(false);
            }

            if (0 < dels.Count)
            {
                for (int loop = dels.Count - 1; loop >= 0; loop--)
                {
                    using (dels[loop])
                    {
                        dels[loop].ToSave = null;
                        CurrentGraffity.Memos.Remove(dels[loop].Data);
                        // 연결된 number 컨트롤 삭제
                        for (int loop2 = pictureBox1.Controls.Count - 1; loop2 >= 0; loop2--)
                        {
                            NumberMemo nmm = pictureBox1.Controls[loop2] as NumberMemo;
                            if (nmm != null)
                            {
                                if (nmm.Data.ID == dels[loop].Data.ID)
                                {
                                    using (nmm)
                                    {
                                        pictureBox1.Controls.Remove(nmm);
                                        nmm.Move -= Nummm_Move;
                                        nmm.StateChanged -= Nummm_StateChanged;
                                    }
                                    //break;
                                }
                            }
                        }
                    }
                }
                int idx = 1;
                foreach (EditMemo emm in pnlMemo.Controls)
                {
                    emm.SetNumber(idx);
                    // 연결된 number 컨트롤 업데이트. 
                    for (int loop2 = pictureBox1.Controls.Count - 1; loop2 >= 0; loop2--)
                    {
                        NumberMemo nmm = pictureBox1.Controls[loop2] as NumberMemo;
                        if (nmm != null)
                        {
                            if (nmm.Data.ID == emm.Data.ID)
                            {
                                nmm.SetData(emm.Data);
                                break;
                            }
                        }
                    }
                    idx++;
                }
                TriggerSaving();
            }
            btnAddMemo.BringToFront();
            btnDelMemo.BringToFront();
        }

        private void btnDelMemoCancel_Click(object sender, EventArgs e)
        {
            foreach (EditMemo emm in pnlMemo.Controls)
            {
                emm.UseDelete(false);
            }
            btnAddMemo.BringToFront();
            btnDelMemo.BringToFront();
        }

        private void btnAddMemo_Click(object sender, EventArgs e)
        {
            Memo mm = new Memo();

            CurrentGraffity.Memos.Add(mm);
            mm.Number = CurrentGraffity.Memos.Count;
            EditMemo em = new EditMemo();
            em.SetData(mm);
            pnlMemo.Controls.Add(em);
            em.Dock = DockStyle.Top;
            em.BringToFront();
            em.ToSave = () =>
            {
                TriggerSaving();
                foreach (NumberMemo nmm in pictureBox1.Controls)
                {
                    nmm.SetData(nmm.Data);
                }
            };
            em.ToDelNumber = (_mm) =>
            {
                for (int loop = pictureBox1.Controls.Count - 1; loop >= 0; loop--)
                {
                    NumberMemo nmm = pictureBox1.Controls[loop] as NumberMemo;
                    if (nmm != null)
                    {
                        if (nmm.Data.ID == _mm.ID)
                        {
                            using (nmm)
                            {
                                pictureBox1.Controls.Remove(nmm);
                                nmm.Move -= Nummm_Move;
                                nmm.StateChanged -= Nummm_StateChanged;
                            }
                            _mm.UseNumber = false;
                            TriggerSaving();
                            //break;
                        }
                    }
                }
            };
            em.Focus();
            TriggerSaving();
        }

        private void btnDelMemo_Click(object sender, EventArgs e)
        {
            btnDelMemoOK.BringToFront();
            btnDelMemoCancel.BringToFront();

            foreach (EditMemo emm in pnlMemo.Controls)
            {
                emm.UseDelete(true);
            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.AllowedEffect == DragDropEffects.Link)
            {
                e.Effect = e.AllowedEffect;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Link)
            {
                Memo mm = e.Data.GetData(typeof(Memo)) as Memo;
                if (mm != null)
                {
                    NumberMemo nmm = new NumberMemo();
                    pictureBox1.Controls.Add(nmm);
                    mm.UseNumber = true;
                    nmm.SetData(mm);
                    Point pt = pictureBox1.PointToClient(new Point(e.X, e.Y));
                    nmm.Left = pt.X;
                    nmm.Top = pt.Y;
                    nmm.Move += Nummm_Move;
                    nmm.StateChanged += Nummm_StateChanged;
                    TriggerSaving();
                }
            }
        }

        private void lbPenColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog1 = new ColorDialog())
            {
                colorDialog1.Color = lbPenColor.BackColor;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    lbPenColor.BackColor = colorDialog1.Color;
                    pd.SetPen(lbPenColor.BackColor, tbPenWidth.Value);
                    rdoPen.Checked = true;
                    tbPenWidth.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUIDesign_Click(object sender, EventArgs e)
        {
            // 디자이너
            using (UIDesigner designer = new UIDesigner())
            {
                //string oldGraffityBackGroundImagePath = CurrentGraffity.BackgroundImagePath;
                //string oldBackgroundImagePath = pd.BackgroundImagePath;
                //pd.BackgroundImagePath = null; //백그라운드 사용 중에 스샷 저장이 안됨.
                //string backgroundImagePath = Slide.BackgroundImagePath;
                int ssWidth = Slide.ScreenSize?.Width ?? 0;
                int ssHeight = Slide.ScreenSize?.Height ?? 0;
                designer.SetData(Slide);
                {
                    designer.WindowState = this.FindForm()?.WindowState ?? FormWindowState.Normal;
                }

                designer.Location = this.FindForm().Location;
                designer.Size = this.FindForm().Size;

                this.FindForm().Hide();
                designer.ShowDialog(this.FindForm());
                this.FindForm().Show();

                //if (Slide.DesignChanged &&
                //    !string.IsNullOrWhiteSpace(oldGraffityBackGroundImagePath) &&
                //    (Slide.BackgroundImagePath ?? "").EndsWith(".SCREEN.png"))
                //{
                //    //디자인이 바뀜... ( 배경이미지 경로는 동일하고!! )
                //    pd.BackgroundImagePath = Slide.BackgroundImagePath;
                //}

                //if (!string.IsNullOrWhiteSpace(oldBackgroundImagePath))
                //{
                //    pd.BackgroundImagePath = oldBackgroundImagePath;
                //}

                //if (!string.IsNullOrWhiteSpace(oldGraffityBackGroundImagePath))
                //{
                //    CurrentGraffity.BackgroundImagePath = Slide.BackgroundImagePath;
                //}

                //if (backgroundImagePath != Slide.BackgroundImagePath ||
                //   (ssWidth != Slide.ScreenSize.Width || ssHeight != Slide.ScreenSize.Height))
                //{
                //    TriggerSaving();
                //}
            }
        }

        private void btnSetBackGroundImage_Click(object sender, EventArgs e)
        {
            // 배경이미지 변경 !!!
            // [삭제], 사진, 캡쳐, 디자인된 화면적용.
            using (SetBackgroundImageFm sbi = new SetBackgroundImageFm())
            {
                sbi.SetData(Slide, CurrentGraffity);
                if (sbi.ShowDialog(this) == DialogResult.OK)
                {
                    string path = sbi.ImagePath;

                    if (sbi.needCopyFile || sbi.dirtyDesignCapture)
                    {
                        string ext = Path.GetExtension(path);
                        string newPath = "";
                        do
                        {
                            newPath = $"{MainForm.__ROOT_DIR}{Slide.ScreenDocumentID}\\{Slide.ID}\\{Guid.NewGuid().ToString("N")}{ext}";
                        } while (File.Exists(newPath));
                        File.Copy(path, newPath, true);
                        path = newPath;
                    }

                    bool isDiff = false;
                    isDiff |= pd.BackgroundImagePath != path;
                    isDiff |= CurrentGraffity.BackgroundImagePath != path;
                    if (isDiff)
                    {
                        pd.BackgroundImagePath = path;
                        CurrentGraffity.BackgroundImagePath = path;
                        TriggerSaving();
                    }
                }
            }
        }

        private void btnDelGraffity_Click(object sender, EventArgs e)
        {
            if (CurrentGraffity != null)
            {
                if ("그림 삭제?".Confirm() != DialogResult.Yes) return;

                //낙서판을 삭제하면서 
                //에러를 예외처리함( 따로 알고리즘 없음 )


                string beforeEmptyAndBackGroundImage = CurrentGraffity.BackgroundImagePath;
                Slide.Graffities.Remove(CurrentGraffity);

                if (Slide.Graffities.Count <= PageIndex)
                {
                    PageIndex--;
                }
                pd.BackgroundImagePath = null;
                pd.ImagePath = null;
                txtTip.Text = "";

                ClearMemos();

                if (File.Exists(CurrentGraffity.ImagePath))
                {
                    File.Delete(CurrentGraffity.ImagePath);                    
                }
                CurrentGraffity = null;

                if (0 <= PageIndex && 0 < Slide.Graffities.Count)
                {
                    CurrentGraffity = Get();
                }

                if (CurrentGraffity == null)
                {
                    Slide.CreateGrffity();
                    bool needBeforeImageSettings = false;
                    if (PageIndex < 0 && 0 < Slide.Graffities.Count)
                    {
                        PageIndex++;
                        needBeforeImageSettings = PageIndex == 0;
                    }
                    CurrentGraffity = Get();
                    if (needBeforeImageSettings)
                    {
                        CurrentGraffity.BackgroundImagePath = beforeEmptyAndBackGroundImage;
                    } 
                }

                SetData(Slide);
                TriggerSaving();
                 
                Invalidate(true);
            }
        }

        private void chUsePen_CheckedChanged(object sender, EventArgs e)
        {
            if (chUsePen.Checked)
            {
                chUsePen.BackgroundImage = Resources.UnLock;
            }
            else
            {
                chUsePen.BackgroundImage = Resources.Lock;
            }
            rdoErase.Enabled = chUsePen.Checked;
            btnAllErase.Enabled = chUsePen.Checked;
            lbPenColor.Enabled = chUsePen.Checked;
            rdoPen.Enabled = chUsePen.Checked;
            rdoPen.Checked = chUsePen.Checked;
            tbPenWidth.Enabled = chUsePen.Checked;
            pd.Enabled = chUsePen.Checked;
        }

        private void btnFirstMove_Click(object sender, EventArgs e)
        {
            // 대표 낙서페이지로 이동.
            if (Slide == null) return;
            if (CurrentGraffity == null) return;

            if (MessageBox.Show("대표 이미지로 옮기시겠습니까?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            if (Slide.Graffities.Any(g => g == CurrentGraffity))
            {
                Slide.Graffities.Remove(CurrentGraffity);
                Slide.Graffities.Insert(0, CurrentGraffity);
                PageIndex = 0;
                CurrentGraffity = Get();
                SetData(Slide);
                TriggerSaving();
            }
        }

        internal void Log(object msg, [System.Runtime.CompilerServices.CallerMemberName] string memName = "")
        {
            System.Diagnostics.Debug.WriteLine($"[{memName}] {msg}");
        }



        #region 단축키 --------------------------------------------------------------------
        protected override void WndProc(ref Message m)
        {
            if (HandleMessages(ref m))
            {
                return;
            }
            // BUG-1809 prevention, filter the InputLangChange messages
            if (PreFilterMessageExternal(ref m))
            {
                return;
            }
            base.WndProc(ref m);
        }

        public static void UnregisterHotkeys()
        {
            foreach (int hotkey in KeyHandlers.Keys)
            {
                UnregisterHotKey(_hotkeyHwnd, hotkey);
            }
            // Remove all key handlers
            KeyHandlers.Clear();
        }

        /// <summary>
        /// Also used in the MainForm WndProc
        /// </summary>
        /// <param name="m">Message</param>
        /// <returns>true if the message should be filtered</returns>
        public static bool PreFilterMessageExternal(ref Message m)
        {
            WindowsMessages message = (WindowsMessages)m.Msg;
            if (message == WindowsMessages.WM_INPUTLANGCHANGEREQUEST || message == WindowsMessages.WM_INPUTLANGCHANGE)
            {
                // For now we always return true
                return true;
                // But it could look something like this:
                //return (m.LParam.ToInt64() | 0x7FFFFFFF) != 0;
            }
            return false;
        }

        /// <summary>
        /// Handle WndProc messages for the hotkey
        /// </summary>
        /// <param name="m"></param>
        /// <returns>true if the message was handled</returns>
        public static bool HandleMessages(ref Message m)
        {
            if (m.Msg != WM_HOTKEY)
            {
                return false;
            }

            HotKeyHandler handler;
            if (KeyHandlers.TryGetValue((int)m.WParam, out handler))
            {
                handler();
            }
            return true;
        }

        // Delegates for hooking up events.
        public delegate void HotKeyHandler();

        private static bool RegisterWrapper(Keys modifierKeyCode, Keys virtualKeyCode, IntPtr _hotkeyHwnd, HotKeyHandler handler, bool ignoreFailedRegistration)
        {
            int success = RegisterHotKey(modifierKeyCode, virtualKeyCode, _hotkeyHwnd, handler);
            return 0 < success;
        }

        // Holds the list of hotkeys
        private static readonly IDictionary<int, HotKeyHandler> KeyHandlers = new Dictionary<int, HotKeyHandler>();
        private static int _hotKeyCounter = 1;
        private const uint WM_HOTKEY = 0x312;
        private static IntPtr _hotkeyHwnd;

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public enum Modifiers : uint
        {
            NONE = 0,
            ALT = 1,
            CTRL = 2,
            SHIFT = 4,
            WIN = 8,
            NO_REPEAT = 0x4000
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint virtualKeyCode);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int GetKeyNameText(uint lParam, [Out] StringBuilder lpString, int nSize);

        /// <summary>
        /// Register a hotkey
        /// </summary>
        /// <param name="modifierKeyCode">The modifier, e.g.: Modifiers.CTRL, Modifiers.NONE or Modifiers.ALT</param>
        /// <param name="virtualKeyCode">The virtual key code</param>
        /// <param name="handler">A HotKeyHandler, this will be called to handle the hotkey press</param>
        /// <returns>the hotkey number, -1 if failed</returns>
        public static int RegisterHotKey(Keys modifierKeyCode, Keys virtualKeyCode, IntPtr _hotkeyHwnd, HotKeyHandler handler)
        {
            if (virtualKeyCode == Keys.None)
            {

                return 0;
            }
            // Convert Modifiers to fit HKM_SETHOTKEY
            uint modifiers = 0;
            if ((modifierKeyCode & Keys.Alt) > 0)
            {
                modifiers |= (uint)Modifiers.ALT;
            }
            if ((modifierKeyCode & Keys.Control) > 0)
            {
                modifiers |= (uint)Modifiers.CTRL;
            }
            if ((modifierKeyCode & Keys.Shift) > 0)
            {
                modifiers |= (uint)Modifiers.SHIFT;
            }
            if (modifierKeyCode == Keys.LWin || modifierKeyCode == Keys.RWin)
            {
                modifiers |= (uint)Modifiers.WIN;
            }
            // Disable repeating hotkey for Windows 7 and beyond, as described in #1559
            //if (IsWindows7OrOlder)
            //{
            //    modifiers |= (uint)Modifiers.NO_REPEAT;
            //}
            if (RegisterHotKey(_hotkeyHwnd, _hotKeyCounter, modifiers, (uint)virtualKeyCode))
            {
                KeyHandlers.Add(_hotKeyCounter, handler);
                return _hotKeyCounter++;
            }
            else
            {
                return -1;
            }
        }
        #endregion 단축키 --------------------------------------------------------------------
    }


    //internal class MouseRightButtonClickMessageFilter : IMessageFilter
    //{
    //    internal Action<Message> RiaseClick = null;

    //    public bool PreFilterMessage(ref Message m)
    //    {
    //        if (m.Msg == 0x7b || m.Msg == 0x204 || m.Msg == 0x205)
    //        {
    //            if (m.Msg == 0x204 || m.Msg == 0x205) // right button Mousedown | Mouseup
    //            {
    //                RiaseClick?.Invoke(m);
    //            }
    //            return true;
    //        }
    //        return false;
    //    }
    //}
}
