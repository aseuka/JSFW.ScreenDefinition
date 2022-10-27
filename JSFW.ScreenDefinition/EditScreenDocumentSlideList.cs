using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW.ScreenDefinition
{
    public partial class EditScreenDocumentSlideList : Form
    {
        public event Action<Slide> SlideSelected = null;

        ScreenDocumentDetail Detail { get; set; }

        protected void OnSlideSelected(Slide slide)
        {
            SlideSelected?.Invoke(slide);
        }

        public Action ToSave = null;

        protected void OnSave()
        {
            ToSave?.Invoke();
        }

        public EditScreenDocumentSlideList()
        {
            InitializeComponent();
            this.Disposed += EditScreenDocumentSlideList_Disposed;
        }

        private void EditScreenDocumentSlideList_Disposed(object sender, EventArgs e)
        {
            SetFixedCurrentItemView(null);
            SetCurrentItemView(null);
            sdMiniView1.Data = null;
        }

        SlideItemView CurrentItemView { get; set; } = null;

        void SetCurrentItemView(SlideItemView item)
        {
            if( CurrentItemView != null && FixedCurrentItemView != CurrentItemView)
            { 
                CurrentItemView.BackColor = SystemColors.Control;
            }

            CurrentItemView = item;

            if (CurrentItemView != null && FixedCurrentItemView != CurrentItemView)
            {
                CurrentItemView.BackColor = Color.Coral;
            }
        }

        internal void SetData(ScreenDocumentHeader header, ScreenDocumentDetail detail, Slide oldSlide = null)
        {
            try
            {
                panel1.SuspendLayout();

                for (int loop = panel1.Controls.Count - 1; loop >= 0; loop--)
                {
                    SlideItemView item = panel1.Controls[loop] as SlideItemView;
                    using (item)
                    {
                        item.MouseDown -= Item_MouseDown;
                        item.MouseDoubleClick -= Item_MouseDoubleClick;
                    }
                }
                 
                sdMiniView1.SetData(header);

                Detail = detail;
                SetFixedCurrentItemView(null);
                SetCurrentItemView(null);
                int order = 1;

                SlideItemView firstSlideItemView = null;
                 
                foreach (Slide slide in Detail?.Slides.OrderBy(o => o.Order))
                {
                    SlideItemView item = new SlideItemView();
                    item.SetData(slide);
                    panel1.Controls.Add(item);
                    item.Dock = DockStyle.Top;
                    item.BringToFront();
                    item.MouseDown += Item_MouseDown;
                    item.MouseDoubleClick += Item_MouseDoubleClick;

                    if (oldSlide == null && order == 1)
                    {
                        firstSlideItemView = item;
                    }
                    else if (slide != null && slide == oldSlide)
                    {
                        firstSlideItemView = item;
                    }
                    order++;
                }

                SetFixedCurrentItemView(firstSlideItemView);
                SetCurrentItemView(firstSlideItemView);
                OnSlideSelected(CurrentItemView?.Data);

            }
            finally
            {
                panel1.ResumeLayout(false);
                panel1.PerformLayout();
            }
        }

        SlideItemView FixedCurrentItemView { get; set; } = null;
        void SetFixedCurrentItemView(SlideItemView item)
        {
            if (FixedCurrentItemView != null)
            {
                FixedCurrentItemView.BackColor = SystemColors.Control;
            }

            FixedCurrentItemView = item;

            if (FixedCurrentItemView != null)
            {
                FixedCurrentItemView.BackColor = Color.DodgerBlue;
            } 
        }

        private void Item_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetFixedCurrentItemView(CurrentItemView);
            OnSlideSelected(CurrentItemView?.Data);
        }

        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            SetCurrentItemView(sender as SlideItemView);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 추가
            Slide slide = new Slide();
            slide.Order = 1;            
            if (0 < Detail.Slides.Count)
            { 
                slide.Order = Detail.Slides.Max(m => m.Order) + 1;
            }
            slide.ScreenDocumentID = sdMiniView1.Data.ID;
            slide.ScreenDesignID = "미지정";
            slide.SystemMenuPath = sdMiniView1.Data.SystemMenuPath;
            slide.CreateDirectory();
            slide.CreateGrffity();
            Detail.Slides.Add(slide);
            SlideItemView item = new SlideItemView();
            item.SetData(slide);
            panel1.Controls.Add(item);
            item.Dock = DockStyle.Top;
            item.BringToFront();
            item.MouseDown += Item_MouseDown;
            item.MouseDoubleClick += Item_MouseDoubleClick;

            SetFixedCurrentItemView(item);
            SetCurrentItemView(item);
            OnSlideSelected(CurrentItemView?.Data);
            OnSave();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // 삭제
            foreach (SlideItemView item in panel1.Controls)
            {
                item.UseDelete(true);
            }

            btnDelOK.BringToFront();
            btnDelCancel.BringToFront();
        }

        private void btnDelOK_Click(object sender, EventArgs e)
        {
            // 삭제 처리
            SetCurrentItemView(null);
            OnSlideSelected(null);
            List<SlideItemView> dels = new List<SlideItemView>();
            foreach (SlideItemView item in panel1.Controls)
            {
                if(item.IsDelete)
                {
                    dels.Add(item);
                }
            }

            for (int loop = dels.Count - 1; loop >= 0; loop--)
            {
                SlideItemView item = dels[loop] as SlideItemView;
                using (item)
                {
                    item.MouseDown -= Item_MouseDown;
                    item.MouseDoubleClick -= Item_MouseDoubleClick;
                    Detail.Slides.Remove( item.Data );
                }
            }
            if (0 < dels.Count)
            {
                OnSave();
            }
             
            foreach (SlideItemView item in panel1.Controls)
            {
                item.UseDelete(false);
            }
            btnAdd.BringToFront();
            btnDel.BringToFront();
        }

        private void btnDelCancel_Click(object sender, EventArgs e)
        {
            // 삭제 취소
            foreach (SlideItemView item in panel1.Controls)
            {
                item.UseDelete(false);
            }
            btnAdd.BringToFront();
            btnDel.BringToFront();
        }

        private void sdMiniView1_Resize(object sender, EventArgs e)
        {

        }
    }
}
