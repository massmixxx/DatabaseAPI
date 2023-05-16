using DatabaseAPI.Models.DTO.ProductCategories;
using MediatR;

namespace DatabaseAPI.Models.Commands.ProductCategories
{
  // Warto zadbać o to, aby command / query było niezmienne:
  // 1. Albo private set + konstruktor z parametrami / statyczna metoda tworząca obiekt
  // 2. Albo "init" zamiast "set"
  // 3. Albo record zamiast class
  public class CategoryCreateCommand : IRequest<ProductCategoryDTO>
  {
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
  }
}
