using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web_API.DTO.CartItemDTO;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet]
        public ActionResult<List<CartItemDTO>> cart_item(string user_id)
        {
            //CartItemDTO cart_items = _context.Cart_Items
            //    .Where(c => c.customer_id == user_id)
            //    .Select(x => new CartItemDTO()
            //    {
            //        cart_item_id = x.cart_item_id,
            //        customer_id = x.customer_id,
            //        product_id = x.product_id,
            //        quantity = x.quantity
            //    }).ToList();
            //return Ok(cart_items);
            return Ok();
        }

        [HttpPost]
        public ActionResult<string> cart_item(int product_id, string user_id, int quantity)
        {
            Cart_Item cart_item = new Cart_Item()
            { 
                customer_id = user_id,
                product_id = product_id,
                quantity = quantity,
                added_on = DateTime.Now,
            };
            _context.Cart_Items.Add(cart_item);
            _context.SaveChanges();
            return "Product Added to cart";
        }

        public ApiExplorerSettingsAttribute
    }
}
