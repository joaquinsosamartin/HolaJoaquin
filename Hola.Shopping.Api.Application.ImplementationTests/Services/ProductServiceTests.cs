using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Hola.Shopping.Api.Application.Contracts.Services;
using Hola.Shopping.Api.Application.Dtos;
using Hola.Shopping.Api.Application.Implementation.Services;
using Hola.Shopping.Api.Data.Contracts;
using Hola.Shopping.Api.Data.Contracts.Repositories;
using Hola.Shopping.Api.Domain.Model;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Hola.Shopping.Api.Application.ImplementationTests.Services
{
    [TestFixture]
    public class ProductServiceTests
    {
        Mock<ILogger<ProductService>> _loggerMock;
        Mock<IMapper> _mapperMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<ProductService>>();
            _mapperMock = new Mock<IMapper>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [TearDown]
        public void Teardown()
        {

        }


        [Test]
        public void ProductServiceConstructorTest()
        {
            // Arrange & Act
            var service = new ProductService(_unitOfWorkMock.Object, _mapperMock.Object, _loggerMock.Object);

            // Assert
            service.Should().NotBeNull();
        }

        [Test]
        public async Task GetAllProductsSuccessTest()
        {
            // Arrange
            var productEntityList = new List<Product> { new Product(), new Product() };
            var productList = new List<ProductDto> { new ProductDto(), new ProductDto() };

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repository => repository.GetAll())
                .Returns(async () => await Task.FromResult(productEntityList));

            _unitOfWorkMock.Setup(x => x.ProductRepository).Returns(productRepositoryMock.Object);

            _mapperMock.Setup(mapper => mapper.Map<IList<Product>, IList<ProductDto>>(It.IsAny<IList<Product>>()))
                .Returns(productList);

            var service = new ProductService(_unitOfWorkMock.Object, _mapperMock.Object, _loggerMock.Object);

            // Act
            var response = await service.GetAll();

            // Assert
            response.Should().NotBeNull();
            response.GetType().Should().Be(typeof(List<ProductDto>));
            response.Should().NotBeNull().And.HaveCount(2);
        }
    }
}