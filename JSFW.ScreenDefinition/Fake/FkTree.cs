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
    public partial class FkTree : UserControl, IFkData
    { 
        Popup Editor = null;
        EditorFkTree TreeEditor = null;

        List<TNode> Nodes { get; set; } = new List<TNode>();

        TNode CurrentNode { get; set; } = null;

        public FkData Data { get; internal set; } = new FkData()
        {
            TypeName = typeof(FkTree).FullName,
            Text = "트리",          
            BackColor = Color.White,
            Visible = true,
            Left = 0,
            Top = 0,
            Width = 151,
            Height = 193,
            IsTree = true,
            TreeContents = @"
#LV1
##@LV2-1
##LV2-2
###LV2-2-1
##LV2-3
###LV2-3-1
###LV2-3-1"
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

            InitRender(Data?.TreeContents??"");
            Invalidate();
        }

        public void DataFlush()
        {
            Data.Left = this.Left;
            Data.Top = this.Top;
            Data.Width = this.Width;
            Data.Height = this.Height;

            SetTreeContent();
        }

        private void SetTreeContent()
        {
            string content = "";
            foreach (var tn in Nodes)
            {
                content += $"{new string('#', tn.Lv)}{(tn.Equals(CurrentNode) ? "@" : "")}{tn.Text}{Environment.NewLine}";
            }
            Data.TreeContents = content;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (isDataBinding || Data == null) return;
            Data.Width = this.Width;
            Data.Height = this.Height;
        }
         
        public FkTree()
        {
            InitializeComponent();

            DoubleBuffered = true;

            Editor = new Popup(TreeEditor = new EditorFkTree());
            Editor.AutoClose = true;
            Editor.Opening += Editor_Opening;
            Editor.Closing += Editor_Closing;
             
            SetData(Data);
        }

        private void Editor_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            IFkData ied = TreeEditor;
            ied.DataFlush();
            SetData(Data);
        }

        private void Editor_Opening(object sender, CancelEventArgs e)
        {
            DataFlush();
            IFkData ied = TreeEditor;
            ied.SetData(Data);
        }

        private void DataClear()
        {
            CurrentNode = null;
            for (int loop = Nodes.Count - 1; loop >= 0; loop--)
            {
                Clear(Nodes[loop]);
                Nodes.RemoveAt(loop);
            }
        }
          
        private void Clear(TNode node)
        {
            for (int loop = node.Nodes.Count - 1; loop >= 0; loop--)
            {
                Clear(node.Nodes[loop]);
                node.Nodes.RemoveAt(loop);
            }
            node.Nodes.Clear();
        }

        internal void InitRender(string treeContent)
        {
            DataClear();

            TNode rootNode = new TNode() { Lv = 0, Text = "ROOT" };
            TNode currentNode = rootNode;

            string[] nodes = treeContent.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string nodestring in nodes)
            {
                int lv = 0;
                string nstring = nodestring.Trim();
                for (int loop = 0; loop < nstring.Length; loop++)
                {
                    if (nstring[loop] == '#')
                    {
                        lv++;
                    }
                    else break;
                }

                if (lv <= 0) lv = 1;

                string txt = nstring.TrimStart('#');
                bool isSelected = false;
                if (txt.StartsWith("@"))
                {
                    isSelected = true;
                }
                txt = txt.TrimStart('@');

                TNode tn = new TNode();
                tn.Text = txt;
                tn.Lv = lv;
                Nodes.Add(tn);

                if (isSelected)
                {
                    CurrentNode = tn;
                }

                if (currentNode.Lv < lv)
                {
                    currentNode.Add(tn);
                    currentNode = tn;
                }
                else if (lv < currentNode.Lv)
                {
                    do
                    {
                        currentNode = currentNode.UpNode;
                    } while (!(currentNode.Lv < lv));
                    currentNode.Add(tn);
                    currentNode = tn;
                }
                else
                {
                    currentNode.UpNode.Add(tn);
                    currentNode = tn;
                }
            }
            rootNode = null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int x = 0;
            int y = 0;
            ListRender(Data.IsTree, e.Graphics, Font, Color.White, Color.Black, x, y, Width, 20);
             
            bool vis = Data.Visible;
            if (vis == false)
            {
                FkCtrlUx.UnVisibleDraw(this, e.Graphics);
            }
        }

        internal void ListRender(bool isTree, Graphics g, Font font, Color back, Color fore, int x, int y, int w, int h)
        {
            foreach (TNode tn in Nodes)
            {
                if (tn.Equals(CurrentNode))
                {
                    tn.Draw(isTree, g, font, Color.DodgerBlue, Color.White, x, y, w, h);
                }
                else
                {
                    tn.Draw(isTree, g, font, back, fore, x, y, w, h);
                }
                y += 20;
            }
        }
         
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            int y = 0;
            bool isSelectChanged = false;
            foreach (TNode tn in Nodes)
            {
                if (Rectangle.FromLTRB(0, y, Width, y + 20).Contains(e.Location))
                {
                    CurrentNode = tn;
                    isSelectChanged = true;
                }
                y += 20;
            }

            if (isSelectChanged)
            {
                SetTreeContent();
            }
            Invalidate();
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

    public class TNode
    {
        public TNode UpNode { get; set; } = null;
        public List<TNode> Nodes { get; private set; } = new List<TNode>();

        public int Lv { get; set; }

        public string Text { get; set; }

        public override string ToString()
        {
            return $"{Lv}. {Text}";
        }

        public int X { get; set; }
        public int Y { get; set; }

        internal void Add(TNode tn)
        {
            tn.UpNode = this;
            Nodes.Add(tn);
        }

        internal void Draw(bool isTree, Graphics g, Font fnt, Color backColor, Color forecolor, int x, int y, int width, int height)
        {
            g.FillRectangle(new SolidBrush(backColor), x, y, width, y + height);
            if (isTree)
            {
                TextRenderer.DrawText(g, new string(' ', 4 * (Lv - 1)) + Text,
                            fnt, Rectangle.FromLTRB(x, y, width, y + height),
                            forecolor, backColor, TextFormatFlags.VerticalCenter);
            }
            else
            {
                TextRenderer.DrawText(g, Text, // GetFullPath(),
                                fnt, Rectangle.FromLTRB(x, y, width, y + height),
                                forecolor, backColor, TextFormatFlags.VerticalCenter);
            }
        }

        private string GetFullPath()
        {
            string txt = $"[{Text}]";
            TNode tn = this;
            while (tn.UpNode != null)
            {
                tn = tn.UpNode;
                txt = $"[{tn.Text}] > {txt}";
            }
            return txt;
        }
    }

}
