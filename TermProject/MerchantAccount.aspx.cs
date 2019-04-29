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
using System.Collections;
using System.Security.Cryptography;     // needed for the encryption classes
using System.IO;                        // needed for the MemoryStream
using System.Text;                      // needed for the UTF8 encoding
using System.Net;                       // needed for the cookie

namespace TermProject
{
    public partial class MerchantAccount : System.Web.UI.Page
    {
        private const int ADDRESS_COLUMN = 0;
        private const int CITY_COLUMN = 1;
        private const int STATE_COLUMN = 2;
        private const int ZIPCODE_COLUMN = 3;
        private const int PHONE_COLUMN = 4;
        private const int EMAIL_COLUMN = 5;
        private const int FIRST_CONTROL = 0;

        DBConnect objDB = new DBConnect();
        SqlCommand objcomm = new SqlCommand();

        ArrayList merchants = new ArrayList();

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAccountInfo();
            }
        }

        protected void ShowAccountInfo()
        {
            string merchantEmail = Session["email"].ToString();
           

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "TP_GetMerchantInfo";
            objcomm.Parameters.AddWithValue("@theEmail", merchantEmail);
            
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objcomm);

            gvAccountInfo.DataSource = myDataSet;
            gvAccountInfo.DataBind();
        }
        protected string GetAPIKey()
        {
            int id = int.Parse(Session["merchantID"].ToString());
            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "TP_GetAPIKey";

            objcomm.Parameters.AddWithValue("@id", id);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);
            string apikey = ds.Tables[0].Rows[0]["apikey"].ToString();

            return apikey;

        }
        protected void UpdateMerchantInfo(Merchant merchant)
        {
            int id = int.Parse(Session["merchantID"].ToString());
            try
            {
                objcomm.CommandType = CommandType.StoredProcedure;
                objcomm.CommandText = "TP_UpdateMerchantInfo";

                objcomm.Parameters.AddWithValue("@id", id);
                objcomm.Parameters.AddWithValue("@address", merchant.Address);
                objcomm.Parameters.AddWithValue("@city", merchant.City);
                objcomm.Parameters.AddWithValue("@state", merchant.State);
                objcomm.Parameters.AddWithValue("@zipcode", merchant.ZipCode);
                objcomm.Parameters.AddWithValue("@phone", merchant.Phone);
                objcomm.Parameters.AddWithValue("@email", merchant.Email);

                objDB.DoUpdateUsingCmdObj(objcomm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        protected void gvAccountInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;

            TextBox TBox;
            TBox = (TextBox) gvAccountInfo.Rows[rowIndex].Cells[ADDRESS_COLUMN].Controls[FIRST_CONTROL];
            string address = TBox.Text;

            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[CITY_COLUMN].Controls[FIRST_CONTROL];
            string city = TBox.Text;

            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[STATE_COLUMN].Controls[FIRST_CONTROL];
            string state = TBox.Text;

            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[ZIPCODE_COLUMN].Controls[FIRST_CONTROL];
            string zipcode = TBox.Text;

            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[PHONE_COLUMN].Controls[FIRST_CONTROL];
            string phone = TBox.Text;

            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[EMAIL_COLUMN].Controls[FIRST_CONTROL];
            string email = TBox.Text;

            Merchant merchant = new Merchant();
            merchant.Address = address;
            merchant.City = city;
            merchant.State = state;
            merchant.ZipCode = zipcode;
            merchant.Phone = phone;
            merchant.Email = email;

            Session["merchant"] = merchant;
            UpdateMerchantInfo(merchant);
            merchants.Add(merchant);
            gvAccountInfo.EditIndex = -1;

            gvAccountInfo.DataSource = merchants;
            gvAccountInfo.DataBind();


        }

        protected void gvAccountInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAccountInfo.EditIndex = e.NewEditIndex;
            ShowAccountInfo();
        }

        protected void gvAccountInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAccountInfo.EditIndex = -1;
            ShowAccountInfo();
        }

        protected void btnRetrieveAPI_Click(object sender, EventArgs e)
        {

            txtAPIKey.Text = GetAPIKey();
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

            if (txtPassword.Text == "")
            {
                lblDisplay.Text = "Please enter your current password";
                txtPassword.Focus();
                lblSuccess.Visible = false;
            }
            else if (txtPassword.Text != Session["password"].ToString())
            {
                lblDisplay.Text = "Please enter correct current password";
                txtPassword.Focus();
                lblSuccess.Visible = false;
            }
            else if (txtPassword.Text == Session["password"].ToString())
            {
                if (txtNewPassword.Text == "")
                {
                    lblDisplay.Text = "Please enter your new password";
                    lblDisplay.Visible = true;
                    lblSuccess.Visible = false;
                }
                else if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    string emailaddress = Session["email"].ToString();
                    string apikey = GetAPIKey();

                    try
                    {
                        lblDisplay.Visible = false;
                        objcomm.CommandType = CommandType.StoredProcedure;
                        objcomm.CommandText = "TP_UpdateMerchantPassword";

                        objcomm.Parameters.AddWithValue("@email", emailaddress);
                        objcomm.Parameters.AddWithValue("@apikey", apikey);
                        objcomm.Parameters.AddWithValue("@password", encryptedPassword);

                        objDB.DoUpdateUsingCmdObj(objcomm);
                        lblSuccess.Visible = true;
                        txtPassword.Text = ""; txtNewPassword.Text = ""; txtConfirmPassword.Text = "";
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    txtNewPassword.Focus();
                    lblDisplay.Text = "Passwords do not match. Please enter again";
                    lblDisplay.Visible = true;
                    lblSuccess.Visible = false;
                }
            }
        }

        protected void btnViewSales_Click(object sender, EventArgs e)
        {
            string apikey = GetAPIKey();

            objcomm.Parameters.Clear();
            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "TP_GetMerchantSales";

            objcomm.Parameters.AddWithValue("@apikey", apikey);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);
            gvSales.DataSource = ds;
            gvSales.DataBind();
        }

        protected void lbSignout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}