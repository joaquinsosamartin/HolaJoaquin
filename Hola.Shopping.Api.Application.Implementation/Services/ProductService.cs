using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Hola.Shopping.Api.Application.Contracts.Services;
using Hola.Shopping.Api.Application.Dtos;
using Hola.Shopping.Api.Data.Contracts;
using Hola.Shopping.Api.Domain.Model;
using Microsoft.Extensions.Logging;

namespace Hola.Shopping.Api.Application.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IList<ProductDto>> GetAll()
        {
            var products = await _unitOfWork.ProductRepository.GetAll();
            return _mapper.Map<IList<Product>, IList<ProductDto>>(products.ToList());
        }

        public async Task<bool> Insert(ProductDto dto)
        {
            try
            {
                var product = _mapper.Map<ProductDto, Product>(dto);

                await Task.Run(() =>
                {
                    _unitOfWork.ProductRepository.Insert(product);
                    _unitOfWork.Commit();
                }, CancellationToken.None);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Insert product dto");
            }

            return false;
        }

        public async Task<bool> Update(ProductDto dto)
        {
            var product = await _unitOfWork.ProductRepository.GetById(dto.Id);

            if (product == null)
            {
                return false;
            }

            MapDtoToProduct(product, dto);

            await Task.Run(() =>
            {
                _unitOfWork.ProductRepository.Update(product);
                _unitOfWork.Commit();
            }, CancellationToken.None);

            return true;
        }

        private async void MapDtoToProduct(Product product, ProductDto dto)
        {
            var size = int.TryParse(dto.Size, out var sizeNumber)
                ? await _unitOfWork.SizeRepository.GetByNumericValue(sizeNumber)
                : await _unitOfWork.SizeRepository.GetByStringValue(dto.Size);

            // TODO: product.Category

            product.Size = size;
            product.IsActive = dto.IsActive;
            product.Barcode128 = dto.Barcode128;
            product.Description = dto.Description;
            product.Reference = dto.Reference;
            product.Color = dto.Color;
            product.Id = dto.Id;
            product.Name = dto.Name;
            product.Prize = dto.Prize;
        }
    }
}
