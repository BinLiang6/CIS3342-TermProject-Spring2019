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
        public Boolean RecordPurchase(int quantity, int product_id, String apikey, String seller_site, [FromBody]CustomerInfo customer)
        {


            if (customer != null)
            {
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddOrder";
                objCommand.Parameters.AddWithValue("@theQuantity", quantity);
                objCommand.Parameters.AddWithValue("@theProductID", product_id);
                objCommand.Parameters.AddWithValue("@theAPI", apikey);
                objCommand.Parameters.AddWithValue("@theSeller", seller_site);
                objCommand.Parameters.AddWithValue("@theName", customer.Name);
                objCommand.Parameters.AddWithValue("@theAddress", customer.Address);
                objCommand.Parameters.AddWithValue("@thePhone", customer.Phone);
                objCommand.Parameters.AddWithValue("@theEmail", customer.Email);

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