using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hola.Shopping.Api.Data.Contracts.Repositories;
using Hola.Shopping.Api.Data.Implementation.Specifications;
using Hola.Shopping.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Hola.Shopping.Api.Data.Implementation.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly HolaShoppingContext _context;

        public SizeRepository(HolaShoppingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Size>> GetAll()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task<Size> GetByNumericValue(int numericValue)
        {
            var specification = new SizeByNumericValueSpecification(numericValue);
            var result = await _context.Sizes.FirstOrDefaultAsync(specification.ToExpression());

            _context.Entry(result).State = EntityState.Unchanged;

            return result;
        }

        public async Task<Size> GetByStringValue(string value)
        {
            var specification = new SizeByStringSpecification(value);
            var result = await _context.Sizes.FirstOrDefaultAsync(specification.ToExpression());

            _context.Entry(result).State = EntityState.Unchanged;

            return result;
        }

        public async void Insert(Size size)
        {
            await _context.Sizes.AddAsync(size);
        }
    }
}
