using ECommerce.Orders.Database;
using ECommerce.Orders.Database.Model;
using ECommerce.Orders.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Orders.Provider
{
    public class OrderProvider : IOrderProvider
    {
        readonly OrderDBContxt _orderDBContxt;
        readonly ILogger _logger;
        public OrderProvider(OrderDBContxt orderDBContxt)
        {
            _orderDBContxt = orderDBContxt;
            SeedData();
        }

        public  void SeedData()
        {
            if(!_orderDBContxt.Orders.Any())
            {
                _orderDBContxt.Orders.Add(new Order { ID = 1, Name = "AbC", Address = "Varanasi", Price = 100 });
                _orderDBContxt.Orders.Add(new Order { ID = 2, Name = "AbC1", Address = "Bangalore", Price = 80 });
                _orderDBContxt.Orders.Add(new Order { ID = 3, Name = "AbC2", Address = "Delhi", Price = 150 });
                _orderDBContxt.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            try
            {
                var orders = await _orderDBContxt.Orders.ToListAsync<Order>();
                if(orders != null)
                {
                    return orders;
                }

                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task< Order> GetOrders(int ID)
        {
            try
            {
                var orders = await _orderDBContxt.Orders.FirstOrDefaultAsync(s => s.ID == ID);
                if (orders != null)
                {
                    return orders;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
