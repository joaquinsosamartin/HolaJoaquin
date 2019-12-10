using System.Collections.Generic;
using System.Threading.Tasks;
using Hola.Shopping.Api.Application.Dtos;

namespace Hola.Shopping.Api.Application.Contracts.Services
{
    public interface IProductService
    {
        Task<IList<ProductDto>> GetAll();
        Task<bool> Insert(ProductDto dto);
        Task<bool> Update(ProductDto dto);
    }
}
