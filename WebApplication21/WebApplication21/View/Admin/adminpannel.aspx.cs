using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication21.View.Admin
{
    public partial class adminpannel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin_id"]!=null)
            {
                Response.Write(Session["admin_id"].ToString());
            }
            else
            {
                Response.Redirect("~/View/Admin/login.aspx");
            }

        }
    }
}