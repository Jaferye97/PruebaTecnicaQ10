using Domain.Model;
using Repository.Context;
using Repository.Interface.Repositories;
using Service.Interface.Services;

namespace Service.Services
{
    public class MateriaService : BaseService<Materia, int, IMateriaRepository>, IMateriaService
    {
        private readonly IMateriaRepository _MateriaRepository;

        public MateriaService(EntityDbContext context, IMateriaRepository repository) : base(context, repository)
        {
            this._MateriaRepository = repository;
        }

        public async Task ToggleActivoAsync(int id)
        {
            var materia = await _MateriaRepository.GetAsync(id);
            if (materia != null)
            {
                materia.Activo = !materia.Activo;
                await base.UpdateAsync(materia);
            }
        }

        public async Task<bool> ExisteCodigoAsync(string codigo, int idRegistroActualizando = 0)
        {
            List<Materia> result;

            if (idRegistroActualizando > 0)
            {
                result = await _MateriaRepository.GetWithPredicateAsync(x => x.Codigo == codigo && x.Id != idRegistroActualizando);
            }
            else
            {
                result = await _MateriaRepository.GetWithPredicateAsync(x => x.Codigo == codigo);
            }

            return result.Count > 0;
        }

        public async Task<List<Materia>> GetAllActivos()
        {
            return await _MateriaRepository.GetWithPredicateAsync(x => x.Activo == true);
        }
    }
}
