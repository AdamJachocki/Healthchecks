using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Health
{
    public class HealthCheckDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var healthCheckOp = CreateHealthcheckOperation("_health", true);
            var dbHealthCheckOp = CreateHealthcheckOperation("_health_db", false);

            var healthPathItem = new OpenApiPathItem();
            healthPathItem.AddOperation(OperationType.Get, healthCheckOp);

            var dbHealthCheckPathItem = new OpenApiPathItem();
            dbHealthCheckPathItem.AddOperation(OperationType.Get, dbHealthCheckOp);

            swaggerDoc.Paths.Add("/_health", healthPathItem);
            swaggerDoc.Paths.Add("/_health_db", dbHealthCheckPathItem);
        }

        private OpenApiOperation CreateHealthcheckOperation(string endpoint, bool returnsJson)
        {
            var result = new OpenApiOperation();
            result.OperationId = $"{endpoint}OperationId";

            var mediaType = returnsJson ? "application/json" : "text/plain";
            var objType = returnsJson ? "object" : "string";
            var schema = new OpenApiSchema
            {
                Type = objType
            };

            var response = new OpenApiResponse
            {
                Description = "Success"
            };

            response.Content.Add(mediaType, new OpenApiMediaType { Schema = schema });
            result.Responses.Add("200", response);

            return result;
        }
    }
}
