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

        public Expression<Func<T, object>> OrderBy {get;private set;}

        public Expression<Func<T, object>> OrderByDecending {get;private set;}

        public int Take {get;private set;}

        public int Skip {get;private set;}

        public bool IsPagingEnabled {get;private set;}

        protected void AddInclude(Expression<Func<T, object>> IncludeExpression)
        {
            Includes.Add(IncludeExpression);
        }
        protected void AddOredrBy(Expression<Func<T, object>>OrederByExpression)
        {
            OrderBy = OrederByExpression;
        }
        protected void AddOrderByDecending (Expression<Func<T, object>>OrederByDescExpression)
        {
            OrderByDecending = OrederByDescExpression;
        }

        protected  void ApplyPaging(int skip , int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
            
        }
    }
}