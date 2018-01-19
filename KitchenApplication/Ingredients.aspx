<%@ Page Title="Ingredients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingredients.aspx.cs" Inherits="KitchenApplication.Ingredients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Ingredients</h1>
    Ingredient Database: <br />
    <asp:DataGrid runat="server" ID="DGVIngredients" /> <br />

    <br /><h2>Add/Edit Ingredients</h2>
    <asp:Button runat="server" ID="btnPrev" Text="Prev." OnClick="btnPrev_Click" />
    <asp:Button runat="server" ID="btnNext" Text="Next" OnClick="btnNext_Click" /> <br />
    
    Ingredient ID: <br />
    <asp:Label runat="server" ID="lblIngredientID" /> <br />

    Ingredient Name: <br />
    <asp:TextBox runat="server" ID="txtIngredientName" /> <br />

    Ingredient Measurement: <br />
    <asp:TextBox runat="server" ID="txtMeasurement" /> <br />
    <br />
    <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
    <asp:Button runat="server" ID="btnNew" Text="New" OnClick="btnNew_Click" />

</asp:Content>
