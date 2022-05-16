using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSetup : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {
            if (IsPostBack == false)
            {
                if (Request.QueryString["adId"] != null)
                {
                    int adminid = Convert.ToInt32(Request.QueryString["adId"]);
                    tblAdmin exAdmin = db.tblAdmins.FirstOrDefault(ad => ad.AdminId == adminid);

                    txtfName.Text = exAdmin.AFirstName;
                    txtlname.Text = exAdmin.ALastName;
                    txtphoneNo.Text = exAdmin.APhoneNo;
                    txtCNIC.Text = exAdmin.ANationalId;
                    txtemail.Text = exAdmin.AEmailAdresss;
                    txtpassword.Text = Decrypt(exAdmin.APassword); //this field will not fill due to password textMode

                    ddlstatus.SelectedValue = ((exAdmin.AStatus) == false) ? "2" : "1";

                }
            }
        }

    }

    protected void btnlogin_OnClick(object sender, EventArgs e)
    {
        /////////////////////check status
        bool status = (ddlstatus.SelectedIndex == 1) ? true : false;

        //////////////////////////////////////
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {

            if (Request.QueryString["adId"] != null)
            {
                int adminid = Convert.ToInt32(Request.QueryString["adId"]);
                tblAdmin exAdmin = db.tblAdmins.FirstOrDefault(ad => ad.AdminId == adminid);
                exAdmin.AFirstName = txtfName.Text;
                exAdmin.ALastName = txtlname.Text;
                exAdmin.APhoneNo = txtphoneNo.Text;
                exAdmin.ANationalId = txtCNIC.Text;
                exAdmin.AEmailAdresss = txtemail.Text;
                exAdmin.APassword = Encript(txtphoneNo.Text);
                exAdmin.AStatus = status;
                db.SaveChanges();
                lblmsg.Text = "Record Updated Successfully";


            }
            else if (Request.QueryString["adId"] == null)
            {
                tblAdmin newAdmin = new tblAdmin();
                newAdmin.AFirstName = txtfName.Text;
                newAdmin.ALastName = txtlname.Text;
                newAdmin.APhoneNo = txtphoneNo.Text;
                newAdmin.ANationalId = txtCNIC.Text;
                newAdmin.AEmailAdresss = txtemail.Text;
                newAdmin.APassword = Encript(txtphoneNo.Text);
                newAdmin.AStatus = status;
                db.tblAdmins.Add(newAdmin);
                db.SaveChanges();
                lblmsg.Text = "Record Inserted Successfully";


                txtfName.Text = "";
                txtlname.Text = "";
                txtphoneNo.Text = "";
                txtCNIC.Text = "";
                txtemail.Text = "";
                txtpassword.Text = "";
                ddlstatus.SelectedValue = "0";

            }




        }
    }

    private static string Key = "keyforencriptionanddecriptionalg";
    private static string IV = "initializationva";


    public string Encript(string plainText)
    {
        byte[] plainTextBytes = ASCIIEncoding.ASCII.GetBytes(plainText);
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

    public static string Decrypt(string cypherText)
    {
        byte[] cypherTextBytes = Convert.FromBase64String(cypherText);
        AesCryptoServiceProvider AES = new AesCryptoServiceProvider
        {
            BlockSize = 128,
            KeySize = 256,
            Key = ASCIIEncoding.ASCII.GetBytes(Key),
            IV = ASCIIEncoding.ASCII.GetBytes(IV),
            Padding = PaddingMode.PKCS7,
            Mode = CipherMode.CBC
        };
        ICryptoTransform crypto = AES.CreateDecryptor(AES.Key, AES.IV);
        byte[] plainTextBytes = crypto.TransformFinalBlock(cypherTextBytes, 0, cypherTextBytes.Length);
        crypto.Dispose();
        String plainText = ASCIIEncoding.ASCII.GetString(plainTextBytes);
        return plainText;
    }

    protected void txtemail_OnTextChanged(object sender, EventArgs e)
    {
        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {
            var exemail = db.GetAdminbyemail(txtemail.Text).ToList(); //firstordefalt method can also be use
            if (exemail.Count > 0 && IsPostBack == false)
            {
                lblemailexixt.Text = "Email already exist";
            }
        }
    }
}