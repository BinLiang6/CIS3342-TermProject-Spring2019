using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Web.Script.Serialization;
using System.Net;
using Utilities;
using ClassLibrary;
using System.Runtime.Serialization.Formatters.Binary;       //needed for BinaryFormatter
using System.IO;                                            //needed for the MemoryStream

namespace TermProject
{
    public partial class Cart : System.Web.UI.Page
    {
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/Record/Purchase/";

        ArrayList productlist = new ArrayList();

        DBConnect objDB = new DBConnect();

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
            String sql = "SELECT cart FROM TP_Customer WHERE customer_id = '" + Session["customerID"].ToString() + "'";
            objDB.GetDataSet(sql);

            //if (objDB.GetField("cart", 0) != System.DBNull.Value)
            //{
            //    // De-serialize the binary data to reconstruct the CreditCard object retrieved
            //    // from the database
            //    Byte[] byteArray = (Byte[])objDB.GetField("cart", 0);

            //    BinaryFormatter deSerializer = new BinaryFormatter();
            //    MemoryStream memStream = new MemoryStream(byteArray);

            //    Product product = (Product)deSerializer.Deserialize(memStream);

            //    productlist = (ArrayList)Session["Productlist"];
            //    productlist.Add(product);

            //    gvCart.DataSource = productlist;
            //    gvCart.DataBind();
            //}
            //else if (objDB.GetField("cart", 0) == System.DBNull.Value)
            //{

            //}

            gvCart.Columns[0].FooterText = "Total";
            gvCart.Columns[4].FooterText = totalcost.ToString("C2");
            productlist = (ArrayList)Session["Productlist"];
            gvCart.DataSource = productlist;

            String[] productid = new string[1];
            productid[0] = "product_id";
            gvCart.DataKeyNames = productid;
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

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            //Retrieve the products in the cart
            //productlist = (ArrayList)Session["Productlist"];
            Product product = new Product();
            // Serialize a City object into a JSON string
            JavaScriptSerializer js = new JavaScriptSerializer();

            //Adding each product into the database
            for (int row = 0; row < gvCart.Rows.Count; row++)
            {
                product.Quantity = Convert.ToInt32(gvCart.Rows[row].Cells[3].Text);
                product.Customer_ID = Convert.ToInt32(Session["customerID"].ToString());
                product.Product_ID = Convert.ToInt32(gvCart.DataKeys[row].Value.ToString());

                String jsonCheckout = js.Serialize(product);

                try
                {
                    // Send the City object to the Web API that will be used to store a new city record in the database.
                    // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                    WebRequest request = WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentLength = jsonCheckout.Length;
                    request.ContentType = "application/json";

                    // Write the JSON data to the Web Request
                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonCheckout);
                    writer.Flush();
                    writer.Close();

                    // Read the data from the Web Response, which requires working with streams.
                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    if (data == "true")
                    {
                        lblSuccess.Visible = true;
                    }
                    else
                    {
                        lblDisplay.Text = "A problem occurred while adding the city to the database. The data wasn't recorded.";
                    }

                    //Response.AddHeader("REFRESH", "3;URL=confirmation.aspx");
                    Response.Redirect("confirmation.aspx");
                }
                catch (Exception ex)
                {
                    lblDisplay.Text = "Error: " + ex.Message;
                }
            }
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