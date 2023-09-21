using System.Threading.Tasks;
using UmvelTest.Entity.Entities;

namespace UmvelTest.Application.Services.Interfaces
{
    public interface IProductService
    {
        public Task<Product> Get(int id);

        public Task<List<Product>> GetAll();
        public Task<Product> Add(Product product);
        public Task Remove(int id);
    }
}