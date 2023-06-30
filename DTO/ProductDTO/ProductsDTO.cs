using System.ComponentModel.DataAnnotations;

namespace Web_API.DTO.ProductDTO
{
    public class ProductsDTO
    {
        public int product_id { get; set; }
        public string? product_name { get; set; }
        public string? product_description { get; set; }
        public decimal price { get; set; }
    }
}
