using Domain.Model;

namespace Service.Interface.Services
{
    public interface IMateriaService : IBaseService<Materia, int>
    {
        Task ToggleActivoAsync(int id);

        Task<bool> ExisteCodigoAsync(string codigo, int idRegistroActualizando = 0);
    }
}
