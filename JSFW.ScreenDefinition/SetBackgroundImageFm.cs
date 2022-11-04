using Greenshot.Destinations;
using Greenshot.Helpers;
using Greenshot.IniFile;
using GreenshotPlugin.Core;
using GreenshotPlugin.UnmanagedHelpers;
using JSFW.ScreenDefinition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW
{
    public partial class SetBackgroundImageFm : Form
    {
        public string ImagePath { get => lbImagePath.Text.TrimEnd(); }

        public bool dirtyDesignCapture = false;

        string _DesignFilePath { get; set; }

        private SetBackgroundImageFm() 
        {
            InitializeComponent();
            this.Disposed += SetBackgroundImageFm_Disposed;
        }

        public SetBackgroundImageFm( string capture_dir) : this()
        {
            
            IniConfig.Init();
            Greenshot.MainForm._conf = IniConfig.GetIniSection<CoreConfiguration>();
            Greenshot.MainForm._conf.Language = "ko-KR";
            Language.CurrentLanguage = "ko-KR";

            Greenshot.MainForm._conf.OutputDestinations.Clear();
            //Greenshot.MainForm._conf.OutputDestinations.Add(EditorDestination.DESIGNATION);
            Greenshot.MainForm._conf.OutputDestinations.Add(FileDestination.DESIGNATION);
            Greenshot.MainForm._conf.OutputDestinations.Add(ClipboardDestination.DESIGNATION);
            Greenshot.MainForm._conf.OutputFilePath = __CAPTURE_DIR = capture_dir;
            Greenshot.MainForm._conf.IECapture = true;
            Greenshot.MainForm._conf.CaptureDelay = 600;

            string LogFileLocation; LogFileLocation = LogHelper.InitializeLog4Net();

            IniConfig.Save();

            bool ignoreFailedRegistration = false;

            GreenshotPlugin.Controls.HotkeyControl.RegisterHotkeyHwnd(Handle);

            //if (!RegisterWrapper(Keys.Alt, Keys.PrintScreen, this.Handle, CaptureWin, ignoreFailedRegistration))
            //{
            //}

            ////Ctrl + Shift + PrintScreen
            //if (!RegisterWrapper(Keys.Control | Keys.Shift, Keys.PrintScreen, this.Handle, CaptureIE, ignoreFailedRegistration))
            //{

            //}
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UnregisterHotkeys();
            base.OnFormClosed(e);
        }

        private void SetBackgroundImageFm_Disposed(object sender, EventArgs e)
        {
            using (pictureBox1.Image) { }
            pictureBox1.Image = null;
        }


        internal string __CAPTURE_DIR { get; private set; }

        public void SetData(Slide slide, Graffity graffity)
        { 
            _DesignFilePath = slide.BackgroundImagePath;
            lbImagePath.Text = graffity.BackgroundImagePath;
            needCopyFile = false;
            dirtyDesignCapture = false;
        }
 
        private void btnEmpty_Click(object sender, EventArgs e)
        {
            lbImagePath.Text = "";
            needCopyFile = false;
            dirtyDesignCapture = false;
        }

        private void btnDesignFile_Click(object sender, EventArgs e)
        {
            lbImagePath.Text = _DesignFilePath;
            needCopyFile = false;
            dirtyDesignCapture = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public bool needCopyFile = false;
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    lbImagePath.Text = ofd.FileName;
                    needCopyFile = true;
                }
            }
        }

        private void lbImagePath_TextChanged(object sender, EventArgs e)
        {
            string filepath = lbImagePath.Text.TrimEnd();

            using (pictureBox1.Image) { }
            pictureBox1.Image = null;
            GC.Collect();

            if (string.IsNullOrWhiteSpace(filepath)) return;

            if (File.Exists(filepath) == false) return;

            using( Image img = Image.FromFile( filepath))
            {
                pictureBox1.Image = img.Clone() as Image;
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            // 캡쳐! 
            try
            {
                CaptureHelper.Install(Handle);
                CaptureHelper.CaptureRegion(true);
            }
            finally
            {
                CaptureHelper.UnInstall(); 

                lbImagePath.Text = Greenshot.MainForm._conf.OutputFileAsFullpath;

                using (Image img = Image.FromFile(lbImagePath.Text))
                {
                    using (pictureBox1.Image) { }
                    pictureBox1.Image = null;
                    GC.Collect();

                    pictureBox1.Image = img.Clone() as Image;
                }
                dirtyDesignCapture = true; // guid로 차후 본 폴더로 복사 됨.
            }
        }

        #region 그린 샷!!!

        void CaptureWin()
        {
            try
            { 
                CaptureHelper.Install(Handle);
                if (Greenshot.MainForm._conf.CaptureWindowsInteractive)
                {
                    CaptureHelper.CaptureWindowInteractive(true);
                }
                else
                {
                    CaptureHelper.CaptureWindow(true);
                }
            }
            finally
            {
                CaptureHelper.UnInstall(); 
            }
        }

        private void CaptureIE()
        { 
            try
            {
                CaptureHelper.Install(Handle);
                CaptureHelper.CaptureIe(true, null);
            }
            finally
            {
                CaptureHelper.UnInstall(); 
            }
        }

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

        #endregion

        private void rdoNomal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNomal.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void rdoStretchImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoStretchImage.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
