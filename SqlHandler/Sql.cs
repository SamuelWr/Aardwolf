using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Aardwolf;

namespace SqlHandler
{
    public static class Sql
    {
        private const string CON_STR = "Data Source=localhost;Initial Catalog=Aardwolf;Integrated Security=SSPI";
        private static Random random = new Random();
        private const int lengthOfSalt = 10;

        /// <summary>
        /// For testing only, liable to be removed without warning.
        /// </summary>
        /// <returns></returns>
        public static string GetUsers()
        {
            string users = "";



            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand = new SqlCommand("select * from users", myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    users += "NAME: " + myReader["username"].ToString()  + Environment.NewLine;
                    
                    
                }
            }
            catch (Exception ex)
            {
                //Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }


            return users;
        }
        /// <summary>
        /// Attempts to log in user, returns userId if successful else -1
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User LogIn(string username, string password)
        {
            User user = null;
            //Todo: get password hash and salt from database

            //Todo: hash from input password.

            //Todo: compare and return
            return user;
        }
        /// <summary>
        /// Creates a new user, returns user object if successful else null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        public static User CreateUser(string userName, string Password, bool isAdmin)
        {
            User user = null;
            //Todo: check that username does not already exist.

            char[] salt = new char[lengthOfSalt];
            for (int i = 0; i < lengthOfSalt; i++)
            {
                salt[i] = (char)random.Next(65, 91);
            }
            var md5 = new System.Security.Cryptography.MD5Cng();
            //md5.ComputeHash(Password);
            //md5.ComputeHash()



            bool success = false;

            return user;
        }
        /// <summary>
        /// Takes a User object referring to a already existing user, makes required changes in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>A bool indicating if the changes succeeded.</returns>
        public static bool UpdateUser(User user)
        {
            bool success = false;

            return success;
        }
        /// <summary>
        /// returns list of all products
        /// </summary>
        public static List<Product> GetProducts()
        {
            //return list of products;
            List<Product> products = null;

            return products;
        }
        /// <summary>
        /// returns list of all products matching search string
        /// </summary>
        /// <param name="searchString"></param>
        public static List<Product> SearchProducts(string searchString)
        {
            List<Product> products = null;
            // retrurn list of products
            return products;
        }

        public static User GetUser(int UserID)
        {
            User user = null;

            return user;
        }
        public static User GetUser(string UserName)
        {
            User user = null;
            return user;
        }
    }
}
