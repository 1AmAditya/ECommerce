using ECommerce.Customers.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Customers.Interface
{
    public interface ICustomerProvider
    {
        Task<Customer> GetCustomers(int ID);
        Task<IEnumerable<Customer>> GetCustomers();
    }
}
