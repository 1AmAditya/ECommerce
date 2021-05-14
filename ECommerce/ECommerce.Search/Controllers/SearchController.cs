using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Search.Controllers
{
    public class SearchController : Controller
    {

        readonly IHttpClientFactory _httpClientFactory;


        public SearchController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        [Route("OrderSearch")]
        public async Task<IActionResult> OrderSearch()
        {
            var client = _httpClientFactory.CreateClient("OrderedService");
            var response = await client.PostAsync($"GetOrders",null);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                var result = JsonSerializer.Deserialize<IEnumerable<object>>(content);
                return Ok(result);
            }

            return null;
        }

        [HttpPost]
        [Route("SearchProduct")]
        public async Task<IActionResult> SearchProduct()
        {
            var client = _httpClientFactory.CreateClient("ProductService");
            var response = await client.PostAsync($"GetProducts",null);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                var result = JsonSerializer.Deserialize<IEnumerable<object>>(content);
                return Ok(result);
            }

            return null;
        }


        [HttpPost]
        [Route("SearchCustomer")]
        public async Task<IActionResult> SearchCustomer()
        {
            var client = _httpClientFactory.CreateClient("CustomerService");
            var response = await client.PostAsync($"GetCustomers",null);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                var result = JsonSerializer.Deserialize<IEnumerable<object>>(content);
                return Ok(result);
            }

            return null;
        }
    }
}
