using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Table> Tables { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public string Email { get; set; }

        public Order()
        {
            OrderId = 0;
            Date = DateTime.Now;
            Total = 0;
            Tables = new List<Table>();
            OrderItems = new List<OrderItem>();
        }
        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
            Total += item.ItemPrice;
        }
        public void CreateReceipt(Order order, Table table)
        {
            OrderId++;
            string content = "Order Date: " + Date.ToString() + " Table number: " + table.TableNumber + "Number of Seats at tabke: " + table.TableCapacity + "\nOrdered Items: \n";
            foreach(OrderItem item in OrderItems)
            {
                content += item.ToString() + "\n";
            }
            content += "Total: " + Total + " €";
            File.WriteAllText($"Receipt#{OrderId}.txt", content);
        }
    }
}
