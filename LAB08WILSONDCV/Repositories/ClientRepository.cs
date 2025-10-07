using LAB08WILSONDCV.Data;
using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly LinqDbContext _context;

        // El DbContext es inyectado gracias a la configuración en Program.cs
        public ClientRepository(LinqDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            // Aquí va la lógica de EF Core y la consulta LINQ
            return await _context.Clients.ToListAsync();
        }
    }
}