using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformResCheck.Model
{
    public class PathAndName
    {
        private static PathAndName _instance;

        public Dictionary<string, string> resxFileNames;    //生成的各个资源文件名字

        public readonly string Path = "C:\\Users\\Lennon\\Desktop\\";
        public readonly string KeyExcelName = "标准翻译.xlsx";
        public readonly string DataExcelName = "test.xlsx";
        public readonly string sheetName = "Sheet1";        

        private PathAndName ()
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

        public static PathAndName getInstance() {
            if (_instance == null)
            {
                _instance = new PathAndName();
            }

            return _instance;
        }


    }
}
