using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class UpdateVehicle : System.Web.UI.Page
    {
        vehicle_navigationEntities db = new vehicle_navigationEntities();
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null || Session["userType"] == "Passenger")
                Response.Redirect("~/");

            id = Request.QueryString["id"];
            if (Request.QueryString["id"] != null)
            {
                int vid = Convert.ToInt32(id);

                var vehicle = db.vehicles.Where(u => u.id == vid).FirstOrDefault();
                if (vehicle != null)
                {
                    Name.Text = vehicle.name;
                    model_name.Text = vehicle.model_name;
                    manufacturer_name.Text = vehicle.manufacturer_name;
                }
            }
            else
            {
                Response.Redirect("ViewVehicles.aspx");
            }
        }

        protected void UpdateVehicle_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int vid = Convert.ToInt32(id);

                var vehicle = db.vehicles.Where(v => v.id == vid).FirstOrDefault();
                if (vehicle != null)
                {
                    vehicle.name = Name.Text;
                    vehicle.model_name = model_name.Text;
                    vehicle.manufacturer_name = manufacturer_name.Text;

                    int res = db.SaveChanges();
                    if (res == 1) 
                    {
                        Response.Redirect("ViewVehicles.aspx?updated");
                    }
                }
            }

            Response.Redirect("ViewVehicles.aspx");
        }


    }
}