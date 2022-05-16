using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SocieryList : System.Web.UI.Page
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
        FillSocietyList();
    }

    protected void gv_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("societySetup.aspx?sid=" + e.CommandArgument); //sid can be replace by any variable name 
        }
        else if (e.CommandName == "delete")
        {
            int sid = Convert.ToInt32(e.CommandArgument);
            using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
            {
                var housesInSociety = db.Gethouse(sid).ToList();
                if (housesInSociety.Count > 0)
                {
                    lblfordelete.InnerText = "Please Delete house first ";

                }
                else
                {

                    db.DeleteSociety(sid);
                }
            }

            FillSocietyList();

        }
    }

    protected void FillSocietyList()
    {
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {

            var Society = db.GetSociety().ToList();
            gv_Socity.DataSource = Society;
            gv_Socity.DataBind();
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