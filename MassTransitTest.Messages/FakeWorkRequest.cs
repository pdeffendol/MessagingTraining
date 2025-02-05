namespace MassTransitTest.Messages;

public record FakeWorkRequest
{
    public int WorkDurationSeconds { get; init; }
    public string CompletedMessage { get; init; }
}