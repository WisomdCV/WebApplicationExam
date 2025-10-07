using LAB08WILSONDCV.DTOs;
using LAB08WILSONDCV.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //ej3
        [HttpGet("{orderId}/details")]
        public async Task<ActionResult<IEnumerable<ProductDetailDto>>> GetOrderDetails(int orderId)
        {
            var details = await _orderRepository.GetProductDetailsByOrderIdAsync(orderId);

            if (!details.Any())
            {
                return NotFound($"No se encontraron detalles para la orden con ID {orderId}.");
            }

            return Ok(details);
        }
    }
}