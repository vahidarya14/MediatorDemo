using DemoDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoDAL.DbContexts
{
    public interface IDbContext
    {
        DbSet<PersonEntity> People { get; set; }


        int SaveChanges();
    }
}
