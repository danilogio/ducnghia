using System;
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
        static EventLog log = new EventLog();

        #region Property
        #region Get Property
        #endregion

        #region Set Property
        #endregion
        #endregion

        #region Method
        public static bool insertAds(string _companyName,
                                        string _address,
                                        string _email,
                                        string _phone,
                                        DateTime _from,
                                        DateTime _end,
                                        string _location,
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
                    record.Location = _location;
                    record.Description = _description;

                    DB.tblAdvertisements.InsertOnSubmit(record);
                    DB.SubmitChanges();

                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, "insert ads id=" + record.ID + " successfully");
                }
            }
            catch (Exception e)
            {
                log.writeLog(DBHelper.strPathLogFile, e.Message);

                return false;
            }
            
            return true;
        }
        #endregion
    }
}
