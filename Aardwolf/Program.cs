using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlHandler;

namespace Aardwolf
{
    class Program
    {
        static void Main(string[] args)
        {
            string users = Sql.GetUsers();
            Console.WriteLine(users);
        }
    }
}
