using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCQRS.PipelineBehaviors
{
    public class ValidationBehaviour<TRequest, TResponse> : 
                 IPipelineBehavior<TRequest, TResponse>  where TRequest:IRequest<TResponse>
    {
        private readonly ILogger<ValidationBehaviour<TRequest, TResponse>> _logger;
        public ValidationBehaviour(ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken ct, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"ValidationBehaviour started=> {typeof(TRequest).Name}");
            var response = await next();
            _logger.LogInformation($"ValidationBehaviour  done=> {typeof(TRequest).Name}");
            return response;
        }
    }

}
