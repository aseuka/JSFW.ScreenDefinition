using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Ink;
using Microsoft.StylusInput;
using Microsoft.StylusInput.PluginData;

namespace JSFW.ScreenDefinition
{
    public class PenDraw : IStylusAsyncPlugin, IDisposable
    {
        //참조 : Microsoft.Ink : c:\Windows\assembly\GAC_64\Microsoft.Ink\6.1.0.0__31bf3856ad364e35\Microsoft.Ink.dll
        //참조 : Microsoft.StylusInput : IStylusAsyncPlugin 구현하려고 참조
        //참조 : Microsoft.StylusInput.PluginData : IStylusAsyncPlugin 구현하려고 참조

        /*
            using Microsoft.Ink;
            using Microsoft.StylusInput;
            using Microsoft.StylusInput.PluginData; 
        */

        // 펜사용시 손바닥 인식 .. 관련해서는 
        // 윈도우10에서 지원하는 기능 설정으로 사용해보자
        // 검색 "펜 설정"  항목 중에 "펜을 사용하는 동안 터치 입력 무시" 옵션을 체크하고 사용하니 그나마... 괜찮다. 

        RealTimeStylus realTimeStylus = null;
        Bitmap bmp = null;
        DynamicRenderer dr = null;

        public bool ImageDataChanged = false;

        System.Windows.Forms.PictureBox HostControl = null;

        public int Width { get; protected set; }
        public int Height { get; protected set; }

        string _BackgroundImagePath = "";
        public string BackgroundImagePath
        {
            get { return _BackgroundImagePath; }
            set
            {
                if (HostControl != null)
                {
                    using (HostControl.BackgroundImage) { }
                    HostControl.BackgroundImage = null;

                    _BackgroundImagePath = value;

                    if (File.Exists(value))
                    {
                        using (Image back = Image.FromFile(value))
                        {
                            if (HostControl.Height < back.Height ||
                                 HostControl.Width < back.Width)
                            {
                                HostControl.BackgroundImageLayout = ImageLayout.None;
                            }
                            else
                            {
                                HostControl.BackgroundImageLayout = ImageLayout.None;
                            }
                            HostControl.BackgroundImage = back.Clone() as Image;
                        }

                        if (bmp != null)
                        {
                            // 배경바꾸고 새로 드로잉 해줘야 함. : 드로잉 하던중에 배경을 바꾸면 드로잉한게 안보임.
                            using (var g = Graphics.FromImage(bmp))
                            {
                                dr.Draw(g);
                            }
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.Assert(true, "배경이미지 파일이 존재하지 않음.");
                    }
                    realTimeStylus.ClearStylusQueues();
                    HostControl.Invalidate();
                }
            }
        }

        string _ImagePath = "";
        public string ImagePath
        {
            get { return _ImagePath; }
            set
            {
                _ImagePath = value;
                InitBitmap();
            }
        }

        public bool Enabled
        {
            get
            {
                if (dr == null) return false;
                return dr.Enabled;
            }
            set
            {
                if (dr != null)
                {
                    dr.Enabled = value;
                }
            }
        }

        public void Init(System.Windows.Forms.PictureBox picture, int width = 1024, int height = 768)
        {
            this.Width = width;
            this.Height = height;

            if (picture == null)
            {
                return;
            }

            if (HostControl != null)
            {
                //HostControl.MouseDown -= Ctrl_MouseDown;
                HostControl.MouseUp -= Ctrl_MouseUp;
            }

            HostControl = picture;

            if (HostControl != null)
            {
                //HostControl.MouseDown -= Ctrl_MouseDown;
                HostControl.MouseUp -= Ctrl_MouseUp;
                HostControl.MouseUp += Ctrl_MouseUp;
                //HostControl.MouseDown += Ctrl_MouseDown;

                HostControl.Paint += HostControl_Paint;
                InitStylus();
            }
        }
  
        private void HostControl_Paint(object sender, PaintEventArgs e)
        {
            dr.Draw(e.Graphics);
            dr.EnableDataCache = false;
            dr.EnableDataCache = true;
        }

        //bool IsEraseDown = false;
        //private void Ctrl_MouseDown(object sender, MouseEventArgs e)
        //{
        //    IsEraseDown = e.Button == MouseButtons.Right &&
        //        dr.DrawingAttributes.RasterOperation == RasterOperation.MergePen; // 지우개
        //}

        private void Ctrl_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //  if (dr.DrawingAttributes.Color == Color.White)
            {
                try
                { 
                    HostControl.SuspendLayout();
                    ImageDataChanged = true;
                    SaveImage(false);
                }
                finally
                {
                    dr.EnableDataCache = false;
                    dr.EnableDataCache = true;
                    HostControl.ResumeLayout(false);
                    HostControl.PerformLayout();
                }
            }
        }

        internal void Refresh()
        {
            dr.Refresh();
        }


        internal void InitStylus()
        {
            using (realTimeStylus)
            {
            }

            using (dr)
            {
            }

            realTimeStylus = new RealTimeStylus(HostControl, true);
            dr = new DynamicRenderer(HostControl);
            SetPen(Color.Black, 90);
            dr.EnableDataCache = true;

            GestureRecognizer gr = null;
            try
            {
                gr = new GestureRecognizer();
                ApplicationGesture[] gestures = { ApplicationGesture.AllGestures };
                gr.EnableGestures(gestures);
                realTimeStylus.SyncPluginCollection.Add(gr);
            }
            catch
            {
            }

            realTimeStylus.SyncPluginCollection.Add(dr);
            realTimeStylus.AsyncPluginCollection.Add(this);
            realTimeStylus.FlicksEnabled = true;
            realTimeStylus.MultiTouchEnabled = true;
            realTimeStylus.Enabled = true;
            dr.Enabled = true;
            HostControl.BackColor = Color.Transparent;
        }

        private void InitBitmap()
        {
            using (bmp)
            {
                if (HostControl != null) HostControl.Image = null;
            }
            bmp = null;

            GC.Collect();

            if (HostControl == null)
            {
                return;
            }

            if (File.Exists(_ImagePath))
            {
                bmp = Bitmap.FromFile(_ImagePath, true) as Bitmap;
            }

            if (bmp == null && !string.IsNullOrWhiteSpace(_ImagePath))
            {
                bmp = new Bitmap(Width, Height);
                bmp.Save(_ImagePath, System.Drawing.Imaging.ImageFormat.Png);
            }
           
            HostControl.Image = bmp;
            bmp?.MakeTransparent(Color.Transparent);
        }

        public void SaveImage(bool isSave)
        {
            if (bmp == null)
            {
                InitBitmap();
            }

            if (bmp != null)
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    dr.Draw(g);
                    realTimeStylus.ClearStylusQueues();
                }
                 
                RefreshImage(isSave);
            }
        }

        private void RefreshImage(bool isSave)
        {
            if (bmp != null)
            {
                Bitmap saveImage = null; // bmp로 전달.

                using (bmp)
                {
                    bmp.MakeTransparent(Color.Transparent);
                    if (isSave && File.Exists(_ImagePath))
                    {
                        bmp.Save(_ImagePath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    if (File.Exists(_ImagePath) == false)
                    {
                        System.Diagnostics.Debug.Print("저장대상 파일경로가 없음.");
                    }

                    HostControl.Image = null;
                    saveImage = bmp.Clone() as Bitmap;
                    HostControl.Image = saveImage;
                    HostControl.Invalidate();
                    bmp.Dispose();
                }
                // bmp 재 할당.
                bmp = saveImage;
                bmp.MakeTransparent();
                saveImage = null;
                GC.Collect();
            }
        }
         
        internal void ClearQue()
        {
            dr.EnableDataCache = false;
            realTimeStylus.ClearStylusQueues();
            HostControl.Refresh();
            dr.EnableDataCache = true;
        }

        public void SetPen(Color c, float width, byte transparency = 0)
        {
            dr.EnableDataCache = false;

            dr.DrawingAttributes = new DrawingAttributes(c);
            dr.DrawingAttributes.AntiAliased = false;
            dr.DrawingAttributes.Transparency = transparency;
            dr.DrawingAttributes.Color = c;
            dr.DrawingAttributes.Height = 1;
            dr.DrawingAttributes.Width = width;
            dr.DrawingAttributes.RasterOperation = RasterOperation.CopyPen;
            dr.DrawingAttributes.IgnorePressure = true;

            dr.EnableDataCache = true;
        }

        internal void AllErase()
        {
            if (bmp == null)
            {
                InitBitmap();
            }

            using (var g = Graphics.FromImage(bmp))
            {
                dr.Draw(g);

                realTimeStylus.ClearStylusQueues();
                g.Clear(Color.White);
            }

            Bitmap saveImage = null;
            using (bmp)
            {
                bmp.MakeTransparent(Color.Transparent);
                HostControl.Image = null;
                saveImage = bmp.Clone() as Bitmap;
                HostControl.Image = saveImage;
                HostControl.Invalidate();
                bmp.Dispose();
            }
            // bmp 재 할당.
            bmp = saveImage;
            bmp.MakeTransparent();
            saveImage = null;
            GC.Collect();
        }

        public void SetEraser(float width = 1500)
        {
            dr.EnableDataCache = false;
            //dr.DrawingAttributes = new DrawingAttributes(Color.Transparent);

            dr.DrawingAttributes.AntiAliased = false;
            dr.DrawingAttributes.Transparency = 0;
            dr.DrawingAttributes.Color = Color.Transparent;
            dr.DrawingAttributes.Height = 1;
            dr.DrawingAttributes.Width = width;
            dr.DrawingAttributes.RasterOperation = RasterOperation.MergePen;
            dr.DrawingAttributes.IgnorePressure = false;

            dr.EnableDataCache = true;
        }

        /// <summary>
        /// 현재 펜 색을 가져온다.
        /// </summary>
        public Color Color
        {
            get
            {
                if (dr == null || dr.DrawingAttributes == null) return Color.Empty;
                return dr.DrawingAttributes.Color;
            }
        }

        public float PenWidth
        {
            get
            {
                if (dr == null || dr.DrawingAttributes == null) return 10f;
                return dr.DrawingAttributes.Width;
            }
        }


        /// <summary>
        /// Defines the types of notifications the plugin is interested in.
        /// </summary>
        DataInterestMask IStylusAsyncPlugin.DataInterest
        {
            get
            {
                return DataInterestMask.AllStylusData | DataInterestMask.CustomStylusDataAdded | DataInterestMask.Packets |
                     //  DataInterestMask.StylusDown | DataInterestMask.StylusUp |
                       DataInterestMask.DefaultStylusData | DataInterestMask.Error
                       ;
            }
        }

        void IStylusAsyncPlugin.CustomStylusDataAdded(RealTimeStylus sender, CustomStylusData data)
        {
            if (data.CustomDataId == GestureRecognizer.GestureRecognitionDataGuid)
            {
                GestureRecognitionData grd = data.Data as GestureRecognitionData;
                if (grd != null)
                {
                    if (grd.Count > 0)
                    {
                        GestureAlternate ga = grd[0];
                        Debug.WriteLine("Gesture=" + ga.Id + ", Confidence=" + ga.Confidence);
                    }
                }
            }
        }

        void IStylusAsyncPlugin.Error(RealTimeStylus sender, ErrorData data) { Log($"{sender}|{data}"); }

        void IStylusAsyncPlugin.InAirPackets(RealTimeStylus sender, InAirPacketsData data) { Log($"{sender}|{data}"); }

        void IStylusAsyncPlugin.Packets(RealTimeStylus sender, PacketsData data) {
            Log($"{sender}|{data}");
            data.SetData(null);
        }

        void IStylusAsyncPlugin.RealTimeStylusDisabled(RealTimeStylus sender, RealTimeStylusDisabledData data) { Log($"{sender}|{data}"); }

        void IStylusAsyncPlugin.RealTimeStylusEnabled(RealTimeStylus sender, RealTimeStylusEnabledData data) { Log($"{sender}|{data}"); }

        void IStylusAsyncPlugin.StylusButtonDown(RealTimeStylus sender, StylusButtonDownData data) { Log($"{sender}|{data}"); }

        void IStylusAsyncPlugin.StylusButtonUp(RealTimeStylus sender, StylusButtonUpData data) { Log($"{sender}|{data}"); }

        void IStylusAsyncPlugin.StylusDown(RealTimeStylus sender, StylusDownData data)
        {
            Log($"{sender}|{data}");
            Tablet currentTablet = sender.GetTabletFromTabletContextId(data.Stylus.TabletContextId);
            if (currentTablet != null)
            {
                if (data.Stylus.Name == ("" + TabletDeviceKind.Mouse))
                { 
                    
                }
            }
        }

        void IStylusAsyncPlugin.StylusUp(RealTimeStylus sender, StylusUpData data)
        {
            Log($"{data}");
            Tablet currentTablet = sender.GetTabletFromTabletContextId(data.Stylus.TabletContextId);
            if (currentTablet != null)
            {
                if (currentTablet.DeviceKind == TabletDeviceKind.Mouse)
                {


                }
            }
        }

        void IStylusAsyncPlugin.StylusInRange(RealTimeStylus sender, StylusInRangeData data) { Log($"{sender}|{data}"); }

        void IStylusAsyncPlugin.StylusOutOfRange(RealTimeStylus sender, StylusOutOfRangeData data) { Log($"{sender}|{data}"); }

        void IStylusAsyncPlugin.SystemGesture(RealTimeStylus sender, SystemGestureData data)
        {
            Log($"{sender}|{data}");
        }

        void IStylusAsyncPlugin.TabletAdded(RealTimeStylus sender, TabletAddedData data) { Log($"{sender}|{data}"); }

        void IStylusAsyncPlugin.TabletRemoved(RealTimeStylus sender, TabletRemovedData data) { Log($"{sender}|{data}"); }

        #region IDisposable Support
        private bool disposedValue = false; // 중복 호출을 검색하려면

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (HostControl != null)
                    {
                        HostControl.MouseUp -= Ctrl_MouseUp;
                        using (HostControl.BackgroundImage)
                        {
                            HostControl.BackgroundImage = null;
                        }
                    }
                    // TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
                    using (bmp)
                    {
                        if (HostControl != null)
                        {
                            HostControl.Image = null;
                        }
                    }
                    using (realTimeStylus)
                    {
                    }
                    using (dr) { }
                }
                HostControl = null;
                bmp = null;
                dr = null;
                realTimeStylus = null;
                GC.Collect();
                // TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.

                disposedValue = true;
            }
        }

        [DllImport("user32.DLL")]
        public static extern bool RegisterTouchWindow(IntPtr hwnd, int ulFlags);

        [DllImport("user32.DLL")]
        public static extern bool UnregisterTouchWindow(IntPtr hwnd);

        // TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
        // ~PenDraw() {
        //   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
        //   Dispose(false);
        // }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
            Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
            // GC.SuppressFinalize(this);
        }
        #endregion

        internal void UseTouchScreen(bool useTouch)
        {
            //if (useTouch)
            //{
            //    RegisterTouchWindow(HostControl.Handle, 2);
            //}
            //else
            //{
            //    UnregisterTouchWindow(HostControl.Handle);
            //}
            //return TouchOnOff(useTouch);
        }

        internal void Log(object msg, [System.Runtime.CompilerServices.CallerMemberName] string memName = "")
        {
          //  Debug.WriteLine($"[{memName}] {msg}");
        }

     
    }
}
