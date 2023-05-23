using System.Net;
using System.Text.Json;

namespace DocVision.WebApi.ExeptionHandlers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    //case EntityNotFoundException e:
                    //    _logger.LogError(error, "Custom handled {1} has occurred.", 
                    //        typeof(EntityNotFoundException));
                    //    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //    break;
                    //case AppException e:
                    //    _logger.LogError(error, "Custom handled AppException has occurred");
                    //    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    //    break;
                    default:
                        _logger.LogError(error, "Unhandled exception has occurred");
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}