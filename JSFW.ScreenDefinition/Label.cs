using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW
{
    //http://aripom.hatenablog.com/entry/2016/08/20/174046
    public class Label : System.Windows.Forms.Label
    {
        private const int WM_LBUTTONDCLICK = 0x203;
        private DataObject clipboardData;   // クリップボードの中身を保持する

        [DefaultValue(false)]
        [Description("Overrides default behavior of Label to copy label text to clipboard on double click")]
        public bool CopyTextOnDoubleClick { get; set; }

        protected override void OnDoubleClick(EventArgs e)
        {
            // データをセット（強制コピーされる前のデータをセット）
            Clipboard.SetDataObject(clipboardData);
            base.OnDoubleClick(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (!CopyTextOnDoubleClick)
            {
                if (m.Msg == WM_LBUTTONDCLICK)
                {
                    // クリップボードを保持している内部データをリセット
                    clipboardData = new DataObject();

                    // クリップボードの中身を取得
                    IDataObject d = Clipboard.GetDataObject();

                    // 全てのDataFormatsのフィールドを検索
                    foreach (FieldInfo info in typeof(DataFormats).GetFields(BindingFlags.Static | BindingFlags.Public))
                    {
                        string format = info.GetValue(null).ToString();

                        // 変換可能なら
                        if (d.GetDataPresent(format) && format != "EnhancedMetafile")
                        {
                            try
                            {
                                // データに追加していく
                                clipboardData.SetData(format, false, d.GetData(format));
                            }
                            catch
                            {
                                //EnhancedMetafile
                                // ppt에서 복사한 객체가 있는 경우! 예외 발생.
                            }
                        }
                    }
                }
            }
            base.WndProc(ref m);
        }
    }
}
