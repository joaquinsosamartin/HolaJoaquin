using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hola.Shopping.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hola.Shopping.Api.Data.Implementation
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly HolaShoppingContext _context;
        private readonly ILogger _logger;

        public DatabaseInitializer(HolaShoppingContext context)
        {
            _context = context;
            //_logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Categories.AnyAsync())
            {
                //_logger.LogInformation("Generating categories");

                await CreateCategoriesAsync();
                await CreateProductsAsync();
                await CreateSizesAsync();

            }
        }

        private async Task CreateSizesAsync()
        {
            var sizes = new List<Size>
            {
                new Size {CountryIso = "es", NumericValue = 40,IsNumeric = true},
                new Size {CountryIso = "es", NumericValue = 42,IsNumeric = true},
                new Size {CountryIso = "es", NumericValue = 48,IsNumeric = true},
                new Size {CountryIso = "es", NumericValue = 32,IsNumeric = true},
                new Size {CountryIso = "es", IsNumeric = false, Value = "XL"},
                new Size {CountryIso = "es", IsNumeric = false, Value = "S"}
            };

            _context.Sizes.AddRange(sizes.AsEnumerable());
            await _context.SaveChangesAsync();
        }

        private async Task CreateCategoriesAsync()
        {
            var categories = new List<Category>
            {
                new Category {Name = "Chaquetas", IsActive = true},
                new Category {Name = "Jerséis y sudaderas", IsActive = true},
                new Category {Name = "Camisetas y tops", IsActive = true},
                new Category {Name = "Vaqueros", IsActive = true},
                new Category {Name = "Vestidos", IsActive = true},
                new Category {Name = "Blusas y blusones", IsActive = true},
                new Category {Name = "Pantalones", IsActive = true},
                new Category {Name = "Faldas", IsActive = true},
                new Category {Name = "Ropa de deporte", IsActive = true},

            };

            _context.Categories.AddRange(categories.AsEnumerable());
            await _context.SaveChangesAsync();
        }

        private async Task CreateProductsAsync()
        {
            //var tech1 = _context.Technologies.First();
            //var tech2 = _context.Technologies.Skip(1).First();
            //var technologies = new List<Technology> { tech1, tech2 };

            //var jobsOffers = new List<JobOffer>()
            //{
            //    new JobOffer
            //    {
            //        Title = "Job Offer 1",
            //        Benefits = "Seguro médico, ticket restaurant, clases inglés",
            //        Description = "Job Offer 1 Description",
            //        IsPublished = true,
            //        PublishDate = DateTime.UtcNow,
            //        Rol = RolEnum.Developer,
            //        Salary = "35000K B. A.",
            //        Status = JobOfferStatusEnum.Open
            //    }
            //};

            //var jobOfferTechnology1 = new JobOfferTechnology
            //{
            //    JobOffer = jobsOffers.First(),
            //    TechnologyId = technologies.First().Id
            //};

            //var jobOfferTechnology2 = new JobOfferTechnology
            //{
            //    JobOffer = jobsOffers.First(),
            //    TechnologyId = technologies.Last().Id
            //};

            //jobsOffers.First().JobOfferTechnologies = new List<JobOfferTechnology> {jobOfferTechnology1, jobOfferTechnology2};
            //_context.JobOffers.AddRange(jobsOffers);
            await _context.SaveChangesAsync();
        }
    }
}
