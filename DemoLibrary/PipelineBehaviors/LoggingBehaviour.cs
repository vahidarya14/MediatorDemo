using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCQRS.PipelineBehaviors
{
    public class LoggingBehaviour<TRequest, TResponse> : 
                 IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //Request
            _logger.LogInformation($"LoggingBehaviour started=>{typeof(TRequest).Name}");
            Type myType = request.GetType();

            var response = await next();
            //Response
            _logger.LogInformation($"LoggingBehaviour  done=> {typeof(TResponse).Name}");
            return response;
        }
    }
}
