using System.ComponentModel.DataAnnotations;

namespace Web_API.Models
{
    public class Products
    {
        [Key]
        public int product_id { get; set; }
        public string? product_name { get; set; }
        public string? product_description { get; set; }
        public decimal price { get; set; }
        public ICollection<Cart_Item>? cart_items { get; set; }
        public ICollection<Wishlist_Item>? wishlist_items { get; set; }
    }
}
