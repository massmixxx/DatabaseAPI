using AutoMapper;
using DatabaseAPI.Database;
using DatabaseAPI.Models.DTO.Products;
using DatabaseAPI.Models.Queries.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.BL.Handlers.Products
{
    public class ProductListQueryHandler : IRequestHandler<ProductListQuery, IEnumerable<ProductDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProductListQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<ProductDTO>(_context.Products).ToListAsync();
        }
    }
}
