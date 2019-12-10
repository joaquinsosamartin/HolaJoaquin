using AutoMapper;
using Hola.Shopping.Api.Application.Contracts.Services;
using Hola.Shopping.Api.Application.Dtos;
using Hola.Shopping.Api.Application.Implementation.Services;
using Hola.Shopping.Api.Data.Implementation.Extensions;
using Hola.Shopping.Api.Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hola.Shopping.Api.Application.Implementation
{
    public static class ServiceCollectionApplicationExtension
    {
        public static IServiceCollection AddDataServiceCollection(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDataServices();
            services.AddDatabaseServerConfiguration(configuration);

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISizeService, SizeService>();

            services.AddTransient<IValueResolver<ProductDto, Product, Size>, SizeResolver>();

            return services;
        }
    }
}
