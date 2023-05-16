using AutoMapper;
using DatabaseAPI.Database;
using DatabaseAPI.Database.Entities;
using DatabaseAPI.Models.Commands.Products;
using DatabaseAPI.Models.DTO.Products;
using MediatR;

namespace DatabaseAPI.BL.Handlers.Products
{
  public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
  {
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public UpdateProductCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
      var currProduct = _context.Products.FirstOrDefault(x => x.Id == request.Id) ?? throw new NullReferenceException("Product was not found.");

      currProduct = _mapper.Map(request, currProduct);

      _context.Update(currProduct);
      await _context.SaveChangesAsync();

      return _mapper.Map<Product, ProductDTO>(currProduct);
    }
  }
}
