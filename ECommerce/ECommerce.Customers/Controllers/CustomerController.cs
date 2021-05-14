using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Customers.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Customers.Controllers
{
    public class CustomerController : Controller
    {
        readonly ICustomerProvider _customerProvider;
        public CustomerController(ICustomerProvider customerProviderr)
        {
            _customerProvider = customerProviderr;
        }

        [HttpPost]
        [Route("GetCustomers")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _customerProvider.GetCustomers();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("GetCustomerByID")]
        public async Task<IActionResult> GetOrderByID(int ID)
        {
            var result = await _customerProvider.GetCustomers(ID);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
