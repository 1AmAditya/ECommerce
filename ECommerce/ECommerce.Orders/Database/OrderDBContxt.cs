using ECommerce.Orders.Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Orders.Database
{
    public class OrderDBContxt : DbContext
    {
        public OrderDBContxt(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
