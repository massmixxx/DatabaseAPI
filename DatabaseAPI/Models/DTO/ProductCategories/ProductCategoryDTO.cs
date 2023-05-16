namespace DatabaseAPI.Models.DTO.ProductCategories
{
  public class ProductCategoryDTO
  {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
