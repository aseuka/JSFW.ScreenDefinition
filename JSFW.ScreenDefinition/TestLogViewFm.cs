using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSFW
{
    public partial class TestLogViewFm : Form
    {
        public TestLogViewFm()
        {
            InitializeComponent();
        }

        public void SetData(string path)
        {
            ScreenDefinition.TestResult result = Ux.LoadFile<ScreenDefinition.TestResult>(path);
            label2.Text = $"{result:RESULT}";

            int order = 1;
            result.Funcs.ForEach(f =>
            {
                txtLog.AppendText($"{order++,2}) {(f.IsConfirm?"[합격]":"[실패]")}{Environment.NewLine}");
                txtLog.AppendText("    " + f.Text.Replace(Environment.NewLine, Environment.NewLine + "    ") + Environment.NewLine + Environment.NewLine);
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
