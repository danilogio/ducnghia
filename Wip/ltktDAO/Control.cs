using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ltktDAO
{
    public class Control
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        LTDHDataContext DB = new LTDHDataContext(@strPathDB);
        EventLog log = new EventLog();

        /// <summary>
        /// Get all record
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tblControl> getAll()
        {
            IEnumerable<tblControl> items = from p in DB.tblControls
                                          select p;
            return items;
        }
        
        /// <summary>
        /// get record
        /// </summary>
        /// <param name="_code"></param>
        /// <returns>tblControl</returns>
        public tblControl getRecord(string _code)
        {
            var r = DB.tblControls.Single(p => p.Code == _code);
            return r;
        }
        
        /// <summary>
        /// get value by string type
        /// </summary>
        /// <param name="_code"></param>
        /// <returns>BLANK if not found</returns>
        public string getValueString(string _code)
        {
            tblControl r = getRecord(_code);
            if (r != null)
            {
                return BaseServices.nullToBlank(r.Value.Trim());
            }
            return CommonConstants.BLANK;
        }
        public void setValue(string _code, string _value)
        {
            try
            {
                if (_value.Length >= 500)
                {
                    _value = _value.Substring(0, 499);
                }
                using (TransactionScope ts = new TransactionScope())
                {
                    var r = DB.tblControls.Single(p => p.Code == _code);
                    r.Value = _value.Trim() ;
                    DB.SubmitChanges();
                    ts.Complete();
                    log.writeLog(DBHelper.strPathLogFile, BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_SUCCESSFUL_TEMPLATE, r.Code, CommonConstants.SQL_TABLE_CONTROL));
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, ex.Message);
            }
        }
        public string getNameString(string _code)
        {
            tblControl r = getRecord(_code);
            if (r != null)
            {
                return BaseServices.nullToBlank(r.Name.Trim());
            }
            return CommonConstants.BLANK;
        }
        /// <summary>
        /// get record by int
        /// </summary>
        /// <param name="_code"></param>
        /// <returns>0 if not found or not converte</returns>
        public int getValueByInt(string _code)
        {
            tblControl r = getRecord(_code);
            int num = 0;
            if (r != null)
            {
                if (Int32.TryParse(r.Value.Trim(), out num))
                {
                    return num;
                }
            }
            return 0;
        }

        /// <summary>
        /// update new value
        /// </summary>
        /// <param name="_code"></param>
        /// <param name="_newVal"></param>
        /// <param name="_username"></param>
        public void updateValue(string _code, string _newVal, string _username)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var r = DB.tblControls.Single(p => p.Code == _code);
                    r.Value = _newVal.Trim();
                    DB.SubmitChanges();
                    ts.Complete();

                    log.writeLog(DBHelper.strPathLogFile, _username, BaseServices.createMsgByTemplate(CommonConstants.SQL_UPDATE_SUCCESSFUL_TEMPLATE, r.Code, CommonConstants.SQL_TABLE_CONTROL));
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, ex.Message);
            }
        }


        public EmailConf getEmailConfig()
        {
            EmailConf emailConf = new EmailConf();
            string strEmailConf = getValueString(CommonConstants.CF_EMAIL_CONFIG);
            //host - port; username; password; smtpserver - port;
            char[] delimiterChars = { '-', ';',};

            string[] emailConfDetails = strEmailConf.Split(delimiterChars);

            if (emailConfDetails.Count() > 5)
            {
                emailConf.Host = emailConfDetails[0];
                emailConf.HostPort = emailConfDetails[1];
                emailConf.Username = emailConfDetails[2];
                emailConf.Password = emailConfDetails[3];
                emailConf.SmptServer = emailConfDetails[4];
                emailConf.SmptPort = emailConfDetails[5];
            }

            return emailConf;
        }
    }
}
