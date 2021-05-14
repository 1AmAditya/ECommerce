using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Products.Database;

namespace ECommerce.Products.Interface
{
    public interface IProductProvider
    {
        Task<Product> GetProducts(int ID);
        Task<IEnumerable<Product>> GetProducts();
    }
}
