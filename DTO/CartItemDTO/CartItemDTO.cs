namespace Web_API.DTO.CartItemDTO
{
    public class CartItemDTO
    {
        public int cart_item_id { get; set; }
        public string customer_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}
