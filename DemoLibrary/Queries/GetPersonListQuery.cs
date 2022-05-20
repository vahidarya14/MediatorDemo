using MediatR;
using System.Collections.Generic;

namespace DemoCQRS.Queries
{
    public record GetPersonListQuery() : IRequest<List<PersonModel>>;

}
