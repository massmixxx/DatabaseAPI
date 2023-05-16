using DatabaseAPI.Models.DTO.ProductCategories;
using MediatR;

namespace DatabaseAPI.Models.Commands.ProductCategories
{
  public class UpdateCategoryCommand : IRequest<ProductCategoryDTO>
  {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
  }
}
