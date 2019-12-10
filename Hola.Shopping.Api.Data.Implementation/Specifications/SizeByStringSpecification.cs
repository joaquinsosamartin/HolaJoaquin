using System;
using System.Linq.Expressions;
using Hola.Shopping.Api.Domain.Model;

namespace Hola.Shopping.Api.Data.Implementation.Specifications
{
    public class SizeByStringSpecification : Specification<Size>
    {
        private readonly string _sizeValue;

        public SizeByStringSpecification(string sizeValue)
        {
            _sizeValue = sizeValue;
        }

        public override Expression<Func<Size, bool>> ToExpression()
        {
           return size => size != null && !size.IsNumeric && size.Value.Equals(_sizeValue,StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
