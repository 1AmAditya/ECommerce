using ECommerce.Customers.Database;
using ECommerce.Customers.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Customers.Provider
{
    public class CustomerProvider : ICustomerProvider
    {
        readonly CustomerDBContext _customerDBContex;
        public CustomerProvider(CustomerDBContext customerDBContex)
        {
            _customerDBContex = customerDBContex;
            SeedData();
        }

        public void SeedData()
        {
            if (!_customerDBContex.Customers.Any())
            {
                _customerDBContex.Customers.Add(new Customer { ID = 1, Name = "AbC", Address = "Varanasi" });
                _customerDBContex.Customers.Add(new Customer { ID = 2, Name = "AbC1", Address = "Bangalore" });
                _customerDBContex.Customers.Add(new Customer { ID = 3, Name = "AbC2", Address = "Delhi" });
                _customerDBContex.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            try
            {
                var orders = await _customerDBContex.Customers.ToListAsync<Customer>();
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

        public async Task<Customer> GetCustomers(int ID)
        {
            try
            {
                var orders = await _customerDBContex.Customers.FirstOrDefaultAsync(s => s.ID == ID);
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
