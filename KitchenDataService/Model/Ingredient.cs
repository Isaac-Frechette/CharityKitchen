using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenDataService.Model
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public string IngredientMeasurementType { get; set; }

        public Ingredient()
        {

        }

        public Ingredient(int ingredientID, string ingredientName, string ingredientMeasurementType)
        {
            IngredientID = ingredientID;
            IngredientName = ingredientName;
            IngredientMeasurementType = ingredientMeasurementType;
        }

        public Ingredient(System.Data.OleDb.OleDbDataReader reader)
        {
            IngredientID = reader.GetInt32(0);
            IngredientName = reader.GetString(1);
            IngredientMeasurementType = reader.GetString(2);
        }
    }
}