using Domain.Model;
using Repository.Context;
using Repository.Interface.Repositories;

namespace Repository.Repositories
{
    public class EstudianteRepository : BaseRepository<Estudiante, EntityDbContext, int>, IEstudianteRepository
    {
        public EstudianteRepository(EntityDbContext context) : base(context)
        {
        }
    }
}
