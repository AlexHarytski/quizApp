using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using quizApp.Application.Queries;

namespace quizApp.HealthCheck
{
    public class ApiHealthCheck: IHealthCheck
    {
        private readonly IMediator _mediator;

        public ApiHealthCheck(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var query = new GetAllQuizzesQuery();
                var result = await _mediator.Send(query, cancellationToken);
                if (result != null)
                {
                    return HealthCheckResult.Healthy("MediatR OK");
                }
                else
                {   
                    return HealthCheckResult.Unhealthy("MediatR unhealthy: null result");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return HealthCheckResult.Unhealthy($"MediatR unhealthy: {e.Message}");
            }
        }
    }
}
