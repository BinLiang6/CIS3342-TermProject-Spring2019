using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;

using System.Security.Cryptography;     // needed for the encryption classes
using System.IO;                        // needed for the MemoryStream
using System.Text;                      // needed for the UTF8 encoding
using System.Net;                       // needed for the cookie

namespace TermProject
{
    public partial class merchant_forgot_password : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objComm = new SqlCommand();

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtAPIKey.Text == "")
            {
                lblDisplay.Text = "Please enter your email and API key";
                lblDisplay.Visible = true;
            }
            else
            {              
                string emailaddress = txtEmail.Text;
                string apikey = txtAPIKey.Text;
                try
                {
                    objComm.CommandType = CommandType.StoredProcedure;
                    objComm.CommandText = "TP_GetMerchantEmailAndAPIKey";
                    objComm.Parameters.AddWithValue("@email", emailaddress);
                    objComm.Parameters.AddWithValue("@apikey", apikey);

                    DataSet ds = objDB.GetDataSetUsingCmdObj(objComm);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        lblDisplay.Visible = false;
                        resetPassword.Visible = true;
                        Session["email"] = ds.Tables[0].Rows[0]["email"].ToString();
                        Session["apikey"] = ds.Tables[0].Rows[0]["apikey"].ToString();

                        email.Visible = false;

                    }
                    else
                    {
                        lblDisplay.Text = "Email or API Key not found";
                        lblDisplay.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String plainTextPassword = txtConfirmPassword.Text;
            String encryptedPassword;

            UTF8Encoding encoder = new UTF8Encoding();      // used to convert bytes to characters, and back
            Byte[] textBytes;                               // stores the plain text data as bytes

            // Perform Encryption
            // Convert a string to a byte array, which will be used in the encryption process.
            textBytes = encoder.GetBytes(plainTextPassword);

            RijndaelManaged rmEncryption = new RijndaelManaged();
            MemoryStream myMemoryStream = new MemoryStream();
            CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            // Use the crypto stream to perform the encryption on the plain text byte array.
            myEncryptionStream.Write(textBytes, 0, textBytes.Length);
            myEncryptionStream.FlushFinalBlock();

            // Retrieve the encrypted data from the memory stream, and write it to a separate byte array.
            myMemoryStream.Position = 0;
            Byte[] encryptedBytes = new Byte[myMemoryStream.Length];
            myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);

            // Close all the streams.
            myEncryptionStream.Close();
            myMemoryStream.Close();

            // Convert the bytes to a string and display it.
            encryptedPassword = Convert.ToBase64String(encryptedBytes);

            if (txtNewPassword.Text == "")
            {
                lblPassword.Text = "Please enter your new password";
                lblPassword.Visible = true;
            }
            else if(txtNewPassword.Text == txtConfirmPassword.Text )
            {
                string emailaddress = Session["email"].ToString();
                string apikey = Session["apikey"].ToString();

                try
                {
                    lblPassword.Visible = false ;
                    objComm.CommandType = CommandType.StoredProcedure;
                    objComm.CommandText = "TP_UpdateMerchantPassword";

                    objComm.Parameters.AddWithValue("@email", emailaddress);
                    objComm.Parameters.AddWithValue("@apikey", apikey);
                    objComm.Parameters.AddWithValue("@password", encryptedPassword);

                    objDB.DoUpdateUsingCmdObj(objComm);
                    lblSuccess.Visible = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }  
            }
            else
            {
                txtNewPassword.Focus();
                lblPassword.Text = "Passwords do not match. Please enter again";
                lblPassword.Visible = true;
            }
        }
    }
}