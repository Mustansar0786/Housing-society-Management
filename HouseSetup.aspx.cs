using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class HouseSetup : System.Web.UI.Page
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
                
                var Society = db.getSociety().ToList();
                ddlcityName.DataSource =Society ;
                ddlcityName.DataTextField = "SocietyName";
                ddlcityName.DataValueField = "SocietyId";
                ddlcityName.DataBind();
                

                if (Request.QueryString["hid"] != null)
                {
                    int hid = Convert.ToInt32(Request.QueryString["hid"]);
                    tblHouse house = db.tblHouse.FirstOrDefault(v => v.HouseId == hid);
                    txtHouseNo.Text = house.NoOfHouses;
                    ddlStoryNo.SelectedIndex = Convert.ToInt32(house.NoOfStory);
                    txtdetail.Text = house.HouseDetail;
                    ddlddlSocietyName.SelectedIndex = Convert.ToInt32(house.SocietyId);
                }
            }
        }

    }

    protected void btnSave_OnClick(object sender, EventArgs e)
    {

        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {
            if (Request.QueryString["hid"] == null)
            {
                tblHouse house = new tblHouse();
                house.NoOfHouses = txtHouseNo.Text;
                house.SocirtyId = Convert.ToInt32(ddlddlSocietyName.SelectedValue);
                house.HouseDetail = txtdetailress.Text;
                house.SocietyEnterDate=DateTime.Now;
                house.NoOfStory = Convert.ToInt32(ddlStoryNo.SelectedValue);

                db.tblHouses.Add(house);
                db.SaveChanges();
                lblmsg.InnerText = "Record Successfully Inserted";


                fillCityList();
                txtSName.Text = "";
                txtTotalHouses.Text = "";
                txtaddress.Text = "";


            }
            else
            {
               house.NoOfHouses = txtHouseNo.Text;
                house.SocirtyId = Convert.ToInt32(ddlddlSocietyName.SelectedValue);
                house.HouseDetail = txtdetailress.Text;
                house.SocietyEnterDate=DateTime.Now;
                house.NoOfStory = Convert.ToInt32(ddlStoryNo.SelectedValue);
                
                db.SaveChanges();
                lblmsg.InnerText = "Record Successfully Updated";

            }

        }

    }

    public void fillSocityList()
    {
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {

          
                var Society = db.getSociety().ToList();
                ddlSocietyName.DataSource =Society ;
                ddlSocietyName.DataTextField = "SocietyName";
                ddlSocietyName.DataValueField = "SocietyId";
                ddlSocietyName.DataBind();
        }
    }
}