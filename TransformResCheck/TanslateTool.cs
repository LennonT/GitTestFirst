using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using TransformResCheck.Model;

namespace TransformResCheck
{
    public partial class TanslateTool : Form
    {

        private DataTable dtable;

        public TanslateTool()
        {
            InitializeComponent();
        }

        //遍历整个表，来输出
        private void printData(System.Data.DataTable dt)
        {
            foreach (DataRow item in dt.Rows)
            {
                foreach (var data in item.ItemArray)
                {
                    Debug.WriteLine(Convert.ToString(data));
                }
            }
        }

        private void ReadExcelBtn_Click(object sender, EventArgs e)
        {
            string pathName = PathAndName.Path + PathAndName.DataExcelName;
            string sheetName = PathAndName.sheetName;

            ExcelReading er = new ExcelReading(pathName, sheetName, "NO");

            dtable = er.dataTable;
            this.dgv.DataSource = dtable;
#if DEBUG
            printData(er.dataTable);
#endif
        }

        private void ToResxBtn_Click(object sender, EventArgs e)
        {
            IOresx iox = new IOresx();
            if (dtable != null)
            {
                string pathName = PathAndName.Path + PathAndName.resxFileNames["en"];
                iox.WritePairToResx(pathName, dtable);  //输出为英文的资源
            }
        }

        //检查Excel中的内容
        private void CheckBtn_Click(object sender, EventArgs e)
        {
            if (dtable == null)
            {
                MessageBox.Show("没有数据");
                return;
            }
            

        }


    }
}
