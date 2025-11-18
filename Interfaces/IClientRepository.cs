using LAB08WILSONDCV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using LAB08WILSONDCV.DTOs;

namespace LAB08WILSONDCV.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        
        Task<IEnumerable<Client>> GetByNameAsync(string name);
        Task<ClientWithOrderCountDto?> GetClientWithMostOrdersAsync();
        Task<IEnumerable<Product>> GetProductsSoldToClientAsync(int clientId);
        Task<IEnumerable<ClientProductCountDto>> GetClientsWithProductCountAsync();
        Task<IEnumerable<SalesByClientDto>> GetTotalSalesByClientAsync();
    }
}