using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mail;
using System.Transactions;
using System.Security.Cryptography;
using System.Web.Security;

namespace ltktDAO
{
    public class Users
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        EventLog log = new EventLog();
        LTDHDataContext DB = new LTDHDataContext(@strPathDB);
        Control control = new Control();
        EmailConf emailConf = new EmailConf();
        ltktDAO.Contact contactDAO = new ltktDAO.Contact();

        #region Property
        #region Get Property
        /// <summary>
        /// Lấy tên hiển thị của user theo id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string getDisplayName(string username)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public string getEmail(string username)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public DateTime getRegisterDate(string username)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public string getUserType(string username)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public string getUserState(string username)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public string getNote(string username)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.Username == username
                                       select record;

            return lst.ElementAt(0).Note;
        }

        /// <summary>
        /// Get set of permission of a users through id
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public IList<tblPermission> getPermissions(int _id)
        {
            IList<tblPermission> lstResult = new List<tblPermission>();
            IEnumerable<tblUser> lstUser = from u in DB.tblUsers
                                           where u.ID == _id
                                           select u;

            if (lstUser.Count() > 0)
            {
                tblUser user = lstUser.ElementAt(0);
                if (user.Permission.Trim().EndsWith(CommonConstants.COMMA))
                    user.Permission = user.Permission.Substring(0, user.Permission.Trim().LastIndexOf(CommonConstants.COMMA));

                string[] permits = user.Permission.Split(Convert.ToChar (CommonConstants.COMMA));

                foreach (string permit in permits)
                {
                    IEnumerable<tblPermission> lstPermits = from p in DB.tblPermissions
                                                            where p.Value == Convert.ToInt32(permit)
                                                            select p;

                    if (lstPermits.Count() > 0)
                        lstResult.Add(lstPermits.ElementAt(0));
                }
            }

            return lstResult;
        }

        /// <summary>
        /// Lấy số bài viết của user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int getNumberOfArticles(string username)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public string getRole(string username)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        public Boolean setPassword(string username, string _password)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
        public Boolean setDisplayName(string username, string _displayName)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
        public Boolean setEmail(string username, string _email)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
        public Boolean setType(string username, Boolean _type)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
        public Boolean setUserState(string username, int _state)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
        public Boolean setRegisterDate(string username, DateTime _registerDate)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
        public Boolean setNumberOfArticles(string username, int _numberOfArticles)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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
        public Boolean setNote(string username, string _note)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);

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

        public IEnumerable<tblUser> getAll()
        {
            LTDHDataContext DB = new LTDHDataContext(strPathDB);
            IEnumerable<tblUser> lst;
            lst = from u in DB.tblUsers
                  orderby u.Username
                  select u;
            return lst;
        }
        public UserInfoVO getUserInfo(string _username)
        {
            UserInfoVO info = null;
            LTDHDataContext DB = new LTDHDataContext(strPathDB);
            IEnumerable<tblUser> lst = from p in DB.tblUsers
                                       where p.Username==_username
                                       select p;
            if(lst!= null && lst.Count()>0)
            {
                info = new UserInfoVO();
                info.DisplayName = lst.ElementAt(0).DisplayName;
                //info.Email = lst.ElementAt(0).Email;
                info.NumArticle = lst.ElementAt(0).NumberOfArticles;
                info.Sex = lst.ElementAt(0).Sex;
            }
            return info;
        }
        /// <summary>
        /// Thêm một user mới
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public Boolean insertUser(tblUser record)
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
        public Boolean updateUser(string _username, tblUser update)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
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
        /// Cập nhật user
        /// </summary>
        /// <param name="_userAdmin"></param>
        /// <param name="_username"></param>
        /// <param name="_displayName"></param>
        /// <param name="_email"></param>
        /// <param name="_notes"></param>
        /// <returns>true if success</returns>
        public bool updateUser(string _userAdmin,
            string _username, string _displayName, string _email, string _notes)
        {
            int id = 0;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var user = DB.tblUsers.Single(u => u.Username == _username);

                    user.DisplayName = _displayName;
                    user.Email = _email;
                    user.Note = _notes;

                    id = user.ID;

                    DB.SubmitChanges();
                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, _userAdmin,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_SUCCESSFUL_TEMPLATE,
                                                                    Convert.ToString(user.ID),
                                                                    CommonConstants.SQL_TABLE_USER));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _userAdmin,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_FAILED_TEMPLATE,
                                                                    Convert.ToString(id),
                                                                    CommonConstants.SQL_TABLE_USER));
                log.writeLog(DBHelper.strPathLogFile, _userAdmin, e.Message);

                return false;
            }
            return true;
        }

        /// <summary>
        /// Update users
        /// </summary>
        /// <param name="_userAdmin"></param>
        /// <param name="_username"></param>
        /// <param name="_displayName"></param>
        /// <param name="_email"></param>
        /// <param name="_state"></param>
        /// <param name="KIADate"></param>
        /// <param name="_notes"></param>
        /// <returns></returns>
        public bool updateUser(string _userAdmin,
            string _username, string _displayName, string _email, int _state, DateTime KIADate, string _notes)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var user = DB.tblUsers.Single(u => u.Username == _username);

                    user.DisplayName = _displayName;
                    user.Email = _email;
                    user.Note = _notes;
                    user.State = _state;
                    if (_state == CommonConstants.STATE_KIA_3D
                        || _state == CommonConstants.STATE_KIA_1W
                        || _state == CommonConstants.STATE_KIA_2W
                        || _state == CommonConstants.STATE_KIA_3W
                        || _state == CommonConstants.STATE_KIA_1M)
                    {
                        user.KIADate = KIADate;
                    }

                    DB.SubmitChanges();
                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, _userAdmin,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_SUCCESSFUL_TEMPLATE,
                                                                    _username,
                                                                    CommonConstants.SQL_TABLE_USER));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _userAdmin,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_FAILED_TEMPLATE,
                                                                    _username,
                                                                    CommonConstants.SQL_TABLE_USER));
                log.writeLog(DBHelper.strPathLogFile, _userAdmin, e.Message);

                return false;
            }
            return true;
        }

        /// <summary>
        /// Mã hóa mật khẩu
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string encryptPassword(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] originalText = ASCIIEncoding.Default.GetBytes(password);
            byte[] cipherText = md5.ComputeHash(originalText);
            return BitConverter.ToString(cipherText);
        }

        /// <summary>
        /// Giải mã mật khẩu
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string decryptPassword(string password)
        {
            return "";
        }


        /// <summary>
        /// Lấy user
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_password"></param>
        /// <param name="_pwdEncrypted"></param>
        /// <returns></returns>
        public tblUser getUser(string _username, string _password, bool _pwdEncrypted)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            string pwd = "";
            if (_pwdEncrypted)
            {
                pwd = _password;
            }
            else
            {
                pwd = encryptPassword(_password);
            }


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
        /// Lấy ra user bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tblUser getUser(int id)
        {
            IEnumerable<tblUser> lst = from record in DB.tblUsers
                                       where record.ID == id
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
        public Boolean isUser(string _username, string _password)
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
        public Boolean existedUser(string _username)
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
        public string existedEmail(string _email)
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
        public Boolean register(string _username,
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
                    Permission permitDAO = new Permission();

                    user.Username = _username;
                    user.DisplayName = _displayName;
                    user.Sex = _sex;
                    user.Email = _email;
                    user.Password = encryptPassword(_password);
                    user.Note = "Password: " + _password;

                    user.Type = true;
                    user.Permission = permitDAO.getValue(CommonConstants.P_N_GENERAL).ToString();
                    user.RegisterDate = DateTime.Today;
                    user.NumberOfArticles = 0;
                    user.State = CommonConstants.STATE_NON_ACTIVE;

                    DB.tblUsers.InsertOnSubmit(user);
                    DB.SubmitChanges();
                    ts.Complete();

                    
                    log.writeLog(DBHelper.strPathLogFile, CommonConstants.USER_GUEST,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE,
                                                                    _username,
                                                                    CommonConstants.SQL_TABLE_USER));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, CommonConstants.USER_GUEST,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_FAILED_TEMPLATE,
                                                                    _username,
                                                                    CommonConstants.SQL_TABLE_USER));

                log.writeLog(DBHelper.strPathLogFile, CommonConstants.USER_GUEST, e.Message);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Phát sinh chuỗi mật khẩu bất kỳ
        /// </summary>
        /// <returns></returns>
        public string generatePassword()
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
        public Boolean updateUserPassword(string _username, string _newPassword)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var user = DB.tblUsers.Single(u => u.Username == _username);

                    user.Note = "New password: " + _newPassword;
                    user.Password = encryptPassword(_newPassword);

                    DB.SubmitChanges();
                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, CommonConstants.USER_GUEST,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE,
                                                                    _username,
                                                                    CommonConstants.SQL_TABLE_USER));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, CommonConstants.USER_GUEST,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_FAILED_TEMPLATE,
                                                                    _username,
                                                                    CommonConstants.SQL_TABLE_USER));

                log.writeLog(DBHelper.strPathLogFile, CommonConstants.USER_GUEST, e.Message);

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
        public Boolean sendNewPassword(string _username, string _newPassword, string _email)
        {
            try
            {
                // Cập nhật mật khẩu
                Boolean isOK = updateUserPassword(_username, _newPassword);

                if (isOK)
                {
                    emailConf = control.getEmailConfig();

                    MailMessage message = new MailMessage();
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", emailConf.SmptServer);
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", emailConf.SmptPort);
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                    //Use 0 for anonymous
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", emailConf.Username);
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", emailConf.Password);
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                    message.From = emailConf.Username;
                    message.To = _email;
                    message.Subject = "Mật khẩu mới tại " + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
                    message.BodyFormat = MailFormat.Text;
                    message.BodyEncoding = Encoding.UTF8;
                    message.Body = "Tên đăng nhập: " + _username + "<br />" + "Mật khẩu: " + _newPassword;
                    SmtpMail.SmtpServer = emailConf.SmptServer + ":" + emailConf.SmptPort;

                    SmtpMail.Send(message);

                    contactDAO.insertEmail(CommonConstants.USER_SYSTEM,
                                                          emailConf.Username,
                                                          _email,
                                                          "Mật khẩu mới tại trang web" + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER),
                                                          "Tên đăng nhập: " + _username + "<br />" + "Mật khẩu: " + _newPassword,
                                                          DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile,
                              CommonConstants.USER_SYSTEM,
                              ex.Message);

                return false;
            }

            return true;
        }


        /// <summary>
        /// Tổng số user
        /// </summary>
        /// <returns></returns>
        public int numberOfUsers()
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var lst = from record in DB.tblUsers
                      select record;

            return lst.Count();
        }

        /// <summary>
        /// Tên user mới nhất
        /// </summary>
        /// <returns></returns>
        public string latestUser()
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IQueryable<tblUser> lst = (from record in DB.tblUsers
                                       orderby record.ID descending
                                       select record).Take(1);

            foreach (tblUser item in lst)
            {
                return item.Username;
            }

            return null;
        }

        /// <summary>
        /// Lấy count user từ id start
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<tblUser> fetchUserList(int start, int count)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblUser> lst = (from record in DB.tblUsers

                                        select record).Skip(start).Take(count);

            return lst;
        }

        public bool isNormalUser(string _username)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                var user = DB.tblUsers.Single(p => p.Username == _username);
                if (user != null)
                {
                    return user.Type;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, ex.Message);
            }
            return true;
        }

        public bool isState(string _username, int _state)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                var user = DB.tblUsers.Single(p => p.Username == _username);
                if (user != null)
                {
                    return user.State == _state ? true : false;
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, ex.Message);
            }
            return false;
        }
        public string formatUsername(string _username)
        {
            string item = CommonConstants.BLANK;
            if (!BaseServices.isNullOrBlank(_username))
            {

                if (!isNormalUser(_username))
                {
                    item = BaseServices.createMsgByTemplate(CommonConstants.TEMP_I_TAG, _username);
                }
                else
                {
                    item = _username;
                }

                if (isState(_username, CommonConstants.STATE_NON_ACTIVE))
                {
                    item = BaseServices.createMsgByTemplate(CommonConstants.TEMP_SPAN_TAG_WITH_COLOR, CommonConstants.CS_NON_ACTIVE, CommonConstants.SX_NON_ACTIVE, item);
                }
                else if (isState(_username, CommonConstants.STATE_ACTIVE))
                {
                    item = BaseServices.createMsgByTemplate(CommonConstants.TEMP_SPAN_TAG_WITH_COLOR, CommonConstants.CS_ACTIVE, CommonConstants.SX_ACTIVE, item);
                }
                else if (isState(_username, CommonConstants.STATE_DELETED))
                {
                    item = BaseServices.createMsgByTemplate(CommonConstants.TEMP_SPAN_TAG_WITH_COLOR, CommonConstants.CS_DELETED, CommonConstants.SX_DELETED, item);
                }
                else if (isState(_username, CommonConstants.STATE_WARNING))
                {
                    item = BaseServices.createMsgByTemplate(CommonConstants.TEMP_SPAN_TAG_WITH_COLOR, CommonConstants.CS_WARNING, CommonConstants.SX_WARNING, item);
                }
                else
                {
                    item = BaseServices.createMsgByTemplate(CommonConstants.TEMP_SPAN_TAG_WITH_COLOR, CommonConstants.CS_KIA, CommonConstants.SX_KIA, item);
                }
            }
            return item;
        }
        /// <summary>
        /// get latest login
        /// </summary>
        /// <returns></returns>
        public string getLatestLogin()
        {
            Statistics statisticDAO = new Statistics();

            string users = statisticDAO.getValue(CommonConstants.SF_LATEST_LOGIN).Trim();
            string res = CommonConstants.BLANK;
            try
            {
                if (!BaseServices.isNullOrBlank(users))
                {
                    string[] arrayUsers = users.Split(CommonConstants.COMMA_CHAR);
                    for (int i = 0; i < arrayUsers.Length; i++)
                    {
                        res += formatUsername(arrayUsers[i]);
                        res += CommonConstants.SPACE;
                        res += CommonConstants.BAR;
                    }
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, ex.Message);
            }
            return res;
        }
        /// <summary>
        /// check permission
        /// </summary>
        /// <param name="strPermission"></param>
        /// <param name="_codePermission"></param>
        /// <returns></returns>
        public bool isAllow(string strPermission, string _codePermission)
        {
            strPermission = BaseServices.nullToBlank(strPermission);

            if (!BaseServices.isNullOrBlank(_codePermission)
                && !BaseServices.isNullOrBlank(strPermission))
            {
                Permission permitDAO = new Permission();
                int p = permitDAO.getValue(_codePermission);
                string[] arrayPermit = strPermission.Split(CommonConstants.COMMA_CHAR);
                for (int i = 0; i < arrayPermit.Length; i++)
                {
                    if (arrayPermit[i].Equals(p.ToString().Trim()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// add permission for user
        /// </summary>
        /// <param name="_username"></param>
        /// <param name="_codePermit"></param>
        /// <param name="_usernameAdmin"></param>
        /// <returns></returns>
        public bool addPermission(string _username, string _codePermit, string _usernameAdmin)
        {
            //LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            Permission permitDAO = new Permission();

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    tblUser u = DB.tblUsers.Single(p => p.Username == _username.Trim());

                    if (u != null)
                    {

                        //user had this permisssion
                        if (isAllow(u.Permission, _codePermit))
                        {
                            ts.Complete();
                            return true;
                        }
                        else
                        {
                            if (!u.Permission.Trim().EndsWith(CommonConstants.COMMA))
                            {
                                u.Permission += CommonConstants.COMMA;
                            }
                            u.Permission += permitDAO.getValue(_codePermit).ToString();
                            DB.SubmitChanges();
                            ts.Complete();

                            //write log
                            log.writeLog(DBHelper.strPathLogFile,
                                        _usernameAdmin,
                                        BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_SUCCESSFUL_TEMPLATE,
                                                                _username + CommonConstants.BAR + _codePermit,
                                                                CommonConstants.SQL_TABLE_PERMISSION));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, _usernameAdmin, ex.Message);
                return false;
            }
            return false;

        }

        /// <summary>
        /// sum of normal user
        /// </summary>
        /// <returns></returns>
        public int sumNormalUser()
        {
            return (from record in DB.tblUsers
                    where record.Type == true
                    && (record.State != CommonConstants.STATE_KIA_3D
                    || record.State != CommonConstants.STATE_KIA_1W
                    || record.State != CommonConstants.STATE_KIA_2W
                    || record.State != CommonConstants.STATE_KIA_3W
                    || record.State != CommonConstants.STATE_KIA_1M)
                    select record).Count();
        }

        /// <summary>
        /// sum of user who is kia
        /// </summary>
        /// <returns></returns>
        public int sumLockedUser()
        {
            return (from record in DB.tblUsers
                    where record.State == CommonConstants.STATE_KIA_3D
                    || record.State == CommonConstants.STATE_KIA_1W
                    || record.State == CommonConstants.STATE_KIA_2W
                    || record.State == CommonConstants.STATE_KIA_3W
                    || record.State == CommonConstants.STATE_KIA_1M
                    select record).Count();
        }

        /// <summary>
        /// sum of admin user
        /// </summary>
        /// <returns></returns>
        public int sumAdminUser()
        {
            return (from record in DB.tblUsers
                    where record.Type == false
                    select record).Count();
        }
        /// <summary>
        /// count all users is new registry
        /// </summary>
        /// <returns></returns>
        public int sumNewRegisterUser()
        {
            return (from r in DB.tblUsers
                    where r.State == CommonConstants.STATE_NON_ACTIVE
                    select r).Count();
        }
        public IEnumerable<tblUser> fetchUsesList(string normalOrAdminOrKIA, int start, int count)
        {
            IEnumerable<tblUser> lst = null;
            switch (normalOrAdminOrKIA)
            {
                case CommonConstants.ACT_NORMAL:
                    lst = (from record in DB.tblUsers
                           where record.Type == true
                           && (record.State != CommonConstants.STATE_KIA_3D
                            || record.State != CommonConstants.STATE_KIA_1W
                            || record.State != CommonConstants.STATE_KIA_2W
                            || record.State != CommonConstants.STATE_KIA_3W
                            || record.State != CommonConstants.STATE_KIA_1M)
                           orderby record.ID descending
                           select record).Skip(start).Take(count);
                    break;
                case CommonConstants.ACT_ADMIN:
                    lst = (from record in DB.tblUsers
                           where record.Type == false
                           && (record.State != CommonConstants.STATE_KIA_3D
                            || record.State != CommonConstants.STATE_KIA_1W
                            || record.State != CommonConstants.STATE_KIA_2W
                            || record.State != CommonConstants.STATE_KIA_3W
                            || record.State != CommonConstants.STATE_KIA_1M)
                           orderby record.ID descending
                           select record).Skip(start).Take(count);
                    break;
                case CommonConstants.ACT_KIA:
                    lst = (from record in DB.tblUsers
                           where record.State == CommonConstants.STATE_KIA_3D
                                || record.State == CommonConstants.STATE_KIA_1W
                                || record.State == CommonConstants.STATE_KIA_2W
                                || record.State == CommonConstants.STATE_KIA_3W
                                || record.State == CommonConstants.STATE_KIA_1M
                           orderby record.ID descending
                           select record).Skip(start).Take(count);
                    break;
                default: break;
            }

            return lst;
        }

        //public bool isSuperAdmin(string username)
        //{
        //    IEnumerable<tblUser> lst = from r in DB.tblUsers
        //                               where r.Username == username
        //                               select r;

        //    if (lst.Count() > 0)
        //    {
        //        tblUser user = lst.ElementAt(0);
        //        string[] permissions = user.Permission.Split(CommonConstants.COMMA);

        //    }
        //}

        /// <summary>
        /// get state through state id
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string getState(int state)
        {
            string strState = CommonConstants.BLANK;
            switch (state)
            {
                case CommonConstants.STATE_NON_ACTIVE:
                    strState = CommonConstants.STATE_NON_ACTIVE_NAME;
                    break;
                case CommonConstants.STATE_ACTIVE:
                    strState = CommonConstants.STATE_ACTIVE_NAME;
                    break;
                case CommonConstants.STATE_KIA_3D:
                    strState = CommonConstants.STATE_KIA_3D_NAME;
                    break;
                case CommonConstants.STATE_KIA_1W:
                    strState = CommonConstants.STATE_KIA_1W_NAME;
                    break;
                case CommonConstants.STATE_KIA_2W:
                    strState = CommonConstants.STATE_KIA_2W_NAME;
                    break;
                case CommonConstants.STATE_KIA_3W:
                    strState = CommonConstants.STATE_KIA_3W_NAME;
                    break;
                case CommonConstants.STATE_KIA_1M:
                    strState = CommonConstants.STATE_KIA_1M_NAME;
                    break;
                case CommonConstants.STATE_WARNING:
                    strState = CommonConstants.STATE_WARNING_NAME;
                    break;
                default:
                    break;
            }

            return strState;
        }

        /// <summary>
        /// search user
        /// </summary>
        /// <param name="_keyword"></param>
        /// <returns></returns>
        public IList<tblUser> search(string _keyword)
        {
            IList<tblUser> results = new List<tblUser>();
            IEnumerable<tblUser> lst = from r in DB.tblUsers
                                       where r.Username.Contains(_keyword)
                                       select r;

            if (lst.Count() > 0)
            {
                results = lst.ToList();
            }

            return results;
        }

        /// <summary>
        /// Update permission, role
        /// </summary>
        /// <param name="_userAdmin"></param>
        /// <param name="_username"></param>
        /// <param name="permits"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool updatePermission(string _userAdmin, string _username, string permits, string role)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var user = DB.tblUsers.Single(u => u.Username == _username);

                    user.Permission = permits;
                    user.Role = role;

                    DB.SubmitChanges();
                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, _userAdmin,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_SUCCESSFUL_TEMPLATE,
                                                                    _username,
                                                                    CommonConstants.SQL_TABLE_USER));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _userAdmin,
                                  BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_FAILED_TEMPLATE,
                                                                    _username,
                                                                    CommonConstants.SQL_TABLE_USER));

                log.writeLog(DBHelper.strPathLogFile, _userAdmin, e.Message);

                return false;
            }

            return true;
        }

        #endregion


        
    }
}
