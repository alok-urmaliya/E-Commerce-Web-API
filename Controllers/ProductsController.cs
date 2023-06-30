using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Web_API.DTO.ProductDTO;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context) 
        {
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<List<ProductsDTO>> products()
        {
            if(_context.Products == null)
            {
                return NotFound();
            }
            var products = _context.Products.Select(p => new ProductsDTO()
            {
                product_id = p.product_id,
                product_name = p.product_name,
                product_description = p.product_description,
                price = p.price
            }).ToList();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult<string> products([FromBody]ProductCreateDTO product)
        {
            Products _product = new Products
            {
                product_name = product.product_name,
                product_description = product.product_description,
                price = product.price,
            };
            _context.Products.Add(_product);
            _context.SaveChanges();

            return "Device Added Successfully";
        }
    }
}
