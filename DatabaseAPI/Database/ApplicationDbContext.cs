using DatabaseAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

// TO EXECUTE EF COMMANDS VIA PACKAGE MANAGER TRY USE SYNTAX EntityFrameworkCore\{ command e.g add-migration, update-database }
// TO EXECUTE EF COMMANDS VIA PACKAGE MANAGER TRY USE SYNTAX EntityFrameworkCore\{ command e.g add-migration, update-database }
// TO EXECUTE EF COMMANDS VIA PACKAGE MANAGER TRY USE SYNTAX EntityFrameworkCore\{ command e.g add-migration, update-database }
// TO EXECUTE EF COMMANDS VIA PACKAGE MANAGER TRY USE SYNTAX EntityFrameworkCore\{ command e.g add-migration, update-database }
// TO EXECUTE EF COMMANDS VIA PACKAGE MANAGER TRY USE SYNTAX EntityFrameworkCore\{ command e.g add-migration, update-database }

namespace DatabaseAPI.Database
{

  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products {get; set; }
    public DbSet<ProductCategory> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder
      .UseChangeTrackingProxies()
      .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override int SaveChanges()
    {
      return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
      return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
      return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      return base.SaveChangesAsync(cancellationToken);
    }

    public override void Dispose()
    {
      Database.CloseConnection();
      base.Dispose();
    }
  }
}
