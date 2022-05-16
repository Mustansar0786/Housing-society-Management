using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class SocietySetup : System.Web.UI.Page
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
                
                var city = db.GetCity().ToList();
                ddlcityName.DataSource = city;
                ddlcityName.DataTextField = "CityName";
                ddlcityName.DataValueField = "CityId";
                ddlcityName.DataBind();
                

                if (Request.QueryString["sid"] != null)
                {
                    int sid = Convert.ToInt32(Request.QueryString["sid"]);
                    tblSociety society = db.tblSocieties.FirstOrDefault(v => v.SocietyId == sid);
                    txtSName.Text = society.SocietyName;
                    txtTotalHouses.Text = Convert.ToString(society.SocietyHouses);
                    txtaddress.Text = society.SocietyAddress;
                    ddlcityName.SelectedIndex = Convert.ToInt32(society.CityId);
                }
            }
        }

    }

    protected void btnSave_OnClick(object sender, EventArgs e)
    {

        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {
            if (Request.QueryString["sid"] == null)
            {
                tblSociety society = new tblSociety();
                society.SocietyName = txtSName.Text;
                society.SocietyHouses = Convert.ToInt32(txtTotalHouses.Text);
                society.CityId = Convert.ToInt32(ddlcityName.SelectedValue);
                society.SocietyAddress = txtaddress.Text;
                society.SocietyEnterDate=DateTime.Now;
                db.tblSocieties.Add(society);
                db.SaveChanges();
                lblmsg.InnerText = "Record Successfully Inserted";


                fillCityList();
                txtSName.Text = "";
                txtTotalHouses.Text = "";
                txtaddress.Text = "";


            }
            else
            {
                int sid = Convert.ToSByte(Request.QueryString["sid"]);
                tblSociety society = db.tblSocieties.FirstOrDefault(v => v.SocietyId == sid);
                society.SocietyName = txtSName.Text;
                society.SocietyHouses = Convert.ToInt32(txtTotalHouses.Text);
                society.CityId = Convert.ToInt32(ddlcityName.SelectedValue);
                society.SocietyAddress = txtaddress.Text;
                db.SaveChanges();
                lblmsg.InnerText = "Record Successfully Updated";

            }

        }

    }

    public void fillCityList()
    {
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {

            var city = db.GetCity().ToList();
            ddlcityName.DataSource = city;
            ddlcityName.DataTextField = "CityName";
            ddlcityName.DataValueField = "CityId";
            ddlcityName.DataBind();
        }
    }
}