using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ltktDAO;
using System.IO;
namespace ltkt.Admin
{
    public partial class ImportData : System.Web.UI.Page
    {
        private ltktDAO.Users userDAO = new ltktDAO.Users();
        ltktDAO.Control control = new ltktDAO.Control();
        ltktDAO.EventLog log = new ltktDAO.EventLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            bool isValid = false;
            if (user != null)
            {
                if (userDAO.isAllow(user.Permission, CommonConstants.P_A_FULL_CONTROL))
                {
                    ///DO WORK HERE ONLY//////////////////////////////
                    isValid = true;
                    AdminMaster page = (AdminMaster)Master;
                    page.updateHeader(CommonConstants.PAGE_ADMIN_IMPORT_NAME);

                    liTitle.Text = CommonConstants.PAGE_ADMIN_IMPORT_NAME
                                   + CommonConstants.SPACE + CommonConstants.HLINE
                                   + CommonConstants.SPACE
                                   + control.getValueString(CommonConstants.CF_TITLE_ON_HEADER);

                    //////////////////////////////////////////////////
                }
            }
            if(!isValid)
            {
                Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_ACCESS_DENIED;
                //Response.Redirect(CommonConstants.DOT + CommonConstants.PAGE_ADMIN_LOGIN);
                Response.Redirect(CommonConstants.PAGE_ADMIN_LOGIN);
            }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            tblUser user = (tblUser)Session[CommonConstants.SES_USER];
            if (user != null)
            {
                if (fileContent.HasFile)
                {
                    string folder = "Data/ImportData";
                    string rootFolder = Server.MapPath("~") + "\\" + folder + "\\";
                    string filename = rootFolder + fileContent.FileName;
                    string fileSave = folder + "\\" + fileContent.FileName;

                    // save file
                    try
                    {
                        if (!Directory.Exists(rootFolder))
                            Directory.CreateDirectory(rootFolder);

                        if (Path.GetExtension(fileContent.FileName) == CommonConstants.EXT_CSV)
                            fileContent.SaveAs(filename);
                        else
                            throw new Exception(CommonConstants.MSG_E_UPLOAD);

                    }
                    catch (Exception ex)
                    {
                        log.writeLog(Server.MapPath(CommonConstants.PATH_LOG_FILE), user.Username, ex.Message);

                        Session[CommonConstants.SES_ERROR] = CommonConstants.MSG_E_COMMON_ERROR_TEXT;
                        Response.Redirect(CommonConstants.DOT + CommonConstants.DOT + 
                                          CommonConstants.SPLASH + CommonConstants.PAGE_LOGIN);
                    }


                    //string type = ddlSubject.SelectedValue;
                    //switch (type)
                    //{
                    //    case CommonConstants.SEC_UNIVERSITY_CODE:
                    //        break;
                    //    case CommonConstants.SEC_ENGLISH_CODE:
                    //        break;
                    //    case CommonConstants.SEC_INFORMATICS_CODE:
                    //        break;
                    //    default: break;
                    //}
                }
            }
            else
            {
                Response.Redirect(CommonConstants.PAGE_LOGIN);
            }
        }
    }
}
