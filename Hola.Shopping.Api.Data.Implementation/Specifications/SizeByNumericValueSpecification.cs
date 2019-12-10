using System;
using System.Linq.Expressions;
using Hola.Shopping.Api.Domain.Model;

namespace Hola.Shopping.Api.Data.Implementation.Specifications
{
    public class SizeByNumericValueSpecification : Specification<Size>
    {
        private readonly int _sizeNumericValue;

        public SizeByNumericValueSpecification(int sizeNumericValue)
        {
            _sizeNumericValue = sizeNumericValue;
        }

        public override Expression<Func<Size, bool>> ToExpression()
        {
           return size => size != null && size.IsNumeric && size.NumericValue.HasValue && size.NumericValue.Value.Equals(_sizeNumericValue);
        }
    }
}
