using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;


namespace TransformResCheck.Model
{
    public class IOresx
    {

        /// <summary>
        /// 用于操作顺序读取文件
        /// </summary>
        private ResXResourceWriter writer;
        /// <summary>
        /// 用于向resx文件中写入和修改
        /// </summary>
        private ResXResourceReader reader;

        /// <summary>
        /// 用于定位相关内容的位置（列、从0开始）
        /// </summary>
        private int keIndex;
        private int valueIndex;
        private int commentIndex;


        //读取哪些列作为相应的数据
        public IOresx(int key=0, int value=1, int comment=2)
        {
            keIndex = key;
            valueIndex = value;
            commentIndex = comment;
        }

        public void WritePairToResx(string fileName, DataTable dt)
        {
            writer = new System.Resources.ResXResourceWriter(fileName);

            ResXDataNode rdn;  //用于写入文件的节点

            foreach (DataRow item in dt.Rows)
            {
                rdn = new ResXDataNode(Convert.ToString(item[keIndex]), Convert.ToString(item[valueIndex]));
                rdn.Comment = Convert.ToString(item[commentIndex]);                
                writer.AddResource(rdn);
            }

            rdn = null;
            writer.Close();
            MessageBox.Show("转换成功");
        }




    }
}
