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
    public partial class MerchantRegistration : System.Web.UI.Page
    {
        string url = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tug13955/TermProjectWS/api/service/Merchants/";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddMerchant_Click(object sender, EventArgs e)
        {
            try
            {
                url = url + "Register/Merchant/";
                Merchant merchant = new Merchant();

                merchant.Seller_site = txtUsername.Text;
                merchant.Desc = txtDesc.Text;
                merchant.Url = txtUrl.Text;
                merchant.Address = txtAddress.Text;
                merchant.City = txtCity.Text;
                merchant.State = txtState.Text;
                merchant.ZipCode = Int32.Parse(txtZipcode.Text);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}