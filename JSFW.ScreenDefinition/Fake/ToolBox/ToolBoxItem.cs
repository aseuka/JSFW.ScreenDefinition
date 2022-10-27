using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Fake.ToolBox
{
    public partial class ToolBoxItem : UserControl
    {
        public string HeaderText { get { return label1.Text; } set { label1.Text = value; } }

        public string TypeName { get; set; }

        //public List<ComplexTypeClass> ComplexTypes { get; internal set; } = new List<ComplexTypeClass>();

        /// <summary>
        /// 사용자정의 도구상자에서 드랍했을때 사용여부를 확인하기 위해 카운팅 플래그로 드랍할때마다 증가처리.
        /// </summary>
        public bool UseCounting { get; internal set; }

        int _UseCount = 0;

        bool isMouseDown = false;
        Point pt;

        public ToolBoxItem()
        {
            InitializeComponent();

            label1.Parent = this;

            this.Disposed += new EventHandler(ToolBoxItem_Disposed);
            this.label1.MouseDown += new MouseEventHandler(label1_MouseDown);
            this.label1.MouseUp += new MouseEventHandler(label1_MouseUp);
            this.label1.MouseMove += new MouseEventHandler(label1_MouseMove);
        }

        void label1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = e.Button == MouseButtons.Left;
            pt = e.Location;
        }

        void label1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int x = e.Location.X - pt.X;
                int y = e.Location.Y - pt.Y;
                int z = (int)Math.Sqrt(Math.Pow((double)Math.Abs(x), 2d) + Math.Pow((double)Math.Abs(y), 2d));

                if (4 < z)
                {
                    // 라디오 ! 체크 면. 라벨은 빼고 x  
                    TooBoxItemDragDropData dragObject = new TooBoxItemDragDropData(TypeName);
                    try
                    {
                        DoDragDrop(dragObject, DragDropEffects.Copy); 
                        isMouseDown = false;
                    }
                    finally
                    {
                        dragObject = null;
                    }
                }
            }
        }

        void ToolBoxItem_Disposed(object sender, EventArgs e)
        {
        }
    }

    internal class TooBoxItemDragDropData
    {
        public List<DragDropFkData> Datas { get; set; }

        internal string TypeName { get; set; }

        internal FkData Data { get; set; } = null;

        /// <summary>
        /// 툴박스용.
        /// </summary>
        /// <param name="tpName"></param>
        /// <param name="data"></param>
        public TooBoxItemDragDropData(string tpName, FkData data = null)
        {
            TypeName = tpName;
            Data = data;
        }

        /// <summary>
        /// 드래그 드랍용.
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="pt"></param>
        public TooBoxItemDragDropData(List<DragDropFkData> datas)
        {
            this.Datas = datas;
        }
    }
}
