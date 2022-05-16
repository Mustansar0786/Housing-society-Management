using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HouseTypeList : System.Web.UI.Page
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
        FileHouseTypeList();
        
    }


    protected void FileHouseTypeList()
    {
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {

            var housetypeList = db.GetHouseType().ToList();
            GV_HouseType.DataSource = housetypeList;
            GV_HouseType.DataBind();
        }
    }

    protected void GV_HouseType_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("HouseTypeSetup.aspx?htid=" + e.CommandArgument); 
        }
        else if (e.CommandName == "delete")
        {
            int htypeid = Convert.ToInt32(e.CommandArgument);
            using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
            {
                db.DeleteHouseType(htypeid);
            }

            FileHouseTypeList();

        }
    }

    protected void GV_HouseType_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        throw new NotImplementedException();
    }

    protected void GV_HouseType_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        throw new NotImplementedException();
    }
}