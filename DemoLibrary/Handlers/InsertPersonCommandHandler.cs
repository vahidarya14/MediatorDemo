using DemoCQRS.Commands;
using DemoDAL.Models;
using DemoDAL.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCQRS.Handlers
{
    public class InsertPersonCommandHandler : IRequestHandler<InsertPersonCommand, PersonModel>
    {
        private readonly IRepository<PersonEntity> _db;

        public InsertPersonCommandHandler(IRepository<PersonEntity> db)
        {
            _db = db;
        }

        public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            var entity= _db.Insert(new PersonEntity { FirstName = request.FirstName, LastName = request.LastName });
            return Task.FromResult(new PersonModel { FirstName=entity.FirstName,LastName=entity.LastName,Id=entity.Id});
        }
    }
}
