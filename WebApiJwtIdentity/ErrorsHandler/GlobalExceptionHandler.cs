using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ApiProperJwt3.ErrorsHandler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> _logger)
        {
            this._logger = _logger;
        }
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);

            var details = new ProblemDetails()
            {
                Detail = $"Error en API {exception.Message}, tomado de Mohamad Lawand",
                Instance = "DemoCustomJwt",
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Error en la API",
                Type = "Server error"
            };

            var response = JsonSerializer.Serialize(details);
            httpContext.Response.ContentType = "application/json"; 
            await httpContext.Response.WriteAsync(response, cancellationToken);
            return true;
        }
    }
}
