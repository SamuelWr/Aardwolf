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
        public decimal Cost { get;  }

        //internal to database, shown only for completeness.
        private int OrderID;

        public OrderItem(int productId, decimal Cost)
        {
            this.ProductId = productId;
            this.Cost = Cost;
        }
    }
}
