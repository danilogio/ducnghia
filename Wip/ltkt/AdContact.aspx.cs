using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ltktDAO;

namespace ltkt
{
    public partial class AdContact : System.Web.UI.Page
    {
        EventLog log = new EventLog();
        ltktDAO.Ads adsDAO = new ltktDAO.Ads();
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.Admin adminDAO = new ltktDAO.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (adminDAO.isON(CommonConstants.AF_ADS))
                {
                    liTitle.Text = CommonConstants.PAGE_ADS_NAME
                                   + CommonConstants.SPACE + CommonConstants.HLINE
                                   + CommonConstants.SPACE
                                   + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);
                }
                else
                {
                    string reason = adminDAO.getReason(CommonConstants.AF_ADS);
                    if (!BaseServices.isNullOrBlank(reason))
                    {
                        Session[CommonConstants.SES_ERROR] = reason;
                    }
                    Response.Redirect(CommonConstants.PAGE_ERROR);
                }
            }
            catch (Exception ex)
            {
                string username = CommonConstants.USER_GUEST;

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message + CommonConstants.NEWLINE + ex.StackTrace);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }

        protected void btnSubmitContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (!recaptcha.IsValid)
                {
                    return;
                }

                string _companyName = txtboxCompanyName.Text;
                string _address = txtAddress.Text;
                string _email = txtboxContactEmail.Text;
                string _phone = txtboxFone.Text;
                
                DateTime _fromDate = DateTime.Parse(txtFromDate.Text);
                bool isOK = false;
                int o= _fromDate.CompareTo(DateTime.Today);
                if (_fromDate.CompareTo(DateTime.Today) == -1)
                {
                    messagePanel.Visible = true;
                    liMessage.Text = CommonConstants.MSG_E_INVALID_FROM_DATE;
                    return;
                }
                DateTime _endDate = DateTime.Parse(txtToDate.Text);
                string _description = getLocation(sender, e);

                if (_description == CommonConstants.BLANK)
                {
                    liMessage.Visible = true;
                    liMessage.Text = BaseServices.createMsgByTemplate(CommonConstants.MSG_E_SELECT_ONE_ITEM,
                                                                        CommonConstants.TXT_LOCATION);
                    return;
                }
                
                isOK = adsDAO.insertAds(_companyName, _address, _email, _phone, _fromDate, _endDate, _description);
                if (isOK)
                {
                    contactPanel.Visible = false;
                    messagePanel.Visible = true;
                    ltktDAO.Statistics statDAO = new ltktDAO.Statistics();
                    statDAO.add(CommonConstants.SF_NUM_NEW_ADV_CONTACT, "1" );
                    liMessage.Text = CommonConstants.MSG_I_ADVERTISEMENT_CONTACT_IS_SENT_SUCCESSFUL;
                }
                else
                {
                    messagePanel.Visible = true;
                    liMessage.Text = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                }
            }
            catch (Exception ex)
            {
                string username = CommonConstants.USER_GUEST;

                log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), username, ex.Message + CommonConstants.NEWLINE + ex.StackTrace);

                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }

        private string getLocation(object sender, EventArgs e)
        {
            string sLocation = "[Loc]";
            int size = chxLocation.Items.Count;
            for (int idx = 0; idx < size; ++idx)
            {
                if (chxLocation.Items[idx].Selected)
                {
                    if (sLocation != "[Loc]")
                    {
                        sLocation += CommonConstants.COMMA;
                    }
                    sLocation += chxLocation.Items[idx].Value;
                }
            }
            if (sLocation.EndsWith(CommonConstants.COMMA))
            {
                sLocation = sLocation.Substring(0, sLocation.Length - 1);
            }
            sLocation += "[Loc]";
            if (sLocation == "[Loc][Loc]")
            {
                return CommonConstants.BLANK;
            }
            return sLocation;
        }
        
    }
}