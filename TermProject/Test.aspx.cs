using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using Utilities;
using ClassLibrary;

namespace TermProject
{
    public partial class Test : System.Web.UI.Page
    {
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetDepartment_Click(object sender, EventArgs e)
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

            gvDepartment.DataSource = departments;
            gvDepartment.DataBind();

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

        protected void btnAddMerchant_Click(object sender, EventArgs e)
        {
            try
            {
                url = url + "Register/Merchant/";
                Merchant merchant = new Merchant();

                merchant.Seller_site = txtUsername.Text;
                merchant.Desc = txtDesc.Text;
                merchant.Email = txtEmail.Text;
                merchant.Phone = txtPhone.Text;

                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsonMerchant = js.Serialize(merchant);

                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentLength = jsonMerchant.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonMerchant);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(theDataStream);
                String data = streamReader.ReadToEnd();
                streamReader.Close();
                response.Close();

                if (data == "true")
                {
                    lblNotify.Text = "Successfully added a merchant!";
                }
                else
                {
                    lblNotify.Text = "An error occurred! The username is already exists!";
                }

                lblNotify.Visible = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        protected void RecordPurchase_Click(object sender, EventArgs e)
        {
            url = url + "Record/Purchase/";

            Order order = new Order();
            order.Customer_ID = Int32.Parse(txtCustomerID.Text);
            order.Product_ID = Int32.Parse(txtProductID.Text);
            order.Quantity = Int32.Parse(txtQTY.Text);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonMerchant = js.Serialize(order);

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = jsonMerchant.Length;
            request.ContentType = "application/json";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(jsonMerchant);
            writer.Flush();
            writer.Close();

            WebResponse response = request.GetResponse();
            Stream theDataStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(theDataStream);
            String data = streamReader.ReadToEnd();
            streamReader.Close();
            response.Close();

            if (data == "true")
            {
                lblNotify2.Text = "Successfully added a merchant!";
            }
            else
            {
                lblNotify2.Text = "An error occurred! Please try again";
            }

            lblNotify2.Visible = true;
        }
    }
}