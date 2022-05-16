using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

public partial class RootLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.Cookies["RootCooky"] != null)
        {
            Session["RootId"] = Request.Cookies["RootCooky"]["CAdminId"];
            Session["RFirstName"] = Request.Cookies["RootCooky"]["CFirstName"];
            Session.Timeout = 1440; //24hours

            Response.Redirect("HomePage.aspx");
        }
    }

    protected void btnlogin_OnClick(object sender, EventArgs e)
    {
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {
            var root = db.RootLOgin(txtemail.Text, Encript(txtpassword.Text)).ToList();
            if (root.Count > 0)
            {
                Session["RootId"] = root[0].RootId;
                Session["RFirstName"] = root[0].RootFName;
                Session.Timeout = 420;
                if (checkremember.Checked)
                {
                    Response.Cookies["RootCooky"]["CAdminId"] = root[0].RootId.ToString();
                    Response.Cookies["RootCooky"]["CFirstName"] = root[0].RootFName;
                    Response.Cookies["RootCooky"].Expires = DateTime.Now.AddDays(1);

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
