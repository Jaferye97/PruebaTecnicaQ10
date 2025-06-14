using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext()
        {
        }

        public EntityDbContext(DbContextOptions<EntityDbContext> options)
          : base(options)
        { }

        public DbSet<Estudiante> Estudiante { get; set; }
    }
}
