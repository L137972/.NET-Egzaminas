using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public abstract class OrderItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
    }
}
