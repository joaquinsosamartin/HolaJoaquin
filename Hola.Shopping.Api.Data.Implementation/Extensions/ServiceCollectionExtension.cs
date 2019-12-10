using System.Reflection;
using Hola.Shopping.Api.Data.Contracts;
using Hola.Shopping.Api.Data.Contracts.Repositories;
using Hola.Shopping.Api.Data.Implementation.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hola.Shopping.Api.Data.Implementation.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddDatabaseServerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HolaShoppingContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

            return services;
        }
    }
}
