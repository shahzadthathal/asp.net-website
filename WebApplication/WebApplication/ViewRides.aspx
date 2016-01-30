<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRides.aspx.cs" Inherits="WebApplication.ViewRides" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
        <h4>View Rides.</h4>  
    
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
    <asp:GridView ID="GridView1" runat="server" onrowdatabound="GridView1_RowDataBound" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" ShowFooter="true" Width="901px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="margin-top: 0px" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="r.id" HeaderText="S. NO" />
                <asp:BoundField DataField="username" HeaderText="User" />
                <asp:BoundField DataField="r.status" HeaderText="Status" />
                <asp:BoundField DataField="r.from_destination" HeaderText="From destination" />
                <asp:BoundField DataField="r.to_destination" HeaderText="To destination" />
                <asp:BoundField DataField="r.created_date" HeaderText="Created date" />
                <asp:BoundField DataField="r.review" HeaderText="Review" />
                <asp:BoundField DataField="r.rating" HeaderText="Rating" /> 
                 <asp:BoundField DataField="r.amount" HeaderText="Amount" DataFormatString="{0:N2}" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        </asp:GridView>

    <!--DataFormatString="{0:N2}"-->


</asp:Content>
