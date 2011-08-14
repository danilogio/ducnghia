using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public static class AdminConstants
    {
        //public const string TITLE = "TITLE";
        //public const string UPLOAD = "UPLOAD";
        //public const string REGISTRY = "REGISTRY";
        //public const string LOGIN = "LOGIN";
        //public const string DOWNLOAD = "DOWNLOAD";
        //public const string COMMENT = "COMMENT";
        //public const string ADS = "ADS";
        //public const string UPLOAD_UNIVERSITY = "UPLOAD_UNI";
        //public const string DOWNLOAD_UNIVERSITY = "DOWNLOAD_UNI";
        //public const string UPLOAD_EL = "UPLOAD_EL";
        //public const string DOWNLOAD_EL = "DOWNLOAD_EL";
        //public const string UPLOAD_IT = "UPLOAD_IT";
        //public const string DOWNLOAD_IT = "DOWNLOAD_IT";
        //public const string NEWS_VIEWS = "NEWS_VIEWS";
        //public const string NEWS_POST = "NEWS_POST";
        //public const string SEARCH = "SEARCH";
        //public const string CONTACT = "CONTACT";
        //public const string UNDERCONSTRUCTION = "UNDERCONSTRUCTION";
        //public const string EMAIL_CONFIG = "EMAIL_CONFIG";
        //public const string EMAIL_SEND = "EMAIL_SEND";
        //public const string UNKNOWN = "UNKNOWN";

        enum FUNCTION
        {
            TITLE = 1,
            UPLOAD = 2,
            REGISTRY = 3,
            LOGIN = 4,
            DOWNLOAD = 5,
            COMMENT = 6,
            ADS = 7,
            UPLOAD_UNIVERSITY= 8,
            DOWNLOAD_UNIVERSITY =9,
            UPLOAD_EL = 11,
            DOWNLOAD_EL = 12,
            UPLOAD_IT =13,
            DOWNLOAD_IT = 14,
            NEWS_VIEWS = 15,
            NEWS_POST =17,
            SEARCH =18,
            CONTACT = 19,
            UNDERCONSTRUCTION = 20,
            EMAIL_CONFIG = 21,
            EMAIL_SEND = 22,
            UNKNOWN = -1,
        };

        enum STATISTIC
        {
            ARTICLES,
            USER,
            NUMBER_RECORD_ON_TAB,
        };

        public static int getIDFunction(FUNCTION func)
        {
            switch (func)
            {
                case FUNCTION.TITLE:
                    {
                        return 1;
                    }
                case FUNCTION.UPLOAD:
                    {
                        return 2;
                    }
                case FUNCTION.REGISTRY:
                    {
                        return 3;
                    }
                case FUNCTION.LOGIN:
                    {
                        return 4;
                    }
                case FUNCTION.DOWNLOAD:
                    {
                        return 5;
                    }
                case FUNCTION.COMMENT:
                    {
                        return 6;
                    }
                case FUNCTION.ADS:
                    {
                        return 7;
                    }
                case FUNCTION.UPLOAD_UNIVERSITY:
                    {
                        return 8;
                    }
                case FUNCTION.DOWNLOAD_UNIVERSITY:
                    {
                        return 9;
                    }
                case FUNCTION.UPLOAD_EL:
                    {
                        return 11;
                    }
                case FUNCTION.DOWNLOAD_EL:
                    {
                        return 12;
                    }
                case FUNCTION.UPLOAD_IT:
                    {
                        return 13;
                    }
                case FUNCTION.DOWNLOAD_IT:
                    {
                        return 14;
                    }
                case FUNCTION.NEWS_VIEWS:
                    {
                        return 15;
                    }
                case FUNCTION.NEWS_POST:
                    {
                        return 17;
                    }
                case FUNCTION.SEARCH:
                    {
                        return 18;
                    }
                case FUNCTION.CONTACT:
                    {
                        return 19;
                    }
                case FUNCTION.UNDERCONSTRUCTION:
                    {
                        return 20;
                    }
                case FUNCTION.EMAIL_CONFIG:
                    {
                        return 21;
                    }
                case FUNCTION.EMAIL_SEND:
                    {
                        return 22;
                    }
            }
            return -1;
        }
    }
}
