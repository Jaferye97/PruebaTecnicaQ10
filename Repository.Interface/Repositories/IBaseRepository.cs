using System.Linq.Expressions;
using Domain.Model.Constants;

namespace Repository.Interface.Repositories
{
    public interface IBaseRepository<TEntity, in TPrimary> where TEntity : IEntity<TPrimary>
    {
        public Task<TEntity> GetAsync(TPrimary id);

        public Task<List<TEntity>> GetAllAsync();

        public Task<List<TEntity>> GetAllByIdAsync(IEnumerable<TPrimary> ids);

        public void Add(TEntity entity);

        public void Add(IEnumerable<TEntity> entity);

        public void Update(TEntity entity);

        public void Update(IEnumerable<TEntity> entity);

        public void Delete(TEntity id);

        public void Delete(IEnumerable<TEntity> id);

        public Task<List<TEntity>> GetWithPredicateAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetUniqueAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
