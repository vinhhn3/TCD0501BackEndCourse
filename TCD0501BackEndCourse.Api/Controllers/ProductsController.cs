using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TCD0501BackEndCourse.Api.Models;
using TCD0501BackEndCourse.Api.Repositories.Interface;

namespace TCD0501BackEndCourse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductsController(
            IProductRepository productRepository
            )
        {
            _productRepository = productRepository;
        }
        // Endpoint: /api/products
        [HttpGet("")]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }
        // Endpoint: /api/products/5

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.GetProduct(id);
            if (product == null) return NotFound();
            return Ok(product);

        }
        // Endpoint: /api/products/create
        [HttpPost("create")]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = _productRepository.Create(product);
            if (!result) return BadRequest();
            return StatusCode(StatusCodes.Status201Created);
        }

        // Endpoint: /api/products/5
        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = _productRepository.Edit(id, product);
            if (!result) return BadRequest();
            return NoContent();
        }

        // Endpoint: /api/products/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok("Delete item successfully ...");
        }
    }
}
