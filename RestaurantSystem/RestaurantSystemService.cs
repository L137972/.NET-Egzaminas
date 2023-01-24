using RestaurantSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;
using MailKit.Search;


namespace RestaurantSystem
{
    public class RestaurantSystemService
    {
        public List<OrderItem> OrderItems { get; set; }
        public List<Receipt> Receipts { get; set; }
        public List<Table> Tables { get; set; }
        public List<OrderItem> AllItems { get; set; }
        public RestaurantSystemService()
        {
            OrderItems = new List<OrderItem>();
            Receipts = new List<Receipt>();
            Tables = new TableRepository().Retrieve();
            AllItems = new List<OrderItem>();
        }
        public Table PickTable(int visitors)
        {
            foreach (Table table in Tables)
            {
                if (visitors <= table.TableCapacity && !table.IsTaken)
                {
                    table.SetTakenStatus(true);
                    return table;
                }
            }
            return null;
        }
        public bool LoadDrinks()
        {
            try
            {
                string[] drinkItemsStrings = File.ReadAllLines("Drinks.csv");
                foreach (string drinkString in drinkItemsStrings)
                {
                    string[] tokens = drinkString.Split(",");
                    Drinks drink = new Drinks(tokens[0], Convert.ToDouble(tokens[1]));
                    AllItems.Add(drink);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LoadFood()
        {
            try
            {
                string[] foodItemsStrings = File.ReadAllLines("Food.csv");
                foreach (string foodString in foodItemsStrings)
                {
                    string[] tokens = foodString.Split(",");
                    Food food = new Food(tokens[0], Convert.ToDouble(tokens[1]));
                    AllItems.Add(food);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SendReceipt(string emailAddress, int orderId)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Lina", "LinaVen137@gmail.com"));
            email.To.Add(new MailboxAddress("Restaurant Client", emailAddress));

            email.Subject = "Restaurant Order Receipt";
            var builder = new BodyBuilder();

            builder.TextBody = @"Your restaurant receipt: ";

            builder.Attachments.Add($"Receipt#{orderId}.txt");

            email.Body = builder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);

                smtp.Authenticate("LinaVen137@gmail.com", "wctjlezoruxdrdew");

                try
                {
                    smtp.Send(email);
                    smtp.Disconnect(true);
                    return true;
                }
                catch
                {
                    return false;
                }
               

            }
        }
    }
}
