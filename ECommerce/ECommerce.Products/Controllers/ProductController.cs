using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Products.Interface;
using ECommerce.Products.Provider;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Products.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductProvider _productProvider;
        public ProductController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        [HttpPost]
        [Route("GetProducts")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _productProvider.GetProducts();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("GetProductByID")]
        public async Task<IActionResult> GetOrderByID(int ID)
        {
            var result = await _productProvider.GetProducts(ID);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
