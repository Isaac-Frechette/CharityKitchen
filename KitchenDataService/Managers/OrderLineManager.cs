using KitchenDataService.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace KitchenDataService.Managers
{
    public class OrderLineManager
    {
        public string QUERY_ORDERLINE_ALL = "SELECT * FROM tblOrderLine";
        public string QUERY_ORDERLINE_ONE = "SELECT * FROM tblOrderLine WHERE OrderID = {0}";

        /// <summary>
        /// Used to execute a query and package the results as a list of OrderLines
        /// </summary>
        /// <param name="query">The query to execute. Two usuable pre-packaged queries are created when a new OrderLineManager is created</param>
        /// <returns>All the Orderlines the query finds, returned as a list</returns>
        public List<OrderLine> SelectOrderLines(string query)
        {
            var products = new List<OrderLine>();
            var dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            var dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            var reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new OrderLine(reader));
            }
            dbConn.Close();
            return products;
        }

        /// <summary>
        /// Removes the association between an order and a specific meal
        /// </summary>
        /// <param name="orderID">The ID of the Order for the Meal to be removed from</param>
        /// <param name="mealID">the Meal to be removed from the Order</param>
        public void RemoveMealFromOrder(int orderID, int mealID)
        {
            string query = $"DELETE FROM tblOrderLine WHERE OrderID = {orderID} AND MealID = {mealID}";
            OleDbConnection dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            dbConn.Open();
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }

        /// <summary>
        /// Inserts a new entry to the database or updates and existing entry based on the ID given.
        /// </summary>
        /// <param name="ID">ID of the entry to update, use 0 to create a new entry</param>
        /// <param name="orderID">The ID of the Order to add a meal to</param>
        /// <param name="mealID">The ID of the Meal to be added to the Order</param>
        /// <param name="mealQuantity"></param>
        public void SaveOrderLine(int ID, int orderID, int mealID, int mealQuantity)
        {
            string query = string.Empty;

            if (ID == 0)
            {
                query = $"INSERT INTO tblOrderLine (OrderID, MealID, MealQuantity) VALUES ({orderID}, {mealID}, {mealQuantity} )";
            }

            else
            {
                query = $"UPDATE tblOrderLine SET OrderID = {orderID}, MealID = {mealID}, MealQuantity = {mealQuantity} WHERE OrderLineID = {ID}";
            }

            OleDbConnection dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            dbConn.Open();
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }
    }
}