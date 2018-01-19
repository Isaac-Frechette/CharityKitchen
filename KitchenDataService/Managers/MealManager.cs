using KitchenDataService.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace KitchenDataService.Managers
{
    public class MealManager
    {
        public string QUERY_MEAL_ALL = "SELECT * FROM tblMeal";
        public string QUERY_MEAL_ONE = "SELECT * FROM tblMeal WHERE MealID = {0}";

        /// <summary>
        /// Used to execute a query and package the results as a list of Meals
        /// </summary>
        /// <param name="query">The query to execute. Two usuable pre-packaged queries are created when a new MealManager is created</param>
        /// <returns>All the Meals the query finds, returned as a list</returns>
        public List<Meal> SelectMeal(string query)
        {
            var products = new List<Meal>();
            var dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            var dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            var reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Meal(reader));
            }
            dbConn.Close();
            return products;
        }


        /// <summary>
        /// Utilises the SQL 'LIKE' operator to search Meals of a similar name
        /// </summary>
        /// <param name="name">The search term to compare results against</param>
        /// <returns>All the Ingredients the query finds, as a list</returns>
        public List<Meal> SearchMeals(string name)
        {
            string query = $"SELECT * FROM tblMeal WHERE MealName LIKE '%{name}%'";
            var products = new List<Meal>();
            var dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            var dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            var reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Meal(reader));
            }
            dbConn.Close();
            return products;
        }

        /// <summary>
        /// Inserts a new entry to the database or updates and existing entry based on the ID given.
        /// </summary>
        /// <param name="ID">ID of the entry to update, use 0 to create a new entry</param>
        /// <param name="mealName">Name of the meal</param>
        /// <param name="mealServingSize">The amount of people the meal is fit to serve</param>
        /// <param name="mealVegetarian">Whether or not the meal is vegetarian</param>
        public void SaveMeal(int ID, string mealName, int mealServingSize, bool mealVegetarian)
        {
            string query = string.Empty;

            if (ID == 0)
            {
                query = $"INSERT INTO tblMeal (MealName, MealServingSize, MealVegetarian) VALUES ('{mealName}', {mealServingSize}, {mealVegetarian})";
            }

            else
            {
                query = $"UPDATE tblMeal SET MealName = '{mealName}', MealServingSize = {mealServingSize}, MealVegetarian = {mealVegetarian} WHERE MealID = {ID}";
            }

            OleDbConnection dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            dbConn.Open();
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }
    }
}