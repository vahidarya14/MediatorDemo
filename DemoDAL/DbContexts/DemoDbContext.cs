using DemoDAL.Entiries;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DemoDAL.DbContexts
{
    public class DemoDbContext : DbContext, IDbContext
    {
        public DbSet<PersonEntity> People { get; set; }

        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
