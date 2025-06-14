using Domain.Model.Constants;
using Repository.Interface.Repositories;
using Service.Interface.Services;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using AutoMapper;

namespace Service.Services
{
    public abstract class BaseService<TEntity, TRequest, TPrimary, TRepository> : IBaseService<TEntity, TRequest, TPrimary>
        where TEntity : IEntity<TPrimary>
        where TRequest : class
        where TRepository : IBaseRepository<TEntity, TPrimary>
    {
        protected readonly TRepository Repository;

        protected readonly DbContext Context;

        protected BaseService(DbContext context, TRepository repository)
        {
            this.Repository = repository;
            this.Context = context;
        }

        protected BaseService(EntityDbContext context, TRepository repository)
        {
            this.Repository = repository;
            this.Context = context;
        }

        public virtual Task<TEntity> GetAsync(TPrimary id)
        {
            return Repository.GetAsync(id);
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return Repository.GetAllAsync();
        }

        public Task<List<TEntity>> GetAllByIdAsync(IEnumerable<TPrimary> ids)
        {
            return Repository.GetAllByIdAsync(ids);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            Repository.Add(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddAsync(ICollection<TEntity> entities)
        {
            Repository.Add(entities);
            await Context.SaveChangesAsync();

            return entities;
        }

        public Task<TEntity> AddAsync(TRequest entityRequest)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TRequest, TEntity>()));
            var model = mapper.Map<TEntity>(entityRequest);

            return this.AddAsync(model);
        }

        public Task<IEnumerable<TEntity>> AddAsync(ICollection<TRequest> entitiesRequest)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ICollection<TRequest>, ICollection<TEntity>>()));
            var models = mapper.Map<ICollection<TEntity>>(entitiesRequest);

            return this.AddAsync(models);
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            Repository.Update(entity);
            return Context.SaveChangesAsync();
        }

        public Task UpdateAsync(ICollection<TEntity> entities)
        {
            Repository.Update(entities);
            return Context.SaveChangesAsync();
        }

        public Task UpdateAsync(TPrimary id, TRequest entityRequest)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<TRequest, TEntity>()));
            var model = mapper.Map<TEntity>(entityRequest);
            model.Id = id;

            return this.UpdateAsync(model);
        }

        public virtual async Task DeleteAsync(TPrimary id)
        {
            var model = await GetAsync(id);
            if (model != null)
            {
                Repository.Delete(model);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(ICollection<TPrimary> id)
        {
            var model = await GetAllByIdAsync(id);
            if (model != null)
            {
                Repository.Delete(model);
                await Context.SaveChangesAsync();
            }
        }
    }
}
