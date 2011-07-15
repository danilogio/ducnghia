using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    class UsersDAO
    {
        #region Property
        #region Get Property
        /// <summary>
        /// Lấy tên hiển thị của user theo id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string getDisplayName(string username)
        {
            LTDHDataContext DB = new LTDHDataContext();
            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                      where record.Username == username
                                      select record;
            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).DisplayName;
            }
            return "Not Exists";
        }

       



        #endregion

        

        #region Set Property
        #endregion
        #endregion

        #region Method
        #endregion
    }
}
