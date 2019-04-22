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
    public partial class CustomerAccount : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAccountInfo();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String password = txtConfirmPassword.Text;
            if (txtPassword.Text == "")
            {
                lblDisplay.Text = "Please enter your current password";
                txtPassword.Focus();
            }
            else if (txtPassword.Text != Session["password"].ToString())
            {
                lblDisplay.Text = "Please enter correct current password";
                txtPassword.Focus();
            }
            else if (txtPassword.Text == Session["password"].ToString())
            {
                if (txtNewPassword.Text == "")
                {
                    lblDisplay.Text = "Please enter your new password";
                    txtNewPassword.Focus();
                }
                else if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    lblDisplay.Text = "";
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_ResetPassword";
                    objCommand.Parameters.AddWithValue("@thePassword", password);
                    objCommand.Parameters.AddWithValue("@theUsername", Session["username"].ToString());
                    objDB.DoUpdateUsingCmdObj(objCommand);

                    lblSuccess.Visible = true;
                }
                else
                {
                    txtConfirmPassword.Focus();
                    lblDisplay.Text = "Passwords do not match. Please enter again";
                }
            }
        }

        protected void ShowAccountInfo()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCustomer_ByUsername";
            objCommand.Parameters.AddWithValue("@theUsername", Session["username"].ToString());
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvAccountInfo.DataSource = myDataSet;
            gvAccountInfo.DataBind();
        }

        protected void gvAccountInfo_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            // Set the row to edit-mode in the GridView
            gvAccountInfo.EditIndex = e.NewEditIndex;
            ShowAccountInfo();
        }

        protected void gvAccountInfo_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            // Set the GridView back to the original state
            // No rows currently being edited
            gvAccountInfo.EditIndex = -1;
            ShowAccountInfo();
        }

        protected void gvAccountInfo_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //int rowIndex = e.RowIndex;
            //int id = int.Parse(gvAccountInfo.Rows[rowIndex].Cells[0].Text);
            //TextBox TBox;
            //TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[1].Controls[0];
            //String name = TBox.Text;
            //TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[2].Controls[0];
            //String url = TBox.Text;

            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "";
            //objCommand.Parameters.AddWithValue("@theName", name);
            //objCommand.Parameters.AddWithValue("@theURL", url);
            //objCommand.Parameters.AddWithValue("@theID", id);
            //objDB.DoUpdateUsingCmdObj(objCommand);

            gvAccountInfo.EditIndex = -1;
            ShowAccountInfo();
        }
    }
}