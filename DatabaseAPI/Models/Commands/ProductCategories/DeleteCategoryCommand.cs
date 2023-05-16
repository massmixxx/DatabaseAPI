using MediatR;

namespace DatabaseAPI.Models.Commands.ProductCategories
{
  public class DeleteCategoryCommand : IRequest
  {
        public int Id { get; set; }
    }
}
