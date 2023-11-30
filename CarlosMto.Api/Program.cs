using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderFullfillment.Application.Services;
using CarlosMto.Application;
using CarlosMto.Application.Services;
using CarlosMto.Application.Services.Interfaces;
using CarlosMto.Infrastructure;
using CarlosMto.Infrastructure.Context;
using CarlosMto.Entity.Entities;
using CarlosMto.Api.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CarlosMto.Application.Services.JWT;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Configuracion
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDBConnection")));
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsersDBConnection")));


builder.Services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IProductService, ProductService>()



//builder.Services
//.AddScoped<IUnitOfWork<ProductDbContext>, UnitOfWork<ProductDbContext>>()
//.AddScoped<IUnitOfWork<UserDbContext>, UnitOfWork<UserDbContext>>()
//            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
//            .AddScoped<IService<Product>, ProductService>()
//            //.AddScoped<ISaleService, SaleService>();
;


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        //ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        //ValidIssuer = jwtSettings["Issuer"],
        //ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))

    };
});

// Registra el servicio JwtService en el contenedor de dependencias
builder.Services.AddSingleton(new JwtService(jwtSettings["SecretKey"]));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TenantIdentificationMiddleware>();



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.UseEndpoints(endpoints => {
//    endpoints.MapControllers();
//});

app.Run();
