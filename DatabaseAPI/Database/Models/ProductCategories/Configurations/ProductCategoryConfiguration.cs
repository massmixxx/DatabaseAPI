using DatabaseAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseAPI.Database.Model.ProductCategories.Configurations
{
  public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
  {
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
      builder.ToTable("ProductCategories");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .ValueGeneratedOnAdd();

      builder.Property(x => x.ModificationDate)
        .HasColumnName("ModificationDate");

      builder.Property(x => x.CreateDate)
        .HasColumnName("CreateDate")
        .HasDefaultValueSql("GETDATE()")
        .ValueGeneratedOnAdd();

      builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
      builder.Property(x => x.Description).HasColumnName("Description");

      builder
        .HasMany(x => x.Products)
        .WithOne(x => x.Category)
        .HasForeignKey(x => x.CategoryId);
    }
  }
}
