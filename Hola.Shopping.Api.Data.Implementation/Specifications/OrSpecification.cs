using System;
using System.Linq.Expressions;
using Hola.Shopping.Api.Data.Contracts;

namespace Hola.Shopping.Api.Data.Implementation.Specifications
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly ISpecification<T> _right;

        public OrSpecification(Specification<T> left, ISpecification<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr, null).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}