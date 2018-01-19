using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenDataService.Model
{
    public class KitchenUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserHash { get; set; }
        public string UserSalt { get; set; }
        public int UserRoleLevel { get; set; }

        public KitchenUser()
        {

        }

        public KitchenUser(int id, string username, string hash, string salt, int roleLevel)
        {
            UserID = id;
            UserName = username;
            UserHash = hash;
            UserSalt = salt;
            UserRoleLevel = roleLevel;
        }

        public KitchenUser(System.Data.OleDb.OleDbDataReader reader)
        {
            UserID = reader.GetInt32(0);
            UserName = reader.GetString(1);
            UserHash = reader.GetString(2);
            UserSalt = reader.GetString(3);
            UserRoleLevel = reader.GetInt32(4);
        }
    }
}