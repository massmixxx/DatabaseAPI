using AutoMapper;
using DatabaseAPI.Database;
using DatabaseAPI.Models.DTO.ProductCategories;
using DatabaseAPI.Models.Queries.ProductCategories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.BL.Handlers.ProductCategories
{
  public class ProductCategoryListQueryHandler : IRequestHandler<ProductCategoryListQuery, IEnumerable<ProductCategoryDTO>>
  {
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProductCategoryListQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public async Task<IEnumerable<ProductCategoryDTO>> Handle(ProductCategoryListQuery request, CancellationToken cancellationToken)
    {
      return await _mapper.ProjectTo<ProductCategoryDTO>(_context.Categories).ToListAsync();
    }
  }
}
