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
    public partial class forgot_password : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Session.Add("retrieve-username", "");
            Session.Add("answer1", "");
            Session.Add("answer2", "");
            Session.Add("answer3", "");

            String email = txtEmail.Text;

            if (email == "")
            {
                txtEmail.Focus();
                lblDisplay.Text = "Please enter your email address";
            }
            else
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetCustomer_ByEmail";
                objCommand.Parameters.AddWithValue("@theEmail", email);
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                if (myDataSet.Tables[0].Rows.Count == 1)
                {
                    lblDisplay.Text = "";
                    securityQuestion.Visible = true;
                    txtEmail.ReadOnly = true;
                    Session.Clear();
                    Session["answer1"] = myDataSet.Tables[0].Rows[0]["sq1"].ToString();
                    Session["answer2"] = myDataSet.Tables[0].Rows[0]["sq2"].ToString();
                    Session["answer3"] = myDataSet.Tables[0].Rows[0]["sq3"].ToString();
                    Session["retrieve-username"] = myDataSet.Tables[0].Rows[0]["username"].ToString();
                }
                else
                {
                    txtEmail.Focus();
                    lblDisplay.Text = "Email address NOT FOUND";
                }
            }
        }

        protected void btnAnswer_Click(object sender, EventArgs e)
        {
            String a1 = txtQuestion1.Text;
            String a2 = txtQuestion2.Text;
            String a3 = txtQuestion3.Text;

            if (a1 == Session["answer1"].ToString() && a2 == Session["answer2"].ToString() && a3 == Session["answer3"].ToString())
            {
                lblAnswer.Text = "";
                resetPassword.Visible = true;
                txtQuestion1.ReadOnly = true;
                txtQuestion2.ReadOnly = true;
                txtQuestion3.ReadOnly = true;
                securityQuestion.Visible = false;
            }
            else
            {
                lblAnswer.Text = "Please provide correct answers to all questions";
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
                txtNewPassword.Focus();
            }
            else if (txtNewPassword.Text == txtConfirmPassword.Text)
            {
                lblPassword.Text = "";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ResetPassword";
                objCommand.Parameters.AddWithValue("@thePassword", encryptedPassword);
                objCommand.Parameters.AddWithValue("@theUsername", Session["retrieve-username"].ToString());
                objDB.DoUpdateUsingCmdObj(objCommand);

                lblSuccess.Visible = true;
                
                Session.Clear();
                Response.AddHeader("REFRESH", "2;URL=login.aspx");
            }
            else
            {
                txtConfirmPassword.Focus();
                txtConfirmPassword.Text = "";
                lblPassword.Text = "Passwords do not match. Please enter again";
            }
        }
    }
}