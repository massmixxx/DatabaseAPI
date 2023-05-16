namespace DatabaseAPI.Models.DTO.Products
{
    public class ProductDTO : ProductEssentialsDTO
    {
        public string Description { get; set; } = null!;
        public string SKU { get; set; } = null!;

        public decimal CurrentPrice { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
