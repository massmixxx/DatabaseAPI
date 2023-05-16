using AutoMapper;
using DatabaseAPI.Database;
using DatabaseAPI.Models.DTO.ProductCategories;
using DatabaseAPI.Models.Queries.ProductCategories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.BL.Handlers.ProductCategories
{
  public class ProductCategoryDetailsQueryHandler : IRequestHandler<ProductCategoryDetailsQuery, ProductCategoryDetailsDTO>
  {
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProductCategoryDetailsQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public async Task<ProductCategoryDetailsDTO> Handle(ProductCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
      return await _mapper.ProjectTo<ProductCategoryDetailsDTO>(_context.Categories.Where(x => x.Id == request.Id)).FirstOrDefaultAsync()
        ?? throw new NullReferenceException();
    }
  }
}
