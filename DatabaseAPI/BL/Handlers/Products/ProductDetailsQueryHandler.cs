using AutoMapper;
using DatabaseAPI.Database;
using DatabaseAPI.Models.DTO.Products;
using DatabaseAPI.Models.Queries.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.BL.Handlers.Products
{
  public class ProductDetailsQueryHandler : IRequestHandler<ProductDetailsQuery, ProductDTO>
  {
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ProductDetailsQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ProductDTO> Handle(ProductDetailsQuery request, CancellationToken cancellationToken)
    {
      var result = await _mapper.ProjectTo<ProductDTO>(_context.Products).FirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new NullReferenceException("Entity was not found.");
      return result;
    }
  }
}
