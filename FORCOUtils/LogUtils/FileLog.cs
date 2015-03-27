using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FORCOUtils.ExceptionUtils;

namespace FORCOUtils.LogUtils
{
    public class FileLog:IGenericLog
    {
        private string fLogPath;
       

        private FileLog()
        {
        }

        public FileLog(string aPath)
        {
            fLogPath = aPath;
        }

        public void AddLogEntry(Exception aException, ELogType aELogType, string aSystemName)
        {
            var _SErrorTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

            if (!fLogPath.EndsWith("\\"))
            {
                fLogPath = fLogPath + "\\";
            }

            using (var _StreamWriter = new StreamWriter(fLogPath + aSystemName + ".txt", true))
            {
                string _LogFormat = "System Error: " + aException.Message;

                var ToEvalException = aException;
                while (ToEvalException.GetInnerExceptionMessage() != null)
                {
                    if (!ToEvalException.Message.Contains("See the inner exception for details"))
                    {
                        _LogFormat += "\n" + ToEvalException.GetInnerExceptionMessage();
                        ToEvalException = ToEvalException.InnerException;
                    }

                }
                _LogFormat += "\nDate: " + _SErrorTime;

                _StreamWriter.WriteLine(
                    "--------------------------------------------------------------------------------");
                _StreamWriter.WriteLine(_LogFormat);
                _StreamWriter.WriteLine(
                    "--------------------------------------------------------------------------------");
            }
        }

       
    }
}
