using MediatR;
using Microsoft.Extensions.Logging;

namespace DemoCQRS.NotificationHandlers
{
    public class InsertedPersonEvent<TNotification> : NotificationHandler<TNotification> where TNotification : INotification
    {
        private readonly ILogger<InsertedPersonEvent<TNotification>> _logger;
        public InsertedPersonEvent(ILogger<InsertedPersonEvent<TNotification>> logger)
        {
            _logger = logger;
        }
        protected override void Handle(TNotification notification)
        {

            _logger.LogInformation($"InsertedPersonEvent");
        }
    }

}
