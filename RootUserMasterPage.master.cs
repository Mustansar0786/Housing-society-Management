using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RootUserMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        if (Session["RootId"]==null)
        {
            Response.Redirect("RootUserLogin.aspx");
        }
                    
        else if( Session["AdminId"]!=null)
        {
            Response.Redirect("AdminLogin.aspx");
            
        }
        


    }
}
