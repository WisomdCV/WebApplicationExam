using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //ej2
        [HttpGet("price-greater-than/{price}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByPrice(decimal price)
        {
            var products = await _productRepository.GetByPriceGreaterThanAsync(price);

            if (!products.Any())
            {
                return NotFound($"No se encontraron productos con un precio mayor a {price}.");
            }
            
            return Ok(products);
        }
        //ej5
        [HttpGet("most-expensive")]
        public async Task<ActionResult<Product>> GetMostExpensiveProduct()
        {
            var product = await _productRepository.GetMostExpensiveAsync();

            if (product == null)
            {
                return NotFound("No se encontraron productos.");
            }

            return Ok(product);
        }
    }
}