using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenDataService.Managers
{
    public static class ConnectionManager
    {
        public static string CONNECTION_STRING;
        public static string USER_CONNECTION_STRING;

        static ConnectionManager()
        {
            CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|KitchenDatabase.accdb";
        }
    }
}