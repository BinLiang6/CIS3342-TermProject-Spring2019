using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;

namespace TermProject
{
    public partial class confirmation : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        ArrayList productlist = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showConfirm(ShowTotalPrice());

                // Set the SQLCommand object's properties for executing a Stored Procedure
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetCustomerInfo_By_Username";
                objCommand.Parameters.AddWithValue("@theID", Convert.ToInt32(Session["customerID"].ToString()));
                // Execute the stored procedure using the DBConnect object and the SQLCommand object
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                lblCustomer.Text = "Customer name: " + myDS.Tables[0].Rows[0]["name"].ToString() + "<br />" +
                                   "Shipping address: " +
                                         myDS.Tables[0].Rows[0]["address"].ToString() + ", " +
                                         myDS.Tables[0].Rows[0]["city"].ToString() + ", " +
                                         myDS.Tables[0].Rows[0]["state"].ToString() + ", " +
                                         myDS.Tables[0].Rows[0]["zipcode"].ToString();
            }
        }
        
        //Display the all of the product in the cart and the toal cost
        public void showConfirm(double totalcost)
        {
            gvConfirm.Columns[0].FooterText = "Total";
            gvConfirm.Columns[4].FooterText = totalcost.ToString("C2");
            productlist = (ArrayList)Session["Productlist"];
            gvConfirm.DataSource = productlist;

            String[] productid = new string[1];
            productid[0] = "product_id";
            gvConfirm.DataKeyNames = productid;
            gvConfirm.DataBind();
        }

        //Calculate the total cost of the cart
        public double ShowTotalPrice()
        {
            productlist = (ArrayList)Session["Productlist"];
            double total = 0.0;
            foreach (Product p in productlist)
            {
                double price = p.Price;
                int quantity = p.Quantity;
                total += p.TotalCost(p.Price, p.Quantity);
            }

            return total;
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            objCommand.Parameters.Clear();
            // Set the SQLCommand object's properties for executing a Stored Procedure
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCustomerInfo_By_Username";
            objCommand.Parameters.AddWithValue("@theID", Convert.ToInt32(Session["customerID"].ToString()));
            // Execute the stored procedure using the DBConnect object and the SQLCommand object
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            Email objEmail = new Email();
            String strTO = myDS.Tables[0].Rows[0]["email"].ToString();
            String strFROM = "amazon-cis3342@temple.edu";
            String strSubject = "Order confirmation";
            String strMessage = "";
            for (int row = 0; row < gvConfirm.Rows.Count; row++)
            {
                strMessage = gvConfirm.Rows[row].Cells[1].Text.ToString() + " | " + gvConfirm.Rows[row].Cells[2].Text.ToString() + " | Quantity: " 
                            + gvConfirm.Rows[row].Cells[3].Text.ToString() + " | Price: $" + gvConfirm.Rows[row].Cells[4].Text.ToString() + "<br />";
            }

            try
            {
                objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                lblDisplay.Text = strMessage;
            }
            catch (Exception ex)
            {
                lblDisplay.Text = "Error: " + ex.Message;
            }
        }
    }
}