using AutoMapper;

using Store.Catalog.Application.DTOs;
using Store.Catalog.Domain;

namespace Store.Catalog.Application.AutoMapper;

public class DTOToDomainMappingProfile : Profile
{
    public DTOToDomainMappingProfile()
    {
        CreateMap<ProductDTO, Product>()
            .ConstructUsing(p => new Product(
            p.Name,
            p.Description,
            p.Active,
            p.Price,
            p.CategoryId,
            p.RegistrationDate,
            p.Image,
            new Dimensions(p.Height, p.Width, p.Depth)));

        CreateMap<CategoryDTO, Category>()
            .ConstructUsing(c => new Category(c.Name, c.Code));
    }
}