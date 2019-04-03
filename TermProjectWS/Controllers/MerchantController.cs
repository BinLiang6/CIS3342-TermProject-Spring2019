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
    }
}