using DemoCQRS.Commands;
using DemoDAL.Entiries;
using DemoDAL.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCQRS.Handlers
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, PersonModel>
    {
        private readonly IRepository<PersonEntity> _db;
        IMediator _mediator;

        public UpdatePersonCommandHandler(IRepository<PersonEntity> db, IMediator mediator)
        {
            _db = db;
            _mediator = mediator;
        }

        public async Task<PersonModel> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity =await _db.UpdateAsync(new PersonEntity(request.FirstName, request.LastName) { Id=request.Id});
            _mediator.Publish(request);
            return new PersonModel(entity.Id, entity.FirstName, entity.LastName);
        }
    }
}
