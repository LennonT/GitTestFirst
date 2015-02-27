using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageConfigCheck.Model
{
    public class InfoDict
    {
        public static readonly List<string> LanguageTemplate;
        public static readonly List<string> CapabilityTemplate;

        static InfoDict()
        {
            LanguageTemplate = new List<string>();
            LanguageTemplate.Add("zh-CN");
            LanguageTemplate.Add("zh-TW");
            LanguageTemplate.Add("zh-HK");
            LanguageTemplate.Add("en");
            LanguageTemplate.Add("en-Us");
            LanguageTemplate.Add("th");
            LanguageTemplate.Add("vi-VN");
            LanguageTemplate.Add("ru");
            LanguageTemplate.Add("it");
            LanguageTemplate.Add("pt-BR");
            LanguageTemplate.Add("es");

            LanguageTemplate.Add("th-TH");

            CapabilityTemplate = new List<string>();
            CapabilityTemplate.Add("ID_CAP_MEDIALIB_PHOTO_FULL");
            CapabilityTemplate.Add("ID_CAP_NETWORKING");
            CapabilityTemplate.Add("ID_CAP_MEDIALIB_AUDIO");
            CapabilityTemplate.Add("ID_CAP_MEDIALIB_PLAYBACK");
            CapabilityTemplate.Add("ID_CAP_IDENTITY_DEVICE");
            CapabilityTemplate.Add("ID_CAP_ISV_CAMERA");
            CapabilityTemplate.Add("ID_CAP_WEBBROWSERCOMPONENT");
            CapabilityTemplate.Add("ID_CAP_LOCATION");
            CapabilityTemplate.Add("ID_CAP_MEDIALIB_PHOTO");
            CapabilityTemplate.Add("ID_CAP_SENSORS");
            CapabilityTemplate.Add("ID_CAP_SPEECH_RECOGNITION");
            CapabilityTemplate.Add("ID_CAP_MAP");
            CapabilityTemplate.Add("ID_CAP_MICROPHONE");

        }


    }
}
