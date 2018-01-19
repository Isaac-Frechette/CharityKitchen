using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenDataService.Model
{
    public class MealIngredient
    {
        //this is based on a table
        public int MealIngredientID { get; set; }
        public int MealID { get; set; }
        public int IngredientID { get; set; }
        public int MealIngredientQuantity { get; set; }

        public MealIngredient()
        {

        }

        public MealIngredient(int mealIngredientID, int mealID, int ingredientID, int mealIngredientQuantity)
        {
            MealIngredientID = mealIngredientID;
            MealID = mealID;
            IngredientID = ingredientID;
            MealIngredientQuantity = mealIngredientQuantity;
        }
    }
}