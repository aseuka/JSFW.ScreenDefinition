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
    public partial class ToolBoxItem_Template : UserControl
    {
        public string HeaderText { get { return label1.Text; } set { label1.Text = value; } }

        public TemplateFkData Data { get; set; }

        public bool IsDelete { get => chkDel.Checked; set => chkDel.Checked = value; }

        bool isMouseDown = false;
        Point pt;

        public ToolBoxItem_Template()
        {
            InitializeComponent();

            chkDel.SendToBack();

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
                    TooBoxItemDragDropData dragObject = new TooBoxItemDragDropData( Data.Data );
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
            Data = null;
        }

        public void UseDelete(bool show = false)
        {
            chkDel.Checked = false;
            chkDel.Visible = show; 
            if (show)
            {
                chkDel.BringToFront();
            }
            else
            {
                chkDel.SendToBack();
            }
        }
    }
}
