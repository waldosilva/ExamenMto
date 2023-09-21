using System.Threading.Tasks;
using UmvelTest.Entity.Entities;

namespace UmvelTest.Application.Services.Interfaces
{
    public interface IClientService
    {
        public Task<Client> Get(int id);
        public Task<List<Client>> GetAll();

        public Task<Client> Create(string name);
        
    }
}