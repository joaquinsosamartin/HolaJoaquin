using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hola.Shopping.Api.Data.Contracts.Repositories;
using Hola.Shopping.Api.Domain.Model;
using LinqKit;
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

        public async Task<int> GetCountAsync(Expression<Func<Product, bool>> filter)
        {
            return await _context.Products.CountAsync(filter);
        }

        // TODO: move to a generic base repository

        public async Task<IEnumerable<Product>> GetAsync(
            Expression<Func<Product, bool>> filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            return await Task.Run(() => GetQueryable(filter, orderBy, includeProperties, skip, take));
        }

        private IQueryable<Product> GetQueryable(
            Expression<Func<Product, bool>> filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null)
        {
            includeProperties ??= string.Empty;
            IQueryable<Product> query = _context.Set<Product>();

            if (filter != null)
            {
                query = query.AsExpandable().Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue && skip.Value > 0)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }
    }
}
