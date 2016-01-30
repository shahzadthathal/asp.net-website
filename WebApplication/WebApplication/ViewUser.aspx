<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="WebApplication.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
   
        <h4>View Users.</h4>
        
    <div class="row">
    <div class="form-group">
            <div class="col-md-2">
            <asp:Button  ID="btnAddUser" runat="server" Text="Add User" Width="149px" OnClick="btnAddUser_Click" CssClass="btn btn-primary"  />
            </div>
            <div class="col-md-2">
             <asp:TextBox runat="server" ID="SearchText" CssClass="form-control" ToolTip="Search" Text="Search" />
             </div>
            
        <div class="col-md-">
                <asp:Button  ID="btnSearch" runat="server" Text="Search" Width="149px" OnClick="btnSearch_Click" CssClass="btn btn-primary"  />
         </div>


      </div>
      </div>

        <hr />
    <asp:GridView ID="GridView1" runat="server" Width="801px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="margin-top: 0px" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="S. NO" />
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="phone" HeaderText="Phone" />
                <asp:BoundField DataField="userType" HeaderText="User Type" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        </asp:GridView>

</asp:Content>
