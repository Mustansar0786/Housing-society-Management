using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
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

    }
}