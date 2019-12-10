using System.Collections.Generic;
using System.Threading.Tasks;
using Hola.Shopping.Api.Domain.Model;

namespace Hola.Shopping.Api.Data.Contracts.Repositories
{
    public interface ISizeRepository
    {
        Task<IEnumerable<Size>> GetAll();
        Task<Size> GetByNumericValue(int numericValue);
        void Insert(Size size);
        Task<Size> GetByStringValue(string value);
    }
}
