using ECommerce.Orders.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Orders.Interface
{
    public interface IOrderProvider
    {
        Task<Order> GetOrders(int ID);
        Task<IEnumerable<Order>> GetOrders();
    }
}
