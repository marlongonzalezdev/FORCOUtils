using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORCOUtils.ImageUtils
{
    public class ImageConverter
    {
        public static string ConvertToWebBase64(string aImageExtension, byte[] aImgeData)
        {
            var _ImageBase64 = Convert.ToBase64String(aImgeData);
            return string.Format("data:image/{0};base64,{1}",aImageExtension, _ImageBase64);
        }
    }
}
