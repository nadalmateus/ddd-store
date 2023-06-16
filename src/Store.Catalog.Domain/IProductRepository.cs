using Store.Core.Data;

namespace Store.Catalog.Domain;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAll();

    Task<Product> GetById(Guid id);

    Task<IEnumerable<Product>> GetByCategory(int code);

    Task<IEnumerable<Category>> GetCategories();

    void Add(Product product);

    void Update(Product product);

    void Add(Category category);

    void Update(Category category);
}