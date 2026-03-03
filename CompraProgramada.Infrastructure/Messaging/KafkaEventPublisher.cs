using CompraProgramada.Application.Interfaces;

namespace CompraProgramada.Infrastructure.Messaging;

public class KafkaEventPublisher : IEventPublisher
{
    public Task PublishAsync<T>(string topic, T message)
    {
        // implementação futura real
        Console.WriteLine($"[KAFKA EVENT] Topic: {topic}");
        return Task.CompletedTask;
    }
}