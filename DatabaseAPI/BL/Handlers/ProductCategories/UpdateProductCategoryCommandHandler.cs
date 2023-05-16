using AutoMapper;
using DatabaseAPI.Database;
using MediatR;
using DatabaseAPI.Models.DTO.ProductCategories;
using DatabaseAPI.Models.Commands.ProductCategories;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.BL.Handlers.ProductCategories
{
  public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ProductCategoryDTO>
  {
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateProductCategoryCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ProductCategoryDTO> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
      var currCategory = await _context.Categories.FirstAsync(x => x.Id == request.Id);
      currCategory = _mapper.Map(request, currCategory);

      _context.Update(currCategory);
      await _context.SaveChangesAsync();

      return _mapper.Map<ProductCategoryDTO>(currCategory);
    }
  }
}
