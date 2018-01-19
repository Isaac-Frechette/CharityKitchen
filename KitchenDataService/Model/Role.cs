using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KitchenDataService.Model
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int UserRoleLevel { get; set; }

        public Role()
        {

        }

        public Role(int id, string role, int roleLevel)
        {
            RoleID = id;
            RoleName = role;
            UserRoleLevel = roleLevel;
        }

        public Role(System.Data.OleDb.OleDbDataReader reader)
        {
            RoleID = reader.GetInt32(0);
            RoleName = reader.GetString(1);
            UserRoleLevel = reader.GetInt32(2);
        }
    }
}