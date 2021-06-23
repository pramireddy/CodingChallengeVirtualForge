using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lab.Technical.Exercise.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetByWhere(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetByIdAsync(int id);

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}