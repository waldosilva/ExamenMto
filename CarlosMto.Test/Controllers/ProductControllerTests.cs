﻿using AutoMapper;
using Castle.Core.Logging;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using OrderFullfillment.Application.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CarlosMto.API.Controllers;
using CarlosMto.Application.Services.Interfaces;
using CarlosMto.Entity.Entities;
using Xunit;
using ILogger = Microsoft.Extensions.Logging.ILogger;
//using YourWebApiNamespace; // Ajusta el espacio de nombres según tu proyecto

public class ProductControllerTests 
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;
    private readonly IMapper _mapper;
    public ProductControllerTests() {
        _productService = A.Fake<ProductService>();
        _logger = A.Fake<ILogger<ProductController>>();
        _mapper =A.Fake<IMapper>();
    }


    [Fact]
    public async void GetProducts_ReturnsSuccessStatusCode()
    {
        // Arrange
        var products = A.Fake<ICollection<Product>>();
        var productsList = A.Fake<List<Product>>();
        A.CallTo(() => _mapper.Map<List<Product>>(products)).Returns(productsList);
        var controller = new ProductController(_logger, _productService);
        // Act
        var response =  await controller.Get(1); // Ajusta la URL según tu ruta de API

        // Assert
        Assert.NotNull(response);
    }
}