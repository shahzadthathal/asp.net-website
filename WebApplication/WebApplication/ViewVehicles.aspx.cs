using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class ViewVehicles : System.Web.UI.Page
    {
        vehicle_navigationEntities db = new vehicle_navigationEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null || Session["userType"] == "Passenger")
                Response.Redirect("~/");

            if (!IsPostBack)
                PopulateGridViwData();

        }

        protected void PopulateGridViwData()
        {
            string userType = Session["userType"].ToString();

            if (userType == "Driver")
            {
                int userid = Convert.ToInt32(Session["userid"]);

                var data = db.vehicles.Where(v => v.ownerId == userid).Join(db.users, v => v.ownerId, u => u.id, (v, u) => new { v = v, ownername = u.name }).OrderByDescending(v => v.v.id);
                 GridView1.DataSource = data.ToList();
                 GridView1.DataBind();
            }
            else if (userType == "Admin")
            {
              var  data = db.vehicles.Join(db.users, v => v.ownerId, u => u.id, (v, u) => new { v = v, ownername = u.name }).OrderByDescending(v => v.v.id);
              GridView1.DataSource = data.ToList();
              GridView1.DataBind();
            
            }
           

            //var data = db.vehicles.Select(p => p);
           

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "edit")
            {
                GridView1.EditIndex = -1;
                String id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                //Response.Redirect("WF11_EditJob.aspx?id=" + id);
                Response.Redirect("UpdateVehicle.aspx?id=" + id);
            }

           
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = SearchText.Text;
            string userType = Session["userType"].ToString();

            if (searchText != String.Empty && userType == "Admin")
            {
               
                    var data = db.vehicles.Where(s=>s.name.Contains(searchText)||s.model_name.Contains(searchText)|| s.manufacturer_name.Contains(searchText) ).Join(db.users, v => v.ownerId, u => u.id, (v, u) => new { v = v, ownername = u.name }).OrderByDescending(v => v.v.id);
                    GridView1.DataSource = data.ToList();
                    GridView1.DataBind();

            }
        }


    }
}