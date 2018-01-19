using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenDataService.Model
{
    public class MealIngredients
    {
        //this is based on the query
        public int MealID { get; set; }
        public string MealName { get; set; }
        public string IngredientName { get; set; }
        public int MealIngredientQuantity { get; set; }
        public string IngredientMeasurementType { get; set; }

        public MealIngredients()
        {

        }

        public MealIngredients(int mealID, string mealName, string ingredientName, int mealIngredientQuantity, string ingredientMeasurementType)
        {
            MealID = mealID;
            MealName = mealName;
            IngredientName = ingredientName;
            MealIngredientQuantity = mealIngredientQuantity;
            IngredientMeasurementType = ingredientMeasurementType;
        }

        public MealIngredients(System.Data.OleDb.OleDbDataReader reader)
        {
            MealID = reader.GetInt32(0);
            MealName = reader.GetString(1);
            IngredientName = reader.GetString(2);
            MealIngredientQuantity = reader.GetInt32(3);
            IngredientMeasurementType = reader.GetString(4);
        }
    }
}