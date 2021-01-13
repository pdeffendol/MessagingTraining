using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransitTest.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MassTransitTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;
        private readonly IPublishEndpoint _publisher;

        public MessagesController(ILogger<MessagesController> logger, IPublishEndpoint publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(string text)
        {
            _logger.LogInformation("Publishing message {Message}", text);
            await _publisher.Publish<SomethingHappenedEvent>(new() { Message = text });

            return Ok();
        }
    }
}
