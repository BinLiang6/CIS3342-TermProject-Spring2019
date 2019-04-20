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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArrayList productlist = (ArrayList) Session["Productlist"];

                gvCart.DataSource = productlist;
                gvCart.DataBind();
            }
        }
        public void showCart()
        {
            ArrayList productlist = (ArrayList)Session["Productlist"];
            gvCart.DataSource = productlist;
            gvCart.DataBind();
        }
        protected void gvCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCart.EditIndex = e.NewEditIndex;

            showCart();
        }

        protected void gvCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCart.EditIndex = -1;

            showCart();
        }

        protected void gvCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            ArrayList productlist = (ArrayList)Session["Productlist"];

            Product product = (Product)productlist[rowIndex];

            TextBox TBox;
            TBox = (TextBox)gvCart.Rows[rowIndex].Cells[4].Controls[0];
            int quantity = Int32.Parse(TBox.Text);
            product.Quantity = quantity;

            Session["ProductList"] = productlist;
            gvCart.EditIndex = -1;
            showCart();

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            
        }

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int row = e.RowIndex;
            ArrayList productlist = (ArrayList)Session["Productlist"];

            productlist.RemoveAt(row);

            Session["ProductList"] = productlist;

            showCart();
        }
    }
}