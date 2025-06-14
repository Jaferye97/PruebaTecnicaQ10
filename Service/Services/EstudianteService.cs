using Domain.Model;
using Repository.Context;
using Repository.Interface.Repositories;
using Service.Interface.Services;

namespace Service.Services
{
    public class EstudianteService : BaseService<Estudiante, int, IEstudianteRepository>, IEstudianteService
    {
        private readonly IEstudianteRepository _EstudianteRepository;

        public EstudianteService(EntityDbContext context, IEstudianteRepository repository) : base(context, repository)
        {
            this._EstudianteRepository = repository;
        }

        public async Task ToggleActivoAsync(int id)
        {
            var estudiante = await _EstudianteRepository.GetAsync(id);
            if (estudiante != null)
            {
                estudiante.Activo = !estudiante.Activo;
                await base.UpdateAsync(estudiante);
            }
        }

        public async Task<bool> ExisteDocumentoAsync(string documento, int idRegistroActualizando = 0)
        {
            List<Estudiante> result;

            if (idRegistroActualizando > 0)
            {
                result = await _EstudianteRepository.GetWithPredicateAsync(x => x.Documento == documento && x.Id != idRegistroActualizando);
            }
            else
            {
                result = await _EstudianteRepository.GetWithPredicateAsync(x => x.Documento == documento);
            }

            return result.Count > 0;

        }
    }
}
