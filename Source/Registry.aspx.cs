using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using DAO;


public partial class Registry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegistry_Click(object sender, EventArgs e)
    {
        string strUsername = txtboxLoginName.Text;

        Boolean isExistedUsername = DAO.UsersDAO.existedUser(strUsername);

        if (isExistedUsername)
        {
            liMessage.Text = "Tên đăng nhập đã được sử dụng.";
            liMessage.Visible = true;
        }
        else
        {
            string strDisplayName = txtboxDisplayName.Text;
            Boolean isFemale = Boolean.Parse(ddlSex.SelectedValue);
            string strPassword = txtboxPassword.Text;
            string strEmail = txtboxEmail.Text;

            string user = DAO.UsersDAO.existedEmail(strEmail);
            if (user != null)
            {
                liMessage.Text = "Email của bạn đã được đăng ký. ";
                liMessage.Text += "Nếu bạn đã đăng ký mà không nhớ mật khẩu.";
                liMessage.Text += "Lấy lại mật khẩu <a href=\"ResetPassword.aspx\">tại đây</a>";
                liMessage.Visible = true;
            }
            else
            { // Mọi điều kiện đã hợp lệ, bắt đầu đăng ký
                Boolean success = DAO.UsersDAO.register(strUsername, strDisplayName, strEmail, isFemale, strPassword);

                if (success)
                {
                    liMessage.Text = "Bạn đã đăng ký thành công. ";
                    liMessage.Text += "Xin vui lòng kiểm tra email để kích hoạt tài khoản!";
                    liMessage.Text += "\n\n <a href=\"Home.aspx\">Quay về trang chủ</a>";
                    liMessage.Visible = true;
                    registerPanel.Visible = false;
                }
                else
                {
                    liMessage.Text = "Quá trình đăng ký không thành công. ";
                    liMessage.Text += "Xin vui lòng thử lại!";
                    liMessage.Visible = true;
                }
            }
        }
                
    }
}
