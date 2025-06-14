using Domain.Model;
using Repository.Context;
using Repository.Interface.Repositories;

namespace Repository.Repositories
{
    public class SemestreRepository : BaseRepository<Semestre, EntityDbContext, int>, ISemestreRepository
    {
        public SemestreRepository(EntityDbContext context) : base(context)
        {
        }
    }
}
