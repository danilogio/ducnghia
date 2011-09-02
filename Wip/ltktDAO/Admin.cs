using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ltktDAO
{
    public class Admin
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        static EventLog log = new EventLog();
        

        /// <summary>
        /// Get record of TblAdmin
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public static IQueryable<tblAdmin> getRecord(string _code)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var item = DB.tblAdmins.Where(p => p.Code == _code);
            return item;
        }
        public static bool changeStateON(string _code, string _username)
        {
            try
            {
                log.writeLog("[" + _username + "]:Change state id=" + _code + " is ON");
                using (TransactionScope ts = new TransactionScope())
                {
                    LTDHDataContext DB = new LTDHDataContext(@strPathDB);
                    var record = DB.tblAdmins.Single(p => p.Code == _code);
                    record.State = true;
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile + CommonConstants.LOG_FILE_PATH, ex.Message);
                return false;
            }
            log.writeLog("[" + _username + "]:Change state ON successful");
            return true;
        }

        public static bool changeStateOFF(string _code, string _username)
        {
            try
            {
                log.writeLog("[" + _username + "]:Change state id=" + _code + " is OFF");
                using (TransactionScope ts = new TransactionScope())
                {
                    LTDHDataContext DB = new LTDHDataContext(@strPathDB);
                    var record = DB.tblAdmins.Single(p => p.Code == _code);
                    record.State = false;
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile + CommonConstants.LOG_FILE_PATH, ex.Message);
                return false;
            }
            log.writeLog("[" + _username + "]:Change state OFF successful");
            return true;
        }
    }

    
}
