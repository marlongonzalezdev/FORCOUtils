using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FORCOUtils.LogUtils
{
    
    public interface IGenericLog
    {
        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Creates alog entry for an Exception class and for all its inner exceptions if any
        /// </summary>
        /// <param name="aException"></param>
        void AddLogEntry(Exception aException, ELogType aLogType, string aSystemName);
    }
}
