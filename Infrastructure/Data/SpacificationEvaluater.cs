using System.Linq;
using Core.Entitties;
using Core.Spacifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpacificationEvaluater<TEntity> where TEntity : BaseEntity 
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpacifications<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); //  p => p.PrudctId == id
            }
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDecending != null)
            {
                query = query.OrderByDescending(spec.OrderByDecending);
            }
            if(spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);


            }
            

            query =spec.Includes.Aggregate(query,(current,include) => current.Include(include));
            return query;


        }
    }
}