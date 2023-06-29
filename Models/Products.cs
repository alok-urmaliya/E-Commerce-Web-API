namespace Web_API.Models
{
    public class Products
    {
        int product_id { get; set; }
        string? product_name { get; set; }
        string? product_description { get; set; }
        decimal price { get; set; }
    }
}
