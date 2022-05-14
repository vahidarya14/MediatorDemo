using MediatR;

namespace DemoCQRS.Commands
{
    public record InsertPersonCommand(string FirstName, string LastName) 
        : IRequest<PersonModel>, INotification;
}
