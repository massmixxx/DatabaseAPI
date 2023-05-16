using DatabaseAPI.Models.DTO.ProductCategories;
using MediatR;

namespace DatabaseAPI.Models.Commands.ProductCategories
{
  public class CategoryCreateCommand : IRequest<ProductCategoryDTO>
  {
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
  }
}
