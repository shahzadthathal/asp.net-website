using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class UpdateUser : System.Web.UI.Page
    {

        vehicle_navigationEntities db = new vehicle_navigationEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null || Session["userType"] != "Admin")
                Response.Redirect("~/");


            String id = Request.QueryString["id"];
            if (Request.QueryString["id"] != null)
            {
                int userid = Convert.ToInt32(id);

                var usr = db.users.Where(u => u.id == userid).FirstOrDefault();
                if (usr != null)
                {
                    Name.Text = usr.name;
                    Email.Text = usr.name;
                    Password.Text = usr.password;
                    ConfirmPassword.Text = usr.password;
                    Phone.Text = usr.phone;
                    NIC.Text = usr.nic;
                    UserType.Text = usr.userType;

                }
            
            }
            else{
                Response.Redirect("ViewUser.aspx");
            }
               
        }

        protected void UpdateUser_Click(object sender, EventArgs e)
        {

            Response.Redirect("ViewUser.aspx");
        }
    }
}