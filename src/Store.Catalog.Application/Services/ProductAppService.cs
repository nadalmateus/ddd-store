using AutoMapper;

using Store.Catalog.Application.DTOs;
using Store.Catalog.Domain;
using Store.Core.DomainObjects;

namespace Store.Catalog.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IProductRepository _productRepository;
    private readonly IStockService _stockService;
    private readonly IMapper _mapper;

    public ProductAppService(IProductRepository productRepository, IMapper mapper, IStockService stockService)
    {
        _productRepository = productRepository;
        _stockService = stockService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetByCategory(int code)
    {
        return _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetByCategory(code));
    }

    public async Task<ProductDTO> GetById(Guid id)
    {
        return _mapper.Map<ProductDTO>(await _productRepository.GetById(id));
    }

    public async Task<IEnumerable<ProductDTO>> GetAll()
    {
        return _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetAll());
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        return _mapper.Map<IEnumerable<CategoryDTO>>(await _productRepository.GetCategories());
    }

    public async Task AddProduct(ProductDTO productDTO)
    {
        var product = _mapper.Map<Product>(productDTO);
        _productRepository.Add(product);

        await _productRepository.UnitOfWork.Commit();
    }

    public async Task UpdateProduct(ProductDTO productDTO)
    {
        var product = _mapper.Map<Product>(productDTO);
        _productRepository.Update(product);

        await _productRepository.UnitOfWork.Commit();
    }

    public async Task<ProductDTO> DebitStock(Guid id, int quantity)
    {
        return !_stockService.DebitStock(id, quantity).Result
            ? throw new DomainException("Failed to debit stock")
            : _mapper.Map<ProductDTO>(await _productRepository.GetById(id));
    }

    public async Task<ProductDTO> ReplenishStock(Guid id, int quantity)
    {
        return !_stockService.ReplenishStock(id, quantity).Result
            ? throw new DomainException("Failed to replenish stock")
            : _mapper.Map<ProductDTO>(await _productRepository.GetById(id));
    }

    public void Dispose()
    {
        _productRepository?.Dispose();
        _stockService?.Dispose();
    }
}