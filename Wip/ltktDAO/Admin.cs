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
        public static IQueryable<tblAdmin> getRecord(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var item = DB.tblAdmins.Where(p => p.ID == _id);
            return item;
        }
        public static bool changeStateON(int _id, string _username)
        {
            try
            {
                log.writeLog("[" + _username + "]:Change state id=" + _id+ " is ON");
                using (TransactionScope ts = new TransactionScope())
                {
                    LTDHDataContext DB = new LTDHDataContext(@strPathDB);
                    var record = DB.tblAdmins.Single(p => p.ID == _id);
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

        public static bool changeStateOFF(int _id, string _username)
        {
            try
            {
                log.writeLog("[" + _username + "]:Change state id=" + _id + " is OFF");
                using (TransactionScope ts = new TransactionScope())
                {
                    LTDHDataContext DB = new LTDHDataContext(@strPathDB);
                    var record = DB.tblAdmins.Single(p => p.ID == _id);
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
