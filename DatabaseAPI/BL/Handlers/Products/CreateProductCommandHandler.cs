using AutoMapper;
using DatabaseAPI.Database;
using DatabaseAPI.Database.Model.Products;
using DatabaseAPI.Models.Commands.Products;
using DatabaseAPI.Models.DTO.Products;
using MediatR;
namespace DatabaseAPI.BL.Handlers.Products
{
  public class CreateProductCommandHandler : IRequestHandler<ProductCreateCommand,ProductDTO>
  {
    private readonly IProductFactory _factory;
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(ApplicationDbContext context, IProductFactory factory, IMapper mapper)
    {
      _factory = factory;
      _context = context;
      _mapper = mapper;
    }

    public async Task<ProductDTO> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
      var product = await _factory.CreateAsync(request.Name, request.Description ?? string.Empty, request.SKU, request.CurrentPrice, request.CategoryId, request.Filename);

      await _context.SaveChangesAsync();

      return _mapper.Map<ProductDTO>(product);
    }
  }
}
