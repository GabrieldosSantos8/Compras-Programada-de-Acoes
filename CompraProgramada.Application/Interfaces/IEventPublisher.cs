namespace CompraProgramada.Application.Interfaces;

public interface IEventPublisher
{
    Task PublishAsync<T>(string topic, T message);
}