using DatabaseAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseAPI.Database.Model.ProductCategories.Configurations
{
  public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
  {
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
      // Nazwa tabeli: Tak czysto informacyjnie - osobiście preferuję twoje podejście w kontekście nazw tabel (liczba mnoga),
      // ale to jest coś, co warto ustalić na początku projektu, bo wielokrotnie spotkałem się z podejściem, gdzie tabele są w liczbie pojedynczej.
      // Nie wchodząc w dyskusję, która konwencja jest lepsza, uważam, że bezwzględnie należy wybrać jedną i jej się trzymać.
      // Jeśli wchodzisz do istniejącego projektu i już na starcie jest śmietnik (bywa), warto zapytać kogoś, która konwencja jest tą właściwą. 
      // W przypadku tej solucji nie ma to większego znaczenia, ale przy dużych projektach warto też pamiętać o definiowaniu schem na bazie
      // (builder.ToTable("TableName", "SchemaName").
      // Ma to moim zdaniem duży sens szczególnie w projektach, które są monolitami lub modularnymi monolitami, albo będąc opartymi o mikroserwisy,
      // współdzielą tą samą instancję bazy danych.
      builder.ToTable("ProductCategories");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .ValueGeneratedOnAdd();

      // Jaką widzisz zaletę w definiowaniu nazw kolumn w sytuacji, gdy nazwa pola = nazwa kolumny?
      builder.Property(x => x.ModificationDate)
        .HasColumnName("ModificationDate");

      builder.Property(x => x.CreateDate)
        .HasColumnName("CreateDate")
        .HasDefaultValueSql("GETDATE()")
        .ValueGeneratedOnAdd();

      // Tam gdzie to możliwe, warto rozważyć zdefiniowanie wprost wielkości kolumny typu tekstowej:
      // .HasMaxLength(x)
      // Domyślnie string jest zamieniany na nvarchar(max), a tak zdefiniowana długość sprawia, że ta kolumna nie podlega indeksacji.
      // O ile dla "Description" może to być trudne (opisu z reguły są długie i często zawierają też znaki formatujące, albo wręcz kod HTML)
      // to już dla "Name" można by przyjąć jakąś wartość brzegową.
      // Prywatnie w tym celu stosuję następujące podejście:
      //    1. staram się wymyśleć najdłuższy sensowny tekst, który może w takim polu się znaleźć.
      //    2. Liczbę znaków zaokrąglam w górę do najbliższej potęgi 2 - bo lubię potęgi 2 :)
      //    3. Mnożę wynik razy dwa - bo mogłem, na coś nie wpaść w pkt 1. 
      builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
      builder.Property(x => x.Description).HasColumnName("Description");

      builder
        .HasMany(x => x.Products)
        .WithOne(x => x.Category)
        .HasForeignKey(x => x.CategoryId);
    }
  }
}
