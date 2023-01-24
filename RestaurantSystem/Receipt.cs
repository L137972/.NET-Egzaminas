using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem
{
    public class Receipt
    {
        public string Content { get; set; }
        public string Email { get; set; }
        public Receipt(string content, string email)
        {
            Content = content;
            Email = email;
        }
    }
}
