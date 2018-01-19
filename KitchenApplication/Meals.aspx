<%@ Page Title="Meals" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Meals.aspx.cs" Inherits="KitchenApplication.Meals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Meals</h1>
    Meal Database: <br />
    <asp:DataGrid runat="server" ID="dgvMeals" /> <br />

    <br /><h2>Add/Edit Meals</h2>
    
    Meal ID: <br />
    <asp:Label runat="server" ID="lblMealID" /> <br />

    Meal Name: <br />
    <asp:TextBox runat="server" ID="txtMealName" /> <br />

    Meal Servings: <br />
    <asp:TextBox runat="server" ID="txtMealServings" /> <br />

    Vegetarian: <br />
    <asp:CheckBox runat="server" ID="chkMealVege" /> <br />
    <br />
    <asp:Button runat="server" ID="btnPrev" Text="Prev." OnClick="btnPrev_Click" />
    <asp:Button runat="server" ID="btnNext" Text="Next" OnClick="btnNext_Click" /> <br />

    <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
    <asp:Button runat="server" ID="btnNew" Text="New" OnClick="btnNew_Click" />
    <br />

    <br />
    <h3>Meal Ingredients</h3>
    Ingredient: <asp:DropDownList runat="server" ID="ddlIngredients" /> <br />
    Amount: <asp:TextBox runat="server" ID="txtIngredientCount" /> <br />
    <asp:Button runat="server" ID="btnAddIngredient" Text="Add" OnClick="btnAddIngredient_Click"/> <br />
    <br />
    Remove/Edit Ingredient:
    <asp:DropDownList runat="server" ID="ddlMealIngredient" /><br />
    <asp:Button runat="server" ID="btnRemoveIngredient" Text="Remove" OnClick="btnRemoveIngredient_Click" /> <br />
    <asp:DataGrid runat="server" ID="dgvMealIngredients" /> <br />

</asp:Content>