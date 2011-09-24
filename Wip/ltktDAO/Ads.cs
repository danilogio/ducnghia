﻿using System;
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

        //public string getImage(int _id)
        //{

        //}
        #endregion
        #endregion

        #region Method
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
                                string _description)
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
                    record.Location = CommonConstants.BLANK;
                    record.Description = _description;
                    record.Code = CommonConstants.ADS_INACTIVE;
                    record.ClickCount = 0;

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
                log.writeLog(DBHelper.strPathLogFile, e.Message);

                return false;
            }

            return true;
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
                                                 orderby record.toDate, record.State descending
                                                 select record).Skip(start).Take(count);

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
                log.writeLog(DBHelper.strPathLogFile, _username, e.Message);

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
                              int _state)
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
                    ads.Location = fileSave;
                    ads.Description = _description;
                    ads.State = _state;
                    //ads.Code = 

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
                log.writeLog(DBHelper.strPathLogFile, _username, e.Message);

                return false;
            }
            return true;
        }

        #endregion

        
    }
}
