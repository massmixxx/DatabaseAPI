namespace DatabaseAPI.Models.DTO.Products
{
  public class ProductEssentialsDTO
  {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public int CategoryId { get; set; }
    }
}
