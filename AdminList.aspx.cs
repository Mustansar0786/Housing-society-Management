using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillStatus();
    }


    protected void GV_AdminList_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("AdminSetup.aspx?adId=" + e.CommandArgument);
        }
        else if (e.CommandName == "delete")
        {
            using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
            {
                int adId = Convert.ToInt32(e.CommandArgument);
                db.DisableAdmin(adId);
                FillStatus();

            }
        }
    }

    protected void GV_AdminList_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        throw new NotImplementedException();
    }

    protected void GV_AdminList_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }


    protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {


            if (ddlStatus.SelectedValue == "0")
            {
                FillStatus();
            }
            else if (ddlStatus.SelectedValue == "1")
            {
                var activeAdmin = db.GetAdminByStatus(true).ToList();
                GV_AdminList.DataSource = activeAdmin;
                GV_AdminList.DataBind();
            }
            else if (ddlStatus.SelectedValue == "2")
            {
                var inactiveAdmin = db.GetAdminByStatus(false).ToList();
                GV_AdminList.DataSource = inactiveAdmin;
                GV_AdminList.DataBind();
            }

        }

    }

    public void FillStatus()
    {
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {
            var allAdmin = db.GetAdmin().ToList();
            GV_AdminList.DataSource = allAdmin;
            GV_AdminList.DataBind();
        }
    }
}