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
        IMediator _mediator;

        public InsertPersonCommandHandler(IRepository<PersonEntity> db, IMediator mediator)
        {
            _db = db;
            _mediator = mediator;
        }

        public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            var entity= _db.Insert(new PersonEntity { FirstName = request.FirstName, LastName = request.LastName });
            _mediator.Publish(request);
            return Task.FromResult(new PersonModel { FirstName=entity.FirstName,LastName=entity.LastName,Id=entity.Id});
        }
    }
}
