using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Repositories
{
    public class TableRepository
    {
        private List<Table> tables;
        public TableRepository()
        {
            tables = new List<Table>();
            tables.Add(new Table(1, 2));
            tables.Add(new Table(2, 2));
            tables.Add(new Table(3, 4));
            tables.Add(new Table(4, 4));
            tables.Add(new Table(5, 6));
        }
        public List<Table> Retrieve()
        {
            return tables;
        }
    }
}
