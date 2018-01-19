using KitchenDataService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenDataService.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderDescription { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderLine> Orders { get; set; }

        public Order()
        {

        }

        public Order(int orderID, string orderDescription, string orderStatus, List<OrderLine> orders)
        {
            OrderID = orderID;
            OrderDescription = orderDescription;
            OrderStatus = orderStatus;
            Orders = orders;
        }

        public Order(System.Data.OleDb.OleDbDataReader reader)
        {
            OrderLineManager olm = new OrderLineManager();
            OrderID = reader.GetInt32(0);
            OrderDescription = reader.GetString(1);
            OrderStatus = reader.GetString(2);
            Orders = olm.SelectOrderLines(string.Format(olm.QUERY_ORDERLINE_ONE, OrderID));
        }
    }
}