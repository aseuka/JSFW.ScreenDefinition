using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.Fake
{
    class JSFW_ChartII : IDisposable
    {
        public enum ChartSeriesType { Line, Column };

        List<Series> ChartSeries = new List<Series>();

        public IList<Series> IChartSeries { get { return ChartSeries; } }

        Control TargetControl { get; set; }

        public bool IsInited { get; set; }

        /// <summary>
        /// Maximum 최대값
        /// </summary>
        public long Maximum = 1L;

        /// <summary>
        /// Minimum
        /// </summary>
        public long Minimum = -1L;

        public int? XOffset { get; set; }
        public int? YOffset { get; set; }

        const int xyOffset = 20;

        internal string[] AxisXs { get; set; }

        /// <summary>
        /// 표시 x축 개수
        /// </summary>
        public long Display_Xcount { get; set; }

        /// <summary>
        /// 펜! ( 그래프 )
        /// </summary>
        Pen p = new Pen(Color.FromArgb(150, Color.Black));

        public JSFW_ChartII(Control target)
        {
            TargetControl = target;
            target.Paint += target_Paint;
        }

        void target_Paint(object sender, PaintEventArgs e)
        {
            if (IsInited)
            {
                DrawBackground(e.Graphics, TargetControl.DisplayRectangle);
            }
        }

        /// <summary>
        /// 백그라운드 ( X축, Y축 그리기 )
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rct"></param>
        void DrawBackground(Graphics g, Rectangle rct)
        {
            if (Display_Xcount == 0) Display_Xcount = 1;

            float offsetz = TargetControl.Width / (Display_Xcount + 2);
            ControlPaint.DrawGrid(g, rct, new Size((int)offsetz, (int)offsetz), Color.Green);
            g.DrawLine(p, 0, TargetControl.Height - (YOffset ?? xyOffset), TargetControl.Width, TargetControl.Height - (YOffset ?? xyOffset)); // x 축
            g.DrawLine(p, (XOffset ?? xyOffset), 0, (XOffset ?? xyOffset), TargetControl.Bottom);  // y축

            float offsetx = (TargetControl.Width - ((XOffset ?? xyOffset) - 10)) / Display_Xcount;
            float drawheight = (float)TargetControl.Height - (YOffset ?? xyOffset);
            float total =  xyOffset + xyOffset * 0.75f; // offsetx; // 시작 포인트

            for (int loop = 0; loop < Display_Xcount; loop++)
            {
                string xName = GetAxixX_Name(loop);
                SizeF textSize = TextRenderer.MeasureText(xName, TargetControl.Font);
                // X축 점 찍기! 
                TextRenderer.DrawText(g, xName, TargetControl.Font, new Point((int)(total), TargetControl.Height - (xyOffset - 5)), Color.Black);
                total += offsetx;
            }

            for (long loop = Minimum; loop < Maximum; loop++)
            {
                // Y축 점 찍기!
            }
        }

        private string GetAxixX_Name(int loop)
        {
            string xName = "";
            if (0 <= loop && loop < AxisXs.Length)
                xName = AxisXs[loop];
            return xName.Trim();
        }

        public Series AddSeries(ChartSeriesType seriesType, Color penColor)
        {
            Series ns = new Series(this, seriesType, TargetControl);
            ns.p = new Pen(Color.FromArgb(150, penColor));
            ChartSeries.Add(ns);
            return ns;
        }


        /// <summary>
        /// x축 설정
        /// </summary>
        public void Init(params string[] axisXs)
        {
            AxisXs = axisXs;
            if (AxisXs != null)
            {
                Display_Xcount = axisXs.Length;
            }
            else
            {
                AxisXs = new string[] { "" };
                Display_Xcount = 1;
            }
            IsInited = true;
            //    Clear();
        }

        public void Dispose()
        {

        }


        /// <summary>
        /// 챠트 컨트롤!! 
        /// </summary>
        public class Series : IDisposable
        {
            JSFW_ChartII Chart { get; set; }

            /// <summary>
            /// 큐~ 리스트 
            /// </summary>
            Queue<ChartPointII> list = new Queue<ChartPointII>();

            /// <summary>
            /// 그려질 컨트롤 패널
            /// </summary>
            Control drawPanel = null;

            public string TitleText { get; set; }

            public int? XOffset { get; set; }
            public int? YOffset { get; set; }

            const int xyOffset = 20;

            ChartSeriesType SeriesType = ChartSeriesType.Line;

            /// <summary>
            /// 생성자
            /// </summary>
            /// <param name="ctrl">그려질 곳</param>
            public Series(JSFW_ChartII chart, ChartSeriesType seriesType, Control ctrl)
            {
                p = new Pen(Color.FromArgb(150, Color.Blue));
                SeriesType = seriesType;
                Chart = chart;
                drawPanel = ctrl;
                ctrl.Paint += new PaintEventHandler(ctrl_Paint);
                ctrl.Resize += new EventHandler(ctrl_Resize);
            }

            /// <summary>
            /// 갯수
            /// </summary>
            internal int Count
            {
                get { return list.Count; }
            }

            /// <summary>
            /// 사이즈 변경!
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void ctrl_Resize(object sender, EventArgs e)
            {
                if (Chart.IsInited) drawPanel.Invalidate();
            }

            /// <summary>
            /// 그리기... 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void ctrl_Paint(object sender, PaintEventArgs e)
            {
                if (Chart.IsInited)
                {
                    //DrawBackground(e.Graphics, drawPanel.DisplayRectangle);
                    DrawTitleString(TitleText, e.Graphics, drawPanel);
                    DrawLine(e.Graphics);
                }
            }

            private static void DrawTitleString(string title, Graphics graphics, Control ctrl)
            {
                Font ft = new Font(ctrl.Font.FontFamily, 15f, FontStyle.Bold);
                SizeF titleBox = graphics.MeasureString(title, ft);

                float centerX = ctrl.Width / 2f - titleBox.Width / 2f;
                float centerY = ctrl.Height / 2f - titleBox.Height / 2f;

                Color drawColor = Color.FromArgb(40, 255, 0, 0);
                TextRenderer.DrawText(graphics, title, ft, Point.Round(new PointF(centerX, centerY)), drawColor);
            }

            /// <summary>
            /// 펜! ( 그래프 )
            /// </summary>
            public Pen p { get; set; }

            List<ChartPointII> items = new List<ChartPointII>();

            /// <summary>
            /// 라인 그리기 
            /// </summary>
            /// <param name="g"></param>
            void DrawLine(Graphics g)
            {
                float offsetx = (drawPanel.Width - ((XOffset ?? xyOffset) - 10 )) / Chart.Display_Xcount;
                float drawheight = (float)drawPanel.Height - (YOffset ?? xyOffset);
                float total = xyOffset + xyOffset * 0.75f;// offsetx;
                items.Clear();
                items.AddRange(list.ToArray());

                long maxOffset = 10L;

                //챠트 시리즈가 겹칠경우를 대비해 조금씩 그려지는 위치에 조정값을 줌.
                int idx = Chart.ChartSeries.IndexOf(this);
                total += (idx * 5f);

                // 동일한 시리즈 일때... 옆으로 옮겨야 되는데.
                // 다른 시리즈일때도 ... 옆으로 간다? 

                for (int loop = 0; loop < items.Count; loop++)
                {
                    ChartPointII item0 = items[loop];
                    if (SeriesType == ChartSeriesType.Line)
                    {
                        g.DrawEllipse(Pens.Coral, total - 1f, drawheight - (((float)item0._ypoint * drawheight) / (Chart.Maximum + maxOffset)) - 1f, 2f, 2f);
                        TextRenderer.DrawText(g, ((float)item0._ypoint).ToString(), drawPanel.Font, new Point((int)total, (int)(drawheight - ((float)item0._ypoint * drawheight) / (Chart.Maximum + maxOffset))), p.Color);

                        if (loop + 1 < items.Count)
                        {
                            ChartPointII item1 = items[loop + 1];
                            // y점 구하는 공식 : 표시 height : MaxValue = 실제y포인트값 : x  를 풀어서 X값이 나오면 y축 좌표계에 따라 표시 Height 에서 뺀다! 
                            g.DrawLine(p, new PointF(total, drawheight - ((float)item0._ypoint * drawheight) / (Chart.Maximum + maxOffset)), new PointF(total + offsetx, drawheight - ((float)item1._ypoint * drawheight) / (Chart.Maximum + maxOffset)));
                        }
                    }
                    else
                    {
                        g.DrawEllipse(Pens.Coral, total - 2.25f, drawheight - (((float)item0._ypoint * drawheight) / (Chart.Maximum + maxOffset)) - 1f, 2f, 2f);
                        TextRenderer.DrawText(g, ((float)item0._ypoint).ToString(), drawPanel.Font, new Point((int)total, (int)(drawheight - ((float)item0._ypoint * drawheight) / (Chart.Maximum + maxOffset))), p.Color);

                        g.FillRectangle(p.Brush, new RectangleF(total - 5f, drawheight - ((float)item0._ypoint * drawheight) / (Chart.Maximum + maxOffset), 10, drawPanel.Height - (drawheight - ((float)item0._ypoint * drawheight) / (Chart.Maximum + maxOffset)) - (YOffset ?? xyOffset)));
                    }
                    total += offsetx;
                    // if (loop >= items.Length) break;
                }
            }

            /// <summary>
            /// 좌표값 추가! 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public Series Add(long y)
            {
                return Add(y, y);
            }

            /// <summary>
            /// 좌표값 추가! 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public Series Add(long y, long MaxY)
            {
                ChartPointII c;
                Chart.Maximum = Chart.Maximum < y ? y : Chart.Maximum;
                if (MaxY > Chart.Maximum)
                {
                    Chart.Maximum = MaxY;
                }
                if (list.Count > (Chart.Display_Xcount - 1))
                {
                    c = list.Dequeue();
                    c._ypoint = y;
                }
                else
                {
                    c = new ChartPointII(y);
                }
                list.Enqueue(c);

                if (drawPanel != null) drawPanel.Invalidate();
                return this; // chain!
            }

            #region IDisposable 멤버

            /// <summary>
            /// 해제
            /// </summary>
            public void Dispose()
            {
                if (drawPanel != null)
                {
                    drawPanel.Paint -= new PaintEventHandler(ctrl_Paint);
                    drawPanel.Resize -= new EventHandler(ctrl_Resize);
                }
                drawPanel = null;
                Chart = null;
                Clear();
            }

            #endregion

            public void Clear()
            {
                if (list != null) list.Clear();
                // for (int loop = 0; loop < Display_Xcount; loop++) { Add("", 0); } 
            }

            public void createEmpty(long? displayxCount = 20)
            {
                long display = displayxCount ?? Chart.Display_Xcount;

                for (int loop = 0; loop < display; loop++)
                {
                    Add(0);
                }
            }


            /// <summary>
            /// 챠트 좌표 포인트
            /// </summary>
            public struct ChartPointII : IDisposable
            {
                /// <summary>
                /// 값 ( 값 )
                /// </summary>
                public float _ypoint;
                /// <summary>
                /// 생성자
                /// </summary> 
                /// <param name="_y"></param>
                public ChartPointII(float _y)
                {
                    _ypoint = _y;
                }

                #region IDisposable 멤버
                /// <summary>
                /// 해제
                /// </summary>
                public void Dispose()
                {
                    _ypoint = 0L;
                }
                #endregion
            }
        }

        public void SeriesClear()
        {
            foreach (var s in IChartSeries)
            {
                using (s)
                {

                }
            }

            IChartSeries.Clear();
        }
    }
}
