namespace MassTransitTest.API;

public record WorkCommand
{
    public string Message { get; set; }
    public int SecondsOfWork { get; set; }
}
