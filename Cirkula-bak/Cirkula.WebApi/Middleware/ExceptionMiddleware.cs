using System.Net;
using System.Text.Json;
using Cirkula.WebApi.Exceptions;

namespace Cirkula.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error capturado por ExceptionMiddleware");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            // Valores por defecto
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string code = "500";
            string message = "Ocurrió un error inesperado";

            // Mapeo por tipo de excepción
            switch (ex)
            {
                case CustomException custom:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    code = custom.Code;
                    message = custom.Message;
                    break;

                case ArithmeticException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    code = "004";
                    message = "Error al hacer algún cálculo";
                    break;

                case DuplicateDataException dup:
                    statusCode = (int)HttpStatusCode.Conflict;
                    code = "006";
                    message = $"Ya existe {dup.Message}";
                    break;

                case KeyNotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    code = "404";
                    message = ex.Message;
                    break;
            }

            context.Response.StatusCode = statusCode;

            var response = new
            {
                success = false,
                code,
                message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
