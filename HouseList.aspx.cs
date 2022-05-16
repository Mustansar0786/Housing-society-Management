using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HouseList : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["RootId"] != null)
        {
            Page.MasterPageFile = "RootUserMasterPage.master";
        }



    }
    protected void Page_Load(object sender, EventArgs e)
    {
        FillHousesList();
    }

    protected void gv_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("HouseSetup.aspx?hid=" + e.CommandArgument);
        }
        else if (e.CommandName == "delete")
        {
            int hid = Convert.ToInt32(e.CommandArgument);
            using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
            
                
                    db.DeleteSociety(sid);
                
            
            FillHousesList();

        }
    }

    protected void FillHousesList()
    {
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {

            var SocietyList = db.GetSociety().ToList();
            gv_Houses.DataSource = SocietyList;
            gv_Houses.DataBind();
        }
    }

    protected void gv_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gv_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        throw new NotImplementedException();
    }
}