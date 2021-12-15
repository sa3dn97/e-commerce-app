using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitties;
using Core.Interfaces;
using Core.Spacifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetbyIdAsync(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public  async Task<T> GetEntityWithSpec(ISpacifications<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        public  async Task<IReadOnlyList<T>> ListAsync(ISpacifications<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

         public  async Task<int> CountAsync(ISpacifications<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
          
        }

        private IQueryable<T> ApplySpecification(ISpacifications<T> spec)
        {

            return SpacificationEvaluater<T>.GetQuery(_context.Set<T>().AsQueryable(),spec);
        }

       
    }
}