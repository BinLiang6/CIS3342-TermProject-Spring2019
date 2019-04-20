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
using ClassLibrary;

namespace TermProject
{
    public partial class Cart : System.Web.UI.Page
    {
        ArrayList productlist = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCart(ShowTotalPrice());             
            }
        }

        //Display the all of the product in the cart and the toal cost
        public void showCart(double totalcost)
        {
            gvCart.Columns[0].FooterText = "Total";
            gvCart.Columns[4].FooterText = totalcost.ToString("C2");
            productlist = (ArrayList)Session["Productlist"];
            gvCart.DataSource = productlist;
            gvCart.DataBind();
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

        //Edit the selecting row
        protected void gvCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCart.EditIndex = e.NewEditIndex;

            showCart(ShowTotalPrice());
        }

        //Canceling the edit row
        protected void gvCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCart.EditIndex = -1;

            showCart(ShowTotalPrice());
        }

        //Update the selected row
        protected void gvCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            productlist = (ArrayList)Session["Productlist"];

            Product product = (Product)productlist[rowIndex];

            TextBox TBox;
            TBox = (TextBox)gvCart.Rows[rowIndex].Cells[3].Controls[0];
            int quantity = Int32.Parse(TBox.Text);
            product.Quantity = quantity;

            Session["ProductList"] = productlist;
            gvCart.EditIndex = -1;
            showCart(ShowTotalPrice());

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            
        }

        //Deleting the selected row
        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int row = e.RowIndex;
            productlist = (ArrayList)Session["Productlist"];

            productlist.RemoveAt(row);

            Session["ProductList"] = productlist;

            showCart(ShowTotalPrice());
        }
    }
}