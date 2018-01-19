using KitchenDataService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenDataService.Model
{
    public class Meal
    {
        public int MealID { get; set; }
        public string MealName { get; set; }
        public int MealServingSize { get; set; }
        public bool MealVegetarian { get; set; }
        public List<MealIngredients> MealIngredients { get; set; }

        public Meal()
        {

        }

        public Meal(int mealID, string mealName, int mealServingSize, bool mealVegetarian, List<MealIngredients> mealIngredients)
        {
            MealID = mealID;
            MealName = mealName;
            MealServingSize = mealServingSize;
            MealVegetarian = mealVegetarian;
            MealIngredients = mealIngredients;
        }

        public Meal(System.Data.OleDb.OleDbDataReader reader)
        {
            MealIngredientsManager mim = new MealIngredientsManager();
            MealID = reader.GetInt32(0);
            MealName = reader.GetString(1);
            MealServingSize = reader.GetInt32(2);
            MealVegetarian = reader.GetBoolean(3);
            MealIngredients = mim.SelectMealIngredients(string.Format(mim.QUERY_MEALINGREDIENTS_BYID, MealID));
        }
    }
}