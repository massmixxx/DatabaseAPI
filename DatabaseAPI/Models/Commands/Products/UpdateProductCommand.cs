using DatabaseAPI.Models.DTO.Products;
using MediatR;

namespace DatabaseAPI.Models.Commands.Products
{
  public class UpdateProductCommand : IRequest<ProductDTO>
  {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string SKU { get; set; } = null!;
    public decimal CurrentPrice { get; set; }
    public string? Filename { get; set; } = null!;
    public int CategoryId { get; set; }
  }
}
