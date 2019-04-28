using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;

using System.Security.Cryptography;     // needed for the encryption classes
using System.IO;                        // needed for the MemoryStream
using System.Text;                      // needed for the UTF8 encoding
using System.Net;                       // needed for the cookie

namespace TermProject
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        DBConnect objconn = new DBConnect();
        SqlCommand objcommand = new SqlCommand();

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {         
            objcommand.CommandType = CommandType.StoredProcedure;
            objcommand.CommandText = "TP_GetUsernameAndEmail";
            objcommand.Parameters.AddWithValue("@username", txtUsername.Text);
            objcommand.Parameters.AddWithValue("@email", txtEmail.Text);
            DataSet ds = objconn.GetDataSetUsingCmdObj(objcommand);

            if(ds.Tables[0].Rows.Count == 0)
            {
                String plainTextPassword = txtPassword.Text;
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

                Customer customer = new Customer();
                if (txtName.Text != "" && txtUsername.Text != "" && txtPassword.Text != "" && txtEmail.Text != "" && txtAddress.Text != "" && txtCity.Text != "" && txtState.Text != "" && txtZipcode.Text != ""
                    && txtPhone.Text != "" && txtSq1.Text != "" && txtSq2.Text != "" && txtSq3.Text != "")
                {
                    customer.Name = txtName.Text;
                    customer.Username = txtUsername.Text;
                    customer.Password = encryptedPassword;
                    customer.Email = txtEmail.Text;
                    customer.Address = txtAddress.Text;
                    customer.City = txtCity.Text;
                    customer.State = txtState.Text;
                    customer.ZipCode = txtZipcode.Text;
                    customer.Phone = txtPhone.Text;
                    customer.Sq1 = txtSq1.Text;
                    customer.Sq2 = txtSq2.Text;
                    customer.Sq3 = txtSq3.Text;
                    lblDisplay.Text = "";
                }
                else
                {
                    lblDisplay.Text = "Please do not leave any field empty";
                }
                
                if (customer != null)
                {
                    try
                    {
                        objcommand.Parameters.Clear();
                        objcommand.CommandType = CommandType.StoredProcedure;
                        objcommand.CommandText = "TP_AddCustomer";

                        objcommand.Parameters.AddWithValue("@name", customer.Name);
                        objcommand.Parameters.AddWithValue("@username", customer.Username);
                        objcommand.Parameters.AddWithValue("@password", customer.Password);
                        objcommand.Parameters.AddWithValue("@address", customer.Address);
                        objcommand.Parameters.AddWithValue("@city", customer.City);
                        objcommand.Parameters.AddWithValue("@state", customer.State);
                        objcommand.Parameters.AddWithValue("@zipcode", customer.ZipCode);
                        objcommand.Parameters.AddWithValue("@phone", customer.Phone);
                        objcommand.Parameters.AddWithValue("@email", customer.Email);
                        objcommand.Parameters.AddWithValue("@sq1", customer.Sq1);
                        objcommand.Parameters.AddWithValue("@sq2", customer.Sq2);
                        objcommand.Parameters.AddWithValue("@sq3", customer.Sq3);

                        int result = objconn.DoUpdateUsingCmdObj(objcommand);

                        if(result == -1)
                        {
                            lblNotif.Text = "An error occurred. Please try again!";
                            lblNotif.Visible = false;
                        }
                        else
                        {
                            lblSuccess.Text = "Successfully created an account";                                                      
                            if(lblNotif.Visible == true)
                            {
                                lblNotif.Visible = false;
                            }
                            lblSuccess.Visible = true;
                            btnSubmit.Visible = false;
                        }          
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }             
            }
            else
            {
                lblNotif.Text = "The username or email is already taken";
                lblNotif.Visible = true;
            }
        }
    }
}