using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW
{ 
    public static class Ux
    {
        public static void SaveFile<T>(T obj, string filePath, Encoding encoding = null)
        {
            if (obj == null) return;

            if (string.IsNullOrWhiteSpace(filePath)) return;

            string dir = Path.GetDirectoryName(filePath);
            if (string.IsNullOrWhiteSpace(dir) == false && Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            File.WriteAllText(filePath, json, encoding ?? Encoding.UTF8);
        }

        public static T LoadFile<T>(string filePath, Encoding encoding = null)
        {
            T obj = default(T);

            if (string.IsNullOrWhiteSpace(filePath) == false && File.Exists(filePath) == false)
            {
                return obj;
            }

            try
            {
                string json = File.ReadAllText(filePath, encoding ?? Encoding.UTF8);
                obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                obj = default(T);
            }
            return obj;
        }

        /// <summary>
        /// 컨트롤 비동기 호출! 
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="ctrl"></param>
        /// <param name="action"></param>
        public static void DoInvoke<TControl>(this TControl ctrl, Action<TControl> action) where TControl : Control
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(action, ctrl);
            }
            else
            {
                action(ctrl);
            }
        }

        public static void AsyncCall(Action asyncMethod = null)
        {
            if (asyncMethod != null)
            {
                try
                {
                    asyncMethod.BeginInvoke(ir => asyncMethod.EndInvoke(ir), null);
                }
                catch { }
            }
        }

        public static void AsyncCall<T>(T args, Action<T> asyncMethod = null)
        {
            if (asyncMethod != null)
            {
                asyncMethod.BeginInvoke(args, ir => asyncMethod.EndInvoke(ir), asyncMethod);
            }
        }

        public static object GetNonPublicProperty(object obj, string propertyName)
        {
            PropertyInfo p = obj.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
            return p.GetValue(obj, null);
        }

        public static void SetNonPublicProperty(object obj, string propertyName, object value)
        {
            PropertyInfo p = obj.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty);
            p.SetValue(obj, value);
        }

        public static void GetNonPublicMethod(object obj, string methodName, object[] values)
        {
            MethodInfo m = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod);
            m.Invoke(obj, values);
        }

        public static DialogResult Alert(this object msg)
        {
            return MessageBox.Show(string.Format("{0}", msg));
        }
        public static DialogResult AlertWarning(this string msg)
        {
            return MessageBox.Show(string.Format("{0}", msg, "경고"));
        }

        public static void DebugWarning(this string msg)
        {
            string title = "";
            try
            {
                System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(1);
                title = sf.GetMethod().Name + ":";
            }
            catch (Exception)
            {
            }

            System.Diagnostics.Debug.WriteLine(msg, title);
        }
        public static void DebugWarning(this string msg, string title)
        {
            System.Diagnostics.Debug.WriteLine(msg, title);
        }
        /// <summary>
        /// Yes or No [ Question ]
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult Confirm(this object msg)
        {
            return MessageBox.Show(string.Format("{0}", msg), "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static int ThumbnailWith = 160;
        public static int ThumbnailHeight = 90;

        /// <summary>
        /// The WM_PRINT drawing options
        /// </summary>
        [Flags]
        enum DrawingOptions
        {
            /// <summary>
            /// Draws the window only if it is visible.
            /// </summary>
            PRF_CHECKVISIBLE = 1,

            /// <summary>
            /// Draws the nonclient area of the window.
            /// </summary>
            PRF_NONCLIENT = 2,
            /// <summary>

            /// Draws the client area of the window.
            /// </summary>
            PRF_CLIENT = 4,

            /// <summary>
            /// Erases the background before drawing the window.
            /// </summary>
            PRF_ERASEBKGND = 8,

            /// <summary>
            /// Draws all visible children windows.
            /// </summary>
            PRF_CHILDREN = 16,

            /// <summary>
            /// Draws all owned windows.
            /// </summary>
            PRF_OWNED = 32
        }


        /// <summary>
        /// 스크롤 생긴 컨트롤을 지정해야 그안에 컨트롤이 가득 찍혀짐. 
        /// </summary>
        /// <param name="ctrl"></param>
        public static System.Drawing.Image ControlShot(this Control ctrl, int offsetWH, bool copyClipboard = true)
        {
            //http://stackoverflow.com/questions/1881317/c-sharp-windows-form-control-to-image
            //todo : 컨트롤을 스크린을 찍어서 클립보드에 넣어준다.
            if (ctrl is ScrollableControl)
            {
                // 스크롤을 0으로 바꿔주어야 스크린 찍을때 안짤림. 
                ((ScrollableControl)ctrl).HorizontalScroll.Value = 0;
                ((ScrollableControl)ctrl).VerticalScroll.Value = 0;
                ((ScrollableControl)ctrl).AutoScrollPosition = new System.Drawing.Point(0, 0);
            }

            const int WM_PRINT = 791;

            using (System.Drawing.Bitmap screenshot = new System.Drawing.Bitmap(
                                                            ctrl.DisplayRectangle.Width + offsetWH,
                                                            ctrl.DisplayRectangle.Height + offsetWH))
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(screenshot))
            {
                try
                {
                    SendMessage(ctrl.Handle,
                                  WM_PRINT,
                                  g.GetHdc().ToInt32(),
                                  (int)(DrawingOptions.PRF_CHILDREN |
                                            DrawingOptions.PRF_CLIENT |
                                            DrawingOptions.PRF_NONCLIENT |
                                            DrawingOptions.PRF_OWNED));
                }
                finally
                {
                    g.ReleaseHdc();
                }
                //screenshot.Save("temp.bmp");  

                if (copyClipboard)
                    Clipboard.SetImage(screenshot);
                return screenshot.GetThumbnailImage(ThumbnailWith, ThumbnailHeight, delegate { return false; }, IntPtr.Zero);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public static DateTime? ToDateTime(this object obj, string Fmt)
        {
            DateTime _datetime;
            //try
            //{ 
            //    _datetime = DateTime.ParseExact("" + obj, "yyyy-MM-dd tt H:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal);
            //    return _datetime;
            //}
            //catch (Exception)
            //{ } 

            if (string.IsNullOrEmpty(Fmt)) Fmt = "yyyy-MM-dd tt hh:mm:ss";

            //if (obj.IsNull() || string.IsNullOrEmpty(("" + obj))) return null;
            //else
            //{
            //    return DateTime.ParseExact("" + obj, Fmt, null, System.Globalization.DateTimeStyles.AssumeLocal);
            //}
            string dt = "" + obj;
            if (dt.Contains("오전") || dt.Contains("오후"))
            {
                if (dt.Length == "yyyy-MM-dd 오후 hh:mm:ss".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd tt hh:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyy-MM-dd 오후 H:mm:ss".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd tt H:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
            }
            else
            {
                if (dt.Length == "yyyy-MM-dd hh:mm:ss".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd hh:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyy-MM-dd h:mm:ss".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd h:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyy-MM-dd hh:mm:ss.fff".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd hh:mm:ss.fff", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyy-MM-dd h:mm:ss.fff".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd h:mm:ss.fff", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyy-MM-dd".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
                else if (dt.Length == "yyyyMMdd".Length)
                {
                    if (DateTime.TryParseExact("" + obj, "yyyyMMdd", null, System.Globalization.DateTimeStyles.AssumeLocal, out _datetime))
                    {
                        return _datetime;
                    }
                }
            }
            return null;
        }

        public static string Toyyyy_MM_dd(this DateTime datetime, string Fmt)
        {
            if (string.IsNullOrEmpty(Fmt)) Fmt = "yyyy-MM-dd";
            return datetime.ToString(Fmt);
        }

        public static T To<T>(this object obj, object DefaultValue) where T : IConvertible
        {
            if (typeof(T).BaseType == typeof(Enum))
            {
                if (Enum.IsDefined(typeof(T), obj))
                {
                    return (T)Enum.Parse(typeof(T), "" + obj);
                }
                else
                {
                    return (T)DefaultValue;
                }
            }

            TypeCode typecode = (TypeCode)Enum.Parse(typeof(TypeCode), typeof(T).Name);

            if (string.IsNullOrEmpty("" + obj))
            {
                switch (typecode)
                {
                    case TypeCode.Boolean:
                        break;
                    case TypeCode.Byte:
                        break;
                    case TypeCode.Char:
                        break;
                    case TypeCode.DBNull:
                        break;
                    case TypeCode.Empty:
                        break;
                    case TypeCode.Object:
                        break;
                    case TypeCode.SByte:
                        break;
                    case TypeCode.String:
                        break;

                    case TypeCode.Double:
                    case TypeCode.Decimal:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.Single:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        obj = DefaultValue ?? "0";
                        break;
                    default:
                        obj = "";
                        break;
                    case TypeCode.DateTime:
                        return (T)obj;
                }
            }
            return (T)Convert.ChangeType(obj, typecode);
        }

    }
}
