using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        vehicle_navigationEntities db = new vehicle_navigationEntities();

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
                db.users.Add(usr);
                int res = db.SaveChanges();

                if (res == 1)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    ErrorMessage.Text = "There is an error to create your account please try again.";
                }
            }

        }
    }
}