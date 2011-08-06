using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ltktDAO
{
    public class BaseServices
    {
        public string getThumbnail(string thumbnail, string location)
        {
            if (thumbnail == "" || thumbnail == null)
            {
                thumbnail = "Data/DefaultImages/" + getDefaultAppropriateThumbnail(getExtension(location));
            }
            return thumbnail;
        }

        public string getExtension(string location)
        {
            FileInfo f = new FileInfo(location);
            string res = "";
            if (f.Exists)
            {
                res = f.Extension;
            }
            return res;
        }

        public string getDefaultAppropriateThumbnail(string extension)
        {
            if (extension.Contains("docx")
                || extension.Contains("doc"))
            {
                return "word.png";
            }
            else if (extension.Contains("ppt")
                || extension.Contains("ppts")
                || extension.Contains("pptx")
                || extension.Contains("ppsx"))
            {
                return "pp.png";
            }
            else if (extension.Contains("rar")
                || extension.Contains("zip")
                || extension.Contains("7z"))
            {

            }
            return "unknown.png";
        }
    }
}
