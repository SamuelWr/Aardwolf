using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlHandler
{
    public static class Sql
    {
        private const string ConStr = "something here";

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
