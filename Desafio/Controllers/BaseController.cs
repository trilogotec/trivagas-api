using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected int UserId { get; private set; }
        private readonly HttpContextAccessor _accessor;
        protected BaseController(HttpContextAccessor accessor)
        {
            _accessor = accessor;
            if (_accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                UserId = GetUserId();
            }
        }

        private int GetUserId()
        {
            var identity = _accessor.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return int.Parse(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            }
            return 0;
        }
    }
}