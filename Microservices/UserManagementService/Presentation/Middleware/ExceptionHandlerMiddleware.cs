using UserManagementService.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace UserManagementService.Presentation.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;  // Default code (500).
            var response = string.Empty;

            switch (ex)
            {
                case FluentValidation.ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    response = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case EntityNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
            }

            if (response == string.Empty)
                response = JsonSerializer.Serialize(new { Error = ex.Message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(response);
        }
    }
}
