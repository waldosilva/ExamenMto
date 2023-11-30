using Microsoft.AspNetCore.Mvc;
using CarlosMto.Application;
using CarlosMto.Application.Services;
using CarlosMto.Application.Services.Interfaces;
using CarlosMto.Application.Services.Request;
using CarlosMto.Entity.Entities;

namespace CarlosMto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;
        private readonly ISaleService _saleService;

        public SaleController(ILogger<SaleController> logger, ISaleService saleService)
        {
            _logger = logger;
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<List<Sale>> GetByDate(DateTime fechaIni, DateTime fechaFin)
        {
            _logger.LogInformation($"Getting range");
            var results = await _saleService.GetByRange(fechaIni, fechaFin);
            
            return results;
        }

        [HttpPost]
        public async Task<Sale> Create(RequestSale sale)
        {
            _logger.LogInformation($"Create Sale");
            return await _saleService.Create(sale);
        }

        [HttpPut]
        public async Task<Sale> Cancel(int salesId)
        {
            _logger.LogInformation($"Create Sale");
            return await _saleService.Cancel(salesId);
        }

    }
}