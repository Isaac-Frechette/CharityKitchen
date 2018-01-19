using KitchenDataService.Managers;
using KitchenDataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace KitchenDataService
{
    /// <summary>
    /// Summary description for KitchenDataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KitchenDataService : System.Web.Services.WebService
    {

        //QueryManager class - group all queries together for ease of access rather than having them contained in seperate managers
        [WebMethod]
        public void CreateUser(string username, string password, int role)
        {
            UserManager um = new UserManager();
            um.CreateNewUser(username, password, role);
        }

        [WebMethod]
        public List<string> GetUserRoles(KitchenUser user)
        {
            UserManager um = new UserManager();
            return um.GetUserRoles(user);
        }

        [WebMethod]
        public KitchenUser Login(string username, string password)
        {
            UserManager um = new UserManager();
            return um.LoginUser(username, password);
        }

        [WebMethod]
        public List<Order> GetAllOrders()
        {
            OrderManager om = new OrderManager();
            return om.SelectOrder(om.QUERY_ORDER_ALL);
        }

        [WebMethod]
        public Order GetOrderByID(string id)
        {
            OrderManager om = new OrderManager();
            return om.SelectOrder(string.Format(om.QUERY_ORDER_ONE, id))[0];
        }

        [WebMethod]
        public List<OrderLine> GetAllOrderLines()
        {
            OrderLineManager olm = new OrderLineManager();
            return olm.SelectOrderLines(olm.QUERY_ORDERLINE_ALL);
        }

        [WebMethod]
        public void SaveOrder(int ID, string orderDesc, string orderStatus)
        {
            OrderManager om = new OrderManager();
            om.SaveOrder(ID, orderDesc, orderStatus);
        }

        [WebMethod]
        public List<OrderLine> GetOrderLinesByID(string id)
        {
            OrderLineManager olm = new OrderLineManager();
            return olm.SelectOrderLines(string.Format(olm.QUERY_ORDERLINE_ONE, id));
        }

        [WebMethod]
        public void SaveOrderLine(int ID, int orderID, int mealID, int mealQuantity)
        {
            OrderLineManager olm = new OrderLineManager();
            olm.SaveOrderLine(ID, orderID, mealID, mealQuantity);
        }

        [WebMethod]
        public void RemovedMealFromOrder(int orderID, int mealID)
        {
            OrderLineManager olm = new OrderLineManager();
            olm.RemoveMealFromOrder(orderID, mealID);
        }

        [WebMethod]
        public void SaveMeal(int ID, string mealName, int mealServingSize, bool mealVegetarian)
        {
            MealManager mm = new MealManager();
            mm.SaveMeal(ID, mealName, mealServingSize, mealVegetarian);
        }

        [WebMethod]
        public List<Ingredient> GetAllIngredients()
        {
            IngredientManager im = new IngredientManager();
            return im.SelectIngredient(im.QUERY_INGREDIENT_ALL);
        }

        [WebMethod]
        public List<Ingredient> SearchIngredients(string query)
        {
            IngredientManager im = new IngredientManager();
            return im.SearchIngredients(query);
        }

        [WebMethod]
        public Ingredient GetIngredientByID(string id)
        {
            IngredientManager im = new IngredientManager();
            return im.SelectIngredient(string.Format(im.QUERY_INGREDIENT_ONE, id))[0];
        }

        [WebMethod]
        public void SaveIngredient(int ID, string name, string measurement)
        {
            IngredientManager im = new IngredientManager();
            im.SaveIngredient(ID, name, measurement);
        }

        [WebMethod]
        public void SaveMealIngredient(int ID, int mealID, int ingredientID, int ingredientQuantity)
        {
            MealIngredientManager mim = new MealIngredientManager();
            mim.SaveIngredient(ID, mealID, ingredientID, ingredientQuantity);
        }

        [WebMethod]
        public List<Meal> GetAllMeals()
        {
            MealManager mm = new MealManager();
            return mm.SelectMeal(mm.QUERY_MEAL_ALL);
        }

        [WebMethod]
        public List<Meal> SearchMeals(string query)
        {
            MealManager mm = new MealManager();
            return mm.SearchMeals(query);
        }

        [WebMethod]
        public Meal GetMealByID(string id)
        {
            MealManager mm = new MealManager();
            return mm.SelectMeal(string.Format(mm.QUERY_MEAL_ONE, id))[0];
        }

        [WebMethod]
        public void RemoveIngredientFromMeal(int mealID, int ingredientID)
        {
            MealIngredientManager mim = new MealIngredientManager();
            mim.RemoveIngredientFromMeal(mealID, ingredientID);
        }
    }
}
