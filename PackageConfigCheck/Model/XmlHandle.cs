using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PackageConfigCheck.Model
{
    public class XmlHandle
    {
        /// <summary>
        /// OEM权限打开标志
        /// </summary>
        public bool OEM_State;

        /// <summary>
        /// Manifest中版本号字符串
        /// </summary>
        public string VersionStr;

        /// <summary>
        /// 保存权限列表
        /// </summary>
        public List<string> Capabilities;

        /// <summary>
        /// 保存语言列表
        /// </summary>
        public List<string> Languages;

        /// <summary>
        /// 启动入口页面地址字符串
        /// </summary>
        public string StatePage;

        /// <summary>
        /// 应用显示名称
        /// </summary>
        public string AppName;

        public string ProductID;

        public string PublisherID;


        public XmlHandle()
        {
            OEM_State = false;
            VersionStr = "";
            Capabilities = new List<string>();
            Languages = new List<string>();
            StatePage = "";
            AppName = "";
            ProductID = "";
            PublisherID = "";
        }

        /// <summary>
        /// 遍历整个xml文件,并应用部分规则
        /// </summary>
        /// <param name="xmlfileName">文件名</param>
        public void TravesalXML(string xmlfileName)
        {
            using (XmlReader xr = XmlReader.Create(xmlfileName))
            {
                while (xr.Read()) //
                {
                    if (xr.NodeType == XmlNodeType.Element)   //有效节点
                    {
                        switch (xr.Name)
                        {
                            case "Capability":
                                Capabilities.Add(xr["Name"]); //将读到的cap名称字符串加入list中
                                if (xr["Name"] == "ID_CAP_MEDIALIB_PHOTO_FULL")  //OEM权限打开
                                {
                                    OEM_State = true;
                                }
                                break;

                            case "App":
                                VersionStr = xr["Version"];  //获得manifest中版本号字段
                                AppName = xr["Title"];       //获得应用名称
                                ProductID = xr["ProductID"];   //获得产品ID号
                                PublisherID = xr["PublisherID"]; //获得发行商ID号

                                break;

                            case "Language":                 //各语言项
                                Languages.Add(xr["code"]);
                                break;

                            case "DefaultTask":             //启动入口
                                StatePage = xr["NavigationPage"];
                                break;

                            default :
                                break;

                        }
                    }
                }
            }
        }

        #region 一些私有的小功能函数

//         private bool JudgeCapability(string capName)
//         {
//             if (capName == "ID_CAP_MEDIALIB_PHOTO_FULL")  //OEM权限打开
//             {
//                 return true;
//             }
// 
//             return false;
//         }



        #endregion


    }
}
