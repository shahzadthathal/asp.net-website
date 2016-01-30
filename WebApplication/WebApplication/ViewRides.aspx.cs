using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class ViewRides : System.Web.UI.Page
    {
        vehicle_navigationEntities db = new vehicle_navigationEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
                Response.Redirect("~/");

            if (!this.IsPostBack)
            {
                PopulateGridViwData();

               //this.BindGrid();
            }


        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            PopulateGridViwData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                /*if (e.Row.RowIndex == 0)     // This is row no.1
                    if (e.Row.Cells[2].Text == "1")
                        e.Row.Cells[2].BackColor = Color.Red;

                if (e.Row.RowIndex == 1)     // This is row no.2
                */
                if (e.Row.Cells[2].Text == "0")
                {
                    e.Row.Cells[2].BackColor = Color.Yellow;
                    e.Row.Cells[2].ForeColor = Color.White;
                    e.Row.Cells[2].Text = "Pending";
                }
                else if (e.Row.Cells[2].Text == "1")
                {
                    e.Row.Cells[2].BackColor = Color.BlueViolet;
                    e.Row.Cells[2].ForeColor = Color.White;
                    e.Row.Cells[2].Text = "Started";
                }
                else if (e.Row.Cells[2].Text == "2")
                {
                    e.Row.Cells[2].BackColor = Color.Green;
                    e.Row.Cells[2].ForeColor = Color.White;
                    e.Row.Cells[2].Text = "Finished";
                }
                else if (e.Row.Cells[2].Text == "3")
                {
                    e.Row.Cells[2].BackColor = Color.Red;
                    e.Row.Cells[2].ForeColor = Color.White;
                    e.Row.Cells[2].Text = "Rejected";
                } 
            }


            decimal TotalSales = (decimal)0.0;
            //int status;
            for (int i = 0; i < GridView1.Rows.Count; ++i)
            {
                TotalSales += Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text);

               /* status = Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);
                if (status == 0)
                {
                    GridView1.Rows[i].Cells[2].Text = "Pending";
                }
                else if (status == 1)
                {
                    GridView1.Rows[i].Cells[2].Text = "Started";
                }
                else if (status == 2)
                {
                    GridView1.Rows[i].Cells[2].Text = "Completed";
                }
                else if (status == 3)
                {
                    GridView1.Rows[i].Cells[2].Text = "Rejected";
                }*/

            }
            
            GridView1.Columns[8].FooterText = String.Format("{0:N2}", TotalSales);
           
        }




        protected void PopulateGridViwData()
        {
            // var data = db.vehicles.Join(db.users, v => v.ownerId, u => u.id, (v, u) => new { v = v, ownername=u.name}).OrderByDescending(v => v.v.id);

            string userType = Session["userType"].ToString();

            int userid = Convert.ToInt32(Session["userid"]);

            if (userType == "Driver")
            {

                //string driver  = db.users.Where(r=>r.id == userid).FirstOrDefault().name;

                var data = db.ride_detail.Where(r => r.driverID == userid)                   
                    //.Join(db.users, s => s.driverID, u => u.id, (s, d) => new { drivername=d.name})
                     .Join(db.users, r => r.passengerID, u => u.id, (r, u) => new { r = r, username = u.name })
                 .OrderByDescending(r => r.r.id); 

                GridView1.DataSource = data.ToList();

                GridView1.DataBind();

            }
            else if (userType == "Passenger")
            {
                //string passenger = db.users.Where(r => r.id == userid).FirstOrDefault().name;

                var data = db.ride_detail.Where(r => r.passengerID == userid)
                    .Join(db.users, r => r.driverID, u => u.id, (r, u) => new { r = r, username = u.name })
                   .OrderByDescending(r => r.r.id);

                GridView1.DataSource = data.ToList();
                GridView1.DataBind();

            }

            else if (userType == "Admin")
            {

                var data = db.ride_detail.Join(db.users, r => r.passengerID, u => u.id, (r, u) => new { r = r, username = u.name })
                   .OrderByDescending(r => r.r.id);

               // var data = db.ride_detail.Select(p => p);
                GridView1.DataSource = data.ToList();
                GridView1.DataBind();

            }

            
        }

        private void BindGrid()
        {
            string query = "SELECT TOP 30 OrderID,";
            query += "(SELECT ProductName FROM Products WHERE ProductID = details.ProductId) ProductName,";
            query += "(Quantity * UnitPrice) Price";
            query += " FROM [Order Details] details";
            query += " ORDER BY OrderID";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            //Calculate Sum and display in Footer Row
                            decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Price"));
                            GridView1.FooterRow.Cells[1].Text = "Total";
                            GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                            GridView1.FooterRow.Cells[2].Text = total.ToString("N2");
                        }
                    }
                }
            }
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
                Response.Redirect("UpdateRide.aspx?id=" + id);
            }

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = SearchText.Text;
            string userType = Session["userType"].ToString();

            if (userType == "Admin")
            {
                if (searchText != String.Empty)
                {

                    var data = db.ride_detail.Where(s => s.from_destination.Contains(searchText) || s.to_destination.Contains(searchText) || s.review.Contains(searchText)).Join(db.users, r => r.passengerID, u => u.id, (r, u) => new { r = r, username = u.name })
                     .OrderByDescending(r => r.r.id);

                    // var data = db.ride_detail.Select(p => p);
                    GridView1.DataSource = data.ToList();
                    GridView1.DataBind();

                }
                else
                {
                     var data = db.ride_detail.Select(p => p);
                    GridView1.DataSource = data.ToList();
                    GridView1.DataBind();

                }
            }

        }




    }
}