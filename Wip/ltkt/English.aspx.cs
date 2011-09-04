using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ltktDAO;

namespace ltkt
{
    public partial class English : System.Web.UI.Page
    {
        ltktDAO.Control control = new ltktDAO.Control();

        protected void Page_Load(object sender, EventArgs e)
        {
            liTitleHeader.Text = CommonConstants.PAGE_ENGLISH_NAME
                           + CommonConstants.SPACE + CommonConstants.HLINE
                           + CommonConstants.SPACE
                           + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

            if (Request.QueryString["section"] != null)
            {
                string section = "";
                section = Request.QueryString["section"];

                switch (section)
                {
                    case "lecture":
                        {
                            liTitle.Text = "Anh văn - Bài giảng";
                            break;
                        }
                    case "exercise":
                        {
                            liTitle.Text = "Anh văn - Bài tập";
                            break;
                        }
                    case "subject":
                        {
                            liTitle.Text = "Anh văn - Đề thi";
                            break;
                        }
                    default:
                        {
                            Session["Error"] = "Đường dẫn trang web không hợp lệ, xin vui lòng kiểm tra lại!";
                            Response.Redirect("Error.aspx");
                            break;
                        }
                }
            }
            else
            {
                Response.Redirect("English.aspx?section=lecture");
            }
        }
    }
}