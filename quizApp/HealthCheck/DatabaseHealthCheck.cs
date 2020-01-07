using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;
using quizApp.Domain.Models;
using quizApp.Persistence;

namespace quizApp.HealthCheck
{
    public class DatabaseHealthCheck: IHealthCheck
    {
        private IRepositoryGeneric<Quiz> _repository;
        public DatabaseHealthCheck(IRepositoryGeneric<Quiz> repository)
        {
            _repository = repository;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var result = await _repository.GetListAsync();
                if (result != null)
                {
                    return HealthCheckResult.Healthy("Database connected");
                }
                return HealthCheckResult.Healthy("Database disconnected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return HealthCheckResult.Unhealthy(e.Message);
            }
        }
    }
}
