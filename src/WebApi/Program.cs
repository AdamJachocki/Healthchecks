
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using WebApi.DAL;
using WebApi.Health;
using WebApi.Services;
using WebApi.Utils;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o =>
            {
                o.DocumentFilter<HealthCheckDocumentFilter>();
            });

            //services
            builder.Services.AddDbContext<AppDbContext>(o =>
                o.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDbConnectionString"))
            );

            builder.Services.AddSingleton<RandomHelper>();
            builder.Services.AddScoped<ForecastService>();
            builder.Services.AddScoped<WeatherService>();

            //healthcheck
            builder.Services.AddHealthChecks()
                .AddDbContextCheck<AppDbContext>(tags: new string[] {"db"})
                .AddCheck<ForecastServiceHealthCheck>("Forecast service");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapHealthChecks("/_health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.MapHealthChecks("/_health_db", new HealthCheckOptions
            {
                Predicate = healthCheck => healthCheck.Tags.Contains("db")
            });

            app.MapControllers();

            app.Run();
        }
    }
}
