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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitContact_Click(object sender, EventArgs e)
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
            DateTime _endDate = DateTime.Parse(txtToDate.Text);
            string _description = getLocation(sender, e);

            try
            {
                bool isOK = ltktDAO.Ads.insertAds(_companyName, _address, _email, _phone, _fromDate, _endDate, _description);

                if (isOK)
                {
                    contactPanel.Visible = false;
                    messagePanel.Visible = true;
                    liMessage.Text = "Quý vị đặt quảng cáo thành công!";
                    liMessage.Text += "<br />Chúng tôi sẽ liên lạc với quý vị để thêm chi tiết<br />";
                }
                else
                {
                    messagePanel.Visible = true;
                    liMessage.Text = "Đã có lỗi xảy ra, xin quý vị vui lòng thử lại!<br />";
                }
            }
            catch (Exception ex)
            {
                string username = CommonConstants.USER_GUEST;

                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                Session[CommonConstants.CONST_SES_ERROR] = CommonConstants.COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }

        private string getLocation(object sender, EventArgs e)
        {
            string sLocation = "[Loc]";
            for (int idx = 0; idx < chxLocation.Items.Count; ++idx)
            {
                if (chxLocation.Items[idx].Selected)
                {
                    if (sLocation != "[Loc]")
                    {
                        sLocation += ",";
                    }
                    sLocation += chxLocation.Items[idx].Text;
                }
            }
            sLocation += "[Loc]";

            return sLocation;
        }
        
    }
}