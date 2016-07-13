using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aardwolf
{
    public class Order
    {
        public string DeliveryAddress { get; set; }
        public double TotalCost
        {
            get
            {
                if (Items != null)
                    return Items.Sum(i => i.Cost);
                else
                    return 0;
            }

        }
        public bool HasBeenDelivered { get; set; }

        List<OrderItem> Items = new List<OrderItem>();

        //internal to database, shown only for completeness.
        private int CustomerId;
    }
}
