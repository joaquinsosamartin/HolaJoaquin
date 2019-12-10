using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hola.Shopping.Api.Data.Contracts.Repositories;
using Hola.Shopping.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Hola.Shopping.Api.Data.Implementation.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly HolaShoppingContext _context;

        public ProductRepository(HolaShoppingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<IEnumerable<Product>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async void Insert(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
