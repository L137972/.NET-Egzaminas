using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class Table
    {
        public int TableNumber { get; set; }
        public int TableCapacity { get; set; }
        public bool IsTaken { get; private set; }

        public Table(int tableNumber, int tableCapacity)
        {
            TableNumber = tableNumber;
            TableCapacity = tableCapacity;
            IsTaken = false;
        }
        public void SetTakenStatus(bool isTaken)
        {
            IsTaken = isTaken;
        }
    }
}
