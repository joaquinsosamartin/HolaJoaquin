using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
