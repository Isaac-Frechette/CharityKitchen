using KitchenDataService.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace KitchenDataService.Managers
{
    public class OrderManager
    {
        public string QUERY_ORDER_ALL = "SELECT * FROM tblOrder";
        public string QUERY_ORDER_ONE = "SELECT * FROM tblOrder WHERE OrderID = {0}";

        /// <summary>
        /// Used to execute a query and package the results as a list of Orders
        /// </summary>
        /// <param name="query">The query to execute. Two usuable pre-packaged queries are created when a new OrderManager is created</param>
        /// <returns>All the Orders the query finds, returned as a list</returns>
        public List<Order> SelectOrder(string query)
        {
            var products = new List<Order>();
            var dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            var dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            var reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Order(reader));
            }
            dbConn.Close();
            return products;
        }

        /// <summary>
        /// Inserts a new entry to the database or updates and existing entry based on the ID given.
        /// </summary>
        /// <param name="ID">ID of the entry to update, use 0 to create a new entry</param>
        /// <param name="orderDesc">A description or name for the Order</param>
        /// <param name="orderStatus">The status of the Order</param>
        public void SaveOrder(int ID, string orderDesc, string orderStatus)
        {
            string query = string.Empty;

            if (ID == 0)
            {
                query = $"INSERT INTO tblOrder (OrderDescription, OrderStatus) VALUES ('{orderDesc}', '{orderStatus}')";
            }

            else
            {
                query = $"UPDATE tblOrder SET OrderDescription = '{orderDesc}', OrderStatus = '{orderStatus}' WHERE OrderID = {ID}";
            }

            OleDbConnection dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            dbConn.Open();
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }
    }
}