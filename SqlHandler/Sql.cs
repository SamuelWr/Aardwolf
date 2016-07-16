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

        public static void AddProduct(string ProductName, string Description, string PictureUrl, string ThumbnailUrl, decimal cost)
        {
            //Todo: change to storedprocedure to avoid Sql injections.
            //Less critical since only admins get to use it.
            //But still good, to handle Nintendo naming their next pokemon Bobby Tables. (robert' drop table users --)
            string commandString = "INSERT into Products "
                              + "(ProductName, Description, PictureUrl, ThumbnailPictureUrl, Cost) "
                              + "values "
                              + $"('{ProductName}', '{Description}', '{PictureUrl}', '{ThumbnailUrl}', {cost}) ";

            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand = new SqlCommand(commandString, myConnection);

            try
            {
                myConnection.Open();
                var rowsAffected = myCommand.ExecuteNonQuery();

                if (rowsAffected != 1)
                    throw new ApplicationException("failed to insert orderItem into database");
            }
            catch (Exception ex)
            {
                //Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }

        }

        private static Random random = new Random();
        private const int lengthOfSalt = 10;

        public static void DeleteOrder(int UserId, int OrderId)
        {
            //We only really need OrderId, but having UserId for errorchecking is nice.
            var commandString = $"SELECT * from Orders WHERE ID = {OrderId} AND CustomerID = {UserId}";
            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand = new SqlCommand(commandString, myConnection);

            try
            {
                //check order exists
                myConnection.Open();
                var myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //Good there exists such an order
                }
                else
                {
                    //order does not exist, end delete.
                    return;
                }
                myConnection.Close();
                //delete order items
                commandString = $"DELETE from OrderItems WHERE OrderID = {OrderId}";
                myConnection = new SqlConnection(CON_STR);
                myCommand = new SqlCommand(commandString, myConnection);
                myConnection.Open();
                int rowsAffected = myCommand.ExecuteNonQuery();
                myConnection.Close();
                //delete order
                commandString = $"DELETE from Orders WHERE ID = {OrderId} AND CustomerID = {UserId}";
                myConnection = new SqlConnection(CON_STR);
                myCommand = new SqlCommand(commandString, myConnection);
                myConnection.Open();
                rowsAffected = myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }


        }

        public static void MakeOrder(int userId, string deliveryAddress, List<OrderItem> orderItems)
        {
            //Add order
            int orderId = -1;

            SqlConnection myConnection = new SqlConnection(CON_STR);
            try
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.CommandText = "insertorder";

                SqlParameter paramUserId = new SqlParameter("@customerid", System.Data.SqlDbType.Int);
                paramUserId.Value = userId;
                myCommand.Parameters.Add(paramUserId);


                SqlParameter paramAddress = new SqlParameter("@address", System.Data.SqlDbType.VarChar);
                paramAddress.Size = 8000;
                paramAddress.Value = deliveryAddress;
                myCommand.Parameters.Add(paramAddress);


                SqlParameter paramOrderId = new SqlParameter("@orderid", System.Data.SqlDbType.Int);
                paramOrderId.Direction = System.Data.ParameterDirection.Output;
                myCommand.Parameters.Add(paramOrderId);

                myConnection.Open();
                int numberofrows = myCommand.ExecuteNonQuery();
                orderId = (int)paramOrderId.Value;

                //Console.WriteLine($"Added {numberofrows} rows.");

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

            //add items to order
            if (orderId != -1)
                foreach (var item in orderItems)
                {
                    AddOrderItem(orderId, item);
                }
        }

        private static void AddOrderItem(int orderId, OrderItem item)
        {
            //Hack: dividing cost by 10000 to make conversion from string to Sql.Money work.
            //stored procedure would probably be better
            var commandString = $"insert into OrderItems (OrderID,ProductID,Cost) values ({orderId},{item.ProductId},'{item.Cost / 10000}')";

            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand = new SqlCommand(commandString, myConnection);

            try
            {
                myConnection.Open();
                var rowsAffected = myCommand.ExecuteNonQuery();

                if (rowsAffected != 1)
                    throw new ApplicationException("failed to insert orderItem into database");
            }
            catch (Exception ex)
            {
                //Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }
        }

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
            //TODO: I might have a security issue here if someone crashes the database at just the right moment.
            // then stored hash and salt is empty string.
            //and input password might be manipulated to return empty string too.
            //          move into try clause and return -1 if any excepton occurs to fix?
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

                //salt = (string)paramSalt.Value;
                //hash = (string)paramHash.Value;
                //userId = (int)paramUserId.Value;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

            //Console.WriteLine($"Hash: {hash}");
            //Console.WriteLine($"Salt: {salt}");
            //Console.WriteLine($"UserId: {userId}");

            //compute hash from input password.
            string ComputedHash = ComputeHash(password, salt);
            //compare and return
            if (hash.Equals(ComputedHash))
                return userId;
            else
                return -1;
        }

        private static string ComputeHash(string password, string salt)
        {
            //Todo: only thing left to get secure log ins (I hope...)
            return "HashHere";

            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new user, returns user object if successful else null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <param name="isAdmin"></param>
        /// <returns>User object representing the new user.</returns>
        
        // Ändrade metoden till en bool då jag bara vill ha info om registreringen lyckades eller ej,
        // eller hade du någon annan tanke på användning av att returnera en user? La även till att
        // standard för isAdmin är false så slipper jag skicka med den som en parameter varje gång
        // eftersom vi bara kommer skapa admins direkt i databasen /Viktor
        public static bool CreateUser(string userName, string Password, bool isAdmin = false)
        {
            //todo: check that username does not already exist.

            //compute hash
            char[] saltArray = new char[lengthOfSalt];
            for (int i = 0; i < lengthOfSalt; i++)
            {
                saltArray[i] = (char)random.Next(65, 91);
            }
            var salt = new string(saltArray);

            string hash = ComputeHash(Password, salt);

            //Insert user in database
            var user = new User(userName);
            user.UserId = InsertUserInDatabase(userName, isAdmin, hash, salt);

            //return user if insert completed.
            if (user.UserId > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Creates a new user in database with supplied data
        /// </summary>
        /// <param name="userName">Username of new user</param>
        /// <param name="hash">Computed password hash</param>
        /// <param name="salt">password salt</param>
        /// <returns>UserId of new user, -1 if failed.</returns>
        private static int InsertUserInDatabase(string userName,bool isAdmin, string hash, string salt)
        {
            int userId = -1;
            SqlConnection myConnection = new SqlConnection(CON_STR);

            try
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.CommandText = "insertuser";

                SqlParameter paramUserName = new SqlParameter("@username", System.Data.SqlDbType.VarChar);
                paramUserName.Value = userName;
                paramUserName.Size = 100;
                myCommand.Parameters.Add(paramUserName);



                SqlParameter paramHash = new SqlParameter("@pwhash", System.Data.SqlDbType.VarChar);
                //paramHash.Direction = System.Data.ParameterDirection.Output;
                paramHash.Value = hash;
                paramHash.Size = 100;
                myCommand.Parameters.Add(paramHash);

                SqlParameter paramSalt = new SqlParameter("@pwsalt", System.Data.SqlDbType.VarChar);
                //paramSalt.Direction = System.Data.ParameterDirection.Output;
                paramSalt.Value = salt;
                paramSalt.Size = 20;
                myCommand.Parameters.Add(paramSalt);

                SqlParameter paramIsAdmin = new SqlParameter("@isadmin", System.Data.SqlDbType.Bit);
                //paramSalt.Direction = System.Data.ParameterDirection.Output;
                paramIsAdmin.Value = isAdmin;
                //paramSalt.Size = 20;
                myCommand.Parameters.Add(paramIsAdmin);


                SqlParameter paramUserId = new SqlParameter("@userid", System.Data.SqlDbType.Int);
                paramUserId.Direction = System.Data.ParameterDirection.Output;
                myCommand.Parameters.Add(paramUserId);

                myConnection.Open();
                int numberofrows = myCommand.ExecuteNonQuery();

                //Console.WriteLine($"Added {numberofrows} rows.");
                //salt = (string)paramSalt.Value;
                //hash = (string)paramHash.Value;
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

            return userId;
        }

        /// <summary>
        /// Takes a User object referring to a already existing user, makes required changes in database
        /// Does not touch orders.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>A bool indicating if the changes succeeded.</returns>
        public static bool UpdateUser(User user)
        {
            //Require password too?
            bool success = false;

            SqlConnection myConnection = new SqlConnection(CON_STR);

            try
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.CommandText = "updateuser";

                SqlParameter paramFirstName = new SqlParameter("@firstname", System.Data.SqlDbType.VarChar);
                paramFirstName.Value = user.FirstName;
                paramFirstName.Size = 100;
                myCommand.Parameters.Add(paramFirstName);

                SqlParameter paramLastName = new SqlParameter("@lastname", System.Data.SqlDbType.VarChar);
                paramLastName.Value = user.LastName;
                paramLastName.Size = 100;
                myCommand.Parameters.Add(paramLastName);

                SqlParameter paramEmail = new SqlParameter("@email", System.Data.SqlDbType.VarChar);
                paramEmail.Value = user.EmailAddress;
                paramEmail.Size = 100;
                myCommand.Parameters.Add(paramEmail);

                SqlParameter paramAddress = new SqlParameter("@address", System.Data.SqlDbType.VarChar);
                paramAddress.Value = user.DeliveryAddress;
                paramAddress.Size = 100;
                myCommand.Parameters.Add(paramAddress);

                SqlParameter paramID = new SqlParameter("@userid", System.Data.SqlDbType.Int);
                paramID.Value = user.UserId;
                myCommand.Parameters.Add(paramID);

                myConnection.Open();
                int numberofrows = myCommand.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return success;
        }
        /// <summary>
        /// returns list of all products
        /// </summary>
        public static List<Product> GetProducts()
        {
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
                        product.Cost = (decimal)myReader["Cost"];

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
