using DatabaseAPI.Models.DTO.Products;
using MediatR;

namespace DatabaseAPI.Models.Queries.Products
{
    public class ProductListQuery : IRequest<IEnumerable<ProductDTO>>
    {
        // model for researching properties
    }
}
