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

        /// <summary>
        /// Chuyển từ DateTime sang chuỗi
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string convertDateToString(DateTime date)
        {
            string strDate = "";
            if (date != null)
            {
                strDate += date.ToShortTimeString();
                strDate += " ngày ";
                strDate += Convert.ToString(date.Day);
                strDate += "/";
                strDate += Convert.ToString(date.Month);
                strDate += "/";
                strDate += Convert.ToString(date.Year);
            }
            return strDate;
        }

        public static string nullToBlank(string target)
        {
            if (target == null)
            {
                return CommonConstants.BLANK;
            }
            return target.Trim();
        }

        public static bool isNullOrBlank(string target)
        {
            if (target != null && target != CommonConstants.BLANK)
            {
                return false;
            }
            return true;
        }

        public static int getYearFromString(string target)
        {
            if (isNullOrBlank(target) || target == CommonConstants.NOW)
            {
                return DateTime.Now.Year;
            }
            return Int32.Parse(target);
        }
        
        public static string createMsgByTemplate(string template, string arg1)
        {
            string msg = CommonConstants.BLANK;
            if (!isNullOrBlank(template))
            {
                msg = String.Format(template, arg1.Trim());
            }
            return msg;
        }
        
        public static string createMsgByTemplate(string template, string arg1, string arg2)
        {
            string msg = CommonConstants.BLANK;
            if (!isNullOrBlank(template))
            {
                msg = String.Format(template, arg1.Trim(), arg2.Trim());
            }
            return msg;
        }
        
        public static string createMsgByTemplate(string template, string arg1, string arg2, string arg3)
        {
            string msg = CommonConstants.BLANK;
            if (!isNullOrBlank(template))
            {
                msg = String.Format(template, arg1.Trim(), arg2.Trim(), arg3.Trim());
            }
            return msg;
        }

        public static string createMsgByTemplate(string template, string arg1, string arg2, string arg3, string arg4)
        {
            string msg = CommonConstants.BLANK;
            if (!isNullOrBlank(template))
            {
                msg = String.Format(template, arg1.Trim(), arg2.Trim(), arg3.Trim(), arg4.Trim());
            }
            return msg;
        }
        
        public static string getNameByCode(string code)
        {
            if(isNullOrBlank(code))
            {
                return CommonConstants.BLANK;
            }
            switch (code)
            {
                case CommonConstants.SUB_MATHEMATICS_CODE:
                    {
                        return CommonConstants.SUB_MATHEMATICS;
                    }
                case CommonConstants.SUB_PHYSICAL_CODE:
                    {
                        return CommonConstants.SUB_PHYSICAL;
                    }
                case CommonConstants.SUB_CHEMICAL_CODE:
                    {
                        return CommonConstants.SUB_CHEMICAL;
                    }
                case CommonConstants.SUB_BIOGRAPHY_CODE:
                    {
                        return CommonConstants.SUB_BIOGRAPHY;
                    }
                case CommonConstants.SUB_GEOGRAPHY_CODE:
                    {
                        return CommonConstants.SUB_GEOGRAPHY;
                    }
                case CommonConstants.SUB_LITERATURE_CODE:
                    {
                        return CommonConstants.SUB_LITERATURE;
                    }
                case CommonConstants.SUB_HISTORY_CODE:
                    {
                        return CommonConstants.SUB_HISTORY;
                    }
                case CommonConstants.SUB_ENGLISH_CODE:
                    {
                        return CommonConstants.SUB_ENGLISH;
                    }
                default:
                    {
                        return CommonConstants.BLANK;
                    }

            }
        }

        public string createOlderLink(string linkTemplate, ArticleSCO articleSCO, int numberOlder)
        {
            string links = CommonConstants.BLANK;
            int startYear = getYearFromString(CommonConstants.NOW);
            int selectedYear = getYearFromString(articleSCO.Time);

            if (articleSCO.Section == CommonConstants.SEC_UNIVERSITY_CODE)
            {
                for (int i = startYear; i >= 2000; i--)
                {
                    if (i == selectedYear)
                    {
                        links += String.Format(CommonConstants.TEMP_LABEL_TAG, i.ToString());
                    }
                    else
                    {
                        links += String.Format(linkTemplate, articleSCO.Subject, i.ToString(), i.ToString());
                    }
                    links += CommonConstants.SPACE;
                }
            }
            return links;
        }
    
        
    }
}
