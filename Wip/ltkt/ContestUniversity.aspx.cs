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
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IEnumerable<tblContestForUniversity> lst = ltktDAO.Contest.getAll();
                productList.DataSource = lst;
                productList.DataBind();
            }
        }

        protected void DataPagerArticles_PreRender(object sender, EventArgs e)
        {
            IEnumerable<tblContestForUniversity> lst = ltktDAO.Contest.getAll();
            productList.DataSource = lst;
            productList.DataBind();
        }
    }
}