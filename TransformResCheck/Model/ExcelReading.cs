using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;  //使用数据库

namespace TransformResCheck.Model
{
    public class ExcelReading
    {
        /// <summary>
        /// 用来保存从Excel表中读取到的全部数据
        /// </summary>
        public System.Data.DataTable dataTable;


        public ExcelReading(string pathName, string sheetName, string HDR = "NO")
        {
            dataTable = ReadExcel(pathName, sheetName, HDR);
        }

        /// <summary>
        /// 执行从Excel读取数据到DB的函数
        /// </summary>
        /// <param name="filePath">Excel文件路径和名字</param>
        /// <param name="sheetName">需要读取的Sheet名</param>
        /// <param name="HDR"> 前几行是否有无效数据，NO:无，YES：有(;IMEX=1)</param>
        /// <returns></returns>
        public System.Data.DataTable ReadExcel(string pathName, string sheetName, string HDR="NO")
        {
            try
            {
                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=" + HDR + "';data source=" + pathName;
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();

                String sql = "SELECT * FROM  ["+ sheetName + "$]"; 

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, sheetName);

                OleConn.Close();

                return OleDsExcle.Tables[sheetName];
            }
            catch (Exception err)
            {
                MessageBox.Show("数据绑定Excel失败! 失败原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }
    }
}
