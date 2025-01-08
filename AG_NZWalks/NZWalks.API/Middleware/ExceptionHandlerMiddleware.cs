using Microsoft.AspNetCore.Http;
using System.Net;

namespace NZWalks.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _requestDelegate;  
        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger ,RequestDelegate requestDelegate)
        {
            _logger = logger;
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception e)
            {
                var errorID = Guid.NewGuid();
                _logger.LogError(e, $"{errorID} : {e.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    ID = errorID,
                    ErrorMessage = "Something went wrong !  We are working on it"
                };

                await httpContext.Response.WriteAsJsonAsync(error);

            }
        }
    }
}
