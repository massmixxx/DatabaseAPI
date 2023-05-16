using DatabaseAPI.Database;
using DatabaseAPI.Models.Commands.Products;
using MediatR;

namespace DatabaseAPI.BL.Handlers.Products
{
  public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
  {
    private readonly ApplicationDbContext _context;

    public DeleteProductCommandHandler(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
      var entity = _context.Products.FirstOrDefault(x => x.Id == request.Id);

      if (entity == null)
        return;

      _context.Remove(entity);
      await _context.SaveChangesAsync();
    }
  }
}
