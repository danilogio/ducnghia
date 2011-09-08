using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web.Mail;

namespace ltktDAO
{
    public class Contact
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        LTDHDataContext DB = new LTDHDataContext(@strPathDB);
        EventLog log = new EventLog();

        #region Property
        #region Get
        #endregion

        #region Set
        /// <summary>
        /// Xét trường from
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_from"></param>
        /// <returns></returns>
        public Boolean setEmailFrom(int _id, string _from)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContacts.Single(TB => TB.ID == _id);

                    record.EmailFrom = _from;

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Xét trường to
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_to"></param>
        /// <returns></returns>
        public Boolean setEmailTo(int _id, string _to)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContacts.Single(TB => TB.ID == _id);

                    record.EmailTo = _to;

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Xét trường subject
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_subject"></param>
        /// <returns></returns>
        public Boolean setSubject(int _id, string _subject)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContacts.Single(TB => TB.ID == _id);

                    record.Subject = _subject;

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Xét nội dung
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_contents"></param>
        /// <returns></returns>
        public Boolean setContents(int _id, string _contents)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContacts.Single(TB => TB.ID == _id);

                    record.Contents = _contents;

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Xét ngày gửi
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_posted"></param>
        /// <returns></returns>
        public Boolean setPosted(int _id, DateTime _posted)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContacts.Single(TB => TB.ID == _id);

                    record.Posted = _posted;

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Xét trạng thái của email
        /// false - chưa đọc
        /// true - đã đọc
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_read"></param>
        /// <returns></returns>
        public Boolean setRead(int _id, Boolean _read)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var record = DB.tblContacts.Single(TB => TB.ID == _id);

                    record.isRead = _read;

                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        #endregion
        #endregion

        #region Method

        /// <summary>
        /// Lấy toàn bộ email liên hệ/góp ý.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblContact> getAll()
        {
            return (from record in DB.tblContacts select record);
        }

        /// <summary>
        /// Lấy email theo ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public tblContact getEmail(int _id)
        {
            IEnumerable<tblContact> lst = from record in DB.tblContacts
                                          where record.ID == _id
                                          select record;
            if (lst.Count() > 0)
            {
                return lst.ElementAt(0);
            }
            return null;
        }

        /// <summary>
        /// Thêm một email
        /// </summary>
        /// <param name="_from"></param>
        /// <param name="_to"></param>
        /// <param name="_subject"></param>
        /// <param name="_content"></param>
        /// <param name="_posted"></param>
        /// <returns></returns>
        public Boolean insertEmail(string _username, string _from, string _to,
                                        string _subject, string _content, DateTime _posted)
        {
            int id = 0;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    tblContact contact = new tblContact();
                    contact.EmailFrom = _from;
                    contact.EmailTo = _to;
                    contact.Subject = _subject;
                    contact.Contents = _content;
                    contact.Posted = _posted;
                    contact.isRead = false;

                    DB.tblContacts.InsertOnSubmit(contact);
                    DB.SubmitChanges();
                    ts.Complete();

                    id = contact.ID;

                    log.writeLog(DBHelper.strPathLogFile,
                                  _username,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE,
                                                                   Convert.ToString(id),
                                                                   CommonConstants.SQL_TABLE_CONTACT));

                }
            }
            catch (Exception e)
            {

                log.writeLog(DBHelper.strPathLogFile,
                                  _username,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE,
                                                                   Convert.ToString(id),
                                                                   CommonConstants.SQL_TABLE_CONTACT));
                log.writeLog(DBHelper.strPathLogFile, _username, e.Message);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Lấy ra số lượng thư chưa đọc
        /// </summary>
        /// <returns></returns>
        public int sumUnread()
        {
            IEnumerable<tblContact> lst = from record in DB.tblContacts
                                          where record.isRead == false
                                          select record;
            return lst.Count();
        }

        /// <summary>
        /// Lấy ra các email chưa đọc
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblContact> getEmailUnread()
        {
            IEnumerable<tblContact> lst = from record in DB.tblContacts
                                          where record.isRead == false
                                          select record;
            return lst;
        }

        /// <summary>
        /// Tổng số emails
        /// </summary>
        /// <returns></returns>
        public int sumEmails()
        {
            IEnumerable<tblContact> lst = from record in DB.tblContacts
                                          select record;
            return lst.Count();
        }

        /// <summary>
        /// get cound email fromt id=start
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<tblContact> fetchEmailList(int start, int count)
        {
            IEnumerable<tblContact> lst = (from record in DB.tblContacts
                                           select record).Skip(start).Take(count);

            return lst;
        }

        /// <summary>
        /// Delete a email
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool deleteEmail(int emailID, string username)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var email = DB.tblContacts.Single (e =>e.ID == emailID);

                    DB.tblContacts.DeleteOnSubmit (email);
                    DB.SubmitChanges ();
                    ts.Complete ();

                    log.writeLog (DBHelper.strPathLogFile,
                              username,
                              BaseServices.createMsgByTemplate (CommonConstants.SQL_DELETE_SUCCESSFUL_TEMPLATE,
                                                                Convert.ToString (emailID),
                                                                CommonConstants.SQL_TABLE_CONTACT));

                }
            }
            catch (Exception e)
            {
                log.writeLog (DBHelper.strPathLogFile,
                              username,
                              BaseServices.createMsgByTemplate (CommonConstants.SQL_DELETE_FAILED_TEMPLATE,
                                                                Convert.ToString (emailID),
                                                                CommonConstants.SQL_TABLE_CONTACT));

                log.writeLog(DBHelper.strPathLogFile,
                              username,
                              e.Message);

                return false;
            }

            return true;
        }

        #endregion



    }
}
