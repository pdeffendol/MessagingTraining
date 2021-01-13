using System;

namespace MassTransitTest.Core
{
    public record SomethingHappenedEvent
    {
        public string Message { get; init; }
    }
}
