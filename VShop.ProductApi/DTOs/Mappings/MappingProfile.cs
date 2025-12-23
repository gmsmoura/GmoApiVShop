using AutoMapper;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap(); // mapeando de ambas as formas

        CreateMap<ProductDTO, Product>(); // mapeando de ProductDTO para Product
        CreateMap<Product, ProductDTO>() // mapeando de Product para ProductDTO
         .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category!.Name)); // mapeando a propriedade CategoryName de ProductDTO a partir da propriedade Name de Category em Product

    }
}
