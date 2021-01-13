using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransitTest.Core;
using Microsoft.Extensions.Logging;

namespace MassTransitTest.ConsoleApp
{
    class SomethingHappenedEventMailer : IConsumer<SomethingHappenedEvent>
    {
        ILogger<SomethingHappenedEventMailer> _logger;

        public SomethingHappenedEventMailer(ILogger<SomethingHappenedEventMailer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<SomethingHappenedEvent> context)
        {
            _logger.LogInformation("Sending fake mail for {Message}", context.Message.Message);

            return Task.CompletedTask;
        }
    }
}
