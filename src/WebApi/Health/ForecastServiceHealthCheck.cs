using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebApi.Services;

namespace WebApi.Health
{
    public class ForecastServiceHealthCheck(ForecastService _forecastService) : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            var result = await _forecastService.IsServiceHealthy();
            if (result)
                return HealthCheckResult.Healthy();
            else
                return HealthCheckResult.Unhealthy();
        }
    }
}
