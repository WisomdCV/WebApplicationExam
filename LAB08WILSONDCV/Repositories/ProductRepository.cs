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
                .Where(p => p.Price > price)
                .ToListAsync();
        }
    }
}