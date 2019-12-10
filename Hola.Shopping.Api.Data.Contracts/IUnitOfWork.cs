using System;
using Hola.Shopping.Api.Data.Contracts.Repositories;

namespace Hola.Shopping.Api.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        ISizeRepository SizeRepository { get; }
        void Commit();
        void RejectChanges();
    }
}
