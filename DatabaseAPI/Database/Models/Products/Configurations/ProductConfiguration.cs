using DatabaseAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseAPI.Database.Model.Products.Configurations
{
  public class ProductConfiguration : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.ToTable("Products");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

      builder.Property(x => x.Name).HasColumnName("Name");
      builder.Property(x => x.CurrentPrice).HasColumnName("CurrentPrice").HasColumnType("money");
      builder.Property(x => x.SKU).HasColumnName("SKU");
      builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
      builder.Property(x => x.Description).HasColumnName("Description");
      builder.Property(x => x.FileName).HasColumnName("Filename");

      builder.Navigation(x => x.Category).AutoInclude();
    }
  }
}
