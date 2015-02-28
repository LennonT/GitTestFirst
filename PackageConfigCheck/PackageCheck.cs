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
        #region 各变量
        /// <summary>
        /// 用以作为检查的各项规则
        /// </summary>
        private static PackageCheckRules _rules;
        /// <summary>
        /// 用以操作zip文件
        /// </summary>
        private static ZipHandle _zip;

        /// <summary>
        /// 当前使用的工作目录
        /// </summary>
        private static string path = @"C:\Users\Lennon\Desktop\Workspace";

        /// <summary>
        /// 用来进行检测的zip包名字
        /// </summary>
        private static string zipFileName = "check.zip";
        private static string zipFileName_full = path + @"\" + zipFileName;

        /// <summary>
        /// 清单文件名
        /// </summary>
        private static string manifestFileName = "WMAppManifest.xml";
        private static string manifestFileName_full = path + @"\" + manifestFileName;

        /// <summary>
        /// 用以记录发生的错误
        /// </summary>
        internal static ErrorInfo ErrorContainer = new ErrorInfo();

#if DEBUG
        internal static int instanceCounter = 0;
#endif

        #endregion 各变量

        public PackageCheck()
        {
            InitializeComponent();

            //初始化规则实例
            _rules = new PackageCheckRules(this);

            //初始化Zip处理实例
            _zip = new ZipHandle(this);
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
                
                TextOutput("拷贝并重命名完成...");
            }
        }

        /// <summary>
        /// 解压缩指定文件，并进行检测，输出测试结果
        /// </summary>
        private void PackageCheckBtn_Click(object sender, EventArgs e)
        {
            //解压缩文件
            _zip.UnZip(manifestFileName, zipFileName, path);

            //检查manifest文件
            Read_Check_XML(manifestFileName_full);

            //检查。。。


            //显示最后结果
            ShowResult();

        }

        /// <summary>
        /// 读取xml文件，并应用检查规则
        /// </summary>
        /// <param name="fileName"> xml完整文件名 </param>
        private void Read_Check_XML(string fileName_full)
        {
            XmlHandle xh = new XmlHandle();
            xh.TravesalXML(fileName_full);   //遍历各项


            //各个判断项目（UI结果显示）

            _rules.CheckOEM(xh.OEM_State);   //判断OEM权限
            _rules.CheckCapabilities(xh.Capabilities);  //判断各个权限,Capbilities检查

            _rules.CheckVersionStr(xh.VersionStr);  //版本号获得

            _rules.CheckLanguage(xh.Languages);   //语言检查

            _rules.CheckStartPage(xh.StatePage);   //启动入口检查

            _rules.CheckAppName(xh.AppName);      //应用名称

            _rules.CheckProductID(xh.ProductID);       //检查产品ID号

            _rules.CheckPublisherID(xh.PublisherID);    //检查发行商ID号

        }

        #region private小工具函数
        /// <summary>
        /// 向UI显示输出检测过程信息
        /// </summary>
        /// <param name="message"> 消息内容 </param>
        /// <param name="success"> 是否为检测成功的消息</param>
        internal void TextOutput(string message, bool success = true)
        {
            if (success)
            {
                ResultShowTextBox.AppendText("------- " + message + Environment.NewLine + Environment.NewLine);
            }
            else  //检测失败时
            {
                ResultShowTextBox.AppendText("x x x x " + message + Environment.NewLine + Environment.NewLine);
                ErrorContainer.AddErrorInfo(message + Environment.NewLine + Environment.NewLine);
            }


            System.Threading.Thread.Sleep(500);
        }

        /// <summary>
        /// 显示最终结果
        /// </summary>
        internal void ShowResult()
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
