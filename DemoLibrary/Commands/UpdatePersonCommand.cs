using MediatR;

namespace DemoCQRS.Commands
{
    public record UpdatePersonCommand(int Id, string FirstName, string LastName)
     : IRequest<PersonModel>, INotification;
}
