using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class SiteMaster : MasterPage
    {
        string userType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null) 
            {
                showlisting.Visible = true;
                showlogout.Visible = true;
                showlogin.Visible = false;

                 userType = Session["userType"].ToString();
                 if (userType == "Admin")
                 {
                     showUser.Visible = true;
                 }
                 else
                 {
                     showUser.Visible = false;
                 }
            }
            else
            {
                showlisting.Visible = false;
                showlogout.Visible = false;
                showlogin.Visible = true;
                showUser.Visible = false;
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Login.aspx");
        }

    }
}