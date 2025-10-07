using LAB08WILSONDCV.Data;
using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Data;
using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}

