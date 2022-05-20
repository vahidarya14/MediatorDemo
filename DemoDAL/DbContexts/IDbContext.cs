using DemoDAL.Entiries;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DemoDAL.DbContexts
{
    public interface IDbContext
    {
        DbSet<PersonEntity> People { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
