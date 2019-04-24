using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;
using Utilities;
using ClassLibrary;
using System.Security.Cryptography;

namespace TermProjectWS.Controllers
{
    [Produces("application/json")]
    [Route("api/service/Merchants")]
    public class MerchantController : Controller
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        //API Get departments
        [HttpGet]
        [HttpGet("GetDepartments")]
        public List<Department> GetDepartments()
        {
            List<Department> deparmentList = new List<Department>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetDepartments";
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                Department deparment = new Department();
                deparment.Department_ID = int.Parse(objDB.GetField("department_id", i).ToString());
                deparment.Name = objDB.GetField("name", i).ToString();

                deparmentList.Add(deparment);
            }

            return deparmentList;
        }

        //API Get products
        [HttpGet("GetProductCatalog/{DepartmentNumber}")]
        public List<Product> GetProductCatalog(int DepartmentNumber)
        {
            List<Product> productList = new List<Product>();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProductCatalog_By_DepartmentNumber";
            objCommand.Parameters.AddWithValue("@theDepartment", DepartmentNumber);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            int count = myDS.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                Product product = new Product();
                product.Product_ID = int.Parse(objDB.GetField("product_id", i).ToString());
                product.Desc = objDB.GetField("desc", i).ToString();
                product.Price = double.Parse(objDB.GetField("price", i).ToString());
                product.Image = objDB.GetField("image", i).ToString();
                productList.Add(product);
            }

            return productList;
        }

        //API Register merchants
        [HttpPost()]
        [HttpPost("Register/Merchant")]
        public Boolean RegisterMerchant([FromBody]Merchant merchant)
        {
            //Generate an API key
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            merchant.Apikey = Convert.ToBase64String(key);

            //Check if there is already an username stored in the database
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMerchant_By_ApiKeyAndSeller";
            objCommand.Parameters.AddWithValue("@theAPI", merchant.Apikey);
            objCommand.Parameters.AddWithValue("@theSeller", merchant.Seller_site);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables[0].Rows.Count == 0) //If there is no other apikey or username already exists
            {
                if (merchant != null)
                {
                    objCommand.Parameters.Clear();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_AddMerchant";
                    objCommand.Parameters.AddWithValue("@theAPI", merchant.Apikey);
                    objCommand.Parameters.AddWithValue("@theSeller", merchant.Seller_site);
                    objCommand.Parameters.AddWithValue("@theDesc", merchant.Desc);
                    objCommand.Parameters.AddWithValue("@theEmail", merchant.Email);
                    objCommand.Parameters.AddWithValue("@thePhone", merchant.Phone);
                    objCommand.Parameters.AddWithValue("@theUrl", merchant.Url);
                    objCommand.Parameters.AddWithValue("@theAddress", merchant.Address);
                    objCommand.Parameters.AddWithValue("@theCity", merchant.City);
                    objCommand.Parameters.AddWithValue("@theState", merchant.State);
                    objCommand.Parameters.AddWithValue("@theZipcode", merchant.ZipCode);
                    objCommand.Parameters.AddWithValue("@thePassword", merchant.Password);

                    int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

                    if (returnValue > 0)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }
            else { return false; } //Return false if APIKey or username already exists
        }

        //API Record purchase
        [HttpPost()]
        [HttpPost("Record/Purchase")]
        public Boolean RecordPurchase([FromBody]Product product, [FromBody]Customer customer)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProduct_By_ProductID";
            objCommand.Parameters.AddWithValue("@theID", product.Product_ID);
            DataSet apikeyDS = objDB.GetDataSetUsingCmdObj(objCommand);
            product.Apikey = apikeyDS.Tables[0].Rows[0]["apikey"].ToString();

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetSeller_By_APIKey";
            objCommand.Parameters.AddWithValue("@theAPI", product.Apikey);
            DataSet sellerDS = objDB.GetDataSetUsingCmdObj(objCommand);
            product.Seller_site = sellerDS.Tables[0].Rows[0]["seller_site"].ToString();

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCustomerInfo_By_Username";
            objCommand.Parameters.AddWithValue("@theID", product.Customer_ID);
            DataSet custDS = objDB.GetDataSetUsingCmdObj(objCommand);
            product.Name = custDS.Tables[0].Rows[0]["name"].ToString();
            product.Address = custDS.Tables[0].Rows[0]["address"].ToString();
            product.City = custDS.Tables[0].Rows[0]["city"].ToString();
            product.State = custDS.Tables[0].Rows[0]["state"].ToString();
            product.ZipCode = custDS.Tables[0].Rows[0]["zipcode"].ToString();
            product.Phone = custDS.Tables[0].Rows[0]["phone"].ToString();
            product.Email = custDS.Tables[0].Rows[0]["email"].ToString();

            if (product != null)
            {
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddOrder";
                objCommand.Parameters.AddWithValue("@theQuantity", product.Quantity);
                objCommand.Parameters.AddWithValue("@theProductID", product.Product_ID);
                objCommand.Parameters.AddWithValue("@theAPI", product.Apikey);
                objCommand.Parameters.AddWithValue("@theSeller", product.Seller_site);
                objCommand.Parameters.AddWithValue("@theID", product.Customer_ID);
                objCommand.Parameters.AddWithValue("@theName", product.Name);
                objCommand.Parameters.AddWithValue("@theAddress", product.Address);
                objCommand.Parameters.AddWithValue("@theCity", product.City);
                objCommand.Parameters.AddWithValue("@theState", product.State);
                objCommand.Parameters.AddWithValue("@theZipcode", product.ZipCode);
                objCommand.Parameters.AddWithValue("@thePhone", product.Phone);
                objCommand.Parameters.AddWithValue("@theEmail", product.Email);
                int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

                if (returnValue > 0)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}