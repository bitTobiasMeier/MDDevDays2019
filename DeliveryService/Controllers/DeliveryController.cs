using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private string path = @"c:\app\data\deliveryservice";

        public DeliveryController()
        {
            Directory.CreateDirectory(path);
        }

        // GET api/Delivery
        [HttpGet]
        public ActionResult<string> Get()
        {
            var filepath = Path.Combine(path, "log.txt");
            return System.IO.File.ReadAllText(filepath) ;
        }

        
        // POST api/Delivery
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            var now = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            var msg = $"{now}: {order.Quantity} * {order.Item} zu {order.Price}";
            System.Diagnostics.Debug.WriteLine(msg);
            var filepath = Path.Combine(path, "log.txt");
            System.IO.File.AppendAllText(filepath, msg);
        }

      
    }
}
