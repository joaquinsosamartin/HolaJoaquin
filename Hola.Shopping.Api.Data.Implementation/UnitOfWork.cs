using System;
using System.Linq;
using Hola.Shopping.Api.Data.Contracts;
using Hola.Shopping.Api.Data.Contracts.Repositories;
using Hola.Shopping.Api.Data.Implementation.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hola.Shopping.Api.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HolaShoppingContext _context;
        private IProductRepository _productRepository;
        private ISizeRepository _sizeRepository;

        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);
        public ISizeRepository SizeRepository => _sizeRepository ??= new SizeRepository(_context);

        public UnitOfWork(HolaShoppingContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
