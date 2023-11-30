using System.Threading.Tasks;
using CarlosMto.Entity.Entities;

namespace CarlosMto.Application.Services.Interfaces
{
    public interface IProductService
    {
        public Task<Product> Get(int id);

        public Task<List<Product>> GetAll();
        public Task<Product> Add(Product product);
        public Task Remove(int id);
    }
    //    public interface IService<T> where T : class
    //{
    //    public Task<T> Get(int id);

    //    public Task<List<T>> GetAll();
    //    public Task<T> Add(T item);
    //    public Task Remove(int id);
    //}
}