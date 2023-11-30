using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarlosMto.Application.Services;
using CarlosMto.Application.Services.Interfaces;
using CarlosMto.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CarlosMto.Application.Services.JWT;

namespace CarlosMto.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        //private readonly IService<Product> _productService;
        private readonly JwtService _jwtService;
        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
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
        public  string Autentificar([FromBody] User user)
        {
            // Supongamos que tienes un ID de usuario que deseas incluir en el token
            var userId = "12345"; // Aquí deberías tener la lógica para obtener el ID de usuario

            // Genera un token JWT utilizando el servicio JwtService
            var token = _jwtService.GenerateToken(userId);

            // Devuelve el token generado en la respuesta
            //return Ok(new { Token = token });
            return token;
        }
    }
}