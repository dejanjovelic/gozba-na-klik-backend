using gozba_na_klik_backend.Exceptions;
using System.Text.Json;

namespace gozba_na_klik_backend.Settings
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public ExceptionHandlingMiddleware() { }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next) 
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {

                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext,  Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ForbiddenException=>StatusCodes.Status403Forbidden,
                ConflictException=>StatusCodes.Status409Conflict,
                NotAuthorizedAccessException=>StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };
            var response = new { error = exception.Message };
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
