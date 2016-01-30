using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Login : System.Web.UI.Page
    {
        vehicle_navigationEntities db = new vehicle_navigationEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {

                var user = db.users.Where(u => u.email == Email.Text && u.password == Password.Text).FirstOrDefault();
                if (user == null)
                {
                    //incorerct
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;

                }
                else
                {
                    Session["userid"] = user.id;
                    Session["name"] = user.name;
                    Session["userType"] = user.userType;

                    Response.Redirect("~/");

                }

            }
        }

    }
}