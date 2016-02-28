<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateVehicle.aspx.cs" Inherits="WebApplication.UpdateVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Update user.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Vehicle Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="The full name field is required." />
            </div>
        </div>


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="model_name" CssClass="col-md-2 control-label">Model Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="model_name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="model_name"
                    CssClass="text-danger" ErrorMessage="The model_name field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="manufacturer_name" CssClass="col-md-2 control-label">Manufacturer Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="manufacturer_name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="manufacturer_name"
                    CssClass="text-danger" ErrorMessage="The Manufacturer name field is required." />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="UpdateVehicle_Click" Text="Update" CssClass="btn btn-primary" />
            </div>
        </div>

        </div>


</asp:Content>
