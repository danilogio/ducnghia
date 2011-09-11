﻿using System;
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
            thumbnail = nullToBlank(thumbnail);
            location = nullToBlank(location);

            //DirectoryInfo d = new DirectoryInfo(".");
            string sPath = DBHelper.strCurrentPath;
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
            else if (str.Length > CommonConstants.DEFAULT_NUMBER_OF_CHARACTER_ON_STRING)
            {
                return (str.Substring(0, CommonConstants.DEFAULT_NUMBER_OF_CHARACTER_ON_STRING) + "..." );
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
        public static int random(int min, int max)
        {
            Random rd = new Random();
            int r = 0;
            r = rd.Next(min, max);
            return r;
        }
        public string getDefaultAppropriateThumbnail(string extension)
        {
            string strThumbnail = CommonConstants.BLANK;
            switch (extension)
            {
                case ".doc":
                case ".docx":
                    strThumbnail = "word-icon.png";
                    break;
                case ".ppt":
                case ".pptx":
                case ".pps":
                case ".ppsx":
                    strThumbnail = "powerpoint-icon.png";
                    break;
                case ".rar":
                case ".zip":
                case ".7z":
                    strThumbnail = "archive-icon.png";
                    break;
                case ".pdf":
                    strThumbnail = "pdf-icon.png";
                    break;
                default:
                    strThumbnail = "unknown_icon.png";
                    break; ;
            }

            return strThumbnail;
        }

        /// <summary>
        /// Chuyển từ DateTime sang chuỗi
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string convertDateToString(DateTime date)
        {
            string strDate = CommonConstants.BLANK;
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

        public static int min(int a, int b)
        {
            if (a > b)
            {
                return b;
            }
            return a;
        }
        public static string nullToBlank(string target)
        {
            if (target == null)
            {
                return CommonConstants.BLANK;
            }
            return target.Trim();
        }
        public static string nullToSharp(string target)
        {
            if (target == null || target == CommonConstants.BLANK)
            {
                return CommonConstants.SHARP;
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
        public static int getValueClassByCode(string code)
        {
            switch (code)
            {
                case CommonConstants.AT_EL_CLASS_10_CODE:
                    {
                        return CommonConstants.AT_EL_CLASS_10;
                    }
                case CommonConstants.AT_EL_CLASS_11_CODE:
                    {
                        return CommonConstants.AT_EL_CLASS_11;
                    }
                case CommonConstants.AT_EL_CLASS_12_CODE:
                    {
                        return CommonConstants.AT_EL_CLASS_12;
                    }
            }
            return -1;
        }
        public static string getNameSubjectByCode(string code)
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
                case CommonConstants.ALL:
                    {
                        return CommonConstants.ALL;
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
        public string createRatingBar(int score, int maxScore)
        {
            string data = CommonConstants.BLANK;
            
            if (score >= 0 && maxScore >= 0 && maxScore >= score)
            {
                maxScore = maxScore / 2;
                score = score / 2;
                int lackScore = maxScore - score;
                string item = CommonConstants.BLANK;

                //build score
                for (int i = 0; i < score; i++)
                {
                    item = createMsgByTemplate(CommonConstants.TEMP_IMG_RATING, CommonConstants.PATH_ACTIVE_RATING_ICON);
                    data += item;
                }

                //build lake score
                for (int i = 0; i < lackScore; i++)
                {
                    item = createMsgByTemplate(CommonConstants.TEMP_IMG_RATING, CommonConstants.PATH_INACTIVE_RATING_ICON);
                    data += item;
                }
            }
            return data;
        }
        
    }
}
