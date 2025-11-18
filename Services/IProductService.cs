using LAB08WILSONDCV.Models;

namespace LAB08WILSONDCV.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetByPriceGreaterThanAsync(decimal price);
        Task<decimal> GetAveragePriceAsync();
        Task<Product?> GetMostExpensiveAsync();
        Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync();
        Task<IEnumerable<Client>> GetClientsByProductAsync(int productId);
    }
}