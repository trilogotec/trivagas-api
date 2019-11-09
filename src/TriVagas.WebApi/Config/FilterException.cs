using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace TriVagas.WebApi.Config
{
    public class FilterException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new {
                success = false,
                message = context.Exception.Message
            }) { StatusCode = 500 };
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
