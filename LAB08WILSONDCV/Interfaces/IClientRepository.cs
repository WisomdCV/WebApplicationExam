using LAB08WILSONDCV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        
        Task<IEnumerable<Client>> GetByNameAsync(string name);
    }
}