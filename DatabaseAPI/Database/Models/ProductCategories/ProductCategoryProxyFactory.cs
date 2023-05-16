using DatabaseAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.Database.Model.ProductCategories
{
  public interface IProductCategoryFactory
  {
    Task<ProductCategory> CreateAsync(string name, string? description);
  }


  public abstract class ProductCategoryFactory : IProductCategoryFactory
  {
    public async Task<ProductCategory> CreateAsync(string name, string? description)
    {
      return await CreateBaseAsync(name, description);
    }

    protected abstract Task<ProductCategory> CreateBaseAsync(string name, string? description);
  }

  // Po co proxy do tworzenia encji?
  public class ProductCategoryProxyFactory : ProductCategoryFactory
  {
    private readonly ApplicationDbContext _context;
        public ProductCategoryProxyFactory(ApplicationDbContext context)
        {
          _context = context;
        }
        protected override async Task<ProductCategory> CreateBaseAsync(string name, string? description)
        {
          ProductCategory category = _context.CreateProxy<ProductCategory>(name, description);
          await _context.AddAsync(category);

          return category;
        }
  }
}
