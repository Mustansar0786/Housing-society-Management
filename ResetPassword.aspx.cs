using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;








    }
    protected void btnReset_OnClick(object sender, EventArgs e)
    {

        using (SocietyManagementSystem_26Entities db = new SocietyManagementSystem_26Entities())
        {
            if ((db.GetAdminbyemail(txtemail.Text).ToList().Count)==1?true:false)
            {

                Response.Write(Convert.ToBoolean(db.GetAdminbyemail(txtemail.Text).ToList().Count));
                db.ChangeAdminPasswordbyemail(txtemail.Text, Encript(txtpassword.Text));
                Response.Redirect("AdminLogin.aspx");
            }





            else if ((db.getRootbyemail(txtemail.Text).ToList().Count) == 1 ? true : false)
            {
                db.ChangeRootPasswordbyemail(txtemail.Text, Encript(txtpassword.Text));
                Response.Redirect("RootLogin.aspx");

            }
            else
            {
                lblmsg.Text = "Email not Exist";
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