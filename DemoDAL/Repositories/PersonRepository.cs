using DemoDAL.DbContexts;
using DemoDAL.Entiries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        public async Task<PersonEntity> InsertAsync(PersonEntity p)
        {
            await _dbContext.People.AddAsync(p);
            await _dbContext.SaveChangesAsync();
            return p;
        }

        public async Task<PersonEntity> UpdateAsync(PersonEntity model)
        {
            var p = await _dbContext.People.FirstOrDefaultAsync(x => x.Id == model.Id);

            p.FirstName=model.FirstName;
            p.LastName=model.LastName;
            _dbContext.People.Update(p);
            await _dbContext.SaveChangesAsync(); ;
            return p;
        }
    }
}
