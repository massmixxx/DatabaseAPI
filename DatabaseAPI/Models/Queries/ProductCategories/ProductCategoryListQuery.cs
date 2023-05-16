using DatabaseAPI.Models.DTO.ProductCategories;
using MediatR;

namespace DatabaseAPI.Models.Queries.ProductCategories
{
  public class ProductCategoryListQuery : IRequest<IEnumerable<ProductCategoryDTO>>
  {
  }
}
