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
                    if (!(myReader["username"] is System.DBNull))
                        users += "NAME: " + (string)myReader["username"];
                    if (!(myReader["firstname"] is System.DBNull))
                        users += "\tFirstname = " + (string)myReader["firstname"];
                    if (!(myReader["lastname"] is System.DBNull))
                        users += "\tLastname = " + (string)myReader["lastname"];
                    if (!(myReader["email"] is System.DBNull))
                        users += "\tEmail = " + (string)myReader["email"];
                    if (!(myReader["address"] is System.DBNull))
                        users += "\tAddress = " + (string)myReader["address"];
                    users += Environment.NewLine;
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
        /// Attempts to log in user, returns User Id if successful, else -1.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int LogIn(string username, string password)
        {
            //throw new NotImplementedException();
            int userId = -1;
            string hash = "", salt = "";
            //get password hash and salt from database
            SqlConnection myConnection = new SqlConnection(CON_STR);

            try
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.CommandText = "getpwdetails";

                SqlParameter paramUserName = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
                paramUserName.Value = username;
                paramUserName.Size = 100;
                myCommand.Parameters.Add(paramUserName);



                SqlParameter paramHash = new SqlParameter("@pwhash", System.Data.SqlDbType.VarChar);
                paramHash.Direction = System.Data.ParameterDirection.Output;
                paramHash.Size = 100;
                myCommand.Parameters.Add(paramHash);

                SqlParameter paramSalt = new SqlParameter("@pwsalt", System.Data.SqlDbType.VarChar);
                paramSalt.Direction = System.Data.ParameterDirection.Output;
                paramSalt.Size = 20;
                myCommand.Parameters.Add(paramSalt);

                SqlParameter paramUserId = new SqlParameter("@userid", System.Data.SqlDbType.Int);
                paramUserId.Direction = System.Data.ParameterDirection.Output;
                myCommand.Parameters.Add(paramUserId);

                myConnection.Open();
                int numberofrows = myCommand.ExecuteNonQuery();

                //Console.WriteLine($"Added {numberofrows} rows.");

                salt = (string)paramSalt.Value;
                hash = (string)paramHash.Value;
                userId = (int)paramUserId.Value;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

            Console.WriteLine($"Hash: {hash}");
            Console.WriteLine($"Salt: {salt}");
            Console.WriteLine($"UserId: {userId}");

            //Todo: compute hash from input password.
            string ComputedHash = "";
            //compare and return
            if (ComputedHash.Equals(hash))
                return userId;
            else
                return -1;
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
            throw new NotImplementedException();
            User user = null;
            //check that username does not already exist.

            char[] salt = new char[lengthOfSalt];
            for (int i = 0; i < lengthOfSalt; i++)
            {
                salt[i] = (char)random.Next(65, 91);
            }
            var md5 = new System.Security.Cryptography.MD5Cng();
            //md5.ComputeHash(salt + Password + salt);
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
            throw new NotImplementedException();
            //Require password too?
            bool success = false;

            return success;
        }
        /// <summary>
        /// returns list of all products
        /// </summary>
        public static List<Product> GetProducts()
        {
            //Todo: test GetProducts()
            List<Product> products = new List<Product>();

            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand = new SqlCommand("select * from Products", myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    var product = new Product();
                    if (!(myReader["ID"] is System.DBNull))
                        product.ProductId = (int)myReader["ID"];
                    if (!(myReader["ProductName"] is System.DBNull))
                        product.ProductName = (string)myReader["ProductName"];
                    if (!(myReader["Description"] is System.DBNull))
                        product.Description = (string)myReader["Description"];
                    if (!(myReader["PictureUrl"] is System.DBNull))
                        product.PictureUrl = (string)myReader["PictureUrl"];
                    if (!(myReader["ThumbnailPictureUrl"] is System.DBNull))
                        product.ThumbnailPictureUrl = (string)myReader["ThumbnailPictureUrl"];
                    if (!(myReader["Cost"] is System.DBNull))
                        product.Cost = (double)myReader["Cost"];

                    products.Add(product);
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


            return products;
        }
        /// <summary>
        /// returns list of all products matching search string
        /// </summary>
        /// <param name="searchString"></param>
        public static List<Product> SearchProducts(string searchString)
        {
            throw new NotImplementedException();
            //write SearchProducts(), might be difficult to make a stored procedure. search locally instead?
            List<Product> products = null;
            // retrurn list of products
            return products;
        }

        public static User GetUser(int UserID)
        {
            User user = null;

            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand = new SqlCommand($"select * from Users WHERE ID = {UserID}", myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string username = "";
                    if (!(myReader["username"] is System.DBNull))
                        username = (string)myReader["username"];
                    user = new User(username);

                    if (!(myReader["firstname"] is System.DBNull))
                        user.FirstName = (string)myReader["firstname"];
                    if (!(myReader["lastname"] is System.DBNull))
                        user.LastName = (string)myReader["lastname"];
                    if (!(myReader["email"] is System.DBNull))
                        user.EmailAddress = (string)myReader["email"];
                    if (!(myReader["Address"] is System.DBNull))
                        user.DeliveryAddress = (string)myReader["Address"];
                    user.UserId = UserID;
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
            if (user != null)
            {
                user.Orders = GetOrders(UserID);
            }

            return user;
        }
        /// <summary>
        /// Deprecated, saved for posterity. (Delete when I am sure it is not needed.)
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        private static User GetUser(string UserName)
        {
            //Todo: Change to stored procedure for security
            User user = null;
            int UserID = -1;

            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand = new SqlCommand($"select * from Users WHERE username = '{UserName}'", myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string username = "";
                    if (!(myReader["username"] is System.DBNull))
                        username = (string)myReader["username"];
                    user = new User(username);

                    if (!(myReader["firstname"] is System.DBNull))
                        user.FirstName = (string)myReader["firstname"];
                    if (!(myReader["lastname"] is System.DBNull))
                        user.LastName = (string)myReader["lastname"];
                    if (!(myReader["email"] is System.DBNull))
                        user.EmailAddress = (string)myReader["email"];
                    if (!(myReader["Address"] is System.DBNull))
                        user.DeliveryAddress = (string)myReader["Address"];

                    if (!(myReader["ID"] is System.DBNull))
                        UserID = (int)(myReader["ID"]);
                    user.UserId = UserID;
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
            if (user != null)
            {
                user.Orders = GetOrders(UserID);
            }


            return user;
        }
        private static List<Order> GetOrders(int UserID)
        {
            var orders = new List<Order>();

            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand = new SqlCommand($"select * from Orders WHERE CustomerID = {UserID}", myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    var order = new Order();

                    if (!(myReader["ID"] is System.DBNull))
                        order.ID = (int)myReader["ID"];
                    if (!(myReader["DeliveryAddress"] is System.DBNull))
                        order.DeliveryAddress = (string)myReader["DeliveryAddress"];
                    if (!(myReader["HasBeenDelivered"] is System.DBNull))
                        order.HasBeenDelivered = (bool)myReader["HasBeenDelivered"];// == 1 ? true : false;

                    orders.Add(order);
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
            foreach (var order in orders)
            {
                order.Items = GetOrderItems(order.ID);
            }

            return orders;
        }

        private static List<OrderItem> GetOrderItems(int OrderID)
        {
            var items = new List<OrderItem>();

            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand = new SqlCommand($"select * from OrderItems WHERE OrderID = {OrderID}", myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    decimal Cost = -1;
                    int productId = -1;
                    if (!(myReader["Cost"] is System.DBNull))
                        Cost = (decimal)myReader["Cost"];
                    if (!(myReader["ProductID"] is System.DBNull))
                        productId = (int)myReader["ProductID"];
                    var item = new OrderItem(productId, Cost);


                    items.Add(item);
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

            return items;
        }
    }
}
