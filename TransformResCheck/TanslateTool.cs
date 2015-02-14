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
        //读取用户数据生成的数据表
        private DataTable userTable;

        //用以做对比的标准表
        private DataTable keyTable;


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

        //点击后，选择用户表，读入数据
        private void ReadExcelBtn_Click(object sender, EventArgs e)
        {
            string pathName = GetPathNameByChoose();
            string sheetName = PathAndName.sheetName;
            userTable = getData(pathName, sheetName);

            this.dgv.DataSource = userTable;

            //读入标准Excel表中内容
            pathName = PathAndName.Path + PathAndName.KeyExcelName;
            sheetName = PathAndName.sheetName;
            keyTable = getData(pathName, sheetName);
        }

        //点击后，根据当前用户数据，生成Resx文件
        private void ToResxBtn_Click(object sender, EventArgs e)
        {
            IOresx iox = new IOresx();
            if (userTable != null)
            {
                string pathName = PathAndName.Path + PathAndName.resxFileNames["en"];
                iox.WritePairToResx(pathName, userTable);  //输出为英文的资源
            }
        }

        //检查用户Excel中的内容
        private void CheckBtn_Click(object sender, EventArgs e)
        {
            if (userTable == null)
            {
                MessageBox.Show("没有数据");
                return;
            }
            //根据设定的规则，使用标准表，对用户表进行检查
            //修改userTable的内容
            //CheckRules

        }

        /// <summary>
        /// 通过系统选择方式，得到文件路径名
        /// </summary>
        private string GetPathNameByChoose()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "(*.xls;*.xlsx)|*.xls;*.xlsx";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                return fileDialog.FileName;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 从Excel读取数据表
        /// </summary>
        private DataTable getData(string pathName, string sheetName, string HDR="NO")
        {
            ExcelReading er = new ExcelReading(pathName, sheetName, HDR);

            return er.dataTable;
        }


    }
}
