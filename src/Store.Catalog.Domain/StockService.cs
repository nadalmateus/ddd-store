using Store.Catalog.Domain.Events;
using Store.Core.Bus;

namespace Store.Catalog.Domain;

public class StockService : IStockService
{
    private readonly IMediatorHandler _bus;
    private readonly IProductRepository _productRepository;

    public StockService(IProductRepository productRepository, IMediatorHandler bus)
    {
        _productRepository = productRepository;
        _bus = bus;
    }

    public async Task<bool> DebitStock(Guid productId, int quantity)
    {
        Product? product = await _productRepository.GetById(productId);

        if (product == null)
        {
            return false;
        }

        if (!product.HasStock(quantity))
        {
            return false;
        }

        product.DebitStock(quantity);

        if (product.StockQuantity < 10)
        {
            await _bus.PublishEvent(new ProductLowStockEvent(product.Id, product.StockQuantity));
        }

        _productRepository.Update(product);
        return await _productRepository.UnitOfWork.Commit();
    }

    public async Task<bool> ReplenishStock(Guid productId, int quantity)
    {
        Product? product = await _productRepository.GetById(productId);

        if (product == null)
        {
            return false;
        }

        product.ReplenishStock(quantity);

        _productRepository.Update(product);
        return await _productRepository.UnitOfWork.Commit();
    }

    public void Dispose()
    {
        _productRepository.Dispose();
    }
}