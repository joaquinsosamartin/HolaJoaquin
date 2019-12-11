using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hola.Shopping.Api.Domain.Model;

namespace Hola.Shopping.Api.Data.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetByName(string name);
        Task<Product> GetById(Guid id);
        void Insert(Product product);
        void Update(Product product);
        Task<int> GetCountAsync(Expression<Func<Product, bool>> filter);
        Task<IEnumerable<Product>> GetAsync(
            Expression<Func<Product, bool>> filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);
    }
}
