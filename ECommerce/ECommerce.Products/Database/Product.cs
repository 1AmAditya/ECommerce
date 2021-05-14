using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Products.Database
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Inventory { get; set; }
    }
}
