using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HouseTypeSetup : System.Web.UI.Page
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
        if (IsPostBack == false)
        {
            using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
            {



                if (Request.QueryString["htid"] != null)
                {
                    int housetypeid = Convert.ToInt32(Request.QueryString["htid"]);
                    tblHouseType houseType = db.tblHouseTypes.FirstOrDefault(v => v.HouseTypeId == housetypeid);
                    txthtypeName.Text = houseType.HouseTypeName;
                }
            }
        }

    }

   
    protected void btnsave_OnClick(object sender, EventArgs e)
    {

        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {
            if (Request.QueryString["htypeid"] == null)
            {
                tblHouseType houseType = new tblHouseType();
                houseType.HouseTypeName = txthtypeName.Text;
                db.tblHouseTypes.Add(houseType);
                db.SaveChanges();
                lblmsg.InnerText = "Record Successfully Inserted";


                
                txthtypeName.Text = "";


            }
            else
            {
                int htypeid = Convert.ToSByte(Request.QueryString["htypeid"]);
                tblHouseType houseType = db.tblHouseTypes.FirstOrDefault(v => v.HouseTypeId == htypeid);
                houseType.HouseTypeName = txthtypeName.Text;
                db.SaveChanges();
                lblmsg.InnerText = "Record Successfully Updated";

            }

        }

    }
}