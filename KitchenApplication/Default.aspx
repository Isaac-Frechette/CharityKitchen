<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KitchenApplication.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>Welcome to the Charity Kitchen</h1>
    <asp:Label runat="server" ID="lblGreeting" />
    <h3>Your Roles:</h3>
    <asp:DataGrid runat="server" ID="dgvRoles" /> <br />
    <h3>Help</h3>
    Below is a help section useful for learning how to handle adding, editing and and removing: Meals, ingredients and orders. <br />
    For a more in-depth guide navigating or using this website please contact your systems administrator. <br />

<h3>Meals</h3>

<h4> Navigating: </h4> 
Half way down the page there will be a 'Prev.' and 'Next' button together, <br />
these buttons can be used to move forward or backwards through the list of meals.
<br />
    <img src="Assets/Meals.PNG" />
<br/>
<h4>To Add a New Meal:</h4>
To add a new meal to the database you must click the 'New' button first, once it says the Meal ID is 0, <br />
Fill in the appropirate details (name, servings, vegetarian) and save it to the database ('Save' button). <br />
Once the meal is added, navigate to it and select meal ingredients below to add to the meal.
<br />
<br/>
<h4>To Edit a Meal:</h4>
To edit and existing meal, navigate to the meal and if changing the name, or serving size use the text boxes provided. <br />
If you would like to edit the ingredients for this meal you must use the add/removed functions at the bottom of the page, <br />
after making any changes you wish to keep  use the 'Save' button in the middle of the page.
<br />

<h3>Orders</h3>
    <br/>
<h4>Navigating:</h4>
Saved orders can be loaded onto the page using the drop down list at the top of the screen. <br />
Once the right order ID is selected use the 'Select' button to populate the form with the order's data.
<br />
    <img src="Assets/Orders.PNG" />
    <br />
<h4>Creating a New Order:</h4>
To create a new order, first press the 'New' button and then fill in the details such as description and status and save. <br />
Once the order is saved to the database (using the 'Save' button) you can navigate to it and add/removed orders <br />
using the bottom half of the form.
<br />
    <br />
<h4>Editing an Order:</h4>
To edit an order you use the drop down list to navigate to it and edit the data in the text fields to change the description or status <br />
and the Order Details portion of the form to add or remove meals from the order.
<br />

<h3>Ingredients</h3>
    <br/>
<h4>Navigating:</h4>
Use the 'Prev.' and 'Next' buttons located under the heading "Add/Edit Ingredients" to navigate through the database of Ingredients.
<br />
    <img src="Assets/Ingredients.PNG" />
    <br />
<h4>Adding an Ingredient:</h4>
To add a new ingredient to the database you click the 'New' button and enter details in the cleared text fields above,<br />
if under the label 'ingredient ID' there is a 0 then a new Ingredient will be saved when the 'Save' button is pressed.
<br />
    <br />
<h4>Editing an Ingredient:</h4>
To edit an existing Ingredient you navigate to the Ingredient of your choice,<br />
once it's selected you edit the name or measurement and click the 'Save' button.

</asp:Content>