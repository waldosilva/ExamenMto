using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarlosMto.Application.Services;
using CarlosMto.Application.Services.Interfaces;
using CarlosMto.Entity.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CarlosMto.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        //private readonly IService<Product> _productService;
        private readonly IProductService _productService;
        public UserController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        //public ProductController(ILogger<ProductController> logger, IService<Product> productService)
        //{
        //    _logger = logger;
        //    _productService = productService;
        //}

        //[HttpGet("{id}")]
        //public async Task<Product> Get(int id)
        //{
        //    _logger.LogInformation($"Getting order id {id}");
        //    return await _productService.Get(id);
        //}
        //[HttpGet]
        //public async Task<List<Product>> GetAll()
        //{
        //    _logger.LogInformation($"Getting all client");
        //    return await _productService.GetAll();
        //}
        [HttpPost("login")]
        public async Task<Product> Autentificar([FromBody] Product product)
        {
            _logger.LogInformation($"Autenticar");
            return await _productService.Add(product);
        }
    }
}