using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace Hahn.ApplicationProcess.February2021.Domain.Behaviors
{
    //public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    //{
    //    private readonly Stopwatch _timer;
    //    private readonly ILogger<IRequest> _logger;
    //    private readonly ICurrentUserService _currentUserService;

    //    public RequestPerformanceBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    //    {
    //        _timer = new Stopwatch();
    //        _logger = logger;
    //        _currentUserService = currentUserService;
    //    }

    //    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    //    {
    //        _timer.Start();

    //        var response = await next();

    //        _timer.Stop();

    //        if (_timer.ElapsedMilliseconds > 500)
    //        {
    //            var name = typeof(TRequest).Name;

    //            _logger.LogWarning("Northwind Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
    //                name, _timer.ElapsedMilliseconds, _currentUserService.UserId, request);
    //        }

    //        return response;
    //    }
    //}
}
