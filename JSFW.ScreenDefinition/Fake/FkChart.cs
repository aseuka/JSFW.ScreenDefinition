using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopupControl;
using JSFW.Fake.Editor;

namespace JSFW.Fake
{
    public partial class FkChart : UserControl, IFkData
    {
        Popup Editor = null;
        EditorFkChart ChartEditor = null;

        JSFW_ChartII chart { get; set; }

        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkChart).FullName,
            Text = "챠트",
            TextAlign = FkDataTextAlign.Left,
            BackColor = Color.White,
            Visible = true,
            Left = 0,
            Top = 0,
            Width = 304,
            Height = 137,
            X축 = "AA BB CC DD EE",
            Series = "#Line|Red|20,60,10,50,90\r\n#Column|Black|50,20,90,60,5"
        };

        public FkChart()
        {
            InitializeComponent();

            chart = new JSFW_ChartII(this);
            chart.Init("");

            DoubleBuffered = true;

            this.Disposed += FkChart_Disposed;

            Editor = new Popup(ChartEditor = new EditorFkChart());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;

            SetData(Data);
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = ChartEditor;
            ied.DataFlush();
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = ChartEditor;
            ied.SetData(Data);
        }

        private void FkChart_Disposed(object sender, EventArgs e)
        {
            chart?.Dispose();
            chart = null;
        }

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

            if (Data != null)
            {
                DrawingChart(Data.X축, Data.Series);
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            bool vis = Data.Visible;
            if (vis == false)
            {
                FkCtrlUx.UnVisibleDraw(this, e.Graphics);
            }
        }

        private void DrawingChart(string xs, string series)
        {
            chart.SeriesClear();
            chart.Init(("" + xs).Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            // @"#Line|Red|20,60,10,50,90"
            // 챠트타입|색상|y값 목록(,) 
            var SeriesArray = ("" + series).Trim().Split("#".ToArray(), StringSplitOptions.RemoveEmptyEntries);

            if (SeriesArray.Length > 0)
            {
                foreach (var Series in SeriesArray)
                {
                    if (string.IsNullOrEmpty(Series.Trim())) continue;

                    var info = ("" + Series).Trim().Split("|".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (info.Length > 0)
                    {
                        var chartType = info[0];
                        var colorName = info[1];
                        var YValues = info[2].Split(',');
                        try
                        {
                            JSFW_ChartII.ChartSeriesType cType = JSFW_ChartII.ChartSeriesType.Line;

                            if (chartType.ToUpper() == "COLUMN")
                            {
                                cType = JSFW_ChartII.ChartSeriesType.Column;
                            }
                            var s = chart.AddSeries(cType, Color.FromName(colorName.TrimStart('#')));
                            foreach (var y in YValues)
                            {
                                if (string.IsNullOrEmpty(y.Trim())) continue;
                                s.Add(Convert.ToInt32(y));
                            }
                        }
                        catch
                        {
                            // 색상 및 y값 에러
                        }
                    }
                }
            }
            this.Invalidate();
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
}
