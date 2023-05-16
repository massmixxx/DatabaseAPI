using MediatR;

namespace DatabaseAPI.Models.Commands.Products
{
  public class DeleteProductCommand : IRequest
  {
        public int Id { get; set; }
  }
}
