using Store.Catalog.Application.DTOs;

namespace Store.Catalog.Application.Services;

public interface IProductAppService : IDisposable
{
    Task<IEnumerable<ProductDTO>> GetByCategory(Guid id);

    Task<ProductDTO> GetById(Guid id);

    Task<IEnumerable<ProductDTO>> GetAll();

    Task<IEnumerable<CategoryDTO>> GetCategories();

    Task AddProduct(ProductDTO productDTO);

    Task UpdateProduct(ProductDTO productDTO);

    Task<ProductDTO> DebitStock(Guid id, int quantity);

    Task<ProductDTO> ReplenishStock(Guid id, int quantity);
}