using AutoMapper;
using DatabaseAPI.Database.Entities;
using DatabaseAPI.Database.Entities.ValueObjects;
using DatabaseAPI.Models.Commands.Products;
using DatabaseAPI.Models.DTO.Products;

namespace DatabaseAPI.Profiles
{
  // Lubię Automappera i często z niego korzystam, ze względu na wygodę i prostotę definiowania mapowań,
  // Musidz jednak mieć na uwadze jedno: Automapper jest strasznie wolny i zasobożerny w porównaniu do innych rozwiązań dostępnych na rynku.
  // Ogólnie każdy mechanizm generuje jakiś narzut, a biorąc pod uwagę, że mapowania wykonywane są często i w dużych ilościach 
  // coraz częściej widzę powrót do pierwotnego podejścia i robienia mapowań ręcznie, np jako extensions method.
  public class ProductProfile : Profile
  {
    public ProductProfile() 
    {
      CreateMap<Product, ProductDTO>()
      .ForMember(x => x.SKU, opt => opt.MapFrom(src => src.SKU))
      .ForMember(x => x.CurrentPrice, opt => opt.MapFrom(src => src.CurrentPrice))
      .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
      .ForMember(x => x.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
      .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

      CreateMap<Product, ProductEssentialsDTO>();

      CreateMap<UpdateProductCommand, Product>()
      .ForMember(x => x.SKU, opt => opt.MapFrom(src => src.SKU))
      .ForMember(x => x.CurrentPrice, opt => opt.MapFrom(src => src.CurrentPrice))
      .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
      .ForMember(x => x.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
      .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
      .ForMember(x => x.FileName, opt => opt.MapFrom(src => src.Filename));
    }
  }
}
