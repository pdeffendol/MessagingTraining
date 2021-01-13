using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransitTest.Core;
using Microsoft.Extensions.Logging;

namespace MassTransitTest.ConsoleApp
{
    class SomethingHappenedEventLogger : IConsumer<SomethingHappenedEvent>
    {
        ILogger<SomethingHappenedEventLogger> _logger;

        public SomethingHappenedEventLogger(ILogger<SomethingHappenedEventLogger> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<SomethingHappenedEvent> context)
        {
            _logger.LogInformation("Received message {Message}", context.Message.Message);

            return Task.CompletedTask;
        }
    }
}
