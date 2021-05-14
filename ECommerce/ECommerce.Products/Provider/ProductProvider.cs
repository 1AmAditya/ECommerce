using ECommerce.Products.Database;
using ECommerce.Products.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Products.Provider
{
    public class ProductProvider : IProductProvider
    {
        readonly ProductDBContext _productDBContext;
        public ProductProvider(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
            SeedData();
        }

        public void SeedData()
        {
            if (!_productDBContext.Products.Any())
            {
                _productDBContext.Products.Add(new Product { ID = 1, Name = "AbC", Address = "Varanasi", Inventory = 100 });
                _productDBContext.Products.Add(new Product { ID = 2, Name = "AbC1", Address = "Bangalore", Inventory = 80 });
                _productDBContext.Products.Add(new Product { ID = 3, Name = "AbC2", Address = "Delhi", Inventory = 150 });
                _productDBContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var orders = await _productDBContext.Products.ToListAsync<Product>();
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

        public async Task<Product> GetProducts(int ID)
        {
            try
            {
                var orders = await _productDBContext.Products.FirstOrDefaultAsync(s => s.ID == ID);
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
