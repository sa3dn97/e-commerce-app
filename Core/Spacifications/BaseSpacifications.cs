using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Spacifications
{
    public class BaseSpacifications<T> : ISpacifications<T>
    {
        public BaseSpacifications()
        {
        }

        public BaseSpacifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria {get; }

        public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> IncludeExpression)
        {
            Includes.Add(IncludeExpression);
        }
    }
}