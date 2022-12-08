using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Linq;

using TCD0501BackEndCourse.Api.Data;
using TCD0501BackEndCourse.Api.Models;

namespace TCD0501BackEndCourse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // Endpoint: /api/products
        [HttpGet("")]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
        // Endpoint: /api/products/5

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        // Endpoint: /api/products/create
        [HttpPost("create")]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        // Endpoint: /api/products/5
        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            var productInDb = _context
                .Products.SingleOrDefault(t => t.Id == id);
            if (productInDb == null) return NotFound();
            if (product.Id != productInDb.Id) return BadRequest();

            productInDb.Name = product.Name;
            productInDb.Description = product.Description;
            productInDb.Price = product.Price;

            _context.SaveChanges();

            return NoContent();
        }

        // Endpoint: /api/products/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context
                .Products.SingleOrDefault(t => t.Id == id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Delete item successfully ...");

        }
    }
}
