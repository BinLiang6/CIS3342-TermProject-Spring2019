using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;

namespace TermProject
{
    public partial class ShoppingSite : System.Web.UI.Page
    {
        DBConnect objdb = new DBConnect();
        SqlCommand objcomm = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "TP_GetDepartments";

            ddlDepartment.DataSource = objdb.GetDataSetUsingCmdObj(objcomm);
            ddlDepartment.DataTextField = "name";
            ddlDepartment.DataValueField = "department_id";

            ddlDepartment.DataBind();


        }
    }
}