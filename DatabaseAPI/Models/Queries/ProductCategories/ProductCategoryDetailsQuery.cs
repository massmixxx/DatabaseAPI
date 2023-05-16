using DatabaseAPI.Models.DTO.ProductCategories;
using MediatR;

namespace DatabaseAPI.Models.Queries.ProductCategories
{
  public class ProductCategoryDetailsQuery : IRequest<ProductCategoryDetailsDTO>
  {
        public int Id { get; set; }
    }
}
