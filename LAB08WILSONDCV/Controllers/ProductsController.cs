using LAB08WILSONDCV.Services; // ¡Añade este!
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
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) // Inyecta el servicio
        {
            _productService = productService;
        }

        //ej2
        [HttpGet("price-greater-than/{price}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByPrice(decimal price)
        {
            var products = await _productService.GetByPriceGreaterThanAsync(price);

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
            var product = await _productService.GetMostExpensiveAsync();

            if (product == null)
            {
                return NotFound("No se encontraron productos.");
            }

            return Ok(product);
        }
        //ej7
        [HttpGet("average-price")]
        public async Task<ActionResult<decimal>> GetAverageProductPrice()
        {
            var average = await _productService.GetAveragePriceAsync();
            return Ok(average);
        }

        //ej8
        [HttpGet("without-description")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsWithoutDescription()
        {
            var products = await _productService.GetProductsWithoutDescriptionAsync();
            if (!products.Any())
            {
                return NotFound("No se encontraron productos sin descripción.");
            }
            return Ok(products);
        }
        //ej12
        [HttpGet("{productId}/buyers")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientsByProduct(int productId)
        {
            var clients = await _productService.GetClientsByProductAsync(productId);
            if (!clients.Any())
            {
                return NotFound($"Ningún cliente ha comprado el producto con ID {productId}.");
            }
            return Ok(clients);
        }
    }
}