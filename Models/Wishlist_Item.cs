using System.ComponentModel.DataAnnotations;

namespace Web_API.Models
{
    public class Wishlist_Item
    {
        [Key]
        public int wishlist_item_id { get; set; }
        public required string customer_id { get; set; }
        public int product_id { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Products product { get; set; }
    }
}
