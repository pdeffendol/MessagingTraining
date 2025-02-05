using MassTransit;
using MassTransitTest.Messages;
using SerilogTimings;

namespace MassTransitTest.Consumer;

internal class FakeWorkRequestHandler : IConsumer<FakeWorkRequest>
{
    ILogger<FakeWorkRequestHandler> _logger;

    public FakeWorkRequestHandler(ILogger<FakeWorkRequestHandler> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<FakeWorkRequest> context)
    {
        using (Operation.Time("{Message}", context.Message.CompletedMessage))
        {
            await Task.Delay(context.Message.WorkDurationSeconds * 1000);
        }
    }
}