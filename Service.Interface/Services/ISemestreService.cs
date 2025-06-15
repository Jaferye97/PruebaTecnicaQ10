using Domain.Model;

namespace Service.Interface.Services
{
    public interface ISemestreService : IBaseService<Semestre, int>
    {
        Task<List<Semestre>> GetAllActivos();
    }
}
