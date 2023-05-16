using DatabaseAPI.Database.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DatabaseAPI.Database.Entities
{
  public class ProductCategory : Entity, IModificationTracked
  {
        public ProductCategory()
        {
            
        }
        protected ProductCategory(string name, string? description)
        {
          Name = name;
          Description = description;
        }
        public virtual string Name { get; set; } = null!;
        public virtual string? Description { get; set; } = null;

        public virtual DateTime? ModificationDate { get; set; }
        public virtual DateTime CreateDate { get; set; }

        public virtual IReadOnlyCollection<Product> Products { get; protected set; } = new ObservableHashSet<Product>();
  }
}
