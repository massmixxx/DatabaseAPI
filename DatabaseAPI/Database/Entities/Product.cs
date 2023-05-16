using DatabaseAPI.Database.Base;
namespace DatabaseAPI.Database.Entities
{
  public class Product : Entity, IModificationTracked
  {
        protected Product()
        {
            
        }

        protected Product(string name, string description, string sku, decimal price, string? filename)
        {
          Name = name;
          Description = description;
          SKU = sku;
          CurrentPrice = price;
          FileName = filename;
          CreateDate = DateTime.Now;
        }

        public virtual string Name { get; set; } = null!;
        public virtual string Description { get; set; } = null!;
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime? ModificationDate { get; set; }
        public virtual decimal CurrentPrice { get; set; }
        public virtual string SKU { get; set; } = null!;
        public virtual string? FileName { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; } = null!;
    }


}