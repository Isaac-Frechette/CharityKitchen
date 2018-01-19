using KitchenDataService.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace KitchenDataService.Managers
{
    public class IngredientManager
    {
        public string QUERY_INGREDIENT_ALL = "SELECT * FROM tblIngredient";
        public string QUERY_INGREDIENT_ONE = "SELECT * FROM tblIngredient WHERE IngredientID = {0}";

        /// <summary>
        /// Used to execute a query and package the results as a list of Ingredients
        /// </summary>
        /// <param name="query">The query to execute. Two usuable pre-packaged queries are created when a new IngredientManager is created</param>
        /// <returns>All the Ingredients the query finds, returned as a list</returns>
        public List<Ingredient> SelectIngredient(string query)
        {
            var products = new List<Ingredient>();
            var dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            var dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            var reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Ingredient(reader));
            }
            dbConn.Close();
            return products;
        }

        /// <summary>
        /// Utilises the SQL 'LIKE' operator to search Ingredients of a similar name
        /// </summary>
        /// <param name="name">The search term to compare results against</param>
        /// <returns>All the Ingredients the query finds, as a list</returns>
        public List<Ingredient> SearchIngredients(string name)
        {
            string query = $"SELECT * FROM tblIngredient WHERE IngredientName LIKE '%{name}%'";
            var products = new List<Ingredient>();
            var dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            var dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            var reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Ingredient(reader));
            }
            dbConn.Close();
            return products;
        }

        /// <summary>
        /// Inserts a new entry to the database or updates and existing entry based on the ID given.
        /// </summary>
        /// <param name="ID">ID of the entry to update, use 0 to create a new entry</param>
        /// <param name="name">Name of the ingredient</param>
        /// <param name="measurement">Quantity of the ingredient</param>
        public void SaveIngredient(int ID, string name, string measurement)
        {
            string query = string.Empty;

            if (ID == 0)
            {
                query = $"INSERT INTO tblIngredient (IngredientName, IngredientMeasurementType) VALUES ('{name}', '{measurement}')";
            }

            else
            {
                query = $"UPDATE tblIngredient SET IngredientName = '{name}', IngredientMeasurementType = '{measurement}' WHERE IngredientID = {ID}";
            }

            OleDbConnection dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            dbConn.Open();
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }
    }
}