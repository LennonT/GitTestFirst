using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackageConfigCheck
{
    public partial class PackageCheck : Form
    {
        /// <summary>
        /// 当前使用的工作目录
        /// </summary>
        private static string path = @"C:\Users\Lennon\Desktop";

        /// <summary>
        /// 用来进行检测的zip包名字
        /// </summary>
        private static string zipFileName = path + @"\" + "test.zip";

        /// <summary>
        /// 清单文件名
        /// </summary>
        private static string manifestFileName = "WMAppManifest.xml";


        public PackageCheck()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择待检测的包，重命名为zip格式，拷贝到工作目录中
        /// </summary>
        private void ChooseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = @"E:\Documents\Package\WP8\Sight";
            fileDialog.RestoreDirectory = true;


            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //若已存在，首先删除
                if (System.IO.File.Exists(zipFileName))
                {
                    System.IO.File.Delete(zipFileName);
                }

                System.IO.File.Copy(fileDialog.FileName, zipFileName);
                MessageBox.Show("拷贝并重命名成功...");
            }         
        }

        /// <summary>
        /// 解压缩指定文件，并进行检测，输出测试结果
        /// </summary>
        private void PackageCheckBtn_Click(object sender, EventArgs e)
        {
            //解压缩文件
            UnZip(manifestFileName);


        }


        #region 解压缩函数
        /// <summary>
        /// 压缩zip
        /// </summary>
        /// <param name="fileToZips">文件路径集合</param>
        /// <param name="zipedFile">想要压成zip的文件名</param>
        private void Zip(string[] fileToZips, string zipedFile)
        {
            using (ZipFile zip = new ZipFile(zipedFile, Encoding.Default))
            {
                foreach (string fileToZip in fileToZips)
                {
                    using (FileStream fs = new FileStream(fileToZip, FileMode.Open, FileAccess.ReadWrite))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        string fileName = fileToZip.Substring(fileToZip.LastIndexOf("\\") + 1);
                        zip.AddEntry(fileName,buffer);
                    }
                }
                zip.Save();
            }
        }

        /// <summary>
        /// 将指定文件解压出来
        /// </summary>
        /// <param name="configFileName"> 想要解压缩得到的文件名 </param>
        private void UnZip(string configFileName)
        {
            using (ZipFile zip = ZipFile.Read(zipFileName))
            {
                foreach (ZipEntry z in zip)
                {
                    if (z.FileName == configFileName)
                        z.Extract(path);
                }
            }

        }

        #endregion 解压缩函数

        #region xml文件读取相关函数
        XMLReader
        #endregion xml 文件读取相关函数


    }
}
