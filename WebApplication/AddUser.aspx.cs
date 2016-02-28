using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class AddUser : System.Web.UI.Page
    {
        vehicle_navigationEntities db = new vehicle_navigationEntities();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null || Session["userType"] != "Admin")
                Response.Redirect("~/");

        }
        
        protected void CreateUser_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {

                user usr = new user();

                usr.name = Name.Text;
                usr.email = Email.Text;
                usr.password = Password.Text;
                usr.phone = Phone.Text;
                usr.nic = NIC.Text;
                usr.userType = UserType.Text;
                usr.street = Street.Text;
                usr.city = City.Text;
                db.users.Add(usr);
                int res = db.SaveChanges();

                if (res == 1)
                {
                    Response.Redirect("ViewUser.aspx");
                }
                else
                {
                    ErrorMessage.Text = "There is an error to create account please try again.";
                }
            }

        }
    }
}