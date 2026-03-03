using CompraProgramada.Application.Interfaces;


namespace CompraProgramada.Infrastructure.Messaging;

public class FakeEventPublisher : IEventPublisher
{
    public Task PublishAsync<T>(string topic, T message)
    {
        Console.WriteLine($"[FAKE EVENT] Topic: {topic}");
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(message));
        return Task.CompletedTask;
    }
}