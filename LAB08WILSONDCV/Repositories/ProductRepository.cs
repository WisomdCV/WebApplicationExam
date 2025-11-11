using LAB08WILSONDCV.Data;
using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly LinqDbContext _context;

        public ProductRepository(LinqDbContext context)
        {
            _context = context;
        }

        //ej2
        public async Task<IEnumerable<Product>> GetByPriceGreaterThanAsync(decimal price)
        {
            //where
            return await _context.Products
                .AsNoTracking() //Evitamos que EF Core rastree los objetos en el contexto - Mejor rendimiento
                .Where(p => p.Price > price)
                .ToListAsync();
        }
        
        // ej5
        public async Task<Product?> GetMostExpensiveAsync()
        {
            return await _context.Products
                .OrderByDescending(p => p.Price)
                .FirstOrDefaultAsync();
        }
        
        // ej7
        public async Task<decimal> GetAveragePriceAsync()
        {
            return await _context.Products.AverageAsync(p => p.Price);
        }

        // ej8
        public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
        {
            return await _context.Products
                .Where(p => string.IsNullOrEmpty(p.Description))
                .ToListAsync();
        }
        
        //ej 12
        public async Task<IEnumerable<Client>> GetClientsByProductAsync(int productId)
        {
            return await _context.OrderDetails
                .Where(od => od.ProductId == productId)
                .Select(od => od.Order.Client) 
                .Distinct() // cliente una sola vez
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }
    }
}