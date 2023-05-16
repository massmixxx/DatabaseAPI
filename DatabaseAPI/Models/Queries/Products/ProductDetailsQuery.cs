using DatabaseAPI.Models.DTO.Products;
using MediatR;

namespace DatabaseAPI.Models.Queries.Products
{
    public class ProductDetailsQuery : IRequest<ProductDTO>
    {
        public int Id { get; set; }
    }
}
