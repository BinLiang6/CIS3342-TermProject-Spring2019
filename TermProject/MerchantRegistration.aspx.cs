using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Script.Serialization;
using Utilities;
using ClassLibrary;

using System.Security.Cryptography;     // needed for the encryption classes
using System.IO;                        // needed for the MemoryStream
using System.Text;                      // needed for the UTF8 encoding
using System.Net;                       // needed for the cookie

namespace TermProject
{
    public partial class MerchantRegistration : System.Web.UI.Page
    {
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/";

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddMerchant_Click(object sender, EventArgs e)
        {
            Merchant merchant = new Merchant();
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

            if (txtName.Text != "" && txtEmail.Text != "" && txtPassword.Text != "" && txtDesc.Text != "" && txtAddress.Text != "" && txtCity.Text != "" && txtState.Text != "" && txtZipcode.Text != "" && txtPhone.Text != "")
            {
                merchant.Seller_site = txtName.Text;
                merchant.Email = txtEmail.Text;
                merchant.Password = encryptedPassword;
                merchant.Desc = txtDesc.Text;
                merchant.Url = txtUrl.Text;
                merchant.Address = txtAddress.Text;
                merchant.City = txtCity.Text;
                merchant.State = txtState.Text;
                merchant.ZipCode = txtZipcode.Text;
                merchant.Phone = txtPhone.Text;
                lblDisplay.Text = "";
            }
            else
            {
                lblDisplay.Text = "Please do not leave any field empty";
            }
            
            if (merchant != null)
            {
                try
                {
                    url = url + "Register/Merchant/";

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string jsonMerchant = js.Serialize(merchant);

                    WebRequest request = WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentLength = jsonMerchant.Length;
                    request.ContentType = "application/json";

                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonMerchant);
                    writer.Flush();
                    writer.Close();

                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(theDataStream);
                    String data = streamReader.ReadToEnd();
                    streamReader.Close();
                    response.Close();

                    if (data == "true")
                    {
                        if (lblNotify.Visible == true)
                        {
                            lblNotify.Visible = false;
                        }
                        lblSuccess.Visible = true;
                        lblSuccess.Text = "Successfully added a merchant!";
                    }
                    else
                    {
                        lblNotify.Text = "An error occurred! The username is already exists!";
                        lblNotify.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblDisplay.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}