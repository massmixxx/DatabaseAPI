using DatabaseAPI.Models.DTO.Products;

namespace DatabaseAPI.Models.DTO.ProductCategories
{
  public class ProductCategoryDetailsDTO : ProductCategoryDTO
  {
        public DateTime? ModificationDate { get; set; }
        public IEnumerable<ProductEssentialsDTO> Products { get; set; } = new List<ProductEssentialsDTO>();
    }
}
