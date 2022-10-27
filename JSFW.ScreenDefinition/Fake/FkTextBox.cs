using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JSFW.Fake.Editor;
using PopupControl;

namespace JSFW.Fake
{
    public partial class FkTextBox : UserControl, IFkData
    {
        Popup Editor = null;
        EditorFkTextBox TextEditor = null;

        public FkData Data { get; internal set; } = new FkData() { 
                        TypeName = typeof(FkTextBox).FullName, 
                        Text = "", 
                        Visible = true,
                        Left = 0,
                        Top = 0,
                        Width = 100,
                        Height = 25,
        };

        bool isDataBinding = false;
        public void SetData(FkData data)
        {
            Data = data;

            try
            {
                isDataBinding = true;
                this.Left = Data.Left;
                this.Top = Data.Top;
                this.Width = Data.Width;
                this.Height = Data.Height;
            }
            finally
            {
                isDataBinding = false;
            }
            Invalidate();
        }

        public void DataFlush()
        {
            Data.Left = this.Left;
            Data.Top = this.Top;
            Data.Width = this.Width;
            Data.Height = this.Height;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (isDataBinding || Data == null) return;
            Data.Width = this.Width;
            Data.Height = this.Height;
        }

        public FkTextBox()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Editor = new Popup(TextEditor = new EditorFkTextBox());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = TextEditor;
            ied.DataFlush();
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = TextEditor;
            ied.SetData(Data);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle textRect = Rectangle.FromLTRB(
                DisplayRectangle.Left + Margin.Left,
                DisplayRectangle.Top + Margin.Top,
                DisplayRectangle.Right - Margin.Right,
                DisplayRectangle.Bottom - Margin.Bottom);

            TextBoxRenderer.DrawTextBox(e.Graphics, this.DisplayRectangle, 
                  System.Windows.Forms.VisualStyles.TextBoxState.Normal);


            string txt = ("" + Data?.Text);
            Color foreClr = ForeColor;
            if (string.IsNullOrWhiteSpace(txt))
            {
                txt = "텍스트를 입력하세요.";
                foreClr = Color.Silver;
            }

            TextFormatFlags TextAlign = TextFormatFlags.Left;

            if ((Data?.TextAlign ?? FkDataTextAlign.Left )== FkDataTextAlign.Center)
            {
                TextAlign = TextFormatFlags.HorizontalCenter; 
            }
            else if ((Data?.TextAlign ?? FkDataTextAlign.Left) == FkDataTextAlign.Right)
            {
                TextAlign = TextFormatFlags.Right;
            } 

            TextRenderer.DrawText(e.Graphics, txt, Font, textRect,
                foreClr, TextFormatFlags.VerticalCenter | TextAlign);

            bool vis = (Data?.Visible ?? false);
            if (vis == false)
            {
                FkCtrlUx.UnVisibleDraw(this, e.Graphics);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (e.Button == MouseButtons.Left)
            {
                ((IFkData)this)?.ShowEdit();
            }
        }

        void IFkData.ShowEdit()
        {
            Editor.Show(this);
        }
    }

    public class FkCtrlUx
    {
        public static bool IsDesignMode { get; set; } = true;

        /// <summary>
        /// 선택된 컨트롤
        /// </summary>
        public static List<Control> SelectedFkControls { get; private set; } = new List<Control>();


        public static Action<FkData, string> DataChanged = null;

        public static bool IgnoreDataChangeEvent = false;

        internal static void OnDataChanged(FkData data, string propertyName)
        {
            if (IgnoreDataChangeEvent) return;

            DataChanged?.Invoke(data, propertyName);
        }

        internal static Control Create(FkData data)
        {
            try
            {
                if (data == null) return null;
                Control ctrl = null;

                IgnoreDataChangeEvent = true;
                ctrl = Activator.CreateInstance(Type.GetType(data.TypeName)) as Control;
                return ctrl;
            }
            finally {
                IgnoreDataChangeEvent = false;
            }
        }

        internal static FkData DataFlush(IFkData ictrl)
        {
            if (ictrl != null)
            {
                try
                {
                    IgnoreDataChangeEvent = true;
                    ictrl.DataFlush();
                }
                finally
                {
                    IgnoreDataChangeEvent = false;
                } 
            }
            return ictrl?.Data;
        }

        internal static void UnVisibleDraw(Control ctrl, Graphics g)
        {
            if (ctrl == null) return;
            if (g == null) return;
             
            Rectangle unVisibleBox = Rectangle.FromLTRB(
                  ctrl.ClientRectangle.Left + 2,
                  ctrl.ClientRectangle.Top + 2,
                  ctrl.ClientRectangle.Width - 3,
                  ctrl.ClientRectangle.Height - 3);

            if (ctrl is FkTabControl)
            {
                unVisibleBox = Rectangle.FromLTRB(
                      ctrl.ClientRectangle.Left + 2,
                      ctrl.ClientRectangle.Top + 2,
                      ctrl.ClientRectangle.Width - 3,
                      ctrl.ClientRectangle.Top + 22);
            }


            SolidBrush unVisibleColor = new SolidBrush(Color.FromArgb(100, Color.Black));
            //g.FillRectangle(unVisibleColor, ctrl.DisplayRectangle);
            g.DrawRectangle(Pens.OrangeRed, unVisibleBox);
            g.DrawLine(Pens.OrangeRed,
                new Point(unVisibleBox.Left, unVisibleBox.Top),
                new Point(unVisibleBox.Right, unVisibleBox.Bottom));
            g.DrawLine(Pens.OrangeRed,
                new Point(unVisibleBox.Right, unVisibleBox.Top),
                new Point(unVisibleBox.Left, unVisibleBox.Bottom));
        }

        internal static IFkData GetIFkData(object obj)
        {
            return obj as IFkData;
        }
    }

    public interface IFkData
    { 
        FkData Data { get; }
        void SetData(FkData data);
        void DataFlush();
        void ShowEdit();
    }

    public enum FkDataTextAlign
    {
         Left,
         Center,
         Right
    }

    public class FkData : ICloneable
    {        
        [Newtonsoft.Json.JsonIgnore]
        public static DragMoveControlObject DragShareMoveControl { get; set; } = null;

        public string TypeName { get; set; }

        public string ScreenDocumentID { get; set; }

        public string SlideID { get; set; }

        public string SlideTitle { get; set; }

        public string ScreenDesignID { get; set; } 

        //가져오기 에서 보여지는 명
        public string DisplaySlideInfo
        {
            get
            {
                string header = ScreenDesignID?.Trim();
                if (string.IsNullOrWhiteSpace(SlideTitle) == false)
                {
                    header = $"{ScreenDesignID?.Trim(), -25}<{SlideTitle?.Trim()}>";
                }
                return header;
            }
        }

        //public string Key { get { return GetProperties("Key"); } set { SetProperties("Key", value); FkCtrlUx.OnDataChanged(this, "Key"); } }

        public string ID { get { return GetProperties("ID"); } set { SetProperties("ID", value); FkCtrlUx.OnDataChanged(this, "ID"); } }
         
        public string Name { get { return GetProperties("Name"); } set { SetProperties("Name", value); FkCtrlUx.OnDataChanged(this, "Name"); } }

        public string Text { get { return GetProperties("Text"); } set { SetProperties("Text", value); FkCtrlUx.OnDataChanged(this, "Text"); } }

        public string ImageType { get { return GetProperties("ImageType"); } set { SetProperties("ImageType", value); FkCtrlUx.OnDataChanged(this, "ImageType"); } }

        public FkDataTextAlign? TextAlign { get { return GetProperties("TextAlign"); } set { SetProperties("TextAlign", value); FkCtrlUx.OnDataChanged(this, "TextAlign"); } }

        public bool Checked { get { return true.Equals( GetProperties("Checked") ?? false); } set { SetProperties("Checked", value); FkCtrlUx.OnDataChanged(this, "Checked"); } }

        public bool Visible { get { return true.Equals( GetProperties("Visible") ?? true); } set { SetProperties("Visible", value); FkCtrlUx.OnDataChanged(this, "Visible"); } }

        public Color ForeColor { get { return GetProperties("ForeColor") ?? Color.Black; } set { SetProperties("ForeColor", value); FkCtrlUx.OnDataChanged(this, "ForeColor"); } }
        public Color BackColor { get { return GetProperties("BackColor") ?? Color.White; } set { SetProperties("BackColor", value); FkCtrlUx.OnDataChanged(this, "BackColor"); } }

        public Color HeaderBackColor { get { return GetProperties("HeaderBackColor") ?? Color.White; } set { SetProperties("HeaderBackColor", value); FkCtrlUx.OnDataChanged(this, "HeaderBackColor"); } }
        public Color HeaderForeColor { get { return GetProperties("HeaderForeColor") ?? Color.Black; } set { SetProperties("HeaderForeColor", value); FkCtrlUx.OnDataChanged(this, "HeaderForeColor"); } }

        public bool Bold { get { return true.Equals(GetProperties("Bold") ?? false); } set { SetProperties("Bold", value); FkCtrlUx.OnDataChanged(this, "Bold"); } }

        /// <summary>
        /// tab page - Header 
        /// </summary>
        public Rectangle? HeadBox { get { return GetProperties("HeadBox"); } set { SetProperties("HeadBox", value); 
                //FkCtrlUx.OnDataChanged(this, "HeadBox"); 
            } }

        public bool GridLine { get { return GetProperties("GridLine") ?? false; } set { SetProperties("GridLine", value); FkCtrlUx.OnDataChanged(this, "GridLine"); } }

        /// <summary>
        /// tab page - selected
        /// </summary>
        public bool Selected { get { return true.Equals(GetProperties("Selected") ?? false); } set { SetProperties("Selected", value); FkCtrlUx.OnDataChanged(this, "Selected"); } }

        public int Left { get { return GetProperties("Left"); } set { SetProperties("Left", value); FkCtrlUx.OnDataChanged(this, "Left"); } }
        public int Top { get { return GetProperties("Top"); } set { SetProperties("Top", value); FkCtrlUx.OnDataChanged(this, "Top"); } }
        public int Width { get { return GetProperties("Width"); } set { SetProperties("Width", value); FkCtrlUx.OnDataChanged(this, "Width"); } }
        public int Height { get { return GetProperties("Height"); } set { SetProperties("Height", value); FkCtrlUx.OnDataChanged(this, "Height"); } }

        public int CellIndex { get { return GetProperties("CellIndex") ?? -1; } set { SetProperties("CellIndex", value); FkCtrlUx.OnDataChanged(this, "CellIndex"); } }

        public int ColsCount { get { return GetProperties("ColsCount") ?? 0; } set { SetProperties("ColsCount", value); FkCtrlUx.OnDataChanged(this, "ColsCount"); } }

        private System.Dynamic.ExpandoObject Properties { get; set; } = new System.Dynamic.ExpandoObject();

        public bool Required { get { return true.Equals(GetProperties("Required") ?? false ); } set { SetProperties("Required", value); FkCtrlUx.OnDataChanged(this, "Required"); } }
       
        /// <summary>
        /// 그리드 설정
        /// </summary>
        public string GridSettings { get { return GetProperties("GridSettings"); } set { SetProperties("GridSettings", value); FkCtrlUx.OnDataChanged(this, "GridSettings"); } }
        
        //챠트
        public string X축 { get { return GetProperties("X축"); } set { SetProperties("X축", value); FkCtrlUx.OnDataChanged(this, "X축"); } }
        //챠트
        public string Series { get { return GetProperties("Series"); } set { SetProperties("Series", value); FkCtrlUx.OnDataChanged(this, "Series"); } }

        //트리
        public string TreeContents { get { return GetProperties("TreeContents"); } set { SetProperties("TreeContents", value); FkCtrlUx.OnDataChanged(this, "TreeContents"); } }
        //트리(true) 또는 리스트(false)
        public bool IsTree { get { return true.Equals(GetProperties("IsTree") ?? true); } set { SetProperties("IsTree", value); FkCtrlUx.OnDataChanged(this, "IsTree"); } }
        //코드파인드(true) 또는 주소검색(false)
        public bool IsCodeFind { get { return true.Equals(GetProperties("IsCodeFind") ?? true); } set { SetProperties("IsCodeFind", value); FkCtrlUx.OnDataChanged(this, "IsCodeFind"); } }
        
        public List<FkData> Childs { get; set; } = new List<FkData>();
     

        protected internal void SetProperties(dynamic propertyName, object value)
        {
            IDictionary<string, object> dic = Properties;
            if (dic.ContainsKey(propertyName))
            {
                dic[propertyName] = value;
            }
            else
            {
                dic.Add(propertyName, value);
            }
        }

        protected internal dynamic GetProperties(string propertyName)
        {
            IDictionary<string, object> dic = Properties;
            if (dic.ContainsKey(propertyName))
            {
                return dic[propertyName];
            }
            else
            {
                return null;
            }
        }

        public FkData()
        {
            ID = Guid.NewGuid().ToString("N");
        }

        public object Clone()
        {
            FkData cloneData = new FkData() {  TypeName = TypeName };
            try
            {
                FkCtrlUx.IgnoreDataChangeEvent = true; 
                foreach (var pv in Properties)
                {
                    cloneData.SetProperties(pv.Key, pv.Value);
                }

                foreach (FkData child in Childs)
                {
                    cloneData.Childs.Add((FkData)child.Clone());
                }
            }
            finally {
                FkCtrlUx.IgnoreDataChangeEvent = false;
            }
            return cloneData;
        }

        public override string ToString()
        {
            return $"{TypeName} ({Childs.Count})";
        }
    }

    public class DragDropFkData
    { 
        public FkData Data { get; set; }

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public DragDropFkData(FkData data)
        {
            Data = data;
        }
    }

    //저장을 위해 바꿈.
    public class TemplateFkData
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public List<DragDropFkData> Data { get; set; }

        public TemplateFkData(List<DragDropFkData> data)
        {
            ID = Guid.NewGuid().ToString("N");
            Data = data;
        }
    }

}
