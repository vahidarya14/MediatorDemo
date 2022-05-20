using DemoCQRS.Commands;
using DemoDAL.Entiries;
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

        public async Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            var entity=await _db.InsertAsync(new PersonEntity ( request.FirstName, request.LastName ));
            _mediator.Publish(request);
            return new PersonModel(entity.Id, entity.FirstName,entity.LastName);
        }
    }
}
