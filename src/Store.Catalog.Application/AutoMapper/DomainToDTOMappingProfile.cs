using AutoMapper;

using Store.Catalog.Application.DTOs;
using Store.Catalog.Domain;

namespace Store.Catalog.Application.AutoMapper;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Product, ProductDTO>()
            .ForMember(d => d.Height, o => o.MapFrom(s => s.Dimensions.Height))
            .ForMember(d => d.Width, o => o.MapFrom(s => s.Dimensions.Width))
            .ForMember(d => d.Depth, o => o.MapFrom(s => s.Dimensions.Depth));

        CreateMap<Category, CategoryDTO>();
    }
}