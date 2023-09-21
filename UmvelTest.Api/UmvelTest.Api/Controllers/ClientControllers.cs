using Microsoft.AspNetCore.Mvc;
using UmvelTest.Application;
using UmvelTest.Application.Services;
using UmvelTest.Application.Services.Interfaces;
using UmvelTest.Entity.Entities;

namespace UmvelTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;
        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public async Task<Client> Get(int id)
        {
            _logger.LogInformation($"Getting client id {id}");
            return await _clientService.Get(id);
        }
        [HttpGet]
        public async Task<List<Client>> GetAll()
        {
            _logger.LogInformation($"Getting all client");
            return await _clientService.GetAll();
        }

        [HttpPost]
        public async Task<Client> Create(string name)
        {
            _logger.LogInformation($"Create basket");
            return await _clientService.Create(name);
        }


    }
}