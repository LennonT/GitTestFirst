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
        private List<DataTable> userTablesFromExcel;
        private List<DataTable> userTablesFromResx;

        /// <summary>
        /// 用以做参考的标准表(来自Excel数据）
        /// </summary>
        private DataTable keyTable;

        /// <summary>
        /// 用于操作Resx文件的句柄
        /// </summary>
        private ResxIO ResxHandle;

        /// <summary>
        /// 用于操作Excel的句柄
        /// </summary>
        ExcelIO ExcelHandle;


        public TanslateTool() 
        {                                                                                                                                                                                                                                                                                                                                                                                                                    
            InitializeComponent();

            ExcelHandle = new ExcelIO();
            ResxHandle = new ResxIO();

            userTablesFromExcel = new List<DataTable>();
            userTablesFromResx = new List<DataTable>();
        }

        #region 读取Excel，转换为Resx
        //点击后，选择用户表，读入数据
        private void ReadExcelBtn_Click(object sender, EventArgs e)
        {

            List<string> excelName_full = GetPathNameByChoose(true);  //Excel文件名（完整路径）
            if (excelName_full.Count == 0)
            {
                ShowResult("未读取到Excel数据");
                return;
            }
            string sheetName = InfoDict.sheetName[0];
            userTablesFromExcel.Add(GetDataFromExcel(excelName_full[0], sheetName));

            this.dgv.DataSource = userTablesFromExcel[0];    //将当前读取的用户表数据显示在界面上

            //读入标准Excel表中内容
            string StandardexcelName_full = InfoDict.Path + @"\" + InfoDict.StandardExcelName;
            sheetName = InfoDict.sheetName[0];
            keyTable = GetDataFromExcel(StandardexcelName_full, sheetName);
        }

        //点击后，根据当前用户数据，生成Resx文件
        private void ToResxBtn_Click(object sender, EventArgs e)
        {
            if (userTablesFromExcel.Count == 0)
            {
                ShowResult("当前没有从Excel中读取到的数据...");
                return;
            }

            //此处在做批量操作时可修改
            string fileName_full = InfoDict.Path + @"\" + InfoDict.resxFileNames["en"];  
            ResxHandle.WriteDataToResx(fileName_full, userTablesFromExcel[0], new InfoIndex());  //输出为英文的资源
        }

        //检查用户Excel中的内容
        private void CheckBtn_Click(object sender, EventArgs e)
        {
            if (userTablesFromExcel.Count == 0)
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
        private List<string> GetPathNameByChoose(bool isExcel=true)
        {
            List<string> names = new List<string>();

            OpenFileDialog fileDialog = new OpenFileDialog();
            if (isExcel)
            {
                fileDialog.Filter = "(*.xls;*.xlsx)|*.xls;*.xlsx|(所有文件)|*.*";
            }
            else
            {
                fileDialog.Filter = "(*.resx)|*.resx|(所有文件)|*.*";
            }

            fileDialog.InitialDirectory = @"C:\Users\Lennon\Desktop\Workspace";
            fileDialog.RestoreDirectory = true;

            fileDialog.Multiselect = true;  //可以一次选择多个文件


            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var item in fileDialog.FileNames)
                {
                    names.Add(item);
                }
            }

            return names;
        }

        /// <summary>
        /// 从Excel读取数据表
        /// </summary>
        private DataTable GetDataFromExcel(string fileName_full, string sheetName, string HDR="NO")
        {
            return ExcelHandle.ReadExcel(fileName_full, sheetName);
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

        #endregion 读取Excel，转换为Resx

        #region 读取Resx，转换为Resx
        private void ReadResxBtn_Click(object sender, EventArgs e)
        {
            List<string> resxFileName_full = GetPathNameByChoose(false);

            if (resxFileName_full.Count == 0)
            {
                ShowResult("读取resx文件错误");
                return;
            }
            //从Resx文件读取数据，并生成DataTable
            userTablesFromResx.Add(ResxHandle.ReadDataFromResx(resxFileName_full[0]));

            ShowResult("读取Resx文件成功");
        }

        #endregion 读取Resx，转换为Resx

        private void CheckResxBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void ToExcelBtn_Click(object sender, EventArgs e)
        {
            //写入新的Excel文件
            string newExcelName_full = InfoDict.Path + @"\" + InfoDict.ForWriteExcelName;
            ExcelHandle.WriteExcelNew(userTablesFromResx[0], newExcelName_full);
        }

        internal void ShowResult(string message)
        {
            this.TipTxtBox.AppendText(message + Environment.NewLine + Environment.NewLine);
        }


    }
}
