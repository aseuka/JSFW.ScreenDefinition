using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceGrid;
using JSFW.GridDesignerCommon;

namespace JSFW.Fake
{
    public partial class FkDataGrid : Grid, IFkData
    {
        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkDataGrid).FullName,
            Text = "그리드",
            Visible = true,
            Left = 0,
            Top = 0,
            Width = 250,
            Height = 150,
            GridSettings = "",
        };

        GridSettings settings { get; set; }

        GridSettings displaySettings { get; set; } = null;

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

                settings?.Dispose();
                settings = null;

                if (string.IsNullOrWhiteSpace(data.GridSettings) == false)
                {
                    settings = Newtonsoft.Json.JsonConvert.DeserializeObject<GridSettings>(Data.GridSettings);
                }
                else
                {
                    settings = new GridSettings() { GUID = Guid.NewGuid().ToString("N") };
                }
              //  settings.To(this);
            }
            finally
            {
                isDataBinding = false;
            }

            displaySettings = settings.Clone() as GridSettings;
             
            SetRowHeights();
            Invalidate();
        }

        public void DataFlush()
        {
            Data.Left = this.Left;
            Data.Top = this.Top;
            Data.Width = this.Width;
            Data.Height = this.Height;
            Data.GridSettings = Newtonsoft.Json.JsonConvert.SerializeObject(settings);
        }

        private void SetRowHeights()
        {
            if (displaySettings == null) return;
            rowHeights.Clear();
            for (int row = 0; row < displaySettings.Rows.Count; row++)
            {
                rowHeights.Add(_ROW_HEIGHT);
            }
            rowHeights.Add(5); //행간 간격

            //마지막 줄 두껍게
            //for (int row = 0; row < displaySettings.Rows.Count - 1; row++)
            //{
            //    rowHeights.Add(_ROW_HEIGHT);
            //}
            //rowHeights.Add(_ROW_HEIGHT + _ROW_HEIGHT);
        }
         
        private void SetColWidths()
        {
            if (displaySettings == null) return;
            colWidths.Clear();

            int rIdx = displaySettings.Rows.Count - 1;
            for (int col = 0; col < displaySettings.Columns.Count; col++)
            {
                //SizeF sf = TextRenderer.MeasureText($"{displaySettings.Columns[col].Name}<{displaySettings.Rows[rIdx].Cells[col].Value}>", fnt);
                SizeF sf = TextRenderer.MeasureText($"{displaySettings.Rows[rIdx].Cells[col].Value}", fnt);
                colWidths.Add((int)(sf.Width + 8f));
            }
        }
        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (isDataBinding || Data == null) return;
            Data.Width = this.Width;
            Data.Height = this.Height;
        }

        public FkDataGrid()
        {
            InitializeComponent();

            DoubleBuffered = true;

            GridSettings.UseScreenDefinition = true;

            BorderStyle = BorderStyle.FixedSingle;

            SetData(Data);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            ((IFkData)this)?.ShowEdit();
        }

        void IFkData.ShowEdit()
        {
            settings.Visible = Data.Visible;
            if (settings.Edit() == DialogResult.OK)
            {
                isDataBinding = true;
                try
                {
                    Data.Visible = settings.Visible;
                    this.Rows.Clear();
                    this.Columns.Clear();
                    this.FixedColumns = 0;
                    this.FixedRows = 0;
                    this.Redim(0, 0);

                    displaySettings?.Dispose();
                    displaySettings = null;

                    displaySettings = settings.Clone() as GridSettings;
                    SetRowHeights();
                    SetColWidths();

                }
                finally
                {
                    isDataBinding = false;
                    Invalidate();
                }
            }
        }
         
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (isDataBinding) return;

            if (displaySettings == null) return;
            DrawGrid(e.Graphics);

            bool vis = (Data?.Visible ?? false);
            if (vis == false)
            {
                FkCtrlUx.UnVisibleDraw(this, e.Graphics);
            }
        }
        
        Font fnt = new Font("굴림체", 8.5f); 
        List<int> rowHeights = new List<int>();
        List<int> colWidths = new List<int>();
        //int colWidth = 140;
        int _ROW_HEIGHT = 22;
         
        private void DrawGrid(Graphics g)
        {
            List<CellRange> cr = GridSettings.GetMergeCellRange(displaySettings, true);

            if (cr.Count <= 0) return;
            if (rowHeights.Count <= 0)
            {
                SetRowHeights();
            }

            if (colWidths.Count <= 0)
            {
                SetColWidths();
            }
              
            int oldxCol = 0;
            int lstRowIndex = cr.Max(r => r.r2);
            int ycnt = 0;

            foreach (CellRange cell in cr)
            {
                //int x =  (cell.c1 - oldxCol) * colWidth;
                //int y = 0;
                //int xx = ((cell.c2 - cell.c1) + 1) * colWidth;
                //int yy = 0;

                int x = 0;
                int xx = 0;
                for (int colIdx = oldxCol; colIdx < cell.c1; colIdx++)
                {
                    x += colWidths[colIdx];
                }

                for (int colIdx = cell.c1; colIdx <= cell.c2; colIdx++)
                {
                    xx += colWidths[colIdx];
                }

                int y = 0; 
                int yy = 0;
                for (int rowIdx = 0; rowIdx < cell.r1; rowIdx++)
                {
                    y += rowHeights[rowIdx];
                }

                for (int rowIdx = cell.r1; rowIdx <= cell.r2; rowIdx++)
                {
                    yy += rowHeights[rowIdx];
                } 

                if (this.Width < (x + xx))
                {
                    oldxCol = cell.c1;
                    // x = (cell.c1 - oldxCol) * colWidth;
                    x = 0;
                    ycnt++;
                }
                y += ycnt * rowHeights.Sum();
                //y += ycnt * _ROW_HEIGHT;
                //y += ycnt * -15;

                Rectangle rect = Rectangle.FromLTRB(x, y, x + xx, y + yy);

                string txt = $"{cell.Value}";

                if (cell.r2 == lstRowIndex)
                {
                    //txt = (displaySettings.Columns[cell.c1].Required ? "*" : "") + $"{displaySettings.Columns[cell.c1].Name}<{cell.Value}>";
                    txt = (displaySettings.Columns[cell.c1].Required ? "*" : "") + $"{cell.Value}";
                    g.FillRectangle(Brushes.Ivory, rect);
                }

                if (settings.Columns[cell.c1].Visible)
                {
                    g.DrawRectangle(Pens.Gray, rect);
                    TextRenderer.DrawText(g, txt, fnt, rect, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                else
                {
                    if (cell.r2 == lstRowIndex)
                    {
                        g.DrawRectangle(Pens.Gray, rect);
                        TextRenderer.DrawText(g, txt, fnt, rect, Color.Silver, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                    else
                    {
                        g.DrawRectangle(Pens.Gray, rect);
                        TextRenderer.DrawText(g, txt, fnt, rect, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }
            }
        }
    }
}