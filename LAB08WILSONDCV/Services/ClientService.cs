using LAB08WILSONDCV.DTOs;
using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LAB08WILSONDCV.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientWithOrderCountDto?> GetClientWithMostOrdersAsync()
        {
            return await _clientRepository.GetClientWithMostOrdersAsync();
        }

        public async Task<IEnumerable<ClientProductCountDto>> GetClientsWithProductCountAsync()
        {
            return await _clientRepository.GetClientsWithProductCountAsync();
        }

        public async Task<IEnumerable<SalesByClientDto>> GetTotalSalesByClientAsync()
        {
            return await _clientRepository.GetTotalSalesByClientAsync();
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Client>> GetByNameAsync(string name)
        {
            return await _clientRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<Product>> GetProductsSoldToClientAsync(int clientId)
        {
            return await _clientRepository.GetProductsSoldToClientAsync(clientId);
        }
    }
}