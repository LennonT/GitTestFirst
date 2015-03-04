using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel.Design;


namespace TransformResCheck.Model
{
    /// <summary>
    /// 用以记录一次取值的各个数据定位位置（列、从0开始）
    /// </summary>
    public struct InfoIndex
    {
        internal int keyIndex;
        internal int valueIndex;
        internal int commentIndex;

        public InfoIndex(int key=0, int value=1, int comment=2)
        {
            keyIndex = key;
            valueIndex = value;
            commentIndex = comment;
        }
    }


    public class ResxIO
    {

        /// <summary>
        /// 用于操作顺序读取文件
        /// </summary>
        private ResXResourceWriter writer;
        /// <summary>
        /// 用于向resx文件中写入和修改
        /// </summary>
        private ResXResourceReader reader;

        public ResxIO()
        {
        }

        /// <summary>
        /// 将数据写入并生成resx文件
        /// </summary>
        /// <param name="fileName"> 将要生成的文件名 </param>
        /// <param name="dt"> 数据来源的表格 </param>
        /// /// <param name="index"> 有效数据的位置 </param>
        public void WriteDataToResx(string fileName, DataTable dt, InfoIndex index)
        {
            writer = new System.Resources.ResXResourceWriter(fileName);

            ResXDataNode rdn;  //用于写入文件的节点

            foreach (DataRow item in dt.Rows)
            {
                rdn = new ResXDataNode(item[index.keyIndex].ToString(), item[index.valueIndex].ToString());
                rdn.Comment = item[index.commentIndex].ToString();
                writer.AddResource(rdn);
            }

            rdn = null;
            writer.Close();
            MessageBox.Show("转换成功");
        }

        /// <summary>
        /// 读取Resx文件，得到DataTable
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public DataTable ReadDataFromResx(string fileName)
        {
            DataTable dt = new DataTable();  //用以装载数据

            //构造DataTable的格式
            DataColumn dc = new DataColumn();
            dc = dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = false;
            dc = dt.Columns.Add("Key", Type.GetType("System.String"));
            dc = dt.Columns.Add("Value", Type.GetType("System.String"));
            dc = dt.Columns.Add("Comment", Type.GetType("System.String"));       

            reader = new ResXResourceReader(fileName);
            reader.UseResXDataNodes = true;         

            var iter = reader.GetEnumerator();
            while (iter.MoveNext())
            {
                ResXDataNode node = (ResXDataNode)iter.Value;

                DataRow newRow = dt.NewRow();
                newRow["Key"] = node.Name;
                newRow["Value"] = node.GetValue((ITypeResolutionService) null);
                newRow["Comment"] = node.Comment;
                dt.Rows.Add(newRow);
                dt.AcceptChanges();
            }   

            return dt;
        }

//         public void SetIndexs(int key, int value, int comment)
//         {
//             keIndex = key;
//             valueIndex = value;
//             commentIndex = comment;
//         }



    }
}
