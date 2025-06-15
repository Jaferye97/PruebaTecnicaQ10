using Domain.Model;

namespace Service.Interface.Services
{
    public interface IMateriaEstudianteSemestreService : IBaseService<MateriaEstudianteSemestre, int>
    {
        Task<List<MateriaEstudianteSemestre>> GetHistorialEstudianteByEstudianteId(int estudianteId);
        Task<bool> ValidarExisteAsignacionAsync(int estudianteId, int materiaId, int semestreId);
        Task<bool> ValidarLimiteCreditosPorMateriaAsync(int estudianteId, int semestreId);
    }
}
