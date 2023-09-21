using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UmvelTest.Application.Services;
using UmvelTest.Application.Services.Interfaces;
using UmvelTest.Entity.Entities;

namespace UmvelTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            _logger.LogInformation($"Getting order id {id}");
            return await _productService.Get(id);
        }
        [HttpGet]
        public async Task<List<Product>> GetAll()
        {
            _logger.LogInformation($"Getting all client");
            return await _productService.GetAll();
        }
        [HttpPost]
        public async Task<Product> Create([FromBody] Product product)
        {
            _logger.LogInformation($"Add product");
            return await _productService.Add(product);
        }
    }
}