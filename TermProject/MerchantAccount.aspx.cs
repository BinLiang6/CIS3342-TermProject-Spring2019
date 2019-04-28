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
            string merchantPassword = Session["password"].ToString();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "TP_GetMerchantInfo";
            objcomm.Parameters.AddWithValue("@theEmail", merchantEmail);
            objcomm.Parameters.AddWithValue("@thePassword", merchantPassword);
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

            if (txtNewPassword.Text == "")
            {
                lblDisplay.Text = "Please enter your new password";
                lblDisplay.Visible = true;
            }
            else if (txtNewPassword.Text == txtConfirmPassword.Text)
            {
                string emailaddress = Session["email"].ToString();
                string apikey = GetAPIKey();
                string password = txtNewPassword.Text;

                try
                {
                    lblDisplay.Visible = false;
                    objcomm.CommandType = CommandType.StoredProcedure;
                    objcomm.CommandText = "TP_UpdateMerchantPassword";

                    objcomm.Parameters.AddWithValue("@email", emailaddress);
                    objcomm.Parameters.AddWithValue("@apikey", apikey);
                    objcomm.Parameters.AddWithValue("@password", password);

                    objDB.DoUpdateUsingCmdObj(objcomm);
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
                lblDisplay.Text = "Passwords do not match. Please enter again";
                lblDisplay.Visible = true;
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
            Response.Redirect("login.aspx");
        }
    }
}