using System.Linq.Expressions;

namespace Hola.Shopping.Api.Data.Implementation.Specifications
{
    public class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _mParameter;
        private readonly Expression _mReplacement;
        public ParameterReplacer(ParameterExpression parameter, Expression replacement)
        {
            this._mParameter = parameter;
            this._mReplacement = replacement;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return object.ReferenceEquals(node, _mParameter) ? _mReplacement : node;
        }

    }
}