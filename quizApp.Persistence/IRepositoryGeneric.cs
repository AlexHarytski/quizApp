using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quizApp.Persistence
{
    public interface IRepositoryGeneric<TEntity> where TEntity: class
    {
        Task<List<TEntity>> GetListAsync();
        Task<List<TEntity>> GetListAsync(Func<TEntity, bool> predicate);
        Task<TEntity> FindByIdAsync(string id);
        Task CreateAsync(TEntity item);
        Task RemoveAsync(string Id);
        Task UpdateAsync(TEntity item);
    }
}