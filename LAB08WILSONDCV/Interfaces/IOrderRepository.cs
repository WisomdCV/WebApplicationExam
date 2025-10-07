using LAB08WILSONDCV.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<ProductDetailDto>> GetProductDetailsByOrderIdAsync(int orderId);
        Task<int?> GetTotalProductQuantityByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetOrdersAfterDateAsync(DateTime date);
        Task<decimal> GetAveragePriceAsync();
        Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync();
    }
}