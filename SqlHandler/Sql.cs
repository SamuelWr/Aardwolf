using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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
        public static int LogIn(string username, string password)
        {
            int userId=-1;
            //Todo: get password hash and salt from database

            //Todo: hash from input password.

            //Todo: compare and return
            return userId;
        }
        /// <summary>
        /// Creates a new user, returns userId if successful -1 else
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        public static int CreateUser(string userName, string Password, bool isAdmin)
        {
            int userId = -1;
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

            return userId;
        }
        /// <summary>
        /// returns list of all products
        /// </summary>
        public static void GetProducts()
        {
            //return list of products;
        }
        /// <summary>
        /// returns list of all products matching search string
        /// </summary>
        /// <param name="searchString"></param>
        public static void SearchProducts(string searchString)
        {
            // retrurn list of products
        }
    }
}
