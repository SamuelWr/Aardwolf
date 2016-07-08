using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHandler
{
    public static class Sql
    {
        private const string CON_STR = "Data Source=localhost;Initial Catalog=Aardwolf;Integrated Security=SSPI";
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
        public static bool LogIn(string username, string password)
        {
            return false;
        }
        public static bool CreateUser(string userName, string Password, bool isAdmin)
        {
            bool success = false;

            return success;
        }
        public static void GetProducts()
        {
            //return list of products;
        }
        public static void SearchProducts(string searchString)
        {
            // retrurn list of products
        }
    }
}
