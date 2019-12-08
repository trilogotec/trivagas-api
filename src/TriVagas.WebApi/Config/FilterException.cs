using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using TriVagas.Services.Exceptions;

namespace TriVagas.WebApi.Config
{
    public class FilterException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            int status = 500;

            if (exception.GetType() == typeof(AuthenticationException))
            {
                status = 400; 
            }

            context.Result = new ObjectResult(new {
                success = false,
                message = context.Exception.Message
            }) { StatusCode = status };
        }
    }

    public class FilterExceptionModelStates : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            var validationErrors = context.ModelState
                .Keys
                .SelectMany(k => context.ModelState[k].Errors)
                .Select(e => e.ErrorMessage)
                .ToArray();

            context.Result = new ObjectResult(new {
                success = false,
                message = validationErrors
            }) { StatusCode = 400 };
        }
    }
}
