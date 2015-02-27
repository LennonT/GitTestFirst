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
using System.Xml;
using PackageConfigCheck.Model;


namespace PackageConfigCheck
{
    public partial class PackageCheck : Form
    {
        /// <summary>
        /// 当前使用的工作目录
        /// </summary>
        private static string path = @"C:\Users\Lennon\Desktop\Workspace";

        /// <summary>
        /// 用来进行检测的zip包名字
        /// </summary>
        private static string zipFileName_full = path + @"\" + "test.zip";

        /// <summary>
        /// 清单文件名
        /// </summary>
        private static string manifestFileName = "WMAppManifest.xml";
        private static string manifestFileName_full = path + @"\" + manifestFileName;


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
                if (System.IO.File.Exists(zipFileName_full))
                {
                    System.IO.File.Delete(zipFileName_full);
                }

                System.IO.File.Copy(fileDialog.FileName, zipFileName_full);
                //MessageBox.Show("拷贝并重命名成功...");
                ShowResult("拷贝并重命名成功...");
            }         
        }

        /// <summary>
        /// 解压缩指定文件，并进行检测，输出测试结果
        /// </summary>
        private void PackageCheckBtn_Click(object sender, EventArgs e)
        {
            //解压缩文件
            UnZip(manifestFileName);

            //检查manifest文件
            Read_Check_XML(manifestFileName_full);


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
            using (ZipFile zip = ZipFile.Read(zipFileName_full))
            {
                foreach (ZipEntry z in zip)
                {
                    if (z.FileName == configFileName)
                    {
                        //若存在，首先删除
                        if (System.IO.File.Exists(path + @"\" + configFileName))
                        {
                            System.IO.File.Delete(path + @"\" + configFileName);
                        }

                        z.Extract(path);
                        ShowResult("解压缩[ " + configFileName + " ]成功...");
                        return;
                    }
                }

                MessageBox.Show("未找到文件[ " + configFileName + " ]");
            }

        }

        #endregion 解压缩函数

        #region xml文件读取相关函数
        private void Read_Check_XML(string fileName)
        {
            XmlHandle xh = new XmlHandle();
            xh.TravesalXML(fileName);   //遍历各项

            #region 各个判断项目（UI结果显示）


            //判断OEM权限
            if (xh.OEM_State)
            {
                ShowResult("OEM开关打开...");
            }
            else
            {
                MessageBox.Show("注意，OEM权限未打开");
            }

            //Capbilities检查



            //版本号获得
            ShowResult("当前版本号为[ " + xh.VersionStr + " ]");


            //语言检查
            if(xh.Languages.Count == 12)   //包含12种语言(9种实际,繁中多1，英语多1，泰语多1)
            {
                //和标准进行对比，并确认所有语言都已添加上
                foreach(var item in InfoDict.LanguageTemplate)
                {
                    if(xh.Languages.Contains(item))
                    {
                        xh.Languages.Remove(item);
                    }
                }

                if (xh.Languages.Count == 0)
                {
                    ShowResult("语言检查通过...");
                }
                else
                {
                    MessageBox.Show("语言检查失败");
                }
            }
            else
            {
                MessageBox.Show("语言门数不对...");
            }

            //启动入口检查
            if (xh.StatePage == "/Views/Camera/CameraPage.xaml")
            {
                ShowResult("启动入口到相机页，正确...");
            }
            else
            {
                MessageBox.Show("启动入口不是到相机...");
            }

            //应用名称
            if (xh.AppName == "Camera360 Sight")
            {
                ShowResult("应用名称，正确...");
            }
            else
            {
                MessageBox.Show("应用名称错误...");
            }




            #endregion

        }


        #endregion xml 文件读取相关函数


        private void ShowResult(string message)
        {
            this.ResultShowTextBox.AppendText(message + Environment.NewLine + Environment.NewLine);

            System.Threading.Thread.Sleep(800);
        }


    }
}
