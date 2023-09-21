using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderFullfillment.Application.Services;
using UmvelTest.Application;
using UmvelTest.Application.Services;
using UmvelTest.Application.Services.Interfaces;
using UmvelTest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Configuracion
builder.Services.AddDbContext<AppDbContext> (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IClientService, ClientService>()
                .AddScoped<IProductService, ProductService>() 
                .AddScoped<ISaleService, SaleService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
