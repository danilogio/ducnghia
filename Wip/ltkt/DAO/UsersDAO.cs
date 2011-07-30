using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mail;
using System.Web.Security;

namespace DucNghia.DAO
{
    public class UsersDAO
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;

        #region Property
        #region Get Property
        /// <summary>
        /// Lấy tên hiển thị của user theo id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string getDisplayName(string username)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
            LTDHDataContext DB = new LTDHDataContext(strPathDB);

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

        /// <summary>
        /// Cập nhật user
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public static Boolean updateUser(string _username, tblUser update)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var user = DB.tblUsers.Single(u => u.Username == _username);

                    user.Password = update.Password;
                    user.DisplayName = update.DisplayName;
                    user.Email = update.Email;
                    user.Type = update.Type;
                    user.Role = update.Role;
                    user.Permission = update.Permission;
                    user.State = update.State;
                    user.RegisterDate = update.RegisterDate;
                    user.NumberOfArticles = update.NumberOfArticles;
                    user.Note = update.Note;

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
        /// Mã hóa mật khẩu
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string encryptPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] originalText = ASCIIEncoding.Default.GetBytes(password);
            byte[] cipherText = md5.ComputeHash(originalText);
            return BitConverter.ToString(cipherText);
        }


        /// <summary>
        /// Lấy user
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_password"></param>
        /// <returns></returns>
        public static tblUser getUser(string _username, string _password)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            string pwd = encryptPassword(_password);

            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.Username == _username && record.Password == pwd
                                       select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0);
            }

            return null;
        }

        /// <summary>
        /// Kiểm tra xem có phải user hay k?
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_password"></param>
        /// <returns></returns>
        public static Boolean isUser(string _username, string _password)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            string pwd = encryptPassword(_password);

            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.Username == _username && record.Password == pwd
                                       select record;
            if (lst.Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra xem đã có username này hay chưa?
        /// </summary>
        /// <param name="_username"></param>
        /// <returns></returns>
        public static Boolean existedUser(string _username)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            //tìm user trong bảng user
            IEnumerable<tblUser> user = from record in DB.tblUsers
                                        where record.Username == _username
                                        select record;

            // nếu tồn tại it nhất 1 user
            if (user.Count() > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Kiểm tra xem đã có email này đăng ký hay chưa?
        /// </summary>
        /// <param name="_email"></param>
        /// <returns></returns>
        public static string existedEmail(string _email)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            //tìm user trong bảng user
            IEnumerable<tblUser> user = from record in DB.tblUsers
                                        where record.Email == _email
                                        select record;

            // nếu tồn tại it nhất 1 user
            if (user.Count() > 0)
            {
                return user.ElementAt(0).Username;
            }

            return null;
        }


        /// <summary>
        /// Đăng ký user mới
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_displayName"></param>
        /// <param name="_email"></param>
        /// <param name="_sex"></param>
        /// <param name="_password"></param>
        /// <returns></returns>
        public static Boolean register(string _username,
            string _displayName,
            string _email,
            Boolean _sex,
            string _password)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    tblUser user = new tblUser();
                    user.Username = _username;
                    user.DisplayName = _displayName;
                    user.Sex = _sex;
                    user.Email = _email;
                    user.Password = encryptPassword(_password);
                    user.Note = "Password: " + _password;

                    user.Type = true;
                    user.Permission = "Normal";
                    user.RegisterDate = DateTime.Today;
                    user.NumberOfArticles = 0;
                    user.State = 0;

                    DB.tblUsers.InsertOnSubmit(user);
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
        /// Phát sinh chuỗi mật khẩu bất kỳ
        /// </summary>
        /// <returns></returns>
        public static string generatePassword()
        {
            //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            //var stringChars = new char[8];
            //var random = new Random();

            //for (int i = 0; i < stringChars.Length; i++)
            //{
            //    stringChars[i] = chars[random.Next(chars.Length)];
            //}

            //return new String(stringChars);

            return Membership.GeneratePassword(8, 0);
        }

        /// <summary>
        /// Cập nhật mật khẩu mới
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_newPassword"></param>
        public static Boolean updateUserPassword(string _username, string _newPassword)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var user = DB.tblUsers.Single(u => u.Username == _username);

                    user.Note = "New password: " + _newPassword;
                    user.Password = encryptPassword(_newPassword);

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
        /// Gửi mật khẩu mới tới user
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_newPassword"></param>
        /// <param name="_email"></param>
        /// <returns></returns>
        public static Boolean sendNewPassword(string _username, string _newPassword, string _email)
        {
            try
            {
                // Cập nhật mật khẩu
                Boolean isOK = updateUserPassword(_username, _newPassword);

                if (isOK)
                {
                    MailMessage message = new MailMessage();
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                    //Use 0 for anonymous
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "trungtamducnghia@gmail.com");
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "123456987");
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                    message.From = "trungtamducnghia@gmail.com";
                    message.To = _email;
                    message.Subject = "Mật khẩu mới tại trang web luyện thi kinh tế";
                    message.BodyFormat = MailFormat.Text;
                    message.BodyEncoding = Encoding.UTF8;
                    message.Body = "Tên đăng nhập: " + _username + "\n" + "Mật khẩu: " + _newPassword;
                    SmtpMail.SmtpServer = "smtp.gmail.com:465";

                    SmtpMail.Send(message);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Tổng số user
        /// </summary>
        /// <returns></returns>
        public static int numberOfUsers()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblUsers
                      select record;

            return lst.Count();
        }

        /// <summary>
        /// method of UniversityDAO
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<tblContestForUniversity> getAll()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblContestForUniversity> lst = from p in DB.tblContestForUniversities
                                                       select p;
            return lst;
        }

        #endregion
    }
}
