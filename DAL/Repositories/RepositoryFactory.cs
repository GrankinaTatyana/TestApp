using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public interface IRepositoryFactory<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity, bool save = true);
        Task AddRangeAsync(IEnumerable<TEntity> entities, bool save = true);
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity, bool save = true);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities, bool save = true);
        int Count();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(int id);
        Task<List<TEntity>> GetAll();
    }

    public class RepositoryFactory<TEntity> : IRepositoryFactory<TEntity> where TEntity : class
    {
        protected readonly Func<DbContext> _factory;
        //protected DbSet<TEntity> _entities;

        public RepositoryFactory(Func<DbContext> factory)
        {
            _factory = factory;
            //using (var context = factory.Invoke())
            //{
            //    _entities = context.Set<TEntity>();
            //}
        }

        public virtual async Task AddAsync(TEntity entity, bool save = true)
        {
            //using (var context = _factory.Invoke())
            //{
            //    await context.AddAsync(entity);
            //    if (save)
            //        await context.SaveChangesAsync();
            //}   
            var context = _factory.Invoke();
            await context.AddAsync(entity);
            if (save)
                await context.SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, bool save = true)
        {
            using (var context = _factory.Invoke())
            {
                await context.AddRangeAsync(entities);
                if (save)
                    await context.SaveChangesAsync();
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            using (var context = _factory.Invoke())
            {
                context.Update(entity);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            using (var context = _factory.Invoke())
            {
                context.UpdateRange(entities);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task RemoveAsync(TEntity entity, bool save = true)
        {
            using (var context = _factory.Invoke())
            {
                context.Remove(entity);
                if (save)
                    await context.SaveChangesAsync();
            }
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities, bool save = true)
        {
            using (var context = _factory.Invoke())
            {
                context.RemoveRange(entities);
                if (save)
                    await context.SaveChangesAsync();
            }
        }

        public virtual int Count()
        {
            using (var context = _factory.Invoke())
            {
                var table = context.Set<TEntity>();
                return table.Count();
            }
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var context = _factory.Invoke();
            var table = context.Set<TEntity>();
            return table.Where(predicate);
        }

        public virtual async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = _factory.Invoke())
            {
                var table = context.Set<TEntity>();
                return await table.SingleOrDefaultAsync(predicate);
            }
        }

        public virtual async Task<TEntity> Get(int id)
        {
            using (var context = _factory.Invoke())
            {
                var table = context.Set<TEntity>();
                return await table.FindAsync(id);
            }
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            using (var context = _factory.Invoke())
            {
                var table = context.Set<TEntity>();
                return await table.ToListAsync();
            }
        }
    }
}
