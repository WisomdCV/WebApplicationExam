using LAB08WILSONDCV.DTOs;
using LAB08WILSONDCV.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB08WILSONDCV.Models;

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
        
        //ej4
        [HttpGet("{orderId}/total-quantity")]
        public async Task<ActionResult<int>> GetTotalQuantityInOrder(int orderId)
        {
            var totalQuantity = await _orderRepository.GetTotalProductQuantityByOrderIdAsync(orderId);
            
            if (totalQuantity == null)
            {
                return NotFound($"No se encontró la orden con ID {orderId}.");
            }
            return Ok(totalQuantity);
        }
        
        //ej6
        [HttpGet("after-date/{date}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersAfterDate(DateTime date)
        {
            //fix utc
            var utcDate = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            
            var orders = await _orderRepository.GetOrdersAfterDateAsync(utcDate);

            if (!orders.Any())
            {
                return NotFound($"No se encontraron órdenes después de la fecha {date:yyyy-MM-dd}.");
            }

            return Ok(orders);
        }
    }
}