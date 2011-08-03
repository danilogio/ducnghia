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
        public static Boolean setEmailFrom(int _id, string _from)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static Boolean setEmailTo(int _id, string _to)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static Boolean setSubject(int _id, string _subject)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static Boolean setContents (int _id, string _contents)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static Boolean setPosted(int _id, DateTime _posted)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static Boolean setRead(int _id, Boolean _read)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static IEnumerable<tblContact> getAll()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            return (from record in DB.tblContacts select record);
        }

        /// <summary>
        /// Lấy email theo ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public static tblContact getEmail(int _id)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public static Boolean insertEmail(string _from, string _to,
                                        string _subject, string _content, DateTime _posted)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Lấy ra số lượng thư chưa đọc
        /// </summary>
        /// <returns></returns>
        public static int sumUnread()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContact> lst = from record in DB.tblContacts
                                          where record.isRead == false
                                          select record;
            return lst.Count();
        }

        /// <summary>
        /// Lấy ra các email chưa đọc
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<tblContact> getEmailUnread()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContact> lst = from record in DB.tblContacts
                                          where record.isRead == false
                                          select record;
            return lst;
        }

        /// <summary>
        /// Tổng số emails
        /// </summary>
        /// <returns></returns>
        public static int sumEmails()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContact> lst = from record in DB.tblContacts
                                          select record;
            return lst.Count();
        }

        #endregion
    }
}
