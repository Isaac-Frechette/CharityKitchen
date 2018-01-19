using KitchenDataService.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography; 
using System.Web;

namespace KitchenDataService.Managers
{
    public class UserManager
    {
        public static string QUERY_BY_USERNAME = "SELECT * FROM tblUsers WHERE UserName LIKE '{0}'";

        /// <summary>
        /// Utilises the SQL 'LIKE' operator to search Users of the same name
        /// </summary>
        /// <param name="userName">The search term to compare results against</param>
        /// <returns>A single User found by the query</returns>
        public KitchenUser GetUserByName(string userName)
        {
            KitchenUser user = new KitchenUser();
            string query = string.Format(QUERY_BY_USERNAME, userName);

            var dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            var dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            var reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                user = new KitchenUser(reader);
            }
            return user;
        }

        /// <summary>
        /// Uses methods from PasswordManager to verify a given password and login a user
        /// </summary>
        /// <param name="username">Username of the user trying to login</param>
        /// <param name="password">Password of the user trying to login</param>
        /// <returns>If the login was successfully returns the requested user, otherwise returns an empty user object</returns>
        public KitchenUser LoginUser(string username, string password)
        {
            PasswordManager pm = new PasswordManager();
            KitchenUser user = new KitchenUser();
            try
            {
                KitchenUser temp = new KitchenUser();
                temp = GetUserByName(username);
                password = pm.HashPassword(password, Convert.FromBase64String(temp.UserSalt));
                if (password.Equals(temp.UserHash))
                {
                    user = temp;
                }
            }
            catch
            {

            }
            return user;
        }

        /// <summary>
        /// Inserts a new entry to the database
        /// </summary>
        /// <param name="username">the username od the user to add</param>
        /// <param name="password">the hashed password to add to the database</param>
        /// <param name="roleLevel">the permissions level of the user</param>
        public void CreateNewUser(string username, string password, int roleLevel)
        {
            string query = string.Empty;
            PasswordManager pm = new PasswordManager();
            string salt = pm.GenerateNewSalt();
            string userHash = pm.HashPassword(password, Convert.FromBase64String(salt));
            query = $"INSERT INTO tblUsers (UserName, UserHash, UserSalt, UserRoleLevel) VALUES ('{username}', '{userHash}', '{salt}', {roleLevel})";


            OleDbConnection dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            dbConn.Open();
            OleDbCommand dbCmd = new OleDbCommand(query, dbConn);
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }

        /// <summary>
        /// gets all role names for roles equal to or less than the given user's roles
        /// </summary>
        /// <param name="user">the username of the user's roles being checked</param>
        /// <returns>a list of strings containing role names</returns>
        public List<string> GetUserRoles(KitchenUser user)
        {
            List<string> roles = new List<string>();
            string query = $"SELECT RoleName FROM tblRoles WHERE UserRoleLevel < {user.UserRoleLevel + 1}";

            var dbConn = new OleDbConnection(ConnectionManager.CONNECTION_STRING);
            var dbCmd = new OleDbCommand(query, dbConn);
            dbConn.Open();
            var reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                roles.Add(reader.GetString(0)); ;
            }
            return roles;
        }

        public void UpdateUser()
        {

        }
    }
}