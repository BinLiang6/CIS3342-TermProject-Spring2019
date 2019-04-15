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

namespace TermProject
{
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        DBConnect objconn = new DBConnect();
        SqlCommand objcommand = new SqlCommand();
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
                Customer customer = new Customer();
                customer.Name = txtName.Text;
                customer.Username = txtUsername.Text;
                customer.Password = txtPassword.Text;
                customer.Email = txtEmail.Text;
                customer.Address = txtAddress.Text;
                customer.Phone = txtPhone.Text;
                customer.Sq1 = txtSq1.Text;
                customer.Sq2 = txtSq2.Text;
                customer.Sq3 = txtSq3.Text;

                if(customer != null)
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
                        objcommand.Parameters.AddWithValue("@phone", customer.Phone);
                        objcommand.Parameters.AddWithValue("@email", customer.Email);
                        objcommand.Parameters.AddWithValue("@sq1", customer.Sq1);
                        objcommand.Parameters.AddWithValue("@sq2", customer.Sq2);
                        objcommand.Parameters.AddWithValue("@sq3", customer.Sq3);

                        int result = objconn.DoUpdateUsingCmdObj(objcommand);

                        if(result == -1)
                        {
                            lblNotif.Text = "An error occurred. Please try again!";
                        }
                        else
                        {
                            lblNotif.Text = "Successfully created an account";
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
                lblNotif.Text = "The username and email are taken";
            }
            

        }
    }
}