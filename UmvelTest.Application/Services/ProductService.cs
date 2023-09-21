using UmvelTest.Application;
using UmvelTest.Application.Services.Interfaces;
using UmvelTest.Entity.Entities;
using UmvelTest.Infrastructure;

namespace OrderFullfillment.Application.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IRepository<Product> _repository;
        
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task<Product> Get(int id)
        {
            return await _repository.GetAsync(id);
        }
        public async Task<List<Product>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Product> Add(Product product)
        {
            _repository.Add(product);
            await UnitOfWork.SaveChangeAsync();
            return product;
        }
        
        public async Task Remove(int id)
        {
            var product = await _repository.GetAsync(id);
            if (product != null)
            {
                _repository.Delete(product);
                await UnitOfWork.SaveChangeAsync();
            }
        }
    }
}