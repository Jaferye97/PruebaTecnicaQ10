using Domain.Model;
using Repository.Context;
using Repository.Interface.Repositories;
using Service.Interface.Services;

namespace Service.Services
{
    public class MateriaEstudianteSemestreService : BaseService<MateriaEstudianteSemestre, int, IMateriaEstudianteSemestreRepository>, IMateriaEstudianteSemestreService
    {
        private readonly IMateriaEstudianteSemestreRepository _MateriaEstudianteSemestreRepository;

        public MateriaEstudianteSemestreService(EntityDbContext context, IMateriaEstudianteSemestreRepository repository) : base(context, repository)
        {
            this._MateriaEstudianteSemestreRepository = repository;
        }
    }
}
