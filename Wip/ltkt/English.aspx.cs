using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ltkt
{
    public partial class English : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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