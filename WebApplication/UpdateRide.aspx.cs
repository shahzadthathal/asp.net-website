using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class UpdateRide : System.Web.UI.Page
    {
        vehicle_navigationEntities db = new vehicle_navigationEntities();
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userid"] == null)
                Response.Redirect("~/");

            id = Request.QueryString["id"];
            if (Request.QueryString["id"] != null)
            {
                int vid = Convert.ToInt32(id);

                var vehicle = db.ride_detail.Where(r => r.id == vid).FirstOrDefault();
                if (vehicle != null)
                {
                    //Name.Text = vehicle.name;
                    //model_name.Text = vehicle.model_name;
                    //manufacturer_name.Text = vehicle.manufacturer_name;
                }
            }
            else
            {
                Response.Redirect("ViewRides.aspx");
            }


        }
    }
}