using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORCOUtils.ExceptionUtils
{
    public static class ExceptionHelpers
    {
        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// Gets the line number for an exception
        /// </summary>
        /// <param name="aException">The exception to get line number</param>
        /// <returns>The exception line number or null if not found</returns>
        public static int? LineNumber(this Exception aException)
            {
                int _Linenum;
                try
                {
                    _Linenum = Convert.ToInt32(aException.StackTrace.Substring(aException.StackTrace.LastIndexOf(":line", StringComparison.Ordinal) + 5));
                }
                catch
                {
                    return null;
                }
                return _Linenum;
            }

         /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
         /// Used also by: 
         /// Modified by: 
         /// <summary>
         /// Used to get all InnerException in a given Exceptio object
         /// </summary>
         /// <param name="aException">The exception to get inner exception</param>
         /// <returns>The Inner exception message if exists. Null otherwise</returns>
         public static string GetInnerExceptionMessage(this Exception aException)
         {
             try
             {
                 return aException.InnerException != null ? aException.InnerException.Message : null;

             }
             catch
             {
                 return null;
             }
         }
    }
}

