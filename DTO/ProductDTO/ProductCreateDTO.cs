namespace Web_API.DTO.ProductDTO
{
    public class ProductCreateDTO
    {
        public string? product_name { get; set; }
        public string? product_description { get; set; }
        public decimal price { get; set; }
    }
}
