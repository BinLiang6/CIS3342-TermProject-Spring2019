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
    public partial class ManagerAccount : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objcomm = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCustomerReport_Click(object sender, EventArgs e)
        {
            try
            {
                objcomm.CommandType = CommandType.StoredProcedure;
                objcomm.CommandText = "TP_GetCustomerSales";

                DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);
                gvCustomerSales.DataSource = ds;
                gvCustomerSales.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        protected void btnSearchInventory_Click(object sender, EventArgs e)
        {
            

            if(txtQuantity.Text == "")
            {
                lblDisplay.Visible = true;
            }
            else
            {
                lblDisplay.Visible = false;
                string qty = txtQuantity.Text;


                try
                {
                    objcomm.CommandType = CommandType.StoredProcedure;
                    objcomm.CommandText = "TP_GetInventoryReport";

                    objcomm.Parameters.AddWithValue("@quantity", qty);

                    DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

                    gvInventory.DataSource = ds;
                    gvInventory.DataBind();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        protected void btnSalesReport_Click(object sender, EventArgs e)
        {
            try
            {
                objcomm.CommandType = CommandType.StoredProcedure;
                objcomm.CommandText = "TP_GetAmazonSales";

                DataSet ds = objDB.GetDataSetUsingCmdObj(objcomm);

                gvAmazonSales.DataSource = ds;
                gvAmazonSales.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}