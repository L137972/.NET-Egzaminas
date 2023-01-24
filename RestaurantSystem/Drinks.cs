using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class Drinks : OrderItem
    {
        public Drinks(string itemName, double itemPrice)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
        }
        public override string ToString()
        {
            return ItemName + " " + ItemPrice + " €";
        }
    }
}
