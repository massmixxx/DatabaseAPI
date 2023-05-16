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
      
      // z typem money bym uważał. Ogólnie występuje on chyba tylko w bazach od MS.
      // Trzeba jednak pamiętać, że choć można tam zapisać wartość z precyzją 4 miejsc po przecinku, pod spodem jest to liczba całkowita
      // (bigint dla money oraz int dla smallmoney), a w sieci można znaleźć masę przykładów (mniej lub bardziej realnych w mojej opinii), które 
      // pokazują, że przy pewnych operacjach ten typ jest nieprecyzyjny (zaokrąglenia części dziesiętnych).
      // Teoretycznie ma to znaczenie w systemach, które na poziomie bazy dancych robią z wartościami pieniężnymi coś więcej niż prosty CRUD.  
      // osobiście, wartości pieniężne trzymam w decimalach i nie wnikam za bardzo w dyskusje bazodanowców, kiedy money można bezpiecznie użyć, a kiedy nie.
      builder.Property(x => x.CurrentPrice).HasColumnName("CurrentPrice").HasColumnType("money");
      
      // pole typu string, domyślnie mapowane jest na nvarchar(max), co z grubsza oznacza "Unicode string bez limitu znaków"
      // Odnośnie samego "max" pisałem przy okazji pola Name w ProductCategoryConfiguration.
      // Tu warto rozważyć jeszcze jedną kwestię: warunki, które opisałem dla kodu SKU (oraz Regex, który użyłeś w SKUNumber) oznaczają, że można 
      // to pole zdefiniować jako varchar, bo tu Unicode nie jest potrzebny.
      // Ten typ (varchar) staram się też definiować  dla pól typu kod pocztowy, numer telefonu - 
      // ogólnie wszędzie tam, gdzie mam pewność, że natura danych wyklucza istnienie znaków rozszerzonych.
      builder.Property(x => x.SKU).HasColumnName("SKU");
      
      builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
      builder.Property(x => x.Description).HasColumnName("Description");
      builder.Property(x => x.FileName).HasColumnName("Filename");

      builder.Navigation(x => x.Category).AutoInclude();
    }
  }
}
