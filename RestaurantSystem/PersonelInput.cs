using MimeKit.Encodings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class PersonelInput
    {
        public PersonelInput() { }
        public int Visitors()
        {
            Console.WriteLine("Number of Visitors: ");
            int visitors = Convert.ToInt32(Console.ReadLine());
            return visitors;
        }
        public void OrderInput()
        {
            Order order = new Order();
            order.OrderId++;

            RestaurantSystemService restaurantSystem = new RestaurantSystemService();
            restaurantSystem.LoadFood();
            restaurantSystem.LoadDrinks();

            //always picks new table, need to be able to add to existing order
            Table table = restaurantSystem.PickTable(Visitors());

            Console.WriteLine("Menu options: ");
            for (int i = 0; i < restaurantSystem.AllItems.Count; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}", i, restaurantSystem.AllItems[i].ItemName.ToString(), restaurantSystem.AllItems[i].ItemPrice.ToString());
            }

            AddItemToOrder(order);
            Console.WriteLine("Would you like to continue adding items to order? (y/n)");
            string continueInput = Console.ReadLine();

            while (continueInput == "y" || continueInput == "yes")
            {
                    AddItemToOrder(order);
                    Console.WriteLine("Would you like to continue adding items to order? (y/n)");
                    continueInput = Console.ReadLine();
            }
            if (continueInput == "n" || continueInput == "no")
            {
                order.CreateReceipt(order, table);
                table.SetTakenStatus(false);
                Console.WriteLine("Would you like to send receipt to email? (y/n)");
                string emailAddress = Console.ReadLine();
                if (emailAddress == "y" || emailAddress == "yes")
                {
                    Console.WriteLine("Enter email address if you'd like to send the receipt: ");
                    emailAddress = Console.ReadLine();
                    restaurantSystem.SendReceipt(emailAddress, order.OrderId);
                }
            } 
            else
            {
                Console.WriteLine("Incorrect input. Input 'y' to continue, 'n' to stop. Try again: ");
                continueInput = Console.ReadLine();
            }
        }
        public void AddItemToOrder(Order order)
        {
            RestaurantSystemService restaurantSystem = new RestaurantSystemService();
            List<OrderItem> orderOptions = restaurantSystem.AllItems;
            restaurantSystem.LoadFood();
            restaurantSystem.LoadDrinks();

            Console.WriteLine("Choose which item to add to order: ");
            int chosenItem = Convert.ToInt32(Console.ReadLine());

            for (int j = 0; j < orderOptions.Count; j++)
            {
                if (chosenItem == j)
                {
                    order.AddItem(orderOptions[j]);
                }
            }
        }
    }
}
