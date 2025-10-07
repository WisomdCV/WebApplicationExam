using LAB08WILSONDCV.Data;
using LAB08WILSONDCV.DTOs;
using LAB08WILSONDCV.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LinqDbContext _context;

        public OrderRepository(LinqDbContext context)
        {
            _context = context;
        }

        //ej3
        public async Task<IEnumerable<ProductDetailDto>> GetProductDetailsByOrderIdAsync(int orderId)
        {
            return await _context.OrderDetails
                .Include(od => od.Product) 
                .Where(od => od.OrderId == orderId) 
                .Select(od => new ProductDetailDto 
                {
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity
                })
                .ToListAsync();
        }
        
        //ej4
        public async Task<int?> GetTotalProductQuantityByOrderIdAsync(int orderId)
        {
            var orderExists = await _context.Orders.AnyAsync(o => o.OrderId == orderId);
            if (!orderExists)
            {
                return null; 
            }
            
            return await _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .SumAsync(od => od.Quantity);
        }
    }
}