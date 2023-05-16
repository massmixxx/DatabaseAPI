namespace DatabaseAPI.Models.DTO.Products
{
  public class ProductListDTO
  {
        public IEnumerable<ProductDTO> Items { get; set; } = new List<ProductDTO>();
        public int Count { get; set; }
  }
}
