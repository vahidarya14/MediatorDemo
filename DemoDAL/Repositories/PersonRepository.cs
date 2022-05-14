using DemoDAL.DbContexts;
using DemoDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DemoDAL.Repositories
{
    public class PersonRepository : IRepository<PersonEntity>
    {
        IDbContext _dbContext;

        public PersonRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<PersonEntity> GetItems() => _dbContext.People.ToList();


        public PersonEntity Insert(PersonEntity p)
        {
            _dbContext.People.Add(p);
            _dbContext.SaveChanges();
            return p;
        }
    }
}
