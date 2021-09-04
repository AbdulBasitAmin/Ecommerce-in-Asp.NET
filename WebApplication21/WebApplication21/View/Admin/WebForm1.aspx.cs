using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication21.Model;

namespace WebApplication21.View.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                selectdata sd = new selectdata();
              string s=  sd.returnscalar("select count(ad_id) from tbl_admin  where ad_email='"+txtemail.Text+"'");
              if (s=="0")
              {
                  admin a = new admin();
                  a.email = txtemail.Text;
                  a.password = txtpassword.Text;
                  a.phone = txtphone.Text;
                  insert i = new insert();
                  Session["admin_id"] = i.signup_admin(a);
                  if (Session["admin_id"]=="-1")
                  {
                        Label1.Text = "some exception ...plz try again...";
                  }
                  else
                  {
                      Response.Redirect("~/View/Admin/adminpannel.aspx");
  
                  }
  
              }
              else if (s=="1")
              {

                  Label1.Text = "Email Already Exist in database...";

              }
              else
              {
                  Label1.Text = "some exception ...plz try again...";
              }



                

            }
        }
    }
}