using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TriVagas.Services.Notify;

namespace TriVagas.WebApi.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly INotify _notify;
        public ApiController(INotify notify)
        {
            _notify = notify;
        }

        protected new IActionResult Response(object obj = null,int code = 200) 
        {
            if (_notify.Any()) 
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notify.GetAll().Select(n => n.Message)
                });
            }

            return new ObjectResult(new
            {
                success = true,
                data = obj
            }) 
            { StatusCode = code };
        }
    }
}