using LAB08WILSONDCV.Data;
using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB08WILSONDCV.DTOs;

namespace LAB08WILSONDCV.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly LinqDbContext _context;

        public ClientRepository(LinqDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        //ej1
        public async Task<IEnumerable<Client>> GetByNameAsync(string name)
        {
            return await _context.Clients
                .Where(c => c.Name.ToLower().StartsWith(name.ToLower()))
                .ToListAsync();
        }
        
        // ej9
        public async Task<ClientWithOrderCountDto?> GetClientWithMostOrdersAsync()
        {
            return await _context.Orders
                .GroupBy(o => o.Client) 
                .Select(g => new ClientWithOrderCountDto
                {
                    ClientId = g.Key.ClientId,
                    Name = g.Key.Name,
                    Email = g.Key.Email,
                    OrderCount = g.Count() 
                })
                .OrderByDescending(dto => dto.OrderCount) 
                .FirstOrDefaultAsync(); 
        }
        
        // ej11
        public async Task<IEnumerable<Product>> GetProductsSoldToClientAsync(int clientId)
        {
            return await _context.Orders
                .Where(o => o.ClientId == clientId)
                .SelectMany(o => o.OrderDetails) 
                .Select(od => od.Product)      
                .Distinct()                     
                .ToListAsync();
        }
        public async Task<IEnumerable<ClientProductCountDto>> GetClientsWithProductCountAsync()
        {
            return await _context.Clients
                .AsNoTracking()
                .Select(client => new ClientProductCountDto
                {
                    ClientName = client.Name,
                    TotalProducts = client.Orders
                                        .SelectMany(order => order.OrderDetails)
                                        .Sum(detail => detail.Quantity)
                })
                .ToListAsync();
        }
    }
}

