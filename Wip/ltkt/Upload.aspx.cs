using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;
using ltktDAO;
using System.IO;


namespace ltkt
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string selIndex = Request["selIndex"];
                int selectedIndex;

                if (selIndex == null)
                {
                    selectedIndex = 0;
                }
                else
                {
                    selectedIndex = Int32.Parse(selIndex);

                    if (selectedIndex == 0)
                    {
                        //ddlType.Visible = false;
                        //lessonType.Visible = false;
                    }
                    else
                    {
                        //ddlType.Visible = true;
                        //lessonType.Visible = true;
                    }
                    Response.End();
                }
            }
        }

        public void btnSubmitUpload_Click(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session["User"];
            if (user != null)
            {
                if (fileContent.HasFile)
                {
                    string folder = "Data";
                    // 0 - ltdh
                    // 1 - english
                    // 2 - tin học
                    int type = ddlSubject.SelectedIndex;
                    switch (type)
                    {
                        case 0:
                            {
                                folder += "\\University\\";
                                folder += Convert.ToString(ddlYear.SelectedValue);
                                break;
                            }
                        case 1:
                            {
                                folder += "\\Informatics\\";
                                folder += Convert.ToString(DateTime.Now.Year);
                                break;
                            }
                        case 2:
                            {
                                folder += "\\English\\";
                                folder += Convert.ToString(DateTime.Now.Year);
                                break;
                            }
                    }

                    string filename = Server.MapPath("~") + "\\" + folder + "\\" + fileContent.FileName;
                    fileContent.SaveAs(filename);

                    if (fileSolving.HasFile)
                    {
                        fileSolving.SaveAs(Server.MapPath("~") + "\\" + folder + "\\" +
                            Path.GetFileNameWithoutExtension(fileContent.FileName) +
                            "_solved" + Path.GetExtension(fileSolving.FileName));
                    }
                    // ghi xuống db

                    switch (type)
                    {
                        case 0:
                            {
                                ltktDAO.Contest.insertContest(txtboxTitle.Text,
                                    txtboxSummary.Text,
                                    user.Username,
                                    DateTime.Now,
                                    Boolean.Parse(ddlTypeContest.SelectedValue),
                                    Convert.ToInt32(ddlBranch.SelectedValue),
                                    Convert.ToInt32(ddlYear.SelectedValue),
                                    filename,
                                    txtboxTag.Text);
                                break;
                            }
                        case 1:
                            {
                                ltktDAO.Informatics.insertInformatic(txtboxTitle.Text,
                                    Convert.ToInt32(ddlType.SelectedValue),
                                    txtboxSummary.Text,
                                    user.Username,
                                    DateTime.Now,
                                    filename,
                                    txtboxTag.Text);
                                break;
                            }
                        case 2:
                            {
                                ltktDAO.English.insertEnglish(txtboxTitle.Text,
                                    Convert.ToInt32(ddlType.SelectedValue),
                                    txtboxSummary.Text,
                                    user.Username,
                                    DateTime.Now,
                                    filename,
                                    txtboxTag.Text);
                                break;
                            }
                    }

                    upload.Visible = false;
                    message.Visible = true;
                    liMessage.Text = "Upload thành công.";
                    liMessage.Text += "<br /><br />Cám ơn bạn đã đóng góp cho trung tâm!";
                    liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a><br />";
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }


    }
}