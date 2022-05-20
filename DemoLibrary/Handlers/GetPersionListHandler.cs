using DemoCQRS.Queries;
using DemoDAL.Entiries;
using DemoDAL.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCQRS.Handlers
{
    public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
    {
        IRepository<PersonEntity> _db;
        public GetPersonListHandler(IRepository<PersonEntity> db)
        {
            _db = db;
        }

        public Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.GetItems().Select(x=>new PersonModel(x.Id,x.FirstName,x.LastName)).ToList());
        }
    }
}
