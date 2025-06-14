using Domain.Model;
using Repository.Context;
using Repository.Interface.Repositories;

namespace Repository.Repositories
{
    public class MateriaEstudianteSemestreRepository : BaseRepository<MateriaEstudianteSemestre, EntityDbContext, int>, IMateriaEstudianteSemestreRepository
    {
        public MateriaEstudianteSemestreRepository(EntityDbContext context) : base(context)
        {
        }
    }
}
