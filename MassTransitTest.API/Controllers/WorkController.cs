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
    public class WorkController : ControllerBase
    {
        private readonly ILogger<WorkController> _logger;
        private readonly IPublishEndpoint _publisher;

        public WorkController(ILogger<WorkController> logger, IPublishEndpoint publisher)
        {
            _logger = logger;
            _publisher = publisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWork(string message, int secondsOfWork)
        {
            _logger.LogInformation("Creating {SecondsOfWork}s of work with message {Message}", secondsOfWork, message);
            await _publisher.Publish<FakeWorkRequest>(new() { WorkDurationSeconds = secondsOfWork, CompletedMessage = message });

            return Ok();
        }
    }
}
