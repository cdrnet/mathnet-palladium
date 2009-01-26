﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MathNet.Palladium.ExpressionAlgebra
{
    internal static class ExpressionBuilder
    {
        public static Expression Reduce(this IEnumerable<Expression> terms, Func<Expression, Expression, Expression> map, Expression defaultIfEmpty)
        {
            Expression sum = null;
            foreach(Expression term in terms)
            {
                sum = (sum == null) ? term : map(sum, term);
            }

            return sum ?? defaultIfEmpty;
        }

        public static Expression CastToDouble(Expression expression)
        {
            if(expression.Type != typeof(double))
            {
                return Expression.Convert(expression, typeof(double));
            }

            return expression;
        }
    }
}
