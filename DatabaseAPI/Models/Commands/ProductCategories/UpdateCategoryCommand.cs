using DatabaseAPI.Models.DTO.ProductCategories;
using MediatR;

namespace DatabaseAPI.Models.Commands.ProductCategories
{
    // pisałem już chyba o tym wcześniej przy okazji któregoś controllera:
    // W CQRS command nie powinien się chwalić tym, co zrobił, tylko to zrobić (ew. krzyknąć wyjątkiem, jak zrobić nie może)
    // od sprawdzenia rezultatów (pobrania danych) jest query
  public class UpdateCategoryCommand : IRequest<ProductCategoryDTO>
  {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
  }
}
