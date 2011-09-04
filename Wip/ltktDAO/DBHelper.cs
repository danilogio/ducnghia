using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public class DBHelper
    {
        public static string strPathDB = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\LTDH.mdf";
        public static string strPathLogFile = AppDomain.CurrentDomain.BaseDirectory + "Log\\EvenLog";
        public static string strCurrentPath = AppDomain.CurrentDomain.BaseDirectory;
    }
}
