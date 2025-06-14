using Domain.Model;

namespace Service.Interface.Services
{
    public interface IMateriaEstudianteSemestreService : IBaseService<MateriaEstudianteSemestre, int>
    {
        Task<List<MateriaEstudianteSemestre>> GetHistorialEstudianteByEstudianteId(int estudianteId);
    }
}
