using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;  //使用数据库

using Microsoft.Office.Interop.Excel;  //做Excel操作的数据库

namespace TransformResCheck.Model
{
    public class ExcelIO
    {
        /// <summary>
        /// 用来保存从Excel表中读取到的全部数据
        /// </summary>
        public System.Data.DataTable dataTable;


        public ExcelIO()
        {
         
        }

        /// <summary>
        /// 执行从Excel读取数据到DB的函数
        /// </summary>
        /// <param name="fileName_full">Excel文件路径和名字</param>
        /// <param name="sheetName">需要读取的Sheet名</param>
        /// <param name="HDR"> 前几行是否有无效数据，NO:无，YES：有</param>
        /// <returns>得到的数据表</returns>
        public System.Data.DataTable ReadExcel(string fileName_full, string sheetName, string HDR = "NO")
        {
            try
            {
                //连接字符串
                //IMEX=0(写)1(读)2(读写)
                string str_conn = "Provider=Microsoft.ACE.OLEDB.12.0;" + 
                                 "Extended Properties=\'Excel 12.0;HDR=" + HDR + ";IMEX=1\';" + 
                                 "Data Source=" + fileName_full;

                using(OleDbConnection ole_conn = new OleDbConnection(str_conn))
                {
                    ole_conn.Open();
                    using (OleDbCommand ole_cmd = ole_conn.CreateCommand())
                    {
                        ole_cmd.CommandText = "SELECT * FROM  [" + sheetName + "$]";
                        OleDbDataAdapter adapter = new OleDbDataAdapter(ole_cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, sheetName);

                        return ds.Tables[sheetName];
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("数据绑定Excel失败! 失败原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        /// <summary>
        /// 将一个DataTable的内容，写入到Excel文件中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fileName_full"></param>
        /// <param name="sheetName"></param>
        public void WriteExcel(System.Data.DataTable dt, InfoIndex index,string fileName_full, string sheetName = "Sheet1")
        {
            try
            {
                string str_conn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                 "Extended Properties='Excel 12.0;HDR=NO;IMEX=0';" +
                                 "Data Source=" + fileName_full;
                //实例化一个Oledbconnection类(实现了IDisposable,要using)
                using (OleDbConnection ole_conn = new OleDbConnection(str_conn))
                {
                    ole_conn.Open();
                    using (OleDbCommand ole_cmd = ole_conn.CreateCommand())
                    {
                        ole_cmd.CommandText = "INSERT INTO [" + sheetName + "$] VALUES ('KeyID','LocalizationContent','Comment')";
                        ole_cmd.ExecuteNonQuery();

                        //循环遍历插入
                        foreach (DataRow item in dt.Rows)
                        {
                            ole_cmd.CommandText = "INSERT INTO [" + sheetName + @"$](KeyID,LocalizationContent,Comment)VALUES('" + 
                                                  item[index.keyIndex].ToString() + "','" +
                                                  item[index.valueIndex].ToString().Replace("'", "''") + "','" +          //Replace需要解决，内容中有单引号的问题
                                                  item[index.commentIndex].ToString().Replace("'", "''") +
                                                  "')";
                            ole_cmd.ExecuteNonQuery();
                        }                        
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("写入Excel失败! 失败原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //第二种写入Excel文件方法，使用COM组件(解决不能新建文件，以及插入空表的问题)
        public void WriteExcelNew(System.Data.DataTable dt, string fileName_full, string sheetName = "Sheet1")
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("无有效数据，无法导出为Excel");
                return;
            }

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Microsoft.Office.Interop.Excel.Workbooks workbooks = app.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range;   //有效数据范围
            long totalCount = dt.Rows.Count;
            long rowRead = 0;      //已填充行数
            float percent = 0;     //完成百分比

            //表头
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];

                range.Interior.ColorIndex = 15;
                range.Font.Bold = true;
            }

            //数据
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
            }
            app.Visible = true;
            workbook.SaveAs(fileName_full);           

        }



    }
}
