using System;
using System.Collections.Generic;

namespace quizApp.Persistence
{
    public interface IRepositoryGeneric<TEntity> where TEntity: class
    {
        List<TEntity> GetList();
        List<TEntity> GetList(Predicate<TEntity> predicate);
        TEntity FindById(int id);
        void Create(TEntity item);
        void Remove(TEntity item);
        void Update(TEntity item);

    }
}