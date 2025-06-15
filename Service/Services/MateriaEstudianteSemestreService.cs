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

        public async Task<bool> ValidarExisteAsignacionAsync(int estudianteId, int materiaId, int semestreId)
        {
            return await _MateriaEstudianteSemestreRepository.CountAsync(x => x.EstudianteId == estudianteId && x.MateriaId == materiaId && x.SemestreId == semestreId) > 0;
        }

        public async Task<bool> ValidarLimiteCreditosPorMateriaAsync(int estudianteId, int semestreId)
        {
            var includes = new Expression<Func<MateriaEstudianteSemestre, object>>[] { x => x.Materia };
            var result = await _MateriaEstudianteSemestreRepository.GetAsync(x => x.EstudianteId == estudianteId && x.SemestreId == semestreId && x.Materia.Creditos >= 4, null, includes);

            return result.Count == 3 ? true : false;
        }
    }
}
