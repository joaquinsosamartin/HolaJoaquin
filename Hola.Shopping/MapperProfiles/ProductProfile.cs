using System.Collections.Generic;
using AutoMapper;
using AutoWrapper.Wrappers;
using Hola.Shopping.Api.Application.Dtos;
using Hola.Shopping.Api.Domain.Model;
using Hola.Shopping.Api.Model;

namespace Hola.Shopping.Api.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<IList<ProductDto>, ApiResponse>()
                .ForCtorParam("result", expression => expression.MapFrom(dto => dto))
                .ForCtorParam("message", expression => expression.MapFrom(dto => string.Empty))
                .ForCtorParam("statusCode", expression => expression.MapFrom(dto => 200))
                .ForCtorParam("apiVersion", expression => expression.MapFrom(dto => "1.0.0.0"));

            CreateMap<string, ApiResponse>()
                .ForCtorParam("result", expression => expression.MapFrom(dto => dto))
                .ForCtorParam("message", expression => expression.MapFrom(dto => string.Empty))
                .ForCtorParam("statusCode", expression => expression.MapFrom(dto => 200))
                .ForCtorParam("apiVersion", expression => expression.MapFrom(dto => "1.0.0.0"));

            CreateMap<ProductRequest, ProductDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Category,
                    expression =>
                        expression.MapFrom(product => product.Category != null ? product.Category.Name : string.Empty))
                .ForMember(dto => dto.Size,
                    expression =>
                        expression.MapFrom(product => product.Size != null
                            ? (product.Size.IsNumeric ? product.Size.NumericValue.Value.ToString() : product.Size.Value)
                            : string.Empty))
                .ReverseMap()
                .ForMember(product => product.Size, expression => expression.Ignore())
                .ForMember(product => product.ProductOrders, expression => expression.Ignore())
                .ForMember(product => product.Attachments, expression => expression.Ignore())
                .ForMember(product => product.Category, expression => expression.Ignore());

            CreateMap<GetProductsPagedRequest, ProductPagedDto>();
        }
    }
}
