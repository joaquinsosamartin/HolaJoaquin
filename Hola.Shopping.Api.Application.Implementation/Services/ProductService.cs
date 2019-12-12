using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Hola.Shopping.Api.Application.Contracts.Services;
using Hola.Shopping.Api.Application.Dtos;
using Hola.Shopping.Api.Data.Contracts;
using Hola.Shopping.Api.Domain.Model;
using LinqKit;
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

                var size = int.TryParse(dto.Size, out var numericValue)
                    ? await _unitOfWork.SizeRepository.GetByNumericValue(numericValue)
                    : await _unitOfWork.SizeRepository.GetByStringValue(dto.Size);

                product.Size = size;

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

        public async Task<GenericCollectionResponse<IList<ProductDto>>> GetPaged(ProductPagedDto dto)
        {
            var response = new GenericCollectionResponse<IList<ProductDto>>();

            Func<IQueryable<Product>, IOrderedQueryable<Product>> order = product => product.OrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(dto.SortParameter))
            {
                order = GetProductOrder(dto.SortParameter, dto.SortOrder);
            }

            var filter = GetProductFilter(dto);

            var totalRecords = await _unitOfWork.ProductRepository.GetCountAsync(filter);

            response.TotalRecords = totalRecords;

            var products = await _unitOfWork.ProductRepository.GetAsync(filter, order, "Categories,Size",
                dto.StartRowIndex, dto.MaximumRows);
            
            var result = _mapper.Map<IList<Product>, IList<ProductDto>>(products.ToList());
            response.Result = result;

            return await Task.FromResult(response);

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
            product.Price = dto.Price;
        }

        private static Func<IQueryable<Product>, IOrderedQueryable<Product>> GetProductOrder(string sortParameter, int sortOrder)
        {
            if (string.IsNullOrEmpty(sortParameter))
            {
                return product => product.OrderBy(x => x.Name);
            }

            switch (sortParameter)
            {
                case "name":
                    return product => sortOrder == 1 ? product.OrderBy(x => x.Name) : product.OrderByDescending(x => x.Name);
                case "color":
                    return product => sortOrder == 1 ? product.OrderBy(x => x.Color) : product.OrderByDescending(x => x.Color);
                case "reference":
                    return product => sortOrder == 1 ? product.OrderBy(x => x.Reference) : product.OrderByDescending(x => x.Reference);
            }

            return null;
        }

        private static Expression<Func<Product, bool>> GetProductFilter(ProductPagedDto requestFilter)
        {
            var predicate = PredicateBuilder.New<Product>(true);


            if (!string.IsNullOrEmpty(requestFilter.Name))
            {
                predicate = predicate.And(a => a.Name.ToLower() == requestFilter.Name.ToLower());
            }

            if (!string.IsNullOrEmpty(requestFilter.Color))
            {
                predicate = predicate.And(a => a.Color == requestFilter.Color);
            }

            if (!string.IsNullOrEmpty(requestFilter.Reference))
            {
                predicate = predicate.And(a => a.Reference == requestFilter.Reference);
            }

            return predicate;
        }
    }
}
