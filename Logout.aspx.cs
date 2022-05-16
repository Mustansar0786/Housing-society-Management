using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminId"] != null) //return to adminlogin
        {
            Session.Abandon();
            Response.Cookies["AdminCooky"].Expires = DateTime.Now.AddMinutes(-3);
            Response.Redirect("AdminLogin.aspx");
        }

        else if (Session["RootId"]!=null) //return to rootlogin
        {
            Session.Abandon();
            Response.Cookies["RootCooky"].Expires = DateTime.Now.AddMinutes(-3);
            Response.Redirect("RootUserLogin.aspx");
        }
        else if (Session["AdminId"] == null && Session["RootId"] == null) //return to adminlogin
        {
            Session.Abandon();
            Response.Cookies["AdminCooky"].Expires = DateTime.Now.AddDays(-3);
            Response.Cookies["RootCooky"].Expires = DateTime.Now.AddMinutes(-3);

            Response.Redirect("AdminLogin.aspx");
        }
    }


}