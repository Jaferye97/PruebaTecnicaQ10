using System.Linq.Expressions;
using Domain.Model.Constants;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Repositories;

namespace Repository.Repositories
{
    public abstract class BaseRepository<TEntity, TContext, TPrimary> : IBaseRepository<TEntity, TPrimary>
        where TEntity : class, IEntity<TPrimary>
        where TContext : DbContext
    {
        protected readonly TContext Context;

        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();

            // Desactivar consulta con seguimiento
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual Task<TEntity> GetAsync(TPrimary id)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return DbSet.ToListAsync();
        }

        public Task<List<TEntity>> GetAllByIdAsync(IEnumerable<TPrimary> ids)
        {
            return DbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entity)
        {
            DbSet.AddRange(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Attach(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Context.Attach(entity).State = EntityState.Modified;
            }
        }

        public void Delete(TEntity entity)
        {
            Context.Attach(entity).State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                Context.Attach(item).State = EntityState.Deleted;
            }
        }

        public Task<List<TEntity>> GetWithPredicateAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = this.DbSet;
            if (includes != null)
            {
                foreach (Expression<Func<TEntity, object>> include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<TEntity> GetUniqueAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return (await GetAsync(filter, orderBy, includes)).FirstOrDefault();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).CountAsync();
        }
    }
}
