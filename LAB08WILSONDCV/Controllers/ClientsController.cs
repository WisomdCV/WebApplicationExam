using LAB08WILSONDCV.Interfaces;
using LAB08WILSONDCV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}