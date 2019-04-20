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

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session.Add("username", "");
            Session.Add("email", "");
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
                        Session["username"] = username;
                        Session["accountType"] = accountType;
                        lblSuccess.Visible = true;
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
                        lblDisplay.Text = "";
                        lblSuccess.Text = "Sign in successfully! Welcome back <b>" + MerchantDS.Tables[0].Rows[0]["seller_site"].ToString() + "</b>"; //Give the first table that found in the dataset
                        Session["email"] = username;
                        Session["accountType"] = accountType;
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
    }
}