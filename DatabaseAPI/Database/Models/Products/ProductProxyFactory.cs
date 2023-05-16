using DatabaseAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.Database.Model.Products
{

  public interface IProductFactory
  {
    Task<Product> CreateAsync(string name, string description, string sku, decimal price, int categoryId, string? filename);
  }

  public abstract class ProductFactory : IProductFactory
  {
    public async Task<Product> CreateAsync(string name, string description, string sku, decimal price, int categoryId, string? filename)
    {
      return await CreateBaseAsync(name, description, sku, price, categoryId, filename);
    }

    protected abstract Task<Product> CreateBaseAsync(string name, string description, string sku, decimal price, int categoryId, string? filename);
  }

  public class ProductProxyFactory : ProductFactory
    {
    private readonly ApplicationDbContext _context;
        public ProductProxyFactory(ApplicationDbContext context)
        {
            _context = context;
        }

    protected override async Task<Product> CreateBaseAsync(string name, string description, string sku, decimal price, int categoryId, string? filename)
    {
      Product product = _context.CreateProxy<Product>(name, description, sku, price, filename);
      product.CategoryId = categoryId;

      await _context.AddAsync(product);

      return product;
    }
  }
}
