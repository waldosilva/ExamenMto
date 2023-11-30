

using CarlosMto.Application.Services.Interfaces;
using CarlosMto.Entity.Entities;
using CarlosMto.Infrastructure;

namespace CarlosMto.Application.Services
{
    public class ClientService : BaseService, IClientService
    {
        private readonly IRepository<Client> _clientRepo;
        
        public ClientService(IUnitOfWork unitOfWork, IRepository<Client> clientRepo) : base(unitOfWork)
        {
            _clientRepo = clientRepo;
            
        }

        public async Task<Client> Get(int id)
        {
            return await _clientRepo.GetAsync(id);
        }
        public async Task<List<Client>> GetAll()
        {
            return await _clientRepo.GetAll();
        }

        public async Task<Client> Create(string name)
        {
            var client = new Client();
            client.Name = name;
            _clientRepo.Add(client);
            await UnitOfWork.SaveChangeAsync();
            return client;
        }

        

      
    }
}