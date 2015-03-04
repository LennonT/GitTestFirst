using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformResCheck.Model
{
    /// <summary>
    /// 用于一些数据库操作
    /// </summary>
    public class CheckRules
    {
        private DataTable keyTable;

        private DataTable userTable;

        internal TanslateTool _MainForm;
        private Object join;
        public CheckRules(TanslateTool tt)
        {
            _MainForm = tt;
        }

        public void InitData(DataTable kt, DataTable ut)
        {
            keyTable = kt;
            userTable = ut;
        }

        /// <summary>
        /// 检查读入的数据是否足够
        /// </summary>
        /// <param name="keyTable"></param>
        /// <param name="userTable"></param>
        /// <returns></returns>
        //         public bool rule_CheckSum()
        //         {
        //             //用户表数据不足
        //             if (userTable.Rows.Count < keyTable.Rows.Count)
        //             {
        //                 _MainForm.ShowResult("用户表，数目不足，请检查……");
        //                 return false;
        //             }
        // 
        //             return true;     
        //         }

        public void rule_CheckDuplication()
        {
            for (int i = 0; i < userTable.Rows.Count; ++i)
            {
                int counter = 0;
                for (int j = i + 1; j < userTable.Rows.Count; ++j)
                {
                    if (userTable.Rows[i][0] == userTable.Rows[j][0])
                    {
                        ++counter;
                    }
                }

                if (counter != 0)
                {
                    MessageBox.Show(userTable.Rows[i][0].ToString() + "重复了： [" + counter + "] 次");
                    return;
                }
            }

            _MainForm.ShowProcessInfo("------重复性检查完毕，没有重复项");
        }

        public bool rule_CheckPrimaryKey()
        {
            //获取主键字符串，并填充到List中，便于后面操作
            List<string> standardPrimaryKeys = new List<string>();
            List<string> userPrimaryKeys = new List<string>();

            for (int i = 0; i < keyTable.Rows.Count; ++i)
            {
                standardPrimaryKeys.Add(keyTable.Rows[i][0].ToString());
            }

            for (int i = 0; i < userTable.Rows.Count; ++i)
            {
                userPrimaryKeys.Add(userTable.Rows[i][0].ToString());
            }

            //得到相同部分
            List<string> SamePartList = new List<string>();
            foreach (var item in userPrimaryKeys)
            {
                //相同项，加入临时表
                if (standardPrimaryKeys.Contains(item))
                {
                    SamePartList.Add(item);
                }
            }

            //各自删除共有元素
            foreach (var item in SamePartList)
            {
                standardPrimaryKeys.Remove(item);
                userPrimaryKeys.Remove(item);
            }

            //判断
            if ((standardPrimaryKeys.Count == 0) && (userPrimaryKeys.Count == 0))
            {
                _MainForm.ShowProcessInfo("两表主键完全一致……");
                return true;
            }

            _MainForm.ShowProcessInfo("以下主键遗漏，未给出： ");
            PrintList(standardPrimaryKeys);

            if (userPrimaryKeys.Count != 0)
            {
                _MainForm.ShowProcessInfo("以下主键多余： ");
                PrintList(userPrimaryKeys);
            }

            return false;
        }


        private void PrintList(List<string> list)
        {
            foreach (var item in list)
            {
                _MainForm.ShowProcessInfo("       " + item + " ");
            }
        }

    }
}
