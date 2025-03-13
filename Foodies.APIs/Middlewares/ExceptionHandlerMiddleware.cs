

using Foodies.APIs.Errors;
using System.Net;
using System.Text.Json;

namespace Foodies.APIs.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, IHostEnvironment env)
        {
            this.logger = logger;
            this.env = env;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = env.IsDevelopment() ? new ServerErrorApiResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                    : new ServerErrorApiResponse((int)HttpStatusCode.InternalServerError);

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
