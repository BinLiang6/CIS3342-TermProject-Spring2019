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
                objCommand.Parameters.Clear();
                ShowOrderHistory();

                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetCustomer_SecurityQuestion";
                objCommand.Parameters.AddWithValue("@theID", Convert.ToInt32(Session["customerID"].ToString()));
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                txtSq1.Text = myDataSet.Tables[0].Rows[0]["sq1"].ToString();
                txtSq2.Text = myDataSet.Tables[0].Rows[0]["sq2"].ToString();
                txtSq3.Text = myDataSet.Tables[0].Rows[0]["sq3"].ToString();
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
                    txtPassword.Text = ""; txtNewPassword.Text = ""; txtConfirmPassword.Text = ""; 
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
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCustomer_ByUsername";
            objCommand.Parameters.AddWithValue("@theUsername", Session["username"].ToString());
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvAccountInfo.DataSource = myDataSet;
            gvAccountInfo.DataBind();
        }

        protected void ShowOrderHistory()
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetOrderHistory";
            objCommand.Parameters.AddWithValue("@theID", Convert.ToInt32(Session["customerID"].ToString()));
            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

            gvOrder.DataSource = myDataSet;
            gvOrder.DataBind();
        }

        protected void gvAccountInfo_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            lblSuccess.Visible = false;
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
            int rowIndex = e.RowIndex;
            TextBox TBox;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[0].Controls[0];
            String username = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[1].Controls[0];
            String name = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[2].Controls[0];
            String address = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[3].Controls[0];
            String city = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[4].Controls[0];
            String state = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[5].Controls[0];
            String zip = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[6].Controls[0];
            String phone = TBox.Text;
            TBox = (TextBox)gvAccountInfo.Rows[rowIndex].Cells[7].Controls[0];
            String email = TBox.Text;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateAccountInfo";
            objCommand.Parameters.AddWithValue("@theID", Convert.ToInt32(Session["customerID"]));
            objCommand.Parameters.AddWithValue("@theUsername", username);
            objCommand.Parameters.AddWithValue("@theName", name);
            objCommand.Parameters.AddWithValue("@theAddress", address);
            objCommand.Parameters.AddWithValue("@theCity", city);
            objCommand.Parameters.AddWithValue("@theState", state);
            objCommand.Parameters.AddWithValue("@theZip", zip);
            objCommand.Parameters.AddWithValue("@thePhone", phone);
            objCommand.Parameters.AddWithValue("@theEmail", email);
            objDB.DoUpdateUsingCmdObj(objCommand);

            gvAccountInfo.EditIndex = -1;
            ShowAccountInfo();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtSq1.ReadOnly = false;
            txtSq2.ReadOnly = false;
            txtSq3.ReadOnly = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtSq1.ReadOnly = true;
            txtSq2.ReadOnly = true;
            txtSq3.ReadOnly = true;
            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;

            lblSecurity.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSq1.Text == "" || txtSq2.Text == "" || txtSq3.Text == "")
            {
                lblSecurity.Text = "Please answer all questions";
            }
            else
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateSecurityQuestion";
                objCommand.Parameters.AddWithValue("@theID", Convert.ToInt32(Session["customerID"]));
                objCommand.Parameters.AddWithValue("@theSQ1", txtSq1.Text);
                objCommand.Parameters.AddWithValue("@theSQ2", txtSq2.Text);
                objCommand.Parameters.AddWithValue("@theSQ3", txtSq3.Text);
                objDB.DoUpdateUsingCmdObj(objCommand);

                txtSq1.ReadOnly = true;
                txtSq2.ReadOnly = true;
                txtSq3.ReadOnly = true;
                btnEdit.Visible = true;
                btnSave.Visible = false;
                btnCancel.Visible = false;

                lblSecurity.Text = "";
            }
        }
    }
}