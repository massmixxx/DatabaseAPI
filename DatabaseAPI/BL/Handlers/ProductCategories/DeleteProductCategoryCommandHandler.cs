using DatabaseAPI.Database;
using DatabaseAPI.Models.Commands.ProductCategories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.BL.Handlers.ProductCategories
{
  public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
  {
    private readonly ApplicationDbContext _context;

    public DeleteProductCategoryCommandHandler(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
      var target = await _context.Categories.FirstAsync(x => x.Id == request.Id);
      _context.Remove(target);
      await _context.SaveChangesAsync();
    }
  }
}
