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

        /// <summary>
        /// 用以记录发生的错误
        /// </summary>
        private static ErrorInfo ErrorContainer = new ErrorInfo();


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
                TextOutput("拷贝并重命名完成...");
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

            //检查。。。


            //显示最后结果
            ShowResult();

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
        private bool UnZip(string configFileName)
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
                        TextOutput("解压缩[ " + configFileName + " ]成功...");
                        return true;
                    }
                }

                MessageBox.Show("未找到文件[ " + configFileName + " ]");
                return false;
            }

        }

        #endregion 解压缩函数

        #region xml文件读取相关函数
        private bool  Read_Check_XML(string fileName)
        {
            XmlHandle xh = new XmlHandle();
            xh.TravesalXML(fileName);   //遍历各项

            
            //各个判断项目（UI结果显示）   均需要执行一遍         
            if (CheckOEM(xh.OEM_State) &   //判断OEM权限

                                            //Capbilities检查
            
                CheckVersionStr(xh.VersionStr) &  //版本号获得
            
                CheckLanguage(xh.Languages) &   //语言检查
            
                CheckStartPage(xh.StatePage) &   //启动入口检查
            
                CheckAppName(xh.AppName) &       //应用名称
            
                CheckProductID(xh.ProductID) &       //检查产品ID号
            
                CheckPublisherID(xh.PublisherID))    //检查发行商ID号
            {
                return true;   //全部通过时，返回true
            }                  //否则，返回false，检查失败

            return false;
        }


        #endregion xml 文件读取相关函数

        #region private小工具函数

        /// <summary>
        /// 像UI显示输出检测过程信息
        /// </summary>
        /// <param name="message"> 消息内容 </param>
        /// <param name="success"> 是否为检测成功的消息</param>
        private void TextOutput(string message, bool success = true)
        {
            if (success)
            {
                this.ResultShowTextBox.AppendText("------- " + message + Environment.NewLine + Environment.NewLine);
            }
            else  //检测失败时
            {
                this.ResultShowTextBox.AppendText("x x x x " + message + Environment.NewLine + Environment.NewLine);
                ErrorContainer.AddErrorInfo(message + Environment.NewLine + Environment.NewLine);
            }
            

            System.Threading.Thread.Sleep(800);
        }

        private bool CheckOEM(bool oem_state)
        {
            if (oem_state)
            {
                TextOutput("OEM开关打开...");
                return true;
            }
            else
            {
                TextOutput("注意，OEM权限未打开",false);
                return false;
            }
        }

        private bool CheckVersionStr(string version_str)
        {
            if (version_str == "1.1.1.0")
            {
                TextOutput("版本号正确，当前版本号为[ " + version_str + " ]");
                return true;
            }
            else
            {
                TextOutput("版本号错误", false);
                return false;
            }            
        }

        private bool CheckLanguage(List<string> langs)
        {
            if (langs.Count == 12)   //包含12种语言(9种实际,繁中多1，英语多1，泰语多1)
            {
                //和标准进行对比，并确认所有语言都已添加上
                foreach (var item in InfoDict.LanguageTemplate)
                {
                    if (langs.Contains(item))
                    {
                        langs.Remove(item);
                    }
                }

                if (langs.Count == 0)
                {
                    TextOutput("语言检查通过...");
                    return true;
                }
                else
                {
                    TextOutput("语言检查失败", false);
                    return false;
                }
            }
            else
            {
                TextOutput("语言门数不对...", false);
                return false;
            }
        }

        private bool CheckStartPage(string start)
        {
            if (start == "/Views/Camera/CameraPage.xaml")
            {
                TextOutput("启动入口到相机页，正确...");
                return true;
            }
            else
            {
                TextOutput("启动入口不是到相机...", false);
                return false;
            }
        }

        private bool CheckAppName(string name)
        {
            if (name == "Camera360 Sight")
            {
                TextOutput("应用名称，正确...");
                return true;
            }
            else
            {
                TextOutput("应用名称错误...", false);
                return false;
            }
        }

        private bool CheckProductID(string id)
        {
            if (id == "{4daadbfb-d834-487f-897a-5e5f249022f8}")
            {
                TextOutput("产品ID正确...");
                return true;
            }
            else
            {
                TextOutput("产品ID错误...", false);
                return false;
            }
        }

        private bool CheckPublisherID(string id)
        {
            if (id == "{c420aca1-c8f6-457b-8014-350ae95e1e98}")
            {
                TextOutput("发行商ID正确...");
                return true;
            }
            else
            {
                TextOutput("发行商ID错误...", false);
                return false;
            }
        }

        private void ShowResult()
        {
            if (ErrorContainer.ErrorCounter == 0)
            {
                MessageBox.Show("检测完成，全部成功！");
            }
            else
            {
                MessageBox.Show("检查完成，共发生[ " + ErrorContainer.ErrorCounter + " ]个错误: \r\n\r\n" + ErrorContainer.ErrorMessage);
                ErrorContainer.Reset();
            }
        }



        #endregion


    }
}
