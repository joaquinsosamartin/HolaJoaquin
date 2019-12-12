using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using Hola.Shopping.Api.Application.Contracts.Services;
using Hola.Shopping.Api.Application.Dtos;
using Hola.Shopping.Api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hola.Shopping.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IMapper mapper, IProductService productService)
        {
            _logger = logger;
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ApiResponse> GetAllProducts()
        {
            _logger.LogInformation("GetAllProducts");
            var productsDto = await _productService.GetAll();
            return new ApiResponse
            {
                Result = productsDto
            };
        }

        [HttpPost]
        [Route("getallpaged")]
        public async Task<ApiResponse> GetProductsPaged(GetProductsPagedRequest request)
        {
            var productsDto = await _productService.GetPaged(_mapper.Map<GetProductsPagedRequest, ProductPagedDto>(request));
            return new ApiResponse { Result = productsDto };
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ApiResponse> InsertProduct([FromBody] ProductRequest request)
        {
            await Task.Run(() => _productService.Insert(_mapper.Map<ProductRequest, ProductDto>(request)));
            return new ApiResponse();
        }

        [HttpPost]
        [Route("update")]
        public async Task<ApiResponse> UpdateProduct([FromBody] ProductRequest request)
        {
            await _productService.Update(_mapper.Map<ProductRequest, ProductDto>(request));
            return new ApiResponse();
        }
    }
}
