using LAB08WILSONDCV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByPriceGreaterThanAsync(decimal price);
        Task<Product?> GetMostExpensiveAsync();
    }
}