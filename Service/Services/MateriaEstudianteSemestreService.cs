using System.Linq.Expressions;
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

        public async Task<List<MateriaEstudianteSemestre>> GetHistorialEstudianteByEstudianteId(int estudianteId)
        {
            var includes = new Expression<Func<MateriaEstudianteSemestre, object>>[] { x => x.Materia, x => x.Semestre };
            return await _MateriaEstudianteSemestreRepository.GetAsync(x => x.EstudianteId == estudianteId, x => x.OrderBy(e => e.Semestre.Mes).ThenBy(e => e.Semestre.Anio), includes);
        }
    }
}
