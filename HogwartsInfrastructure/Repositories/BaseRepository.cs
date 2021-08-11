using HogwartsCore.Repositories;
using HogwartsCore.Services;
using HogwartsInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HogwartsInfrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly HogwartsContext db;
        protected readonly IAppLogger<TEntity> logger;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(HogwartsContext db, IAppLogger<TEntity> logger)
        {
            this.db = db;
            this.logger = logger;
            dbSet = db.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
            logger.LogInformation($"{nameof(entity)} was saved successfully");
            return entity;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            var result = await db.SaveChangesAsync() > 0;
            logger.LogInformation($"{nameof(entity)} was updated successfully");
            return result;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            var result = await db.SaveChangesAsync() > 0;
            logger.LogInformation($"{nameof(entity)} was deleted successfully");
            return result;
        }

        public async Task<TEntity> GetByCodeAsync(Guid code) => await db.Set<TEntity>().FindAsync(code);

        public async Task<IQueryable<TEntity>> GetAllAsync() => await Task.FromResult(db.Set<TEntity>().AsQueryable());

        public async Task<IQueryable<TEntity>> QueryableWithWhereConditionAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Task.FromResult(db.Set<TEntity>().Where(predicate).AsQueryable());


    }
}
