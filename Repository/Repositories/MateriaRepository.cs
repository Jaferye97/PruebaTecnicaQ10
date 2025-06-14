using Domain.Model;
using Repository.Context;
using Repository.Interface.Repositories;

namespace Repository.Repositories
{
    public class MateriaRepository : BaseRepository<Materia, EntityDbContext, int>, IMateriaRepository
    {
        public MateriaRepository(EntityDbContext context) : base(context)
        {
        }
    }
}
