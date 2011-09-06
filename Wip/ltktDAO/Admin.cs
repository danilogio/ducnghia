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
        /// Get all record
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblAdmin> getAll()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblAdmin> items = from p in DB.tblAdmins
                                         select p;
            return items;
        }
        /// <summary>
        /// Get record of TblAdmin
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public IEnumerable<tblAdmin> getRecord(string _code)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblAdmin> item = DB.tblAdmins.Where(p => p.Code == _code);
            return item;
        }
        /// <summary>
        /// get message con admin function
        /// </summary>
        /// <param name="_code"></param>
        /// <returns></returns>
        public string getMessage(string _code)
        {
            string res = CommonConstants.BLANK;
            IEnumerable<tblAdmin> lst = getRecord(_code);
            if (lst.Count() > 0)
            {
                res = lst.ElementAt(0).Message;
            }
            return res;
        }
        /// <summary>
        /// get reason of admin function
        /// </summary>
        /// <param name="_code"></param>
        /// <returns></returns>
        public string getReason(string _code)
        {
            string res = CommonConstants.BLANK;
            IEnumerable<tblAdmin> lst = getRecord(_code);
            if (lst.Count() > 0)
            {
                res = lst.ElementAt(0).Reason;
            }
            return res;
        }
        /// <summary>
        /// check function is ON
        /// </summary>
        /// <param name="_code"></param>
        /// <returns></returns>
        public bool isON(string _code)
        {

            IEnumerable<tblAdmin> lst = getRecord(_code);
            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).State;
            }
            return false;

        }
        /// <summary>
        /// change state of function is ON
        /// </summary>
        /// <param name="_code"></param>
        /// <param name="_username"></param>
        /// <returns></returns>
        public bool changeStateON(string _code, string _username)
        {
            try
            {
                
                using (TransactionScope ts = new TransactionScope())
                {
                    LTDHDataContext DB = new LTDHDataContext(@strPathDB);
                    var record = DB.tblAdmins.Single(p => p.Code == _code);
                    record.State = true;
                    DB.SubmitChanges();
                    ts.Complete();
                    log.writeLog(DBHelper.strPathLogFile, 
                                _username, 
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_CHANGE_STATE_ON, 
                                                                _code));
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, ex.Message);
                return false;
            }
            
            return true;
        }
        /// <summary>
        /// change state of function is OFF
        /// </summary>
        /// <param name="_code"></param>
        /// <param name="_username"></param>
        /// <returns></returns>
        public bool changeStateOFF(string _code, string _username)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    LTDHDataContext DB = new LTDHDataContext(@strPathDB);
                    var record = DB.tblAdmins.Single(p => p.Code == _code);
                    record.State = false;
                    DB.SubmitChanges();
                    ts.Complete();
                    log.writeLog(DBHelper.strPathLogFile,
                                _username,
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_CHANGE_STATE_OFF,
                                                                _code));
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, ex.Message);
                return false;
            }
            return true;
        }
    }

    
}
