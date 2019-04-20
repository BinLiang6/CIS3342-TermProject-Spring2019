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
using System.Data;
using System.Data.SqlClient;

namespace TermProject
{
    public partial class ShoppingSite : System.Web.UI.Page
    {
        DBConnect objdb = new DBConnect();
        SqlCommand objcomm = new SqlCommand();
        int count = 1 ;
        ArrayList productlist = new ArrayList();
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            // url = url + "GetDepartments/";
            else if (!IsPostBack)
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                Department[] departments = js.Deserialize<Department[]>(data);

                ddlDepartment.DataSource = departments;
                ddlDepartment.DataTextField = "name";
                ddlDepartment.DataValueField = "department_id";
                ddlDepartment.DataBind();

                ViewState["cart"] = lbCart.Text;

                DisplayProduct();
            }
            
        public void DisplayProduct()
        {
            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "TP_GetAllProducts";

            DataSet ds = objdb.GetDataSetUsingCmdObj(objcomm);

            gvProducts.DataSource = ds;
            gvProducts.DataBind();
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
        protected void btnGetProduct_Click(object sender, EventArgs e)
        {

            int departmentnumber = Int32.Parse(ddlDepartment.SelectedValue);
            url = url + "GetProductCatalog/" + departmentnumber.ToString();

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Product[] products = js.Deserialize<Product[]>(data);

            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewState["count"] != null)
            {
                count = (int)ViewState["count"] + 1;
            }
            
            lbCart.Text = ViewState["cart"].ToString() + " (" + count.ToString() + ")";
            ViewState["count"] = count;

            Product product = new Product();
            product.Image = gvProducts.SelectedRow.Cells[0].Text;
            product.Title = gvProducts.SelectedRow.Cells[1].Text;
            product.Desc = gvProducts.SelectedRow.Cells[2].Text;
            product.Price = Convert.ToDouble(gvProducts.SelectedRow.Cells[3].Text);
            TextBox tb = (TextBox) gvProducts.SelectedRow.FindControl("txtQuantity");
            
            product.Quantity = Convert.ToInt32(tb.Text);

            if(ViewState["Productlist"] != null)
            {
                productlist = (ArrayList) ViewState["Productlist"];
                productlist.Add(product);
            }
            else
            {
                productlist.Add(product);
            }
            ViewState["Productlist"] = productlist;
            Session["Productlist"] = productlist;

        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            if (Session["Productlist"] != null)
            {
                Response.Redirect("Cart.aspx");
            }
            else
            {
                lblNotify.Text = "Your cart is empty!";
                lblNotify.Visible = true;
            }
            
        }

        protected void lbCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}