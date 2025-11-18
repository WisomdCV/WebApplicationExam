using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LAB08WILSONDCV.DTOs;

namespace LAB08WILSONDCV.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderWithDetailsDto>> GetAllOrdersWithDetailsAsync();
        Task<decimal> GetTotalSalesAsync();
        Task<IEnumerable<ProductDetailDto>> GetProductDetailsByOrderIdAsync(int orderId);
        Task<int?> GetTotalProductQuantityByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetOrdersAfterDateAsync(DateTime date);
    }
}