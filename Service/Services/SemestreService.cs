using Domain.Model;
using Repository.Context;
using Repository.Interface.Repositories;
using Service.Interface.Services;

namespace Service.Services
{
    public class SemestreService : BaseService<Semestre, int, ISemestreRepository>, ISemestreService
    {
        private readonly ISemestreRepository _SemestreRepository;

        public SemestreService(EntityDbContext context, ISemestreRepository repository) : base(context, repository)
        {
            this._SemestreRepository = repository;
        }

        public async Task<List<Semestre>> GetAllActivos()
        {
            return await _SemestreRepository.GetWithPredicateAsync(x => x.Activo == true);
        }
    }
}
