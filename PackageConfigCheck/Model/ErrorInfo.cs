using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageConfigCheck.Model
{
    //用以记录错误信息的小类
    public class ErrorInfo
    {
        public int ErrorCounter;
        public string ErrorMessage;

        public ErrorInfo()
        {
            ErrorCounter = 0;
            ErrorMessage = "";
        }

        internal void AddErrorInfo(string error_info)
        {
            ++ErrorCounter;
            ErrorMessage += "[" + ErrorCounter.ToString() + "]" + error_info;
        }

        internal void Reset()
        {
            ErrorCounter = 0;
            ErrorMessage = "";
        }
    }
}
