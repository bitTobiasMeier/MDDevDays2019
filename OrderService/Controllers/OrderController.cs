using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET api/order
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Hello", "Magdeburg" };
        }

        // GET api/order/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        // POST api/order
        [HttpPost]
        public async void Post([FromBody] Order order)
        {
            System.Diagnostics.Debug.WriteLine($"{order.Quantity} * {order.Item} zu {order.Price}");
            var client = new HttpClient();
            var svcname = Environment.GetEnvironmentVariable("DeliveryServiceName");
            await client.PostAsJsonAsync("http://" + svcname + "/api/Delivery/", order);
        }

       
    }

}
