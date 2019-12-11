using System;
using System.Collections.Generic;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using Moq;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Hola.Shopping.Api.Application.Contracts.Services;
using FluentAssertions;
using System.Threading.Tasks;
using Hola.Shopping.Api.Application.Dtos;
using AutoWrapper.Wrappers;
using Hola.Shopping.Api.Model;

namespace Hola.Shopping.Api.Controllers.Tests
{
    [TestFixture]
    public class ProductControllerTests
    {
        Mock<ILogger<ProductController>> _loggerMock;
        Mock<IMapper> _mapperMock;
        Mock<IProductService> _productServiceMock;

        [SetUp]
        public void Setup()
        {
           _loggerMock = new Mock<ILogger<ProductController>>();
           _mapperMock = new Mock<IMapper>();
           _productServiceMock = new Mock<IProductService>();
        }

        [TearDown]
        public void Teardown()
        {
            
        }


        [Test]
        public void ProductControllerConstructorTest()
        {
            // Arrange & Act
            var controller = new ProductController(_loggerMock.Object, _mapperMock.Object, _productServiceMock.Object);

            // Assert
            controller.Should().NotBeNull();
        }

        [Test]
        public async Task GetAllProductsSuccessTest()
        {
            // Arrange
            var productList = new List<ProductDto> { new ProductDto(), new ProductDto() };
            _productServiceMock.Setup(x => x.GetAll()).Returns(async () => await Task.FromResult(productList));


            var controller = new ProductController(_loggerMock.Object, _mapperMock.Object, _productServiceMock.Object);
            
            // Act
            var response = await controller.GetAllProducts();

            // Assert
            response.Result.Should().NotBeNull();
            response.GetType().Should().Be(typeof(ApiResponse));

            var list = response.Result as IList<ProductDto>;
            list.Should().NotBeNull().And.HaveCount(2);
        }

        [Test]
        public async Task GetAllProductsThrowExceptionTest()
        {
            // Arrange
            var productList = new List<ProductDto> { new ProductDto(), new ProductDto() };
            _productServiceMock.Setup(x => x.GetAll()).Throws(new JoaquinServiceException("Service exception"));

            var controller = new ProductController(_loggerMock.Object, _mapperMock.Object, _productServiceMock.Object);

            // Act & Assert
            Assert.That(async () => await controller.GetAllProducts(), Throws.TypeOf<JoaquinServiceException>());
        }

        [Test]
        public async Task GetProductsPagedSuccessTest()
        {
            // Arrange
            var productList = new List<ProductDto> { new ProductDto(), new ProductDto(), new ProductDto(), new ProductDto(), new ProductDto(), new ProductDto() };
            var responseList = new GenericCollectionResponse<IList<ProductDto>>()
            {
                Result = productList,
                TotalRecords = 6
            };

            _productServiceMock.Setup(x => x.GetPaged(It.IsAny<ProductPagedDto>())).Returns(async () => await Task.FromResult(responseList));

            var controller = new ProductController(_loggerMock.Object, _mapperMock.Object, _productServiceMock.Object);

            // Act
            var response = await controller.GetProductsPaged(new GetProductsPagedRequest());

            // Assert
            response.Result.Should().NotBeNull();
            response.GetType().Should().Be(typeof(ApiResponse));

            var result = response.Result as GenericCollectionResponse<IList<ProductDto>>;
            result.Result.Should().NotBeNull().And.HaveCount(6);
            result.TotalRecords.Should().Be(6);
        }

        [Test]
        [Ignore("")]
        public void InsertProductTest()
        {
            Assert.Fail();
        }

        [Test]
        [Ignore("")]
        public void UpdateProductTest()
        {
            Assert.Fail();
        }
    }

    [Serializable]
    public class JoaquinServiceException : Exception
    {
        public JoaquinServiceException(string message) : base(message)
        {
        }
    }
}