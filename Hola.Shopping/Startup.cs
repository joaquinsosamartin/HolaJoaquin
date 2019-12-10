using System.Reflection;
using AutoMapper;
using AutoWrapper;
using Hola.Shopping.Api.Application.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Hola.Shopping.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataServiceCollection(Configuration);
            services.AddApplicationServices();

            services.AddAutoMapper(GetAutoMapperAssemblies());

            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        IConfigurationSection googleAuthNSection =
            //            Configuration.GetSection("Authentication:Google");

            //        options.ClientId = googleAuthNSection["ClientId"];
            //        options.ClientSecret = googleAuthNSection["ClientSecret"];
            //    });

            services.AddCors(options =>
            {
                options.AddPolicy("GooglePolicy", builder => builder
                    //.WithOrigins(Configuration.GetValue<string>("GoogleClientPolicy"), "Access-Control-Allow-Origin", "Access-Control-Allow-Credentials")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials()
                );
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hola Shopping Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("GooglePolicy");
            //app.UseAuthentication();

            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions
            {
                IsApiOnly = true,
                IsDebug = true,
                ShowApiVersion = false,
                ShowStatusCode = true
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hola Shopping Api V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }

        private static Assembly[] GetAutoMapperAssemblies()
        {
            return new[] { Assembly.GetAssembly(typeof(Startup)), Assembly.GetAssembly(typeof(SizeResolver))  };
        }
    }
}
