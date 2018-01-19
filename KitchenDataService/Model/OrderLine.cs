using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenDataService.Model
{
    public class OrderLine
    {
        public int OrderLineID { get; set; }
        public int OrderID { get; set; }
        public int MealID { get; set; }
        public int MealQuantity { get; set; }

        public OrderLine()
        {

        }

        public OrderLine(int orderLineID, int orderID, int mealID, int mealQuantity)
        {
            OrderLineID = orderLineID;
            OrderID = orderID;
            MealID = mealID;
            MealQuantity = mealQuantity;
        }

        public OrderLine(System.Data.OleDb.OleDbDataReader reader)
        {
            OrderLineID = reader.GetInt32(0);
            OrderID = reader.GetInt32(1);
            MealID = reader.GetInt32(2);
            MealQuantity = reader.GetInt32(3);
        }
    }
}