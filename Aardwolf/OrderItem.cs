using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aardwolf
{
    public class OrderItem
    {
        public int ProductId { get; }
        public double Cost { get; set; }

        //internal to database, shown only for completeness.
        private int OrderID;
    }
}
