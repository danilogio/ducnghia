using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;
namespace ltkt
{
    public partial class ContestUniversity : System.Web.UI.Page
    {
        Contest contestDAO = new Contest();
        EventLog log = new EventLog();
        public void Page_Load(object sender, EventArgs e)
        {
            ArticleSCO articleSCO = new ArticleSCO();
            try
            {
                articleSCO.Subject = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_SUBJECT]);
                articleSCO.Time = BaseServices.nullToBlank(Request.QueryString[CommonConstants.REQ_TIME]);

                Session[CommonConstants.SES_ARTICLE_SCO] = articleSCO;
                lblTitle.Text = CommonConstants.SEC_UNIVESITY;

                if (!IsPostBack)
                {
                    if (!BaseServices.isNullOrBlank(articleSCO.Subject) && !BaseServices.isNullOrBlank(articleSCO.Time))
                    {
                        lblTitle.Text += CommonConstants.SPACE;
                        lblTitle.Text += CommonConstants.BAR;
                        lblTitle.Text += CommonConstants.SPACE;
                        lblTitle.Text += BaseServices.getNameByCode(articleSCO.Subject);
                        IEnumerable<tblContestForUniversity> lst = contestDAO.getArticleBySubjectAndTime(articleSCO);
                        productList.DataSource = lst;
                        productList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                Session[CommonConstants.CONST_SES_ERROR] = CommonConstants.COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }

        protected void DataPagerArticles_PreRender(object sender, EventArgs e)
        {
            ArticleSCO articleSCO = new ArticleSCO();
            articleSCO = (ArticleSCO)Session[CommonConstants.SES_ARTICLE_SCO];
            lblTitle.Text = CommonConstants.SEC_UNIVESITY;
            if (articleSCO != null)
            {
                try
                {
                    if (!BaseServices.isNullOrBlank(articleSCO.Subject) && !BaseServices.isNullOrBlank(articleSCO.Time))
                    {
                        lblTitle.Text += CommonConstants.SPACE;
                        lblTitle.Text += CommonConstants.BAR;
                        lblTitle.Text += CommonConstants.SPACE;
                        lblTitle.Text += BaseServices.getNameByCode(articleSCO.Subject);
                        IEnumerable<tblContestForUniversity> lst = contestDAO.getArticleBySubjectAndTime(articleSCO);
                        productList.DataSource = lst;
                        productList.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                    string username = CommonConstants.USER_GUEST;
                    if (user != null)
                    {
                        username = user.Username;
                    }

                    log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                    Session[CommonConstants.CONST_SES_ERROR] = CommonConstants.COMMON_ERROR_TEXT;
                    Response.Redirect(CommonConstants.PAGE_ERROR);
                }
            }
        }
    }
}