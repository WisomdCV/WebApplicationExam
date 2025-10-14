using System.Collections.Generic;
using System.Threading.Tasks;
using LAB08WILSONDCV.DTOs;
using LAB08WILSONDCV.Models;

namespace LAB08WILSONDCV.Services
{
    public interface IClientService
    {
        Task<ClientWithOrderCountDto?> GetClientWithMostOrdersAsync();
        Task<IEnumerable<ClientProductCountDto>> GetClientsWithProductCountAsync();
        Task<IEnumerable<SalesByClientDto>> GetTotalSalesByClientAsync();
        Task<IEnumerable<Client>> GetAllAsync();
        Task<IEnumerable<Client>> GetByNameAsync(string name);
        Task<IEnumerable<Product>> GetProductsSoldToClientAsync(int clientId);
    }
}