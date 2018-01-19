using KitchenDataService.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace KitchenDataService.Managers
{
    public class PasswordManager
    {

        /// <summary>
        /// Gets the hash of a given user's password from the connected database
        /// </summary>
        /// <param name="userName">The username of user's hash to get</param>
        /// <returns>The queried hash is returned as a string</returns>
        public string GetUserHash(string userName)
        {
            KitchenUser user = new KitchenUser();

            string.Format(UserManager.QUERY_BY_USERNAME, userName);
            var dbConn = new OleDbConnection(ConnectionManager.USER_CONNECTION_STRING);
            var dbCmd = new OleDbCommand(UserManager.QUERY_BY_USERNAME, dbConn);
            dbConn.Open();
            var reader = dbCmd.ExecuteReader();
            if (reader.Read())
            {
                user = new KitchenUser(reader);
            }
            return user.UserHash;
        }

        /// <summary>
        /// Generates a new byte array and converts it to a string to be stored as a user's salt
        /// </summary>
        /// <returns>A series of random bytes converted to a string</returns>
        public string GenerateNewSalt()
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Uses the parogram's given hashing algorithm to hash a password and combine it with salt provided
        /// </summary>
        /// <param name="password">The password to be hashed</param>
        /// <param name="salt">The salt associated with the user having their password hashed</param>
        /// <returns>The result of the hashing is returned as a string</returns>
        public string HashPassword(string password, byte[] salt)
        {
            //Create the Rfc2898DeriveBytes and get the hash value:
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            //Combine the salt and password bytes for later use:
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //Turn the combined salt+hash into a string for storage

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            //Add to database or return here 
            return savedPasswordHash;
        }

        /// <summary>
        /// Used to verify the stored hash against a new hash generated from a provided when this method is called
        /// </summary>
        /// <param name="username">The user you are verifying</param>
        /// <param name="password">The password to attempt to hash and compare against the database</param>
        /// <returns>True is the same, false if different</returns>
        public bool VerifyPassword(string username, string password)
        {
            UserManager um = new UserManager();
            bool login = false;
            /* Fetch the stored value */
            string savedPasswordHash = um.GetUserByName(username).UserHash;

            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            /* Get the salt */
            
            byte[] salt = Convert.FromBase64String(um.GetUserByName(username).UserSalt);

            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                {
                    login = false;
                }
                else
                {
                    login = true;
                }
            return login;
        }
    }
}