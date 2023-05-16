using AutoMapper;
using DatabaseAPI.Database.Entities;
using DatabaseAPI.Models.Commands.ProductCategories;
using DatabaseAPI.Models.Commands.Products;
using DatabaseAPI.Models.DTO.ProductCategories;

namespace DatabaseAPI.Profiles
{
  public class ProductCategoriesProfile : Profile
  {
        public ProductCategoriesProfile()
        {
          CreateMap<ProductCategory, ProductCategoryDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

           CreateMap<ProductCategory, ProductCategoryDetailsDTO>()
           .IncludeBase<ProductCategory, ProductCategoryDTO>()
           .ForMember(x => x.ModificationDate, opt => opt.MapFrom(src => src.ModificationDate))
           .ForMember(x => x.Products, opt => opt.MapFrom(src => src.Products))
           .ReverseMap();

           CreateMap<ProductCategory, UpdateCategoryCommand>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
            .ReverseMap();
    }
    }
}
