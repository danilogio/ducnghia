using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ltktDAO
{
    public class Ads
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        EventLog log = new EventLog();
        LTDHDataContext DB = new LTDHDataContext(@strPathDB);

        #region Property
        #region Get Property

        /// <summary>
        /// Lấy trạng thái của một quảng cáo qua id
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public string getState(int _id)
        {
            var ads = DB.tblAdvertisements.Single(a => a.ID == _id);
            string strState = null;

            if (ads != null)
            {
                switch (ads.State)
                {
                    case CommonConstants.STATE_UNCHECK:
                        {
                            strState = CommonConstants.STATE_UNCHECK_NAME;
                            break;
                        }
                    case CommonConstants.STATE_CHECKED:
                        {
                            strState = CommonConstants.STATE_CHECKED_NAME;
                            break;
                        }
                    case CommonConstants.STATE_PENDING:
                        {
                            strState = CommonConstants.STATE_PENDING_NAME;
                            break;
                        }
                    case CommonConstants.STATE_STICKY:
                        {
                            strState = CommonConstants.STATE_STICKY_NAME;
                            break;
                        }
                    default:
                        break;
                }
            }

            return strState;
        }

        /// <summary>
        /// Chuyển trạng thái của một quảng cáo qua dạng chuỗi
        /// </summary>
        /// <param name="_state"></param>
        /// <returns></returns>
        public string convertStateToString(int _state)
        {
            string strState = null;

            switch (_state)
            {
                case CommonConstants.STATE_UNCHECK:
                    {
                        strState = CommonConstants.STATE_UNCHECK_NAME;
                        break;
                    }
                case CommonConstants.STATE_CHECKED:
                    {
                        strState = CommonConstants.STATE_CHECKED_NAME;
                        break;
                    }
                case CommonConstants.STATE_PENDING:
                    {
                        strState = CommonConstants.STATE_PENDING_NAME;
                        break;
                    }
                case CommonConstants.STATE_STICKY:
                    {
                        strState = CommonConstants.STATE_STICKY_NAME;
                        break;
                    }
                case CommonConstants.STATE_BLOCK:
                    {
                        strState = CommonConstants.STATE_BLOCK_NAME;
                        break;
                    }
                default:
                    break;
            }

            return strState;
        }

        /// <summary>
        /// Lấy ra một quảng cáo
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public tblAdvertisement getAds(int _id)
        {
            IEnumerable<tblAdvertisement> lst = from record in DB.tblAdvertisements
                                                where record.ID == _id
                                                select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0);
            }

            return null;
        }
        public tblAdvertisement getAds(string _code)
        {
            IEnumerable<tblAdvertisement> lst = from record in DB.tblAdvertisements
                                                where record.Code == _code
                                                select record;

            if (lst.Count() > 0)
            {
                return lst.ElementAt(0);
            }

            return null;
        }
        /// <summary>
        /// check quảng cáo tồn tại
        /// </summary>
        /// <param name="_code"></param>
        /// <returns></returns>
        public bool isExisted(string _code)
        {
            IEnumerable<tblAdvertisement> lst = from p in DB.tblAdvertisements
                                                where p.Code.Trim() == _code
                                                select p;
            if (lst.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool isExisted(int _id)
        {
            
            IEnumerable<tblAdvertisement> lst = from p in DB.tblAdvertisements
                                                where p.ID == _id
                                                select p;
            if (lst.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public bool isState(int _id, int _state)
        {
            IEnumerable<tblAdvertisement> lst = from p in DB.tblAdvertisements
                                                where p.ID == _id
                                                select p;
            if (lst.Count() > 0)
            {
                if (lst.ElementAt(0).State == _state)
                {
                    return true;
                }
            }
            return false;
        }
        public string getImageUrl(string _code)
        {
            IEnumerable<tblAdvertisement> lst = from p in DB.tblAdvertisements
                                                where p.Code == _code
                                                select p;
            if (lst.Count() > 0)
            {
                return "~/" + lst.ElementAt(0).FilePath.Trim();
            }
            
            return CommonConstants.BLANK;
        }
        
        #endregion
        #endregion

        #region Method
        public void addClickCount(string _code)
        {
            try
            {
                var r = DB.tblAdvertisements.Single(p => p.Code == _code);

                using (TransactionScope ts = new TransactionScope())
                {

                    if (r != null)
                    {
                        r.ClickCount += 1;
                        DB.SubmitChanges();
                        ts.Complete();
                    }
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
            }
        }
        /// <summary>
        /// Thêm một quảng cáo
        /// </summary>
        /// <param name="_companyName"></param>
        /// <param name="_address"></param>
        /// <param name="_email"></param>
        /// <param name="_phone"></param>
        /// <param name="_from"></param>
        /// <param name="_end"></param>
        /// <param name="_description"></param>
        /// <returns></returns>
        public bool insertAds(string _companyName,
                                string _address,
                                string _email,
                                string _phone,
                                DateTime _from,
                                DateTime _end,
                                string _location)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    tblAdvertisement record = new tblAdvertisement();
                    record.Company = _companyName;
                    record.Address = _address;
                    record.Email = _email;
                    record.Phone = _phone;
                    record.fromDate = _from;
                    record.toDate = _end;
                    record.Price = 0;
                    record.FilePath = CommonConstants.BLANK;
                    record.Location = _location;
                    record.Code = CommonConstants.ADS_INACTIVE;
                    record.ClickCount = 0;
                    record.NavigateUrl = CommonConstants.BLANK;
                    record.FilePath = CommonConstants.BLANK;
                    record.Description = CommonConstants.BLANK;
                    record.Size = CommonConstants.DEFAULT_ADS_IMG_SIZE;
                    record.State = CommonConstants.STATE_UNCHECK;

                    DB.tblAdvertisements.InsertOnSubmit(record);
                    DB.SubmitChanges();

                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile,
                                BaseServices.createMsgByTemplate (CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE,
                                                                    record.ID.ToString(),
                                                                    CommonConstants.SQL_TABLE_ADVERTISEMENT));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
                return false;
            }

            return true;
        }
        public int cloneAds(string _companyName,
                                string _address,
                                string _email,
                                string _phone,
                                DateTime _from,
                                DateTime _end,
                                string _location,
                                string _navigateUrl,
                                string _description)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            int id = -1;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    tblAdvertisement record = new tblAdvertisement();
                    record.Company = _companyName;
                    record.Address = _address;
                    record.Email = _email;
                    record.Phone = _phone;
                    record.fromDate = _from;
                    record.toDate = _end;
                    record.Price = 0;
                    record.FilePath = CommonConstants.BLANK;
                    record.Location = _location;
                    record.Code = CommonConstants.ADS_INACTIVE;
                    record.ClickCount = 0;
                    record.NavigateUrl = _navigateUrl;
                    record.FilePath = CommonConstants.BLANK;
                    record.Description = _description;
                    record.Size = CommonConstants.DEFAULT_ADS_IMG_SIZE;
                    record.State = CommonConstants.STATE_UNCHECK;

                    DB.tblAdvertisements.InsertOnSubmit(record);
                    DB.SubmitChanges();

                    ts.Complete();

                    id = record.ID;

                    log.writeLog(DBHelper.strPathLogFile,
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_INSERT_SUCCESSFUL_TEMPLATE,
                                                                    record.ID.ToString(),
                                                                    CommonConstants.SQL_TABLE_ADVERTISEMENT));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
                return -1;
            }

            return id;
        }
        public void resetState(string _code)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {

                    var ads = DB.tblAdvertisements.Single(a => a.Code == _code);
                    ads.Code = CommonConstants.ADS_INACTIVE;
                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
            }
        }
        /// <summary>
        /// Tổng số quảng cáo
        /// </summary>
        /// <returns></returns>
        public int countAds()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            return (from record in DB.tblAdvertisements select record).Count();
        }

        /// <summary>
        /// Lấy ra ds count quảng cáo, từ id = start
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<tblAdvertisement> fetchAdsList(int start, int count)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            IEnumerable<tblAdvertisement> lst = (from record in DB.tblAdvertisements
                                                 orderby record.toDate descending
                                                 select record).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblAdvertisement> fetchAdsList(int state, int start, int count)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            IEnumerable<tblAdvertisement> lst = (from record in DB.tblAdvertisements
                                                 where record.State == state
                                                 orderby record.toDate descending
                                                 select record).Skip(start).Take(count);

            return lst;
        }
        public IEnumerable<tblAdvertisement> fetchAdsListByLocation(int start, int count)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            IEnumerable<tblAdvertisement> lst = (from record in DB.tblAdvertisements
                                                 where record.Code.Trim() != CommonConstants.ADS_INACTIVE
                                                 orderby record.toDate descending
                                                 select record).Skip(start).Take(count);

            return lst;
        }
        public int countAdsListByState(int state)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            int num = (from record in DB.tblAdvertisements
                       where record.State == state
                       select record).Count();

            return num;
        }
         public int countAdsListByLocation()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            int num = (from record in DB.tblAdvertisements
                       where record.Code.Trim() != CommonConstants.ADS_INACTIVE
                       select record).Count();

            return num;
        }
        public string getNameOfLocation(string _code)
        {
           
            switch (_code)
            {
                case CommonConstants.ADS_TOP_BANNER:
                    {
                        return CommonConstants.ADS_TOP_BANNER_NAME;
                    }
                case CommonConstants.ADS_TOP_LEADER_BANNER:
                    {
                        return CommonConstants.ADS_TOP_LEADER_BANNER_NAME;
                    }
                case CommonConstants.ADS_TOP_RIGHT_BANNER:
                    {
                        return CommonConstants.ADS_TOP_RIGHT_BANNER_NAME;
                    }
                case CommonConstants.ADS_MIDDLE_RIGHT_BANNER:
                    {
                        return CommonConstants.ADS_MIDDLE_RIGHT_BANNER_NAME;
                    }
                case CommonConstants.ADS_BOTTOM_RIGHT_BANNER:
                    {
                        return CommonConstants.ADS_BOTTOM_RIGHT_BANNER_NAME;
                    }
                case CommonConstants.ADS_TOP_LEFT_BANNER:
                    {
                        return CommonConstants.ADS_TOP_LEFT_BANNER_NAME;
                    }
                case CommonConstants.ADS_MIDDLE_LEFT_BANNER:
                    {
                        return CommonConstants.ADS_MIDDLE_LEFT_BANNER_NAME;
                    }
                case CommonConstants.ADS_BOTTOM_LEFT_BANNER:
                    {
                        return CommonConstants.ADS_BOTTOM_LEFT_BANNER_NAME;
                    }
                case CommonConstants.ADS_BOTTOM_1_BANNER:
                    {
                        return CommonConstants.ADS_BOTTOM_1_BANNER_NAME;
                    }
                case CommonConstants.ADS_BOTTOM_2_BANNER:
                    {
                        return CommonConstants.ADS_BOTTOM_2_BANNER_NAME;
                    }
                case CommonConstants.CONST_ONE_NEGATIVE:
                    {
                        return CommonConstants.TXT_PLEASE_SELECT;
                    }
            }
            return CommonConstants.BLANK;
        }

        public ArrayList getFreeLocationList()
        {
            ArrayList lst = new ArrayList();
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (!isExisted(CommonConstants.ADS_TOP_BANNER))
            {
                lst.Add(CommonConstants.ADS_TOP_BANNER);
            }
            if (!isExisted(CommonConstants.ADS_TOP_LEADER_BANNER))
            {
                lst.Add(CommonConstants.ADS_TOP_LEADER_BANNER);
            }
            if (!isExisted(CommonConstants.ADS_TOP_RIGHT_BANNER))
            {
                lst.Add(CommonConstants.ADS_TOP_RIGHT_BANNER);
            }
            if (!isExisted(CommonConstants.ADS_MIDDLE_RIGHT_BANNER))
            {
                lst.Add(CommonConstants.ADS_MIDDLE_RIGHT_BANNER);
            }
            if (!isExisted(CommonConstants.ADS_BOTTOM_RIGHT_BANNER))
            {
                lst.Add(CommonConstants.ADS_BOTTOM_RIGHT_BANNER);
            }
            if (!isExisted(CommonConstants.ADS_TOP_LEADER_BANNER))
            {
                lst.Add(CommonConstants.ADS_TOP_LEADER_BANNER);
            }
            if (!isExisted(CommonConstants.ADS_MIDDLE_LEFT_BANNER))
            {
                lst.Add(CommonConstants.ADS_MIDDLE_LEFT_BANNER);
            }
            if (!isExisted(CommonConstants.ADS_BOTTOM_LEFT_BANNER))
            {
                lst.Add(CommonConstants.ADS_BOTTOM_LEFT_BANNER);
            }
            if (!isExisted(CommonConstants.ADS_BOTTOM_1_BANNER))
            {
                lst.Add(CommonConstants.ADS_BOTTOM_1_BANNER);
            }
            if (!isExisted(CommonConstants.ADS_BOTTOM_2_BANNER))
            {
                lst.Add(CommonConstants.ADS_BOTTOM_2_BANNER);
            }
            return lst;
        }
        public ArrayList getUnfreeLocationList()
        {
            ArrayList lst = new ArrayList();
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            if (isExisted(CommonConstants.ADS_TOP_BANNER))
            {
                lst.Add(CommonConstants.ADS_TOP_BANNER);
            }
            if (isExisted(CommonConstants.ADS_TOP_LEADER_BANNER))
            {
                lst.Add(CommonConstants.ADS_TOP_LEADER_BANNER);
            }
            if (isExisted(CommonConstants.ADS_TOP_RIGHT_BANNER))
            {
                lst.Add(CommonConstants.ADS_TOP_RIGHT_BANNER);
            }
            if (isExisted(CommonConstants.ADS_MIDDLE_RIGHT_BANNER))
            {
                lst.Add(CommonConstants.ADS_MIDDLE_RIGHT_BANNER);
            }
            if (isExisted(CommonConstants.ADS_BOTTOM_RIGHT_BANNER))
            {
                lst.Add(CommonConstants.ADS_BOTTOM_RIGHT_BANNER);
            }
            if (isExisted(CommonConstants.ADS_TOP_LEADER_BANNER))
            {
                lst.Add(CommonConstants.ADS_TOP_LEADER_BANNER);
            }
            if (isExisted(CommonConstants.ADS_MIDDLE_LEFT_BANNER))
            {
                lst.Add(CommonConstants.ADS_MIDDLE_LEFT_BANNER);
            }
            if (isExisted(CommonConstants.ADS_BOTTOM_LEFT_BANNER))
            {
                lst.Add(CommonConstants.ADS_BOTTOM_LEFT_BANNER);
            }
            if (isExisted(CommonConstants.ADS_BOTTOM_1_BANNER))
            {
                lst.Add(CommonConstants.ADS_BOTTOM_1_BANNER);
            }
            if (isExisted(CommonConstants.ADS_BOTTOM_2_BANNER))
            {
                lst.Add(CommonConstants.ADS_BOTTOM_2_BANNER);
            }
            return lst;
        }
        /// <summary>
        /// Xóa 1 record quảng cáo
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_username"></param>
        /// <returns></returns>
        public bool deleteAds(int _id, string _username)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var ads = DB.tblAdvertisements.Single(a => a.ID == _id);

                    DB.tblAdvertisements.DeleteOnSubmit(ads);
                    DB.SubmitChanges();

                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, _username,
                                BaseServices.createMsgByTemplate (CommonConstants.SQL_DELETE_SUCCESSFUL_TEMPLATE,
                                                                    _id.ToString(),
                                                                    CommonConstants.SQL_TABLE_ADVERTISEMENT));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _username,
                                BaseServices.createMsgByTemplate(CommonConstants.SQL_DELETE_FAILED_TEMPLATE,
                                                                    _id.ToString(),
                                                                    CommonConstants.SQL_TABLE_ADVERTISEMENT));
                log.writeLog(DBHelper.strPathLogFile, _username, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Update Ads
        /// </summary>
        /// <param name="adsID"></param>
        /// <param name="_company"></param>
        /// <param name="_address"></param>
        /// <param name="_email"></param>
        /// <param name="_phone"></param>
        /// <param name="_fromDate"></param>
        /// <param name="_toDate"></param>
        /// <param name="_price"></param>
        /// <param name="fileSave"></param>
        /// <param name="_description"></param>
        /// <param name="_state"></param>
        public bool updateAds(int adsID, string _username,
                              string _company,
                              string _address,
                              string _email,
                              string _phone,
                              DateTime _fromDate,
                              DateTime _toDate,
                              int _price,
                              string fileSave,
                              string _description,
                              string _navigation,
                              string _location,
                              string _size,
                              int _state,
                              string _code)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var ads = DB.tblAdvertisements.Single(a => a.ID == adsID);

                    ads.Company = _company;
                    ads.Address = _address;
                    ads.Email = _email;
                    ads.Phone = _phone;
                    ads.fromDate = _fromDate;
                    ads.toDate = _toDate;
                    ads.Price = _price;
                    ads.FilePath = fileSave;
                    ads.Description = _description;
                    ads.NavigateUrl = _navigation;
                    ads.Size = _size;
                    ads.State = _state;
                    ads.Location = _location;

                    if (!isExisted(_code) || _state == CommonConstants.STATE_BLOCK)
                    {
                        ads.Code = _code;
                    }

                    DB.SubmitChanges();
                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, _username,
                                 BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_SUCCESSFUL_TEMPLATE, Convert.ToString (adsID), CommonConstants.SQL_TABLE_ADVERTISEMENT));
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _username,
                                 BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_FAILED_TEMPLATE, Convert.ToString(adsID), CommonConstants.SQL_TABLE_ADVERTISEMENT));
                log.writeLog(DBHelper.strPathLogFile, _username, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
                return false;
            }
            return true;
        }

        public bool checkAds(string _username)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    IEnumerable<tblAdvertisement> lst = from record in DB.tblAdvertisements select record;
                    foreach (tblAdvertisement record in lst)
                    {
                        if (record.State == CommonConstants.STATE_ACTIVE)
                        {
                            if ((DateTime)record.toDate < DateTime.Now)
                            {
                                record.State = CommonConstants.STATE_BLOCK;
                                record.Code = CommonConstants.ADS_INACTIVE;
                            }
                            else if ((DateTime)record.toDate >= DateTime.Now
                                        && (DateTime)record.toDate <= DateTime.Now.Subtract(TimeSpan.FromDays(7)))
                            {
                                record.State = CommonConstants.STATE_PENDING;
                            }
                        }
                    }

                    DB.SubmitChanges();
                    ts.Complete();
                }

            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, _username, e.Message
                                                        + CommonConstants.NEWLINE
                                                        + e.Source
                                                        + CommonConstants.NEWLINE
                                                        + e.StackTrace
                                                        + CommonConstants.NEWLINE
                                                        + e.HelpLink);
                return false;
            }

            return true;
        }

        #endregion



        
    }
}
