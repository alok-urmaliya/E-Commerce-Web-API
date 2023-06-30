using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Web_API.Models
{
    public class Customer : IdentityUser
    {
        public required string customer_name { get; set; }
        public required byte[]? customer_avatar { get; set; }
        public required string city { get; set; }
        public required string? pin_code { get; set; }

        public bool? IsActive { get; set; }
        public ICollection<Cart_Item>? cart_items { get; set; }
        public ICollection<Wishlist_Item>? wishlist_items { get; set; }
    }
}
