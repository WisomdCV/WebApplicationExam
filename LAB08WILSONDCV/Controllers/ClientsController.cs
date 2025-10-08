using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB08WILSONDCV.DTOs;

namespace LAB08WILSONDCV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var clients = await _clientRepository.GetAllAsync();
            return Ok(clients);
        }
        //Ej1
        [HttpGet("search/{name}")]
        public async Task<ActionResult<IEnumerable<Client>>> SearchClientsByName(string name)
        {
            var clients = await _clientRepository.GetByNameAsync(name);

            if (!clients.Any())
            {
                return NotFound($"No se encontraron clientes cuyo nombre comience con '{name}'.");
            }
            
            return Ok(clients);
        }
        
        // ej 9
        [HttpGet("with-most-orders")]
        public async Task<ActionResult<ClientWithOrderCountDto>> GetClientWithMostOrders()
        {
            var client = await _clientRepository.GetClientWithMostOrdersAsync();
            if (client == null)
            {
                return NotFound("No se encontraron clientes o pedidos.");
            }
            return Ok(client);
        }
        
        //Ej 11
        [HttpGet("{clientId}/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsSoldToClient(int clientId)
        {
            var products = await _clientRepository.GetProductsSoldToClientAsync(clientId);
            if (!products.Any())
            {
                return NotFound($"No se encontraron productos vendidos al cliente con ID {clientId}.");
            }
            return Ok(products);
        }
    }
}