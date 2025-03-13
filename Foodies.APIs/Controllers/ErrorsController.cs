using Foodies.APIs.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodies.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        private readonly ILogger logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            this.logger = logger;
        }
        public ActionResult Error(int code)
        {
            string message = string.Empty;
            switch (code)
            {
                case 404:
                    message = "API Endpoint doesn't exist ;( ";
                    break;
                case 405:
                    message = "Oops!! Wrong Method -_- ";
                    break;
                default:
                    break;
            }
            logger.Log(LogLevel.Warning, $"{code}: {message}");
            var response = new JsonResult(new BaseErrorApiResponse(code, message));
            response.StatusCode = code;
            return response;
        }
    }
}
