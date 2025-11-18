using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetByPriceGreaterThanAsync(decimal price)
        {
            return await _productRepository.GetByPriceGreaterThanAsync(price);
        }

        public async Task<decimal> GetAveragePriceAsync()
        {
            return await _productRepository.GetAveragePriceAsync();
        }

        public async Task<Product?> GetMostExpensiveAsync()
        {
            return await _productRepository.GetMostExpensiveAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
        {
            return await _productRepository.GetProductsWithoutDescriptionAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsByProductAsync(int productId)
        {
            return await _productRepository.GetClientsByProductAsync(productId);
        }
    }
}