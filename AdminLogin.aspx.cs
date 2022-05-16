using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.Cookies["AdminCooky"] != null)
        {
            Session["AdminId"] = Request.Cookies["AdminCooky"]["CAdminId"];
            Session["FirstName"] = Request.Cookies["AdminCooky"]["CFirstname"];
            Session["EmailAddress"] = Request.Cookies["AdminCooky"]["CEmailAddress"];
            Session.Timeout = 1440;

            Response.Redirect("HomePage.aspx");
        }
    }

    protected void btnlogin_OnClick(object sender, EventArgs e)
    {
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {
            
            var admin = db.AdminLOgin(txtemail.Text, Encript(txtpassword.Text)).ToList();
            if (admin.Count > 0)
            {
                Session["AdminId"] = admin[0].AdminId;
                Session["FirstName"] = admin[0].AFirstName;
                Session["EmailAddress"] = admin[0].AEmailAdresss;
                Session.Timeout = 1440;

                if (chkremember.Checked)
                {

                    Response.Cookies["AdminCooky"]["CAdminId"] = admin[0].AdminId.ToString();
                    Response.Cookies["AdminCooky"]["CFirstName"] = admin[0].AFirstName;
                    Response.Cookies["AdminCooky"]["CEmailAddress"] = admin[0].AEmailAdresss;
                    Response.Cookies["AdminCooky"].Expires = DateTime.Now.AddDays(1);

                }

                Response.Redirect("HomePage.aspx");

            }
           
            else
            {
                lblmsg.Text = "Please Enter Valid email and password";

            }
        }

    }

    private static string Key = "keyforencriptionanddecriptionalg";
    private static string IV = "initializationva";


    public string Encript(string plainText)
    {
        byte[] plainTextBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(plainText);
        AesCryptoServiceProvider AES = new AesCryptoServiceProvider
        {
            BlockSize = 128,
            KeySize = 256,
            Key = ASCIIEncoding.ASCII.GetBytes(Key),
            IV = ASCIIEncoding.ASCII.GetBytes(IV),
            Padding = PaddingMode.PKCS7,
            Mode = CipherMode.CBC
        };
        ICryptoTransform crypto = AES.CreateEncryptor(AES.Key, AES.IV);
        byte[] cypherTextBytes = crypto.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
        crypto.Dispose();
        string cypherText = Convert.ToBase64String(cypherTextBytes);
        return cypherText;
    }


}