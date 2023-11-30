using System.Threading.Tasks;
using CarlosMto.Application.Services.Request;
using CarlosMto.Entity.Entities;

namespace CarlosMto.Application.Services.Interfaces
{
    public interface ISaleService
    {
        public Task<List<Sale>> GetByRange(DateTime ini,DateTime fin);

        public Task<Sale> Create(RequestSale saleInfo);

        public Task<Sale> Cancel(int salesId);


    }
}