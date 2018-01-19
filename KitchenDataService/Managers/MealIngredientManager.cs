using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace KitchenDataService.Managers
{
    public class MealIngredientManager
    {
        /// <summary>
        /// Inserts a new entry to the database or updates and existing entry based on the ID given.
        /// </summary>
        /// <param name="ID">ID of the entry to update, use 0 to create a new entry</param>
        /// <param name="mealID">ID of the meal to link this entry to</param>
        /// <param name="ingredientID">ID of the Ingredient to attach to the given meal</param>
        /// <param name="ingredientQuantity">Quantity of this ingredient to add to this meal</param>
        public void SaveIngredient(int ID, int mealID, int ingredientID, int ingredientQuantity)
        {
            string query = string.Empty;

            if (ID == 0)
            {
                query = $"INSERT INTO tblMealIngredient (MealID, IngredientID, MealIngredientQuantity) VALUES ({mealID}, {ingredientID}, {ingredientQuantity} )";
            }

            else
            {
                query = $"UPDATE tblMealIngredient SET MealID = {mealID}, IngredientID = {ingredientID}, MealIngredientQuantity = {ingredientQuantity} WHERE MealIngredientID = {ID}";
            }

            OleDbConnection dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            dbConn.Open();
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }

        /// <summary>
        /// Used to delete an association between a meal and its ingredients
        /// </summary>
        /// <param name="mealID">Meal to removed an ingredient from</param>
        /// <param name="ingredientID">Ingredient to be removed from specified meal</param>
        public void RemoveIngredientFromMeal(int mealID, int ingredientID)
        {
            string query = $"DELETE FROM tblMealIngredient WHERE MealID = {mealID} AND IngredientID = {ingredientID}";
            OleDbConnection dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            dbConn.Open();
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }
    }
}