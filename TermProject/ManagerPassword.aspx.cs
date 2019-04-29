using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class ManagerPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Session["manager"] = "AMAZON";
                
            if (txtPassword.Text == "AMAZON")
            {
                Response.Redirect("ManagerAccount.aspx");
            }
            else
            {
                lblDisplay.Visible = true;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}