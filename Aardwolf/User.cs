﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aardwolf
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        //Todo: consider changing address to a class instead of a string.
        public string DeliveryAddress { get; set; }


        public List<Order> Orders = new List<Order>();

        //internal to database, shown here only for completeness. Don't use them.
        private string PasswordHash;
        private string PasswordSalt;

        public User(string UserName)
        {
            this.UserName = UserName;
        }
    }
}
