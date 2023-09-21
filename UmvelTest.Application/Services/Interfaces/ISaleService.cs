using System.Threading.Tasks;
using UmvelTest.Application.Services.Request;
using UmvelTest.Entity.Entities;

namespace UmvelTest.Application.Services.Interfaces
{
    public interface ISaleService
    {
        public Task<List<Sale>> GetByRange(DateTime ini,DateTime fin);

        public Task<Sale> Create(RequestSale saleInfo);
        

    }
}