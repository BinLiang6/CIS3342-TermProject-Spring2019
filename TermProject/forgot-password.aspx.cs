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
    public partial class forgot_password : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Session.Add("username", "");
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
                    Session["username"] = myDataSet.Tables[0].Rows[0]["username"].ToString();
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
            }
            else
            {
                lblAnswer.Text = "Please provide correct answers to all questions";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String password = txtConfirmPassword.Text;

            if (txtNewPassword.Text == "")
            {
                lblPassword.Text = "Please enter your new password";
            }
            else if (txtNewPassword.Text == txtConfirmPassword.Text)
            {
                lblPassword.Text = "";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ResetPassword";
                objCommand.Parameters.AddWithValue("@thePassword", password);
                objCommand.Parameters.AddWithValue("@theUsername", Session["username"].ToString());
                objDB.DoUpdateUsingCmdObj(objCommand);

                lblSuccess.Visible = true;
                Session.Clear();
                Response.AddHeader("REFRESH", "3;URL=login.aspx");
            }
            else
            {
                txtConfirmPassword.Focus();
                lblPassword.Text = "Passwords do not match. Please enter again";
            }
        }
    }
}