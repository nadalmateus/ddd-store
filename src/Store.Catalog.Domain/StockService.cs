namespace Store.Catalog.Domain
{
    public class StockService : IStockService
    {
        private readonly IProductRepository _productRepository;

        public StockService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> DebitStock(Guid productId, int quatity)
        {
            var product = await _productRepository.GetById(productId);

            if (product == null) return false;

            if (!product.HasStock(quatity)) return false;

            product.DebitStock(quatity);

            _productRepository.Update(product);
            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReplenishStock(Guid productId, int quatity)
        {
            var product = await _productRepository.GetById(productId);

            if (product == null) return false;

            product.ReplenishStock(quatity);

            _productRepository.Update(product);
            return await _productRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}