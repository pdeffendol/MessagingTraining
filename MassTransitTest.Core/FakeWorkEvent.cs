using System;
namespace MassTransitTest.Core
{
    public record FakeWorkEvent
    {
        public int WorkDurationSeconds { get; init; }
        public string CompletedMessage { get; init; }
    }
}
