using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JSFW.Fake.ToolBox;

namespace JSFW.Fake
{
    public partial class FkUserControl : UserControl, IFkData
    {
        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkUserControl).FullName,
            Text = "",
            Visible = true,
            Left = 0,
            Top = 0,
            Width = 150,
            Height = 70,
            ScreenDesignID = "",
            GridLine = false
        };

        public void SetData(FkData data)
        {
            ClearContent();
            Data = data;
            Padding = new Padding(3);
            if (Data != null)
            {
                this.Left = Data.Left;
                this.Top = Data.Top;
                this.Width = Data.Width;
                this.Height = Data.Height;

                if (string.IsNullOrWhiteSpace(Data.Text) == false)
                {
                    Padding = new Padding(3, 3 + 22 + 3, 3, 3);
                    _HeaderBackColorBrush = new SolidBrush(Data.HeaderBackColor);
                }

                try
                {
                    this.SuspendLayout();
                    foreach (FkData childData in data.Childs)
                    {
                        Control innerCtrl = FkCtrlUx.Create(childData);
                        this.Controls.Add(innerCtrl);
                        IFkData ifk = innerCtrl as IFkData;
                        ifk.SetData(childData);
                    }
                }
                finally {
                    this.ResumeLayout(false);
                }
            }
        }

        private void ClearContent()
        {
            try
            {
                this.SuspendLayout(); 
                for (int loop = this.Controls.Count - 1; loop >= 0; loop--)
                {
                    using (this.Controls[loop])
                    {
                        this.Controls.RemoveAt(loop);
                    }
                }
            }
            finally {
                this.ResumeLayout(false);
            }
        }

        public void DataFlush()
        {
            Data.Left = this.Left;
            Data.Top = this.Top;
            Data.Width = this.Width;
            Data.Height = this.Height;
            List<FkData> childs = new List<FkData>();
            FkData[] fkDataArr = DataFlush(this);
            childs.AddRange(fkDataArr);
            Data.Childs.Clear();
            Data.Childs.AddRange(childs.ToArray());
        }

        private FkData[] DataFlush(Control prntCtrl)
        {
            List<FkData> childs = new List<FkData>();

            foreach (Control inner in prntCtrl.Controls)
            {
                IFkData ifk = inner as IFkData;
                if (ifk != null)
                {
                    ifk.DataFlush();
                    FkData __data = (FkData)((ICloneable)ifk.Data).Clone();
                    childs.Add(__data);
                }
            }
            return childs.ToArray();
        }


        void IFkData.ShowEdit()
        {

        }

        public FkUserControl()
        {
            InitializeComponent();

            DoubleBuffered = true;

            SetData(Data);
        }

        SolidBrush _HeaderBackColorBrush { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle textRect = Rectangle.FromLTRB(
                ClientRectangle.Left + Padding.Left,
                ClientRectangle.Top + 3,
                ClientRectangle.Right - Padding.Right,
                ClientRectangle.Top + 3 + Padding.Top);

            Point pt = new Point(DisplayRectangle.Left + Padding.Left + 1,
                                 DisplayRectangle.Top + Padding.Top + 1);

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Dashed);

            string txt = ("" + Data?.Text);
            Color foreClr = ForeColor;
            if (!string.IsNullOrWhiteSpace(txt))
            {
                e.Graphics.FillRectangle(_HeaderBackColorBrush, textRect);

                TextRenderer.DrawText(e.Graphics, txt, Font, textRect,
                    foreClr, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

                SizeF sz = TextRenderer.MeasureText(txt, Font);
                // e.Graphics.DrawLine(Pens.DarkGray, sz.Width + 5, textRect.Top + 3 + 6, textRect.Right, textRect.Top + 3 + 6);
            }

            bool vis = (Data?.Visible ?? false);
            if (vis == false)
            {
                FkCtrlUx.UnVisibleDraw(this, e.Graphics);
            }

            bool hasLine = (Data?.GridLine ?? false);

            if (hasLine)
            {
                int x = 5;
                int y = 3 + Padding.Top;
                int w = this.Width - 5;
                int h = this.Height;

                while (y < h)
                {
                    e.Graphics.DrawLine(Pens.Gray, x, y, w, y);
                    y += FkPanel.__GridRowHeight;
                }
            }
             
            if (CurrentMovingControl != null)
            {
                int cnt = (Width / _Width);
                for (int loop = 0; loop < (Width / _Width); loop++)
                {
                    for (int loop2 = 0; loop2 < (Height / _Height); loop2++)
                    {
                        int x = sMargin + (loop * _Width);
                        int y = sMargin + (loop2 * _Height);
                        e.Graphics.DrawRectangle(Pens.LightGray, x, y, _Width, _Height);
                        //TextRenderer.DrawText(e.Graphics, $"{ (loop2 * cnt) + loop}", Font, new Rectangle(x, y, _Width, _Height), ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                        //e.Graphics.FillEllipse(Brushes.Gray, x - 3, y - 3, 6, 6);
                        //e.Graphics.DrawEllipse(Pens.Black, x - 16, y - 16, 32, 32);
                        //TextRenderer.DrawText(e.Graphics, "" + (loop2 * (Width / _Width) + loop + 1), Font, new Point(x + 10, y + 10), Color.Black);
                    }
                }
                //e.Graphics.DrawLine(Pens.Red, label1.Location, NearPoint);  
                //e.Graphics.DrawRectangle(Pens.Yellow, NearPoint.X, NearPoint.Y, _Width, _Width);
                e.Graphics.FillEllipse(Brushes.Orange, NearPoint.X - 4, NearPoint.Y - 4, 8, 8);
                e.Graphics.DrawEllipse(Pens.Silver, NearPoint.X - 8, NearPoint.Y - 8, 16, 16);
            }

            foreach (Control item in this.Controls)
            {
                if (FkCtrlUx.SelectedFkControls.Any(c => c.Equals(item)))
                { 
                    e.Graphics.FillRectangle(Brushes.DodgerBlue, Rectangle.Inflate( item.Bounds, 2, 2));
                }
            }
        }
         
        bool IsOldMDown = false;
        bool isMDown = false;
        bool isCopyDragMDown = false;
        bool isSleep = false;
        Point pt;
        double oldDistance = 10000d;
        protected internal Point NearPoint;
        Point oldNearPoint;

        /*컨트롤 사이즈 변경*/
        bool IsRS = false;
        Rectangle RSZ;
        readonly int OFFSET = FkPanel.OFFSET;
        Control CurrentMovingControl { get; set; } = null;
        Control CurrentReSizeControl { get; set; } = null;// 컨트롤.MouseMove시 커서변경과 관련된 변수.

        protected bool? HasOutLine { get; set; } = false;

        protected internal int sMargin = 5;

        /// <summary>
        /// 80
        /// </summary>
        readonly int _Width = FkPanel._Width; // 라벨100 = 기본
        /// <summary>
        /// 28
        /// </summary>
        readonly int _Height = FkPanel.__GridRowHeight;
         
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            Attatched_Event(e.Control);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            DeAttatched_Event(e.Control);
        }

        private void DeAttatched_Event(Control control)
        {
            control.MouseDown -= control_MouseDown;
            control.MouseUp -= control_MouseUp;
            control.MouseMove -= control_MouseMove;
            control.MouseLeave -= Control_MouseLeave;
            control.MouseEnter -= Control_MouseEnter;
        }

        private void Attatched_Event(Control control)
        {
            DeAttatched_Event(control);

            control.MouseDown += control_MouseDown;
            control.MouseUp += control_MouseUp;
            control.MouseMove += control_MouseMove;
            control.MouseLeave += Control_MouseLeave;
            control.MouseEnter += Control_MouseEnter;
        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentMovingControl = null;

            Control ctrl = sender as Control;
            /*
                아이템 선택의 조건!

                1. 마우스 왼쪽 버튼을 클릭하여 아이템을 선택한 경우.
                    - Shift 키가 같이 눌리지 않고, 선택된 그룹에 속하지 않았을때 ... 선택그룹을 초기화.
                
                2. 마우스 왼쪽 버튼이 Shift나 Control이 동시에 눌리지 않은 경우 
                    - 아이템 선택으로 간주하여 선택 그룹에 등록
                3. 마우스 왼쪽 버튼을 클릭하고 Shift 키가 눌렸을 경우
                    - 선택그룹에 추가되어 있지 않은 아이템은 추가로 등록. 
             */

            IFkData content = sender as IFkData;

            isCopyDragMDown = sender is IFkData && 
                e.Button == MouseButtons.Left && 
                ModifierKeys == Keys.Control;

            isMDown = !isCopyDragMDown && e.Button == MouseButtons.Left;

            if (isMDown) CurrentMovingControl = sender as Control;

            if( isMDown )
            {
                if( ModifierKeys != Keys.Shift ||
                    !FkCtrlUx.SelectedFkControls.Any(c => c.Parent.Equals(CurrentMovingControl.Parent)))
                {
                    FkCtrlUx.SelectedFkControls.Clear();
                }

                if (!FkCtrlUx.SelectedFkControls.Any( c => c.Equals( sender )))
                {
                    FkCtrlUx.SelectedFkControls.Add(sender as Control);
                }
                Invalidate(true);
            }
             
            oldDistance = 10000d;
            isSleep = false;
            pt = e.Location;

            if (isMDown)
            {
                ReCalcBox(sender as Control);

                if (RSZ.Contains(e.Location))
                {
                    IsRS = true;
                    Cursor = Cursors.SizeNWSE;
                    return;
                }
            }
            Cursor = Cursors.Default;
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMDown && CurrentMovingControl != null)
            {
                if (IsRS)
                {
                    int x = (e.X - pt.X);
                    int y = (e.Y - pt.Y);
                    int w = CurrentMovingControl.Width + x;
                    int h = CurrentMovingControl.Height + y;
                    if (CurrentMovingControl.Width + x < 20)
                    {
                        w = 20;
                    }
                    if (CurrentMovingControl.Height + y < 20)
                    {
                        h = 20;
                    }
                    CurrentMovingControl.Width = w;
                    CurrentMovingControl.Height = h;
                    pt = e.Location; // 1개씩 늘리자.
                    CurrentMovingControl.Refresh();
                }
                else
                {
                    //CurrentMovingControl.Left += e.Location.X - pt.X;
                    //CurrentMovingControl.Top += e.Location.Y - pt.Y;
                    // 부모컨트롤 밖으로 나가지 못하게 막음. 
                    if (CheckArea(e.Location, CurrentMovingControl))
                    {
                        CurrentMovingControl.Left += e.Location.X - pt.X;
                        CurrentMovingControl.Top += e.Location.Y - pt.Y;
                        // pt = e.Location; // 있으면 X
                    }
                }

                SetMagnatic(CurrentMovingControl);
                //Invalidate(Rectangle.FromLTRB(oldNearPoint.X - 32, oldNearPoint.Y - 32, oldNearPoint.X + 32, oldNearPoint.Y + 32));
                //Invalidate(Rectangle.FromLTRB(NearPoint.X - 32, NearPoint.Y - 32, NearPoint.X + 32, NearPoint.Y + 32));
                Invalidate(false);
            }
            else if (isCopyDragMDown)
            {
                int x = e.Location.X - pt.X;
                int y = e.Location.Y - pt.Y;
                int z = (int)Math.Sqrt(Math.Pow((double)Math.Abs(x), 2d) + Math.Pow((double)Math.Abs(y), 2d));

                if (4 < z)
                {
                    IFkData content = sender as IFkData;
                    TooBoxItemDragDropData dragObject = new TooBoxItemDragDropData(sender.GetType().FullName, content.Data.Clone() as FkData );
                    try
                    {
                        DoDragDrop(dragObject, DragDropEffects.Copy);
                        isCopyDragMDown = false;
                    }
                    finally
                    {
                        dragObject = null;
                    }
                }
            }

            ReCalcBox(sender as Control);

            if (RSZ.Contains(e.Location))
            {
                Cursor = Cursors.SizeNWSE;
                return;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            CurrentMovingControl = null;
            CurrentReSizeControl = null;

            isCopyDragMDown = false;

            if (isSleep)
            {
                isMDown = IsOldMDown = false; isSleep = false;
            }
            else
            {
                isMDown = IsOldMDown = false;
                IsRS = false;
            }
            oldDistance = 10000d;
            
            Invalidate(true);

            ReCalcBox(sender as Control);

            //Invalidate(Rectangle.FromLTRB(oldNearPoint.X - 32, oldNearPoint.Y - 32, oldNearPoint.X + 32, oldNearPoint.Y + 32));
            //Invalidate(Rectangle.FromLTRB(NearPoint.X - 32, NearPoint.Y - 32, NearPoint.X + 32, NearPoint.Y + 32));
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            CurrentReSizeControl = null;
            ReCalcBox(sender as Control);
            Cursor = Cursors.Default;
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            CurrentReSizeControl = sender as Control;
        }
         
        private void ReCalcBox(Control sender = null)
        {
            if (CurrentReSizeControl != null)
            {
                sender = CurrentReSizeControl;
            }

            if (sender != null)
            {
                RSZ.X = sender.Width - OFFSET;
                RSZ.Y = sender.Height - OFFSET;
                RSZ.Width = OFFSET;
                RSZ.Height = OFFSET;
            }
            else
            {
                RSZ.X = -OFFSET;
                RSZ.Y = -OFFSET;
                RSZ.Width = OFFSET;
                RSZ.Height = OFFSET;
            }
        }


        private bool CheckArea(Point loc, Control ctrl)
        {
            return true;

            bool isIn = false;

            if (ctrl == null || ctrl.Parent == null) return isIn;

            Rectangle rect = ctrl.Parent.DisplayRectangle;
            int x = ctrl.Left + loc.X - pt.X;
            int y = ctrl.Top + loc.Y - pt.Y;

            Rectangle rect2 = new Rectangle(x, y, ctrl.Width, ctrl.Height);

            if (rect.Contains(rect2))
            {
                isIn = true;
            }
            return isIn;
        }

        protected internal void SetMagnaticDragOver(Point dOverPoint)
        {
            if (CurrentMovingControl == null) return;

            int r = dOverPoint.Y / _Height;
            int c = dOverPoint.X / _Width;
            if (0 < dOverPoint.X % _Width)
            {
                c++;
            }
            int cnt = (Width / _Width);

            // 가까운 점 구하기 
            int xx = c * _Width;
            if ((dOverPoint.X % _Width) != 0 && (dOverPoint.X % _Width) < (_Width / 2))
            {
                xx = (c - 1) * _Width;
            }
            int yy = yy = r * _Height;
            if (0 < (dOverPoint.Y % _Height) / (_Height / 2))
            {
                yy = (r + 1) * _Height;
            }
            oldNearPoint.X = NearPoint.X;
            oldNearPoint.Y = NearPoint.Y;

            NearPoint = new Point(sMargin + xx, sMargin + yy);

            double dx = Math.Abs(dOverPoint.X - NearPoint.X);
            double dy = Math.Abs(dOverPoint.Y - NearPoint.Y);
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (Math.Abs(distance / 2) > 2)
            {
                int arrow = 0;
                if (oldDistance > distance)
                {
                    arrow = -1;
                }
                else if (oldDistance < distance)
                {
                    arrow = 1;
                }

                if (arrow < 0 && distance <= 8)
                {
                    dOverPoint.X = NearPoint.X;
                    dOverPoint.Y = NearPoint.Y;
                    oldDistance = distance = 0;
                    IsOldMDown = isMDown;
                    isMDown = false;
                    isSleep = true;
                    Action sleep = new Action(DragSleep);
                    sleep.BeginInvoke(ir => sleep.EndInvoke(ir), sleep);
                }
                else
                {
                    oldDistance = distance;
                } 
            }
        }

        private void SetMagnatic(Control calcControl)
        {
            if (calcControl == null) return;

            int r = calcControl.Top / _Height;
            int c = calcControl.Left / _Width;
            if (0 < calcControl.Left % _Width)
            {
                c++;
            }
            int cnt = (Width / _Width);

            // 가까운 점 구하기 
            int xx = c * _Width;
            if ((calcControl.Left % _Width) != 0 && (calcControl.Left % _Width) < (_Width / 2))
            {
                xx = (c - 1) * _Width;
            }
            int yy = yy = r * _Height;
            if (0 < (calcControl.Top % _Height) / (_Height / 2))
            {
                yy = (r + 1) * _Height;
            }
            oldNearPoint.X = NearPoint.X;
            oldNearPoint.Y = NearPoint.Y;

            NearPoint = new Point(sMargin + xx, sMargin + yy);

            double dx = Math.Abs(calcControl.Left - NearPoint.X);
            double dy = Math.Abs(calcControl.Top - NearPoint.Y);
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (Math.Abs(distance / 2) > 2)
            {
                int arrow = 0;
                if (oldDistance > distance)
                {
                    arrow = -1;
                }
                else if (oldDistance < distance)
                {
                    arrow = 1;
                }

                if (arrow < 0 && distance <= 8)
                {
                    calcControl.Left = NearPoint.X;
                    calcControl.Top = NearPoint.Y;
                    oldDistance = distance = 0;
                    IsOldMDown = isMDown;
                    isMDown = false;
                    isSleep = true;
                    Action sleep = new Action(DragSleep);
                    sleep.BeginInvoke(ir => sleep.EndInvoke(ir), sleep);
                }
                else
                {
                    oldDistance = distance;
                }
                //label1.Text = "" + (r * cnt + c) + ", " + (int)distance + " : " + arrow;
                //label1.Update();
            }
            // todo : 컨트롤 위치값 기록! 
            IFkData content = calcControl as IFkData;
            if (content != null)
            {
                content.Data.CellIndex = (r * cnt + c) - 1; // offset 때문인지 1개 카운트가 더 됨.
                if (content.Data.CellIndex < 0) content.Data.CellIndex = 0;
                content.Data.ColsCount = cnt;
                content.Data.Left = calcControl.Left;
                content.Data.Top = calcControl.Top; 
            }
        }

        private void DragSleep()
        {
            int time = 16;
            while (isSleep && (0 < time--))
            { // 120ms 동안.. 
                System.Threading.Thread.Sleep(10);
            }
            isMDown = IsOldMDown;
        }
         
        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            if (e.AllowedEffect == DragDropEffects.Copy && e.Data.GetDataPresent(typeof(TooBoxItemDragDropData).FullName))
            {
                TooBoxItemDragDropData dropObject = e.Data.GetData(typeof(TooBoxItemDragDropData).FullName) as TooBoxItemDragDropData;
                if (dropObject != null && !string.IsNullOrWhiteSpace(dropObject.TypeName))
                {
                    bool hasAddControl = false;
                    List<Control> addControls = new List<Control>();

                    Control ctrl = Activator.CreateInstance(Type.GetType(dropObject.TypeName)) as Control;

                    if (ctrl != null)
                    {
                        IFkData content = ctrl as IFkData;
                        if (content != null)
                        {
                            content.Data.Left = CurrentMovingControl.Left;
                            content.Data.Top = CurrentMovingControl.Top;
                            if (dropObject.Data != null)
                            {
                                content.SetData(dropObject.Data);
                            }
                        }
                        this.Controls.Add(ctrl); hasAddControl = true;
                        addControls.Add(ctrl);
                        ctrl.Location = NearPoint;
                        ctrl.BringToFront();
                        ctrl.Focus();
                        SetMagnatic(ctrl);
                    }

                    if (hasAddControl)
                    {
                        FkCtrlUx.SelectedFkControls.Clear();
                    }
                    FkCtrlUx.SelectedFkControls.AddRange(addControls);
                    addControls.Clear();

                    FkCtrlUx.GetIFkData(FkCtrlUx.SelectedFkControls[FkCtrlUx.SelectedFkControls.Count - 1])?.ShowEdit();

                    this.FindForm().Invalidate(true);
                }
                control_MouseUp(null, null);
            }
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            if (e.AllowedEffect == DragDropEffects.Copy && e.Data.GetDataPresent(typeof(TooBoxItemDragDropData).FullName))
            {
                e.Effect = e.AllowedEffect;
            }
            else
            {
                e.Effect = DragDropEffects.None;
                control_MouseUp(null, null);
            }
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            if (e.AllowedEffect == DragDropEffects.Copy && e.Data.GetDataPresent(typeof(TooBoxItemDragDropData).FullName))
            {
                CurrentMovingControl = this as Control;
                isMDown = IsOldMDown = true;
                oldDistance = 10000d;
                isSleep = false;
                pt = MousePosition;
                Point dOverPoint = PointToClient(new Point(e.X, e.Y));
                SetMagnaticDragOver(dOverPoint);
            }
            else
            {
                e.Effect = DragDropEffects.None;
                control_MouseUp(null, null);
            }
            Invalidate(false);
        }

        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);
            control_MouseUp(null, null);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            FkCtrlUx.SelectedFkControls.Clear();
            Invalidate(true);
        }
    }
}
