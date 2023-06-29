using Microsoft.AspNetCore.Identity;

namespace Web_API.Models
{
    public class User : IdentityUser
    {   
        public int user_id { get; set; }
        public required string name { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
        public bool is_active { get; set; }
        public byte[]? avatar { get; set; }

        public ICollection<Cart_Item> Cart_Items { get; set; }
        public ICollection<Wishlist_Item> Wishlist_Item; { get; set; }
    }
}
