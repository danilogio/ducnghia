using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
namespace ltktDAO
{
    public class Sticky
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        static EventLog log = new EventLog();
        /// <summary>
        /// Check existed record in DB
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_article"></param>
        /// <returns></returns>
        public bool checkExisted(int _type, int _article)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblSticky> lst = DB.tblStickies.Where(r =>r.Type == _type && r.Article == _article);

            if (lst.Count() > 0)
            { 
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        public bool insertSticky(tblSticky record, string _username)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                log.writeLog("[" + _username + "]:INSERT Sticky where _type=" + record.Type + " and article=" + record.Article);
                using (TransactionScope ts = new TransactionScope())
                {
                    DB.tblStickies.InsertOnSubmit(record);

                    DB.SubmitChanges();

                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile + CommonConstants.PATH_LOG_FILE, e.Message);
                return false;
            }
            log.writeLog("[" + _username + "]:INSERT Sticky successful");
            return true;
        }

        public bool deleteSticky(int _type, int _article, string _username)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                log.writeLog("[" + _username + "]:DELETE Sticky where _type=" + _type + " and article=" + _article);
                using (TransactionScope ts = new TransactionScope())
                {
                    tblSticky s = DB.tblStickies.Single(p => p.Type == _type && p.Article == _article);
                    DB.tblStickies.DeleteOnSubmit(s);

                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile + CommonConstants.PATH_LOG_FILE, ex.Message);
                return false;
            }
            log.writeLog("[" + _username + "]:DELETE Sticky successful");
            return true;
        }
    }
}
