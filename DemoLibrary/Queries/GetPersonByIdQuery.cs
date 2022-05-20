using MediatR;

namespace DemoCQRS.Queries
{
    public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;

}
