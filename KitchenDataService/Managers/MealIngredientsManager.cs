using KitchenDataService.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace KitchenDataService.Managers
{
    public class MealIngredientsManager
    {
        public string QUERY_MEALINGREDIENTS_BYID = "SELECT * FROM qryMealIngredients WHERE MealID = {0}";

        /// <summary>
        /// Used to execute a query and package the results as a list of MealIngredients
        /// </summary>
        /// <param name="query">The query to execute. A usuable pre-packaged query is created when a new MealIngredientsManager is created</param>
        /// <returns>All the MealIngredients the query finds, returned as a list</returns>
        public List<MealIngredients> SelectMealIngredients(string query)
        {
            var products = new List<MealIngredients>();
            var dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            var dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            var reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new MealIngredients(reader));
            }
            dbConn.Close();
            return products;
        }
    }
}