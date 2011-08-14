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
            if (thumbnail != null)
            {
                thumbnail = thumbnail.Trim();
            }
            else
            {
                thumbnail = "";
            }
            if (location != null)
            {
                location = location.Trim();
            }
            DirectoryInfo d = new DirectoryInfo(".");
            string sPath = d.FullName + "\\ltkt\\";
            FileInfo f = new FileInfo(sPath + thumbnail);
            
            if (thumbnail == "" || thumbnail == null || f.Exists == false)
            {
                thumbnail = "Data/DefaultImages/" + getDefaultAppropriateThumbnail(getExtension(sPath + location));
            }
            return thumbnail;
        }

        public string subString(string str)
        {
            if (str == null) return null;
            else if (str.Length > CommonConstants.NUMBER_OF_CHARACTER_ON_STRING)
            {
                return (str.Substring(0, CommonConstants.NUMBER_OF_CHARACTER_ON_STRING) + "..." );
            }
            return str.Trim();
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
