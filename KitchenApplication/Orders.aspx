<%@ Page Title="Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="KitchenApplication.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Orders</h1>
    Select an order:
    <asp:DropDownList runat="server" ID="ddlOrders" />
    <asp:Button runat="server" ID="btnSelect" Text="Select" OnClick="btnSelect_Click" /> <br />
    <asp:GridView runat="server" ID="dgvOrders" />
    Order ID:<br />
    <asp:Label runat="server" ID="lblOrderID" Text="0"/> <br />
    Order Description:<br />
    <asp:TextBox runat="server" ID="txtOrderDesc" /> <br />
    Order Status:<br />
    <asp:TextBox runat="server" ID="txtOrderStatus" /> <br />
    <asp:Button runat="server" ID="btnNew" Text="New" OnClick="btnNew_Click" />
    <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />



    <h3>Order Details</h3>
    <asp:GridView runat="server" ID="dgvOrderDetails" /><br />
    Add Meals to Order: <br />
    <asp:DropDownList runat="server" ID="ddlOrderMeals" /> <br />
    Quantitiy: <br />
    <asp:TextBox runat="server" ID="txtMealAmount" /> <br />
    <asp:Button runat="server" ID="btnAddMeal" Text="Add" OnClick="btnAddMeal_Click" />
    <asp:Button runat="server" ID="btnRemoveMeal" Text="Remove" OnClick="btnRemoveMeal_Click" />

</asp:Content>
