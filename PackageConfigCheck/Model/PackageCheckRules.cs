using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackageConfigCheck.Model
{
    public class PackageCheckRules
    {
        /// <summary>
        /// 主UI所在的form
        /// </summary>
        private PackageCheck _MainForm;

        public PackageCheckRules(PackageCheck pc)
        {
            _MainForm = pc;
        }
        
        internal bool CheckOEM(bool oem_state)
        {
            if (oem_state)
            {
                _MainForm.TextOutput("OEM开关打开...");
                return true;
            }
            else
            {
                _MainForm.TextOutput("注意，OEM权限未打开", false);
                return false;
            }
        }

        internal bool CheckVersionStr(string version_str)
        {
            if (version_str == "1.1.1.0")
            {
                _MainForm.TextOutput("版本号正确，当前版本号为[ " + version_str + " ]");
                return true;
            }
            else
            {
                _MainForm.TextOutput("版本号错误", false);
                return false;
            }
        }

        internal bool CheckLanguage(List<string> langs)
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
                    _MainForm.TextOutput("语言检查通过...");
                    return true;
                }
                else
                {
                    _MainForm.TextOutput("语言检查失败", false);
                    return false;
                }
            }
            else
            {
                _MainForm.TextOutput("语言门数不对...", false);
                return false;
            }
        }

        internal bool CheckCapabilities(List<string> caps)
        {
            if (caps.Count == 13)   //包含12种语言(9种实际,繁中多1，英语多1，泰语多1)
            {
                //和标准进行对比，并确认所有语言都已添加上
                foreach (var item in InfoDict.CapabilityTemplate)
                {
                    if (caps.Contains(item))
                    {
                        caps.Remove(item);
                    }
                }

                if (caps.Count == 0)
                {
                    _MainForm.TextOutput("授权检查通过...");
                    return true;
                }
                else
                {
                    _MainForm.TextOutput("授权检查失败", false);
                    return false;
                }
            }
            else
            {
                _MainForm.TextOutput("授权数目不对...", false);
                return false;
            }
        }

        internal bool CheckStartPage(string start)
        {
            if (start == "/Views/Camera/CameraPage.xaml")
            {
                _MainForm.TextOutput("启动入口到相机页，正确...");
                return true;
            }
            else
            {
                _MainForm.TextOutput("启动入口不是到相机...", false);
                return false;
            }
        }

        internal bool CheckAppName(string name)
        {
            if (name == "Camera360 Sight")
            {
                _MainForm.TextOutput("应用名称，正确...");
                return true;
            }
            else
            {
                _MainForm.TextOutput("应用名称错误...", false);
                return false;
            }
        }

        internal bool CheckProductID(string id)
        {
            if (id == "{4daadbfb-d834-487f-897a-5e5f249022f8}")
            {
                _MainForm.TextOutput("产品ID正确...");
                return true;
            }
            else
            {
                _MainForm.TextOutput("产品ID错误...", false);
                return false;
            }
        }

        internal bool CheckPublisherID(string id)
        {
            if (id == "{c420aca1-c8f6-457b-8014-350ae95e1e98}")
            {
                _MainForm.TextOutput("发行商ID正确...");
                return true;
            }
            else
            {
                _MainForm.TextOutput("发行商ID错误...", false);
                return false;
            }
        }
    }
}
