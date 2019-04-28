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
    public partial class merchant_forgot_password : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objComm = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            

            if (txtEmail.Text == "" ||  txtAPIKey.Text == "")
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
            if(txtNewPassword.Text == "")
            {
                lblPassword.Text = "Please enter your new password";
                lblPassword.Visible = true;
            }
            else if(txtNewPassword.Text == txtConfirmPassword.Text )
            {
                string emailaddress = Session["email"].ToString();
                string apikey = Session["apikey"].ToString();
                string password = txtNewPassword.Text;

                try
                {
                    lblPassword.Visible = false ;
                    objComm.CommandType = CommandType.StoredProcedure;
                    objComm.CommandText = "TP_UpdateMerchantPassword";

                    objComm.Parameters.AddWithValue("@email", emailaddress);
                    objComm.Parameters.AddWithValue("@apikey", apikey);
                    objComm.Parameters.AddWithValue("@password", password);

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