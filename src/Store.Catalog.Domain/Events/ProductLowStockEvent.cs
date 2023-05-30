using Store.Core.DomainObjects;

namespace Store.Catalog.Domain.Events;

public class ProductLowStockEvent : DomainEvent
{
    public ProductLowStockEvent(Guid aggregateId, int remainingStock) : base(aggregateId)
    {
        RemainingStock = remainingStock;
    }

    public int RemainingStock { get; private set; }
}