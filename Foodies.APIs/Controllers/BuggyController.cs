using Foodies.APIs.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodies.APIs.Controllers
{
    [Route("errors")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class BuggyController : ControllerBase
    {
        [HttpGet("ResourceNotFound")]  // Get: errors/notfound
        public ActionResult GetResourceNotFound()
        {
            return NotFound(new BaseErrorApiResponse(404));
        }

        [HttpGet("badrequest")]  // Get: errors/badrequest
        public ActionResult GetBadRequest()
        {
            return BadRequest(new BaseErrorApiResponse(400));
        }

        [HttpGet("unauthorized")]  // Get: errors/unauthorized
        public ActionResult GetUnAuthorized()
        {
            return Unauthorized(new BaseErrorApiResponse(401));
        }

        [HttpGet("validation/{id}")]  // Get: errors/validation/one
        public ActionResult GetValidationBadRequest(int id, string address)
        {
            return Ok();
        }

        [HttpGet("servererror")]  // Get: errors/servererror
        public ActionResult GetServerError()
        {
            List<string> foods = new List<string> { "food1", "food2" };
            return Ok(foods[3]);
        }

        // endpoint not found error
    }
}
