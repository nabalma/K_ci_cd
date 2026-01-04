using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Kolyya.Api.Messages;

namespace Kolyya.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public OrdersController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TouristicCardOrdered message)
        {
            Console.WriteLine("📥 Requête reçue dans /api/orders");
            Console.WriteLine($"🔹 Titre : {message.CardTitle}");
            Console.WriteLine($"🔹 Destination : {message.Destination}");
            Console.WriteLine($"🔹 OrderedBy : {message.OrderedBy}");

            try
            {
                await _publishEndpoint.Publish(message);
                Console.WriteLine("✅ Message publié dans RabbitMQ !");
                return Ok(new { status = "Commande envoyée" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERREUR lors du publish RabbitMQ : {ex.Message}");
                return StatusCode(500, new
                {
                    status = "Erreur RabbitMQ",
                    message = ex.Message
                });
            }
        }
    }
}
