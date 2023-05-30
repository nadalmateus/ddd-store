using Store.Core.Messages;

namespace Store.Core.Bus;

public interface IMediatorHandler
{
    Task PublishEvent<T>(T @event) where T : Event;
}