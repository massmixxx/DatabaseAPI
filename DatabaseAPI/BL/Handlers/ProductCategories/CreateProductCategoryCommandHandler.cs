using AutoMapper;
using DatabaseAPI.Database;
using DatabaseAPI.Database.Model.ProductCategories;
using MediatR;
using DatabaseAPI.Models.Commands.ProductCategories;
using DatabaseAPI.Models.DTO.ProductCategories;

namespace DatabaseAPI.BL.Handlers.ProductCategories
{
  public class CreateProductCategoryCommandHandler : IRequestHandler<CategoryCreateCommand, ProductCategoryDTO>
  {
    private readonly IProductCategoryFactory _factory;
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateProductCategoryCommandHandler(ApplicationDbContext context, IProductCategoryFactory factory, IMapper mapper)
    {
      _factory = factory;
      _context = context;
      _mapper = mapper;
    }

    public async Task<ProductCategoryDTO> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
      var category = await _factory.CreateAsync(request.Name, request.Description);
      await _context.SaveChangesAsync();
      return _mapper.Map<ProductCategoryDTO>(category);
    }
  }
}
