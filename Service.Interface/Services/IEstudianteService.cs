using Domain.Model;

namespace Service.Interface.Services
{
    public interface IEstudianteService : IBaseService<Estudiante, int>
    {
        Task ToggleActivoAsync(int id);
        Task<bool>ExisteDocumentoAsync(string documento, int idRegistroActualizando = 0);
        Task<List<Estudiante>> GetByNombreDocumentoByFilter(string filter);
        Task<List<Estudiante>> GetAllActivos();
    }
}
