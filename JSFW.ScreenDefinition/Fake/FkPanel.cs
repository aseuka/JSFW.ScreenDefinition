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
using JSFW.ScreenDefinition;
using JSFW.Fake.Editor;
using PopupControl;

namespace JSFW.Fake
{
    public partial class FkPanel : Panel, IFkData
    {
        Popup Editor = null;
        EditorFkPanel PanelEditor = null;

        public static readonly int __GridRowHeight = 28;

        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkPanel).FullName,
            Text = "",
            HeaderBackColor = Color.DodgerBlue,
            Visible = true,
            Left = 0,
            Top = 0,
            Width = 150,
            Height = 70,
            GridLine = true
        };

        bool isDataBinding = false;
        public void SetData(FkData data)
        {
            try
            {
                isDataBinding = true;
                ClearContent();
                Data = data;
                Padding = new Padding(3);
                if (Data != null)
                {
                    this.Left = Data.Left;
                    this.Top = Data.Top;
                    this.Width = Data.Width;
                    this.Height = Data.Height;

                    this.BackColor = Data.BackColor;

                    if (string.IsNullOrWhiteSpace(Data.Text) == false)
                    {
                        Padding = new Padding(3, 3 + 22 + 3, 3, 3);
                        _HeaderBackColorBrush = new SolidBrush(Data.HeaderBackColor);
                        _HeaderForeColor = Data.HeaderForeColor;
                    }

                    foreach (FkData childData in data.Childs)
                    {
                        Control innerCtrl = FkCtrlUx.Create(childData);
                        this.Controls.Add(innerCtrl);
                        IFkData ifk = innerCtrl as IFkData;
                        ifk.SetData(childData);
                    }

                    Invalidate();
                }
            }
            finally
            {
                isDataBinding = false;
            }
        }

        private void ClearContent()
        {
            for (int loop = this.Controls.Count - 1; loop >= 0; loop--)
            {
                using (this.Controls[loop])
                {
                    this.Controls.RemoveAt(loop);
                }
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
                if( ifk != null )
                {
                    ifk.DataFlush(); 
                    FkData __data = (FkData)((ICloneable)ifk.Data).Clone();
                    childs.Add(__data);
                }
            } 
            return childs.ToArray();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (isDataBinding || Data == null) return;
            Data.Width = this.Width;
            Data.Height = this.Height;
        }

        public FkPanel()
        {
            InitializeComponent();

            AllowDrop = true;
            DoubleBuffered = true;

            SetData(Data);

            Editor = new Popup(PanelEditor = new EditorFkPanel());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = PanelEditor;
            ied.DataFlush();
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = PanelEditor;
            ied.SetData(Data);
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

        Color _HeaderForeColor { get; set; }
        SolidBrush _HeaderBackColorBrush { get; set; }
        Font Fnt = new Font("굴림체", 10f, FontStyle.Bold);

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

            int hasLine_x = 5; // hasLine 
            int hasLine_y = 0 + Padding.Top;

            string txt = ("" + Data?.Text);

            if (!string.IsNullOrWhiteSpace(txt))
            {
                hasLine_y = 3 + Padding.Top;

                e.Graphics.FillRectangle(_HeaderBackColorBrush, textRect);

                TextRenderer.DrawText(e.Graphics, txt, Fnt, textRect,
                    _HeaderForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                //SizeF sz = TextRenderer.MeasureText(txt, Font);
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
                int w = this.Width - 5;
                int h = this.Height;

                while (hasLine_y < h)
                {
                    e.Graphics.DrawLine(Pens.Gray, hasLine_x, hasLine_y, w, hasLine_y);
                    hasLine_y += __GridRowHeight;
                }
            }

            if (CurrentMovingControl != null)
            {
                for (int loop = 0; loop < (Width / _Width); loop++)
                {
                    for (int loop2 = (!string.IsNullOrWhiteSpace(txt) ? 1 : 0); loop2 < (Height / _Height); loop2++)
                    {
                        int x = sMargin + (loop * _Width);
                        int y = sMargin + (loop2 * _Height);
                        e.Graphics.DrawRectangle(Pens.LightGray, x, y, _Width, _Height);
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

            if (FkData.DragShareMoveControl != null &&
                FkData.DragShareMoveControl.MoveControl != null &&
                this.Equals(FkData.DragShareMoveControl.MoveDragOverControl))
            {
                Rectangle moveBound = new Rectangle()
                {
                    X = NearPoint.X,
                    Y = NearPoint.Y,
                    Width = FkData.DragShareMoveControl.MoveControl.Width,
                    Height = FkData.DragShareMoveControl.MoveControl.Height
                };
                e.Graphics.DrawRectangle(Pens.OrangeRed, moveBound);
            }

            foreach (Control item in this.Controls)
            {
                if (FkCtrlUx.SelectedFkControls.Any(c => c.Equals(item)))
                {
                    e.Graphics.FillRectangle(Brushes.DodgerBlue, Rectangle.Inflate(item.Bounds, 2, 2));
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
        public static readonly int OFFSET = 8;
        Control CurrentMovingControl { get; set; } = null;
        Control CurrentReSizeControl { get; set; } = null;// 컨트롤.MouseMove시 커서변경과 관련된 변수.
         
        protected bool? HasOutLine { get; set; } = false;

        protected internal int sMargin = 5;

        /// <summary>
        /// 51
        /// </summary>
        public static readonly int _Width = 51; // 라벨100 = 기본
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

            if (isMDown)
            {
                if (ModifierKeys != Keys.Shift ||
                    !FkCtrlUx.SelectedFkControls.Any(c => c.Parent.Equals(CurrentMovingControl.Parent)))
                {
                    FkCtrlUx.SelectedFkControls.Clear();
                }

                if (!FkCtrlUx.SelectedFkControls.Any(c => c.Equals(sender)))
                {
                    FkCtrlUx.SelectedFkControls.Add(sender as Control);
                }
                this.FindForm()?.Invalidate(true);
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
                    int x = (e.X - pt.X);
                    int y = (e.Y - pt.Y);
                    int z = (int)Math.Sqrt(Math.Pow((double)Math.Abs(x), 2d) + Math.Pow((double)Math.Abs(y), 2d));

                    if (4 < z)
                    {
                        CurrentMovingControl.Visible = false;
                        FkCtrlUx.SelectedFkControls.Clear();
                        using (FkData.DragShareMoveControl = new DragMoveControlObject()
                        {
                            MoveControl = CurrentMovingControl,
                            IsSuccess = false
                        })
                        {
                            this.DoDragDrop(FkData.DragShareMoveControl, DragDropEffects.Move);
                            if (FkData.DragShareMoveControl != null && !FkData.DragShareMoveControl.IsSuccess)
                            {
                                FkData.DragShareMoveControl.MoveControl.Visible = true;
                            }
                        }
                    }

                    //CurrentMovingControl.Left += e.Location.X - pt.X;
                    //CurrentMovingControl.Top += e.Location.Y - pt.Y;
                    // 부모컨트롤 밖으로 나가지 못하게 막음. 

                    //if (CheckArea(e.Location, CurrentMovingControl))
                    //{
                    //    CurrentMovingControl.Left += e.Location.X - pt.X;
                    //    CurrentMovingControl.Top += e.Location.Y - pt.Y;
                    //    // pt = e.Location; // 있으면 X
                    //}
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
                    // 라디오 ! 체크 면. 라벨은 빼고 x  
                    Control ctrl = sender as Control;
                    FkCtrlUx.SelectedFkControls.Remove(ctrl);
                    FkCtrlUx.SelectedFkControls.Add(ctrl);
                    List<DragDropFkData> Datas = new List<DragDropFkData>();
                    foreach (Control inner in FkCtrlUx.SelectedFkControls)
                    {
                        IFkData content = inner as IFkData;
                        Datas.Add(new DragDropFkData(content.Data.Clone() as FkData)
                        {
                            OffsetX = inner.Left - ctrl.Left,
                            OffsetY = inner.Top - ctrl.Top
                        });
                    }
                    TooBoxItemDragDropData dragObject = new TooBoxItemDragDropData(Datas);
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

            Invalidate(false);

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
                //label1.Text = "" + (r * cnt + c) + ", " + (int)distance + " : " + arrow;
                //label1.Update(); 
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
                else if (0 < (dropObject.Datas?.Count ?? 0))
                {
                    bool hasAddControl = false;
                    List<Control> addControls = new List<Control>();

                    Point __nearpt = NearPoint;
                    foreach (DragDropFkData fkdata in dropObject.Datas)
                    {
                        Control ctrl = Activator.CreateInstance(Type.GetType(fkdata.Data.TypeName)) as Control;
                        this.Controls.Add(ctrl); hasAddControl = true;
                        IFkData content = ctrl as IFkData;
                        if (content != null)
                        {
                            content.SetData(fkdata.Data);
                        }
                        addControls.Add(ctrl);
                        ctrl.Location = __nearpt;
                        ctrl.Left += fkdata.OffsetX;
                        ctrl.Top += fkdata.OffsetY;
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
            else if (e.AllowedEffect == DragDropEffects.Move && e.Data.GetDataPresent(typeof(DragMoveControlObject).FullName))
            {
                DragMoveControlObject dropObject = e.Data.GetData(e.Data.GetFormats()[0]) as DragMoveControlObject;
                if (dropObject != null)
                {
                    if (dropObject != null && !this.Equals(dropObject.MoveControl))
                    {
                        if (this.Controls.Contains(dropObject.MoveControl) == false)
                        {
                            this.Controls.Add(dropObject.MoveControl);
                        }
                        dropObject.MoveControl.Location = NearPoint;
                        dropObject.MoveControl.BringToFront();
                        dropObject.MoveControl.Focus();
                        dropObject.IsSuccess = dropObject.MoveControl.Visible = true;
                        SetMagnatic(dropObject.MoveControl);
                    }
                    this.FindForm().Invalidate(true);
                }
                control_MouseUp(null, null);
            }
        }
         
        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            if ((e.AllowedEffect == DragDropEffects.Move && e.Data.GetDataPresent(typeof(DragMoveControlObject).FullName)) ||
                (e.AllowedEffect == DragDropEffects.Copy && e.Data.GetDataPresent(typeof(TooBoxItemDragDropData).FullName)))
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
            else if (e.AllowedEffect == DragDropEffects.Move && e.Data.GetDataPresent(typeof(DragMoveControlObject).FullName))
            {
                FkData.DragShareMoveControl.MoveDragOverControl = this;
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

        //사용안함 : 주석을 해제하면 클릭했을때 판넬이 선택이 안됨.
        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //    FkCtrlUx.SelectedFkControls.Clear();
        //    Invalidate(true);
        //}
    }
}
