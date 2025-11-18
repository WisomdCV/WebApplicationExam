using System;
using LAB08WILSONDCV.DTOs;
using LAB08WILSONDCV.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderWithDetailsDto>> GetAllOrdersWithDetailsAsync()
        {
            return await _orderRepository.GetAllOrdersWithDetailsAsync();
        }

        public async Task<decimal> GetTotalSalesAsync()
        {
            return await _orderRepository.GetTotalSalesAsync();
        }

        public async Task<IEnumerable<ProductDetailDto>> GetProductDetailsByOrderIdAsync(int orderId)
        {
            return await _orderRepository.GetProductDetailsByOrderIdAsync(orderId);
        }

        public async Task<int?> GetTotalProductQuantityByOrderIdAsync(int orderId)
        {
            return await _orderRepository.GetTotalProductQuantityByOrderIdAsync(orderId);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAfterDateAsync(DateTime date)
        {
            return await _orderRepository.GetOrdersAfterDateAsync(date);
        }
    }
}