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
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            
            if (username == "")
            {
                txtUsername.Focus();
                lblDisplay.Text = "Please enter your username";
            }
            else if (password == "")
            {
                txtPassword.Focus();
                lblDisplay.Text = "Please enter your password";
            }
            else
            {
                // Set the SQLCommand object's properties for executing a Stored Procedure
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetLogIn";
                objCommand.Parameters.AddWithValue("@theUsername", username);
                objCommand.Parameters.AddWithValue("@thePassword", password);
                // Execute the stored procedure using the DBConnect object and the SQLCommand object
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                try
                {
                    lblDisplay.Text = "";
                    lblSuccess.Text = "Sign in successfully! Welcome back <b>" + myDataSet.Tables[0].Rows[0]["name"].ToString() + "</b>"; //Give the first table that found in the dataset
                    lblSuccess.Visible = true;
                    Response.AddHeader("REFRESH", "3;URL=Test.aspx");
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