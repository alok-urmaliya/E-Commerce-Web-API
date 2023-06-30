using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API.Models
{
    public class Cart_Item
    {
        [Key]
        public int cart_item_id { get; set; }
        public string customer_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public DateTime added_on { get; set; }
        public virtual Customer customer { get; set; }
        public virtual Products product { get; set; }
    }
}
