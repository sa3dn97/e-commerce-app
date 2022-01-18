using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Spacifications;

namespace Core.Interfaces
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
         Task<T> GetbyIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpacifications<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpacifications<T> spec);
        Task<int> CountAsync(ISpacifications<T> spec);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}