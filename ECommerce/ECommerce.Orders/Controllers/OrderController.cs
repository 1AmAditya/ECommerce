using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Orders.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Orders.Controllers
{
    public class OrderController : Controller
    {
        readonly IOrderProvider _orderProvider;
        public OrderController(IOrderProvider orderProvider)
        {
            _orderProvider = orderProvider;
        }

        [HttpPost]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await  _orderProvider.GetOrders();

            if(result != null)
            {
                return Ok(result);
            }

            return NotFound(); 
        }

        [HttpPost]
        [Route("GetOrderByID")]
        public async Task<IActionResult> GetOrderByID(int ID)
        {
            var result = await _orderProvider.GetOrders(ID);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
