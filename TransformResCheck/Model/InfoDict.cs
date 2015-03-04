using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformResCheck.Model
{
    internal static class InfoDict
    {
        internal static readonly Dictionary<string, string> resxFileNames;    //生成的各语言版本，资源文件名字

        internal static readonly string Path = @"C:\Users\Lennon\Desktop\Workspace";   //工作目录
        internal static readonly string StandardExcelName = "标准翻译.xlsx";  //用于做为参考的Excel文件名字
        internal static readonly string ForReadExcelName = "test.xlsx";        //目标Excel文件，用于读取
        internal static readonly string ForWriteExcelName = "result.xlsx";     //写入到的Excel文件名字

        internal static readonly string[] sheetName = {"Sheet1", "Sheet2"} ;  //各页面名字

        static InfoDict()
        {
            resxFileNames = new Dictionary<string, string>();
            resxFileNames.Add("en", "CommonRes.resx");          //英语
            resxFileNames.Add("cn", "CommonRes.zh-CN.resx");    //中文简体
            resxFileNames.Add("tw", "CommonRes.zh-TW.resx");    //中文繁体
            resxFileNames.Add("th", "CommonRes.th.resx");       //泰语
            resxFileNames.Add("ru", "CommonRes.ru.resx");       //俄语
            resxFileNames.Add("it", "CommonRes.it.resx");       //意大利语
            resxFileNames.Add("es", "CommonRes.es.resx");       //西班牙语
            resxFileNames.Add("vi", "CommonRes.vi-VN.resx");    //越南语
            resxFileNames.Add("pt", "CommonRes.pt.resx");       //巴西葡语
            resxFileNames.Add("hk", "CommonRes.zh-HK.resx");    //香港繁体
        }
    }
}
