using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORCOUtils.EnumUtils
{
    public class EnumParser
    {
        public static T ParseEnum<T>(string aValue)
        {
            return (T)Enum.Parse(typeof(T), aValue, true);
        }
        public static T ParseEnum<T>(int aValue) 
        {
            return (T)Enum.ToObject(typeof(T), aValue);
        }
    }
}
