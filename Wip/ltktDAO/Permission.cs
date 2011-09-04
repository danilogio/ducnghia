using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltktDAO
{
    public class Permission
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        LTDHDataContext DB = new LTDHDataContext(@strPathDB);
        EventLog log = new EventLog();
        /// <summary>
        /// return permision record
        /// </summary>
        /// <param name="_code"></param>
        /// <returns></returns>
        public tblPermission getRecord(string _code)
        {
            IEnumerable<tblPermission> lst = from p in DB.tblPermissions
                    where p.Code == _code
                    select p;
            if (lst == null)
                return null;
            return lst.ElementAt(0);
        }

        /// <summary>
        /// get name of permission
        /// </summary>
        /// <param name="_code"></param>
        /// <returns></returns>
        public string getName(string _code)
        {
            tblPermission r = getRecord(_code);
            if (BaseServices.isNullOrBlank(r.Name))
            {
                return CommonConstants.BLANK;
            }
            return r.Name.Trim();
        }

        /// <summary>
        /// get value of permission
        /// </summary>
        /// <param name="_code"></param>
        /// <returns></returns>
        public int getValue(string _code)
        {
            tblPermission r = getRecord(_code);
            return r.Value;
        }

    }
}
