

using CarlosMto.Application.Services.Interfaces;
using CarlosMto.Application.Services.Request;
using CarlosMto.Entity.Entities;
using CarlosMto.Infrastructure;

namespace CarlosMto.Application.Services
{
    public class SaleService : BaseService, ISaleService
    {
        private readonly IRepository<Sale> _saleRepo;
        private readonly IRepository<Product> _productRepo;

        public SaleService(IUnitOfWork unitOfWork, IRepository<Sale> saleRepo, IRepository<Product> productRepo) : base(unitOfWork)
        {
            _saleRepo = saleRepo;
            _productRepo = productRepo;
        }
        
        public async Task<List<Sale>> GetByRange(DateTime ini, DateTime fin)
        {
            var result = await _saleRepo.GetAll();
            

            return  result.Where(item => item.Date >= ini && item.Date <= fin).ToList();
        ;
        }


    public async Task<Sale> Create(RequestSale saleInfo)
        {
            var sale = new Sale(saleInfo.CustomerId, saleInfo.Date);

            if (saleInfo.Items != null)
            {
                foreach (var item in saleInfo.Items)
                {
                    Concept concept = new Concept();
                    concept.Product = await _productRepo.GetAsync(item.ProductId);
                    concept.Quantity = item.Quantity;
                    concept.UnitPrice = item.UnitPrice;
                    concept.Amount = concept.Quantity * item.UnitPrice;
                    sale.Products.Add(concept);
                }
            }
            sale.Total = sale.Products.Sum(_ => _.Amount);

            await UnitOfWork.ExecuteTransactionAsync(async () =>
            {
                _saleRepo.Add(sale);
                //await _basketService.MarkAsResolved(orderInfo.BasketId);
                return await UnitOfWork.SaveChangeAsync();
            });
            return sale;
        }
        public async Task<Sale> Cancel(int saleId)
        {
            var sale = await _saleRepo.GetAsync(saleId);

            if (sale!= null)
            {
                sale.StatusId = (int)EstatusSale.Cancelado;
                await UnitOfWork.SaveChangeAsync();

            }
            return sale;
        }



    }
}