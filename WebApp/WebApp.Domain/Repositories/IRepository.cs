using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Domain.Models.Shared;

namespace WebApp.Domain.Repositories
{
    public interface IRepository<TEntity, in TPrimaryKey> where TEntity : IEntity<TPrimaryKey>
    {
        Task<List<TEntity>> GetAllAsync();

        TEntity Get(TPrimaryKey id);

        Task<TEntity> GetAsync(TPrimaryKey id);

        Task<List<TEntity>> FilterAsync(Func<TEntity, bool> predicate);

        void Add(TEntity entity);

        void AddOrUpdate(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Remove(TPrimaryKey id);

        Task SaveChangesAsync();

        void SaveChanges();

    }
}
