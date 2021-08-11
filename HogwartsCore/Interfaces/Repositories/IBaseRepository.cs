using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HogwartsCore.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetByCodeAsync(Guid code);
        Task<IQueryable<TEntity>> QueryableWithWhereConditionAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> UpdateAsync(TEntity entity);
    }
}