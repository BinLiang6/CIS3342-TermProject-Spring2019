using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace TermProject
{
    public partial class login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.Cookies["CIS3342_Cookie"] != null)
            {
                String accountType = ddlLogin.SelectedValue.ToString();

                if (accountType == "customer")
                {
                    HttpCookie cookie = Request.Cookies["CIS3342_Cookie"];
                    txtUsername.Text = cookie.Values["username"].ToString();
                    txtPassword.Text = cookie.Values["password"].ToString();
                }
                else if (accountType == "merchant")
                {

                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session.Add("customerID", "");
            Session.Add("username", "");
            Session.Add("email", "");
            Session.Add("password", "");
            Session.Add("accountType", "");

            String username = txtUsername.Text;
            String password = txtPassword.Text;
            String accountType = ddlLogin.SelectedValue.ToString();

            if (username == "")
            {
                txtUsername.Focus();
                lblDisplay.Text = "Please enter your username or email address";
            }
            else if (password == "")
            {
                txtPassword.Focus();
                lblDisplay.Text = "Please enter your password";
            }
            else
            {
                if (accountType == "customer")
                {
                    // Set the SQLCommand object's properties for executing a Stored Procedure
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_GetLogIn_Customer";
                    objCommand.Parameters.AddWithValue("@theUsername", username);
                    objCommand.Parameters.AddWithValue("@thePassword", password);
                    // Execute the stored procedure using the DBConnect object and the SQLCommand object
                    DataSet CustomerDS = objDB.GetDataSetUsingCmdObj(objCommand);

                    try
                    {
                        lblDisplay.Text = "";
                        lblSuccess.Text = "Sign in successfully! Welcome back <b>" + CustomerDS.Tables[0].Rows[0]["name"].ToString() + "</b>"; //Give the first table that found in the dataset
                        Session["customerID"] = CustomerDS.Tables[0].Rows[0]["customer_id"].ToString();
                        Session["username"] = username;
                        Session["accountType"] = accountType;
                        Session["password"] = password;
                        lblSuccess.Visible = true;

                        if (chkRemember.Checked == true)
                        {
                            HttpCookie customerCookie = new HttpCookie("CIS3342_Cookie");
                            customerCookie.Values["username"] = txtUsername.Text;
                            customerCookie.Values["password"] = txtPassword.Text;
                            customerCookie.Values["LastVisited"] = DateTime.Now.ToString();
                            customerCookie.Expires = new DateTime(2025, 1, 1);
                            Response.Cookies.Add(customerCookie);
                        }

                        Response.AddHeader("REFRESH", "3;URL=ShoppingSite.aspx");
                    }
                    catch
                    {
                        lblDisplay.Text = "Incorrect username OR password";
                        txtPassword.Focus();
                    }
                }
                else if (accountType == "merchant")
                {
                    // Set the SQLCommand object's properties for executing a Stored Procedure
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_GetLogIn_Merchant";
                    objCommand.Parameters.AddWithValue("@theEmail", username);
                    objCommand.Parameters.AddWithValue("@thePassword", password);
                    // Execute the stored procedure using the DBConnect object and the SQLCommand object
                    DataSet MerchantDS = objDB.GetDataSetUsingCmdObj(objCommand);

                    try
                    {
                        string merchantName = MerchantDS.Tables[0].Rows[0]["seller_site"].ToString();
                        string merchantID = MerchantDS.Tables[0].Rows[0]["id"].ToString();
                        lblDisplay.Text = "";
                        lblSuccess.Text = "Sign in successfully! Welcome back <b>" + merchantName + "</b>"; //Give the first table that found in the dataset
                        Session["merchantID"] = merchantID;
                        Session["email"] = username;
                        Session["accountType"] = accountType;
                        Session["password"] = password;
                        lblSuccess.Visible = true;
                        Response.AddHeader("REFRESH", "3;URL=MerchantAccount.aspx");
                    }
                    catch
                    {
                        lblDisplay.Text = "Incorrect username OR password";
                        txtPassword.Focus();
                    }
                }
            }
        }

        protected void lbForgotPassword_Click(object sender, EventArgs e)
        {
            if (ddlLogin.SelectedValue.ToString() == "customer")
            {
                Response.Redirect("forgot-password.aspx");
            }
            else if (ddlLogin.SelectedValue.ToString() == "merchant")
            {
                Response.Redirect("merchant-forgot-password.aspx");
            }
        }
    }
}