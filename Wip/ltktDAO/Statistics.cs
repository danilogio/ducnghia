using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ltktDAO
{
    public class Statistics
    {
        // Lấy đường dẫn cơ sở dữ liệu
        static string strPathDB = DBHelper.strPathDB;
        EventLog log = new EventLog();
        /// <summary>
        /// Tống tất cả các bài viết (ltđh, anh văn, tin học)
        /// </summary>
        /// <returns></returns>
        public int sumArticle()
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);

            int sumContest = (from contest in DB.tblContestForUniversities
                              select contest).Count();
            int sumEnglish = (from english in DB.tblEnglishes
                              select english).Count();
            int sumInformatics = (from informatics in DB.tblInformatics
                                  select informatics).Count();

            return (sumContest + sumEnglish + sumInformatics);
        }

        public tblStatistic getRecord(string Code)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            var p = DB.tblStatistics.Single(r => r.Code == Code.Trim());
            return p;
        }

        public string getValue(string _code)
        {
            tblStatistic statistic = getRecord(_code);
            return statistic.Value;
        }
        
        /// <summary>
        /// add number
        /// </summary>
        /// <param name="_code"></param>
        /// <param name="_newVal"></param>
        public void add(string _code, string _newVal)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var r = DB.tblStatistics.Single(p => p.Code == _code);
                    long oldVal = long.Parse(r.Value);
                    long newVal = long.Parse(_newVal);
                    oldVal += newVal;
                    r.Value = oldVal.ToString();
                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile,ex.Message);
            }
        }
        public void addLatestLoginUser(string username)
        {
            LTDHDataContext DB = new LTDHDataContext(@strPathDB);
            try
            {
                username = BaseServices.nullToBlank(username);
                using (TransactionScope ts = new TransactionScope())
                {
                    var r = DB.tblStatistics.Single(p => p.Code == CommonConstants.SF_LATEST_LOGIN);
                    if (!BaseServices.isNullOrBlank(r.Value))
                    {
                        string[] arrayUser = r.Value.Split(CommonConstants.COMMA_CHAR);
                        if (arrayUser[0].Contains(username))
                            return;
                        if (arrayUser.Length >= 10)
                        {
                            r.Value = CommonConstants.BLANK;
                            for (int i = 0; i < arrayUser.Length - 1; i++)
                            {
                                r.Value += arrayUser[i];
                                r.Value += CommonConstants.COMMA;
                            }
                            r.Value = r.Value.Substring(0, r.Value.Length - 1);
                        }
                        if (!r.Value.StartsWith(CommonConstants.COMMA))
                        {
                            username += CommonConstants.COMMA;
                        }
                        username += r.Value.Trim();
                        r.Value = username;
                    }
                    else
                    {
                        r.Value = username;
                    }
                    
                    DB.SubmitChanges();
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                log.writeLog(DBHelper.strPathLogFile, ex.Message);
            }
        }
    }
}
