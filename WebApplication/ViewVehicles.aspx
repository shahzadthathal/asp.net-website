<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewVehicles.aspx.cs" Inherits="WebApplication.ViewVehicles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    
        <h4>View Vehicles.</h4>   
    
    <div class="row">
    <div class="form-group">
            
            <div class="col-md-2">
             <asp:TextBox runat="server" ID="SearchText" CssClass="form-control" ToolTip="Search" Text="Search" />
             </div>
            
        <div class="col-md-">
                <asp:Button  ID="btnSearch" runat="server" Text="Search" Width="149px" OnClick="btnSearch_Click" CssClass="btn btn-primary"  />
         </div>


      </div>
      </div>
    
        
        <hr />
    <asp:GridView ID="GridView1" runat="server" Width="801px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="margin-top: 0px" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="v.id" HeaderText="S. NO" />
                <asp:BoundField DataField="v.name" HeaderText="Name" />
                <asp:BoundField DataField="v.model_name" HeaderText="Model Name" />
                <asp:BoundField DataField="v.manufacturer_name" HeaderText="Manufacturer name" />
                
                <asp:BoundField DataField="ownername" HeaderText="Owner name" />
                <asp:CommandField ShowEditButton="True" />               
            </Columns>
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        </asp:GridView>

    <!-- <asp:BoundField DataField="ownername" HeaderText="Owner Name" />-->

</asp:Content>
