using System;
namespace MassTransitTest.Core;

public record FakeWorkRequest
{
    public int WorkDurationSeconds { get; init; }
    public string CompletedMessage { get; init; }
}