namespace Store.Catalog.Domain
{
    public interface IStockService
    {
        Task<bool> DebitStock(Guid productId, int quatity);

        Task<bool> ReplenishStock(Guid productId, int quatity);
    }
}