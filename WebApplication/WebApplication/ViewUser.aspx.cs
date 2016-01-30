using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class ViewUser : System.Web.UI.Page
    {
        vehicle_navigationEntities db = new vehicle_navigationEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                
                Response.Redirect("~/");
            }
            else
            {
                string userType = Session["userType"].ToString();
                if(userType !="Admin")
                    Response.Redirect("~/");
            }
                

            if(!IsPostBack)
                 PopulateGridViwData();
        }

        protected void PopulateGridViwData() 
        {
         
            var data = db.users.Select(p => p);
            GridView1.DataSource = data.ToList();
            GridView1.DataBind();

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "edit")
            {
                GridView1.EditIndex = -1;
                String id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                //Response.Redirect("WF11_EditJob.aspx?id=" + id);
                Response.Redirect("UpdateUser.aspx?id=" + id);
            }

            else if (e.CommandName.ToLower() == "delete")
            {
                GridView1.EditIndex = -1;
                String id = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                DeleteUser(Convert.ToInt32(id));
            }
        }

        protected void DeleteUser(int id) 
        {
           // db.users.Remove(id);
        
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("AddUser.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = SearchText.Text;
            
            if (searchText != String.Empty) {
               var data =  db.users
                      .Where(t =>
                              t.name.Contains(searchText) ||
                              t.email.Contains(searchText) ||
                              t.userType.Contains(searchText) ||
                              t.phone.Contains(searchText)
                          );

                GridView1.DataSource = data.ToList();
                GridView1.DataBind();
             }
            else
            {

                var data = db.users.Select(u => u);
                GridView1.DataSource = data.ToList();
                GridView1.DataBind();

            }
        }


       

       

    }
}