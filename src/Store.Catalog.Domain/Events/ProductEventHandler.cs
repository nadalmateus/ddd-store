using MediatR;

namespace Store.Catalog.Domain.Events;

public class ProductEventHandler : INotificationHandler<ProductLowStockEvent>
{
    private readonly IProductRepository _productRepository;

    public ProductEventHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(ProductLowStockEvent message, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetById(message.AggregateId);
    }
}