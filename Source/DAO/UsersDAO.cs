using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

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

        /// <summary>
        /// Lấy ra email của username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string getEmail(string username)
        {
            LTDHDataContext DB = new LTDHDataContext();
            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.Username == username
                                       select record;
            if (lst.Count() > 0)
            {
                return lst.ElementAt(0).Email;
            }
            return "Not Exists";
        }

        /// <summary>
        /// Lấy ra ngày đăng ký thành viên của user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static DateTime getRegisterDate(string username)
        {
            LTDHDataContext DB = new LTDHDataContext();
            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.Username == username
                                       select record;
         
            return lst.ElementAt(0).RegisterDate;
        }

        /// <summary>
        /// Lấy loại thành viên
        /// - Admin
        /// - Normal
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string getUserType(string username)
        {
            LTDHDataContext DB = new LTDHDataContext();
            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.Username == username
                                       select record;

            if (lst.ElementAt(0).Type == false)
            {
                return "Admin";
            }

            return "Normal";
        }


        /// <summary>
        /// Lấy trạng thái của user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string getUserState(string username)
        {
            LTDHDataContext DB = new LTDHDataContext();
            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.Username == username
                                       select record;

            int type = lst.ElementAt(0).State;
            string strState = "";
            switch (type)
            {
                case 0:
                    {
                        strState = "Non-Active";
                        break;
                    }
                case 1:
                    {
                        strState = "Active";
                        break;
                    }
                case 2:
                    {
                        strState = "Warning";
                        break;
                    }
                case 31:
                    {
                        strState = "KIA 3 ngày";
                        break;
                    }
                case 32:
                    {
                        strState = "KIA 1 tuần";
                        break;
                    }
                case 33:
                    {
                        strState = "KIA 2 tuần";
                        break;
                    }
                case 34:
                    {
                        strState = "KIA 3 tuần";
                        break;
                    }
                case 35:
                    {
                        strState = "KIA 1 tháng";
                        break;
                    }

                default:
                    break;
            }

            return strState;
        }

        /// <summary>
        /// Lấy ra ghi chú về user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string getNote(string username)
        {
            LTDHDataContext DB = new LTDHDataContext();
            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.Username == username
                                       select record;

            return lst.ElementAt(0).Note;
        }

        /// <summary>
        /// Lấy số bài viết của user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static int getNumberOfArticles(string username)
        {
            LTDHDataContext DB = new LTDHDataContext();
            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.Username == username
                                       select record;

            return lst.ElementAt(0).NumberOfArticles;
        }

        /// <summary>
        /// lấy tên role của user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string getRole(string username)
        {
            LTDHDataContext DB = new LTDHDataContext();
            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.Username == username
                                       select record;

            return lst.ElementAt(0).Role;
 
        }

        #endregion

        #region Set Property
        /// <summary>
        /// Xét password cho user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="_password"></param>
        /// <returns></returns>
        public static Boolean setPassword(string username, string _password)
        {
            LTDHDataContext DB = new LTDHDataContext();

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblUsers.Single(TB => TB.Username == username);
                record.Password = _password;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét tên hiển thị cho user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="_displayName"></param>
        /// <returns></returns>
        public static Boolean setDisplayName(string username, string _displayName)
        {
            LTDHDataContext DB = new LTDHDataContext();

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblUsers.Single(TB => TB.Username == username);
                record.DisplayName = _displayName;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }
        
        /// <summary>
        /// Xét email cho user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="_email"></param>
        /// <returns></returns>
        public static Boolean setEmail(string username, string _email)
        {
            LTDHDataContext DB = new LTDHDataContext();

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblUsers.Single(TB => TB.Username == username);
                record.Email = _email;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét loại user
        /// false - Admin
        /// true - Normal
        /// </summary>
        /// <param name="username"></param>
        /// <param name="_type"></param>
        /// <returns></returns>
        public static Boolean setType(string username, Boolean _type)
        {
            LTDHDataContext DB = new LTDHDataContext();

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblUsers.Single(TB => TB.Username == username);
                record.Type = _type;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét trạng thái của user
        /// 0: Non-Active (mới đăng ký thành viên)
        /// 1: Active (Trạng thái hoạt động bình thường)
        /// 2: Warning (khi gửi bài bị báo xấu)
        /// 31: KIA 3 ngày
        /// 32: KIA 1 tuần
        /// 33: KIA 2 tuần
        /// 34: KIA 3 tuần
        /// 35: KIA 1 tháng
        /// </summary>
        /// <param name="username"></param>
        /// <param name="_state"></param>
        /// <returns></returns>
        public static Boolean setUserState(string username, int _state)
        {
            LTDHDataContext DB = new LTDHDataContext();

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblUsers.Single(TB => TB.Username == username);
                record.State = _state;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét ngày đăng ký thành viên của user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="_registerDate"></param>
        /// <returns></returns>
        public static Boolean setRegisterDate(string username, DateTime _registerDate)
        {
            LTDHDataContext DB = new LTDHDataContext();

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblUsers.Single(TB => TB.Username == username);
                record.RegisterDate = _registerDate;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét số bài viết của user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="_numberOfArticles"></param>
        /// <returns></returns>
        public static Boolean setNumberOfArticles(string username, int _numberOfArticles)
        {
            LTDHDataContext DB = new LTDHDataContext();

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblUsers.Single(TB => TB.Username == username);
                record.NumberOfArticles = _numberOfArticles;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        /// <summary>
        /// Xét ghi chú cho user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="_note"></param>
        /// <returns></returns>
        public static Boolean setNote(string username, string _note)
        {
            LTDHDataContext DB = new LTDHDataContext();

            using (TransactionScope ts = new TransactionScope())
            {
                var record = DB.tblUsers.Single(TB => TB.Username == username);
                record.Note = _note;
                DB.SubmitChanges();

                ts.Complete();
            }

            return true;
        }

        #endregion
        #endregion

        #region Method
        /// <summary>
        /// Thêm một user mới
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static Boolean insertUser(tblUser record)
        {
            LTDHDataContext DB = new LTDHDataContext();

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DB.tblUsers.InsertOnSubmit(record);

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

        public static Boolean updateUser(tblUser record)
        {
            return true;
        }

        #endregion
    }
}
