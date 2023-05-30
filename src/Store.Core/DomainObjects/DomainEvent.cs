using Store.Core.Messages;

namespace Store.Core.DomainObjects;

public class DomainEvent : Event
{
    public DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}