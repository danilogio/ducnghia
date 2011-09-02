﻿using System;
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
        EventLog log = new EventLog();
        ltktDAO.Informatics informaticsDAO = new ltktDAO.Informatics();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[CommonConstants.SES_USER] == null)
                {
                    Response.Redirect(CommonConstants.PAGE_LOGIN);
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
            catch (Exception ex)
            {
                tblUser user = (tblUser)Session[CommonConstants.SES_USER];
                string username = CommonConstants.USER_GUEST;
                if (user != null)
                {
                    username = user.Username;
                }

                log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), username, ex.Message);

                Session[CommonConstants.SES_ERROR] = CommonConstants.COMMON_ERROR_TEXT;
                Response.Redirect(CommonConstants.PAGE_ERROR);
            }
        }

        public void btnSubmitUpload_Click(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
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

                    string rootFolder = Server.MapPath("~") + "\\" + folder + "\\";
                    string filename = rootFolder + fileContent.FileName;
                    string fileSave = folder + "\\" + fileContent.FileName;
                    string fileSolvingSave = "";
                    // save file
                    if (!Directory.Exists(rootFolder))
                    {
                        Directory.CreateDirectory(rootFolder);
                    }

                    fileContent.SaveAs(filename);

                    if (fileSolving.HasFile)
                    {
                        fileSolving.SaveAs(Server.MapPath("~") + "\\" + folder + "\\" +
                            Path.GetFileNameWithoutExtension(fileContent.FileName) +
                            "_solved" + Path.GetExtension(fileSolving.FileName));

                        fileSolvingSave = folder + "\\" +
                            Path.GetFileNameWithoutExtension(fileContent.FileName) +
                            "_solved" + Path.GetExtension(fileSolving.FileName);
                    }
                    // ghi xuống db
                    try
                    {
                        switch (type)
                        {
                            case 0:
                                {
                                    if (fileSolvingSave != CommonConstants.BLANK)
                                    {
                                        ltktDAO.Contest.insertContest(txtboxTitle.Text,
                                                                        txtboxSummary.Text,
                                                                        user.Username,
                                                                        DateTime.Now,
                                                                        Boolean.Parse(ddlTypeContest.SelectedValue),
                                                                        Convert.ToInt32(ddlBranch.SelectedValue),
                                                                        Convert.ToInt32(ddlYear.SelectedValue),
                                                                        fileSave,
                                                                        txtboxTag.Text,
                                                                        true,
                                                                        fileSolvingSave);
                                    }
                                    else
                                    {
                                        ltktDAO.Contest.insertContest(txtboxTitle.Text,
                                                                           txtboxSummary.Text,
                                                                           user.Username,
                                                                           DateTime.Now,
                                                                           Boolean.Parse(ddlTypeContest.SelectedValue),
                                                                           Convert.ToInt32(ddlBranch.SelectedValue),
                                                                           Convert.ToInt32(ddlYear.SelectedValue),
                                                                           fileSave,
                                                                           txtboxTag.Text,
                                                                           false,
                                                                           null);
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    informaticsDAO.insertInformatic(txtboxTitle.Text,
                                        Convert.ToInt32(ddlType.SelectedValue),
                                        txtboxSummary.Text,
                                        user.Username,
                                        DateTime.Now,
                                        fileSave,
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
                                        fileSave,
                                        txtboxTag.Text);
                                    break;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.writeLog(Server.MapPath(CommonConstants.LOG_FILE_PATH), user.Username, ex.Message);

                        Session[CommonConstants.SES_ERROR] = CommonConstants.COMMON_ERROR_TEXT;
                        Response.Redirect(CommonConstants.PAGE_ERROR);
                    }

                    upload.Visible = false;
                    message.Visible = true;
                    liMessage.Text = CommonConstants.UPLOAD_SUCCESSFUL;
                    liMessage.Text += "<br /><br />Cám ơn bạn đã đóng góp cho trung tâm!";
                    liMessage.Text += "<br />Bài viết của bạn sẽ được kiểm duyệt trong vòng 24h";
                    liMessage.Text += "<br /><br /><a href=\"Home.aspx\">Quay về trang chủ</a><br />";
                }
            }
            else
            {
                Response.Redirect(CommonConstants.PAGE_LOGIN);
            }
        }


    }
}