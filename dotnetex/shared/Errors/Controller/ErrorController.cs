using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace dotnetex.shared.Errors.Controller
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            HttpException error = (HttpException)exception.Error;
            var statusCode = (int)error.Status;
            // var statusCode = exception.Error.GetType().Name switch
            // {
            //     "HttpException" => HttpStatusCode.BadRequest,
            //     _ => HttpStatusCode.InternalServerError,
            // };
            return Problem(detail: error.Message, statusCode: statusCode);
        }
    }
}