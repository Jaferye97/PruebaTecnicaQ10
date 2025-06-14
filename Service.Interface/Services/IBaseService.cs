namespace Service.Interface.Services
{
    public interface IBaseService<TEntity, TRequest, TPrimary>
    {
        public Task<TEntity> GetAsync(TPrimary id);

        public Task<List<TEntity>> GetAllAsync();

        public Task<List<TEntity>> GetAllByIdAsync(IEnumerable<TPrimary> ids);

        public Task<TEntity> AddAsync(TEntity entity);

        public Task<IEnumerable<TEntity>> AddAsync(ICollection<TEntity> entities);

        public Task UpdateAsync(TEntity entity);

        public Task UpdateAsync(ICollection<TEntity> entities);

        public Task<TEntity> AddAsync(TRequest entityRequest);

        public Task<IEnumerable<TEntity>> AddAsync(ICollection<TRequest> entitiesRequest);

        public Task UpdateAsync(TPrimary id, TRequest entityRequest);

        public Task DeleteAsync(TPrimary id);

        public Task DeleteAsync(ICollection<TPrimary> id);
    }
}
